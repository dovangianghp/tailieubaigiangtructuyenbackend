using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_nhom10
{
    public partial class lopchitiet : System.Web.UI.Page
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
            //lấy mã lớp
            int idlop = int.Parse((string)Request.QueryString["id"]);
            //
            diendan.InnerHtml="<a href=diendan.aspx?idl="+idlop+"><span><img src='anh/local.png' class='logodiendan'/></span>Diễn đàn trao đổi</a>";
            List<LOP> listlop = (List<LOP>)Application["dslop"];
            //lấy tên lớp
            string tenlp = "";
            foreach (LOP lp in listlop)
            {
                if (lp.IDL == idlop)
                {
                    tenlp = lp.TenLOP;
                }
            }
            //
            string hl = "Chào mừng " + (string)Session["Name"] + " tới lớp " + tenlp + "!";
            hello.InnerText += hl;
            //danh sách lịch lớp
            List<Lop_lich> listlich = (List<Lop_lich>)Application["dsdate"];
            int demstart = 0;
            int demend=0;
            int demlich = 0;
            DateTime tgx=new DateTime(1,1,1);
            DateTime thistime = DateTime.Now;
            foreach (Lop_lich lpl in listlich)
            {
                if (lpl.IDL == idlop)
                {
                    if (lpl.Lich <= thistime)
                    {
                        DateTime tg = lpl.Lich;
                        string sd = "";
                        if ((bool)tg.Equals(tgx) == true)
                        {
                            demstart++;
                            demend = 0;
                        }
                        else
                        {
                            demstart = 0;
                            demend++;
                        }
                        if (demend != 0)
                        {
                            sd += "</section>";
                        }
                        if (demstart == 0)
                        {
                            sd += "<section class='sx'>";
                            sd += "<div class='thoigian'>" + lpl.Lich.ToShortDateString() + "</div>";
                            sd += "<div class='filehien'><a href='" + lpl.URL + "' target='_blank' class='urllop'>" + lpl.Titile + "</a></div>";
                            sd += "<div class='thongtin'>" + lpl.Infor + "</div>";
                        }

                        else
                        {
                            sd += "<div class='filehien'><a href='" + lpl.URL + "' target='_blank' class='urllop'>" + lpl.Titile + "</a></div>";
                            sd += "<div class='thongtin'><i>" + lpl.Infor + "</i></div>";
                        }
                        tgx = tg;
                        ND.InnerHtml += sd;
                        demlich++;
                    }
                }
            }
            if (demlich == 0)
            {
                ND.InnerHtml += "<center style='color:red'>Lớp chưa có bài nào!</center>";
            }
        }
    }
}