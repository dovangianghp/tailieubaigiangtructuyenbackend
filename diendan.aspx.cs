using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_nhom10
{
    public partial class diendan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string inners1 = "", inners2 = "";
            if ((bool)Session["login"] == true)
            {
                int idnum = (int)Session["id"];
                ten.InnerText = (string)Session["Name"];
                inners1 += "<li id = 'id'>" + "ID: " + idnum.ToString() + "</li><li id = 'email'>Mail: " + (string)Session["email"] + "</li>";
                if ((string)Session["Doituong"] == "admin")
                {
                    inners2 += "<li class = 'ad1'><a href = 'QuanlyDSlop.aspx'><i class='iconF fas fa-user-cog'></i>Quản lý DS lớp</a></li><li class = 'ad2' runat = 'server'><a href= 'QuanlyMember.aspx'><span><img class='icon' src='anh/icon21.png'/></span>Quản lý DS mem</a></li>";
                }
                else if ((string)Session["Doituong"] == "Giáo viên")
                {
                    inners2 += "<li class ='GV'><a href = 'QuanlyLop.aspx'><i class='iconF fas fa-chalkboard-teacher'></i>Quản lý lớp</a></li>";
                }
                else if ((string)Session["Doituong"] == "Sinh viên")
                {
                    inners2 += "<li class ='GV'><a href = 'Lichhoc.aspx'><i class = 'iconF far fa-calendar-check'></i>Lịch lớp của tôi</a></li>";
                }
                inners1 += "<li class = 'form_exit'><form runat = 'server' method='post'><button type = 'submit' id = 'button_exit' class='button_exit' name='exit' value='true' runat = 'server'><span><i class='fas fa-sign-out-alt'></i></span>Thoát</button ></form ></li >";
            }
            else
            {
                inners1 += "<li><a href = 'login.aspx' class='button' ><span><i class='iconF fas fa-sign-in-alt'></i></span>Đăng nhập</a></li>";
                inners1 += "<li><a href= 'regist.aspx' class='button' ><span><i class='iconF fas fa-user-plus'></i></span>Đăng kí</a></li>";
            }
            account.InnerHtml = inners1;
            if (!IsPostBack)
            {
                nav.InnerHtml += inners2;
            }
            if (Request.Form["exit"] == "true")
            {
                Session.Abandon();
                Response.Redirect("login.aspx");
            }

            string namechat = (string)Session["Name"];
            username.InnerHtml = namechat;
            List<chat> listchat = (List<chat>)Application["dschat"];
            int idlopchat = int.Parse(Request.QueryString["idl"]);
            listchat.Sort();
            foreach (chat x in listchat)
            {
                if (x.IDchat ==idlopchat) {
                    string nhomchat = "<div class='framechat'>";
                    nhomchat += "<div class='userds' id='userds'><div class='logo'><img src='anh/tk.png' class='logoimg'/></div>";
                    nhomchat += "<div class='name_time'><h2>" + x.Name + "</h2><h5>" + x.Timechat + "</h5></div></div>";
                    nhomchat += "<div class='ND'>" + x.Noidung + "</div>";
                    nhomchat += "</div>";

                    content_chat.InnerHtml += nhomchat;
                } 
            }
            string pathx = "listchat.xml";
            if ((string)Request.Form["btndiendan"] == "true")
            {
                chat usernow = new chat();
                DateTime d1 = DateTime.Now;
                string noidung = (string)Request.Form["textdiendan"];
                usernow.IDchat = idlopchat;
                usernow.Name = namechat;
                usernow.Timechat = d1;
                usernow.Noidung = noidung;
                listchat.Add(usernow);
                //ghi file:
                
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<chat>));

                System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(pathx));
                Application["dschat"] = listchat;
                writer.Serialize(_file,listchat);
                _file.Close();

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
    }
}