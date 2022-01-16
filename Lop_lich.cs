using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_nhom10
{
    public class Lop_lich : IComparable<Lop_lich>
    {
        int Stt;
        int Idl;
        DateTime lich;
        string url;
        string thongtin;
        string titile;
        
        public int STT
        {
            get => Stt; set => Stt = value;
        }

        public int IDL
        {
            get => Idl;set => Idl = value;
        }
        public DateTime Lich
        {
            get => lich; set => lich = value;
        }
        public string URL
        {
            get => url; set => url = value;
        }
        public string Infor { get => thongtin; set => thongtin = value; }
        public string Titile { get => titile; set => titile = value; }
        public int CompareTo(Lop_lich other)
        {
            return this.Lich.CompareTo(other.Lich);
        }
    }
}