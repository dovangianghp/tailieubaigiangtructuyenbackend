using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_nhom10
{
    public class chat:IComparable<chat>
    {
        int idchat;
        string name;
        DateTime timechat;
        string noidung;
        
        public int IDchat { get => idchat; set => idchat = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Timechat { get => timechat; set => timechat = value; }
        public string Noidung { get => noidung; set => noidung = value; }

        public int CompareTo(chat other)
        {
            return other.Timechat.CompareTo(this.Timechat);
        }
    }
}