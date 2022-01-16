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
    public partial class WebForm3 : System.Web.UI.Page
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
            if ((string)Session["Doituong"]!="Giáo viên" || (bool)Session["login"] == false)
            {
                Response.Redirect("trangchu.aspx");
            }
            string path5 = "listdate.xml";
           
            List<int> lopGV = (List<int>)Session["IDlop"];
            List<Lop_lich> loplich = (List<Lop_lich>)Application["dsdate"];
            Table_Loplich();
            if (lopGV != null)
            {
                foreach(int lpGV in lopGV)
                {
                    DropDownList1.Items.Add(lpGV.ToString());
                }
            }
            if (Request.Form["btnRegistlop"]=="true")
            {
                Lop_lich lpl = new Lop_lich();
                lpl.STT = loplich.Count+1;
                lpl.IDL = int.Parse(DropDownList1.SelectedValue);
                lpl.Lich = DateTime.Parse(Request.Form["txtdate"]);
                lpl.Titile = Request.Form["txttitile"];
                lpl.Infor = Request.Form["txtinfor"];
                if (FileUpload1.HasFile)
                {
                    if (CheckFileType(FileUpload1.FileName))
                    {
                        string fileName = "data/" + FileUpload1.FileName;
                        string filePath = MapPath(fileName);
                        FileUpload1.SaveAs(filePath);
                        lpl.URL = fileName;
                        loplich.Add(lpl);
                        loplich.Sort();
                        Application["dsdate"] = loplich;
                        //Ghi file
                        System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Lop_lich>));

                        System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path5));

                        writer.Serialize(_file, loplich);
                        _file.Close();

                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    else
                    {
                        string alert = "";
                        alert += "<script>alert('Chỉ nhận file pdf,powerpoint!!!');</script>";
                        Response.Write(alert);
                    }
                }
            }
            foreach (Lop_lich lpl in loplich)
            {
                string k = (string)Request.Form["btnXoax"];
                if ( k!=null)
                {
                    if (int.Parse(k) == lpl.STT)
                    {
                        loplich.Remove(lpl);
                        Application["dsdate"] = loplich;
                        //Ghi file
                        System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Lop_lich>));

                        System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path5));

                        writer.Serialize(_file, loplich);
                        _file.Close();

                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                        break;
                    }
                }
            }
        }
        bool CheckFileType(string filename)
        {
            string ext = Path.GetExtension(filename);
            switch (ext.ToLower())
            {
                case ".pptx":
                    return true;
                case ".pdf":
                    return true;
                case ".pps":
                    return true;
                case ".ppt":
                    return true;
                default:
                    return false;
            }
        }
        protected void Table_Loplich()
        {
            
                List<Lop_lich> loplich = (List<Lop_lich>)Application["dsdate"];

                for (int j = 0; j < loplich.Count; j++)
                {
                    HtmlTableRow r = new HtmlTableRow();
                    HtmlTableCell c0 = new HtmlTableCell();
                    c0.Controls.Add(new LiteralControl(loplich[j].STT.ToString()));
                    r.Cells.Add(c0);
                    HtmlTableCell c1 = new HtmlTableCell();
                    c1.Controls.Add(new LiteralControl(loplich[j].IDL.ToString()));
                    r.Cells.Add(c1);
                    HtmlTableCell c2 = new HtmlTableCell();
                    c2.Controls.Add(new LiteralControl(loplich[j].Lich.ToShortDateString()));
                    r.Cells.Add(c2);
                    HtmlTableCell c3 = new HtmlTableCell();
                    c3.Controls.Add(new LiteralControl(loplich[j].URL.ToString()));
                    r.Cells.Add(c3);
                    HtmlTableCell c6 = new HtmlTableCell();
                    string txtbutton = "<form runat='server' method='post'><button type='submit' value='" + loplich[j].STT.ToString() + "' class='btn' name='btnXoax' runat='server'>Xóa</button></form>";
                    c6.Controls.Add(new LiteralControl(txtbutton));
                    r.Cells.Add(c6);
                    table4.Rows.Add(r); table4.Visible = true;
                }
        }
    }
}