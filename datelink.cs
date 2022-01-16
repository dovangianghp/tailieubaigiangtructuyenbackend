using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_nhom10
{
    public class datelink : IComparable<datelink>
    {
        int idll;
        string tenlop;
        string tenGV;
        DateTime ngay;
        string urll;
       
        public int IDLL { get => idll; set => idll = value; }
        public string TENLOP { get => tenlop; set => tenlop = value; }
        public DateTime NGAY { get => ngay; set => ngay = value; }
        public string TENGV { get => tenGV; set => tenGV = value; }
        public string URLL { get => urll; set => urll = value; }
       

        public int CompareTo(datelink other)
        {
            return this.NGAY.CompareTo(other.NGAY);
        }
    }
}