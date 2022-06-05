using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public delegate void CursorHandler(string type);
    public partial class MainWindow : Window
    {
        bool IsWork = false;
        int xStart;
        int yStart;
        event CursorHandler CursorHandler = null;
        public int _userId;
        public MainWindow()
        {
            InitializeComponent();
            EventCB.Items.Add("Все");
            EventCB.Items.Add("сдвиг");
            EventCB.Items.Add("Left");
            EventCB.Items.Add("Right");
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            IsWork = !IsWork;
            xStart = (int)Mouse.GetPosition(null).X;
            yStart = (int)Mouse.GetPosition(null).Y;
            if (IsWork)
            {
                CursorHandler += new CursorHandler(MoveEvent);
                (sender as Button).Content = "Стоп";
                DbConnect.client.SendMessage("Начало записи");
            }
            else
            {
                CursorHandler -= new CursorHandler(MoveEvent);
                (sender as Button).Content = "Старт";
                DbConnect.client.SendMessage("Остановка записи");
            }

        }

        private void Window_QueryCursor(object sender, QueryCursorEventArgs e)
        {

            if (IsWork)
            {
                int xNow = (int)Mouse.GetPosition(null).X;
                int yNow = (int)Mouse.GetPosition(null).Y;
                if (Math.Abs(xStart - xNow) >= 10 || Math.Abs(yStart - yNow) >= 10)
                {
                    xStart = xNow;
                    yStart = yNow;
                    CursorHandler.Invoke("сдвиг");
                }
            }
        }
        public void MoveEvent(string type)
        {
                ServiceReference.CursorPos cursorPos = new ServiceReference.CursorPos()
                {
                    XPos = xStart,
                    YPos = yStart,
                    DateTime = DateTime.Now,
                    TypeEvent = type,
                    UserId = _userId
                };
            GridList.Items.Add(cursorPos);
            SendCursor(cursorPos);
            
        }
        void SendCursor(ServiceReference.CursorPos cursorPos)
        {
            DbConnect.client.SaveData(cursorPos);
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsWork)
            {
                int xNow = (int)Mouse.GetPosition(this).X;
                int yNow = (int)Mouse.GetPosition(this).Y;
                string type = e.ChangedButton.ToString();
                CursorHandler.Invoke(type);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var cursor in DbConnect.client.LoadData(_userId))
            {
                GridList.Items.Add(cursor);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridList.Items.Clear();
            foreach (var cursor in DbConnect.client.LoadData(_userId))
            {
                GridList.Items.Add(cursor);
            }
        }

        private void EventCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridList.Items.Clear();
            if (EventCB.SelectedValue.ToString() == "Все")
            {
                foreach (var cursor in DbConnect.client.LoadData(_userId))
                {
                    GridList.Items.Add(cursor);
                }
            }
            else
            {
                foreach (var cursor in DbConnect.client.SortDataByType(_userId, EventCB.SelectedValue.ToString()))
                {
                    GridList.Items.Add(cursor);
                }
            }
        }
    }
}
