using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BTL_nhom10
{
    public partial class QuanlyMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["Doituong"] != "admin" || (bool)Session["login"] == false)
            {
                Response.Redirect("trangchu.aspx");
            }
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
            string path = "listMember.xml";
            
            List<Member> list = (List<Member>)Application["dsmem"];

            Table_Load();
            
            if (Request.Form["btnRegista"] == "true")
            {
                Member mb = new Member();
                mb.ID = list.Count;
                mb.Email = Request.Form["txtMaila"];
                mb.Ten = Request.Form["txtFullNamea"];
                mb.Pass1 = Request.Form["txtPassa"];
                mb.Doituong = Request.Form["txtDoituong"];
                

                bool checktrung = false;
                foreach (Member mem in list)
                {
                    if (mem.Email.Equals(mb.Email))
                    {
                        checktrung = true;
                        break;
                    }
                }

                if (!checktrung)
                {
                    if (mb.ID == 0)
                    {
                        mb.Doituong = "admin";
                    }
                    foreach (Member mem in list)
                    {
                        if (mem.ID == mb.ID)
                        {
                            mb.ID++;
                        }
                    }
                    list.Add(mb);
                    //Ghi file
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));

                    System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                    writer.Serialize(_file, list);
                    _file.Close();
                    Application["dsmem"] = list;
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    string alert = "";
                    alert += "<script>alert('Tài khoản đã tồn tại!');</script>";
                    Response.Write(alert);
                }
                
            }
            
            foreach (Member mb in list)
            {
                if (Request.Form["btnXoaa"] == mb.ID.ToString())
                {
                    list.Remove(mb);
                    //Ghi file
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));

                    System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                    writer.Serialize(_file, list);
                    _file.Close();
                    Application["dsmem"] = list;
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    break;
                }
            }

        }
        private void Table_Load()
        {
            List<Member> list = (List<Member>)Application["dsmem"];
            for (int j = 0; j < list.Count; j++)
            {
                HtmlTableRow r = new HtmlTableRow();
                HtmlTableCell c1 = new HtmlTableCell();
                c1.Controls.Add(new LiteralControl(list[j].ID.ToString()));
                r.Cells.Add(c1);
                HtmlTableCell c2 = new HtmlTableCell();
                c2.Controls.Add(new LiteralControl(list[j].Email.ToString()));
                r.Cells.Add(c2);
                HtmlTableCell c3 = new HtmlTableCell();
                c3.Controls.Add(new LiteralControl(list[j].Pass1.ToString()));
                r.Cells.Add(c3);
                HtmlTableCell c5 = new HtmlTableCell();
                c5.Controls.Add(new LiteralControl(list[j].Ten.ToString()));
                r.Cells.Add(c5);
                HtmlTableCell c4 = new HtmlTableCell();
                c4.Controls.Add(new LiteralControl(list[j].Doituong.ToString()));
                r.Cells.Add(c4);
                HtmlTableCell c6 = new HtmlTableCell();
                string txtbutton = "<form runat='server' method='post'><button type='submit' value='" + list[j].ID.ToString() + "' class='btn' name='btnXoaa' runat='server'>Xóa</button></form>";
                c6.Controls.Add(new LiteralControl(txtbutton));
                r.Cells.Add(c6);
                table1.Rows.Add(r); table1.Visible = true;
            }
        }
    }
}