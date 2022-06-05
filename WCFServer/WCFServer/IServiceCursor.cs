using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServer
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IServiceCursor" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceCursor
    {
        [OperationContract]
        List<CursorPos> LoadData(int id);
        [OperationContract]
        void SaveData(CursorPos cursorPos);
        [OperationContract]
        User Connection(string login, string password);
        [OperationContract]
        void SendMessage(string msg);
        [OperationContract]
        List<CursorPos> SortDataByType(int id, string type);
    }
}
