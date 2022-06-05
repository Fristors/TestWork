using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServer
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceCursor" в коде и файле конфигурации.
    public class ServiceCursor : IServiceCursor
    {
        ApplicationContext db;
        public User Connection(string login, string password)
        {
            Console.WriteLine("Авторизация");
            db = new ApplicationContext();
            User user = db.User.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
            return user == null ? new User() : user;
        }
        public List<CursorPos> LoadData(int id)
        {
            Console.WriteLine("Загрузка данных");
            db = new ApplicationContext();
            var cursors = db.CursorPos.Where(x => x.UserId == id).ToList();
            return cursors;
        }
        public void SaveData(CursorPos cursorPos)
        {
            db.CursorPos.Add(cursorPos);
            db.SaveChanges();
        }
        public void SendMessage(string msg)
        {
            Console.WriteLine(msg);
        }
        public List<CursorPos> SortDataByType(int id, string type)
        {
            Console.WriteLine("Загрузка данных");
            db = new ApplicationContext();
            List<CursorPos> cursors = db.CursorPos.Where(x => x.UserId == id && x.TypeEvent == type).ToList();
            return cursors;
        }
    }
}
