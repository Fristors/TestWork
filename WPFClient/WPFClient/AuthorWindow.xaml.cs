using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace WPFClient
{
    /// <summary>
    /// Логика взаимодействия для AuthorWindow.xaml
    /// </summary>
    public partial class AuthorWindow : Window
    {
        public AuthorWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(Login.Text) && !string.IsNullOrEmpty(Password.Text))
            {
                var user = DbConnect.client.Connection(Login.Text, Password.Text);
                MainWindow mw = new MainWindow();
                if (user != null)
                {
                    mw._userId = user.Id;
                    mw.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DbConnect.client = new ServiceReference.ServiceCursorClient();
        }
    }
}
