using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_nhom10
{
    public class LOP
    {
        int idL;
        string GV;
        string tenLOP;
        string url;
        /*List<int> sv;
        public LOP(int idL,string GV,string url,List<int> sv)
        {
            this.idL = idL;
            this.GV = GV;
            this.url = url;
            this.sv = sv;
        }*/
        public string TenGV { get => GV; set => GV = value; }
        public string TenLOP { get => tenLOP; set => tenLOP = value; }
        public int IDL { get => idL; set => idL = value; }
        public string URL { get => url; set => url = value; }
        //public List<int> DSSV { get => sv; set => sv = value; }
        
    }
}