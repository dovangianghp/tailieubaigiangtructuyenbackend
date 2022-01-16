using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_nhom10
{
    public class Member
    {
        int id;
        string email;
        string ten;
        string pass;
        string doituong;
        
        /*List<int> lop;
        public Member(int id, string email,string ten,string pass,string doituong, List<int> lop)
        {
            this.id = id ;
            this.email = email;
            this.ten = ten ;
            this.pass = pass ;
            this.doituong = doituong ;
            this.lop = lop;
        }*/

        public int ID { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Pass1 { get => pass; set => pass = value; }
        public string Doituong { get => doituong; set => doituong = value; }
       
        //public List<int> DSLop{ get => lop; set => lop = value; }

    }
    
}