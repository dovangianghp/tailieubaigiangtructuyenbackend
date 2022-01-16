using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Serialization;

namespace BTL_nhom10
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            string path = "listMember.xml";
            List<Member> list = new List<Member>();
            if (File.Exists(Server.MapPath(path)))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                list = (List<Member>)reader.Deserialize(file);
                list = list.OrderBy(Member => Member.ID).ToList();
                file.Close();
            }
            Application["dsmem"] =list;
        
        
            string path1 = "listLop.xml";
            List<LOP> listlop = new List<LOP>();
            if (File.Exists(Server.MapPath(path1)))
            {
                // Đọc file
                XmlSerializer reader1 = new XmlSerializer(typeof(List<LOP>));
                StreamReader file1 = new StreamReader(Server.MapPath(path1));

                listlop = (List<LOP>)reader1.Deserialize(file1);
                listlop = listlop.OrderBy(LOP => LOP.IDL).ToList();
                file1.Close();
            }

            Application["dslop"] =listlop;

            string path2 = "listregist.xml";
            List<SV_LOP> listSVlop = new List<SV_LOP>();
            if (File.Exists(Server.MapPath(path2)))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader2 = new System.Xml.Serialization.XmlSerializer(typeof(List<SV_LOP>));
                StreamReader file2 = new StreamReader(Server.MapPath(path2));

                listSVlop = (List<SV_LOP>)reader2.Deserialize(file2);
                listSVlop = listSVlop.OrderBy(SV_LOP => SV_LOP.IDSV).ToList();
                file2.Close();
            }

            Application["dsSVlop"] = listSVlop;

            string path3 = "listdate.xml";
            List<Lop_lich> listdate = new List<Lop_lich>();
            if (File.Exists(Server.MapPath(path3)))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader3 = new System.Xml.Serialization.XmlSerializer(typeof(List<Lop_lich>));
                StreamReader file3 = new StreamReader(Server.MapPath(path3));

                listdate = (List<Lop_lich>)reader3.Deserialize(file3);
                listdate = listdate.OrderBy(Lop_lich => Lop_lich.Lich).ToList();
                file3.Close();
            }

            Application["dsdate"] = listdate;

            string path4 = "listchat.xml";
            List<chat> listchat = new List<chat>();
            if (File.Exists(Server.MapPath(path4)))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader4 = new System.Xml.Serialization.XmlSerializer(typeof(List<chat>));
                StreamReader file4 = new StreamReader(Server.MapPath(path4));

                listchat = (List<chat>)reader4.Deserialize(file4);
                listchat = listchat.OrderBy(chat => chat.Timechat).ToList();
                file4.Close();
            }

            Application["dschat"] = listchat;

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["timehienhanh"] = null; 
            Session["login"] = false;
            Session["id"] = "";
            Session["email"] = "";
            Session["Name"] = "";
            Session["Pass"] = "";
            Session["Doituong"] = "";
            Session["IDlop"] = new List<int>();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}