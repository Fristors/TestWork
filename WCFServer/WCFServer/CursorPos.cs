using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class CursorPos
    {
        public int Id { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public string TypeEvent { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
    }
}
