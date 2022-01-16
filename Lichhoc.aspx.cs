using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BTL_nhom10
{
    public partial class Lichhoc : System.Web.UI.Page
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

            List<int> lopSV = (List<int>)Session["IDlop"];
            List<Lop_lich> loplich = (List<Lop_lich>)Application["dsdate"];
            List<LOP> DSlop = (List<LOP>)Application["dslop"];
            List<datelink> a = new List<datelink>();
            if (lopSV != null)
            {
                foreach (int lpSV in lopSV)
                {
                    foreach (Lop_lich lplich in loplich)
                    {
                        if (lplich.IDL == lpSV)
                        {
                            datelink a1 = new datelink();
                            a1.IDLL = lpSV;
                            a1.NGAY = lplich.Lich;
                            a1.TENGV = "";
                            a1.TENLOP = "";
                            a1.URLL = "";
                            a.Add(a1);
                        }
                    }
                }
                for (int i = 1; i < a.Count; i++)
                {
                    if (a[i - 1].NGAY == a[i].NGAY)
                    {
                        a.RemoveAt(i);
                        i--;
                    }
                }
                foreach (datelink a1 in a)
                {
                    foreach (LOP dsll in DSlop)
                    {
                        if (a1.IDLL == dsll.IDL)
                        {
                            a1.TENGV = dsll.TenGV;
                            a1.TENLOP = dsll.TenLOP;
                            a1.URLL = dsll.URL;
                        }
                    }
                }
                a.Sort();
                if (!IsPostBack)
                {
                    h1.InnerText += (string)Session["Name"];
                }
                if (a.Count == 0)
                {
                    h3.InnerText = "Bạn chưa đăng kí lớp nào!";
                }
                if ((string)Request.Form["choosebtn"] == "true")
                {
                    string kt = (string)Request.Form["choose"];
                    if (kt == "Tất cả")
                    {
                        h3.InnerText = "";
                        for (int j = 0; j < a.Count; j++)
                        {
                            HtmlTableRow r = new HtmlTableRow();
                            HtmlTableCell c1 = new HtmlTableCell();
                            c1.Controls.Add(new LiteralControl(a[j].NGAY.ToString()));
                            r.Cells.Add(c1);
                            HtmlTableCell c2 = new HtmlTableCell();
                            c2.Controls.Add(new LiteralControl(a[j].TENLOP.ToString()));
                            r.Cells.Add(c2);
                            HtmlTableCell c3 = new HtmlTableCell();
                            c3.Controls.Add(new LiteralControl(a[j].TENGV.ToString()));
                            r.Cells.Add(c3);
                            HtmlTableCell c6 = new HtmlTableCell();
                            string txtbutton = "<a href='" + a[j].URLL + "'>Nhấn vào đây để xem lớp</a>";
                            c6.Controls.Add(new LiteralControl(txtbutton));
                            r.Cells.Add(c6);
                            tablelich.Rows.Add(r); tablelich.Visible = true;
                        }
                    }
                    if(kt=="Sắp tới")
                    {
                        h3.InnerText = "";
                        int demst = 0;
                        for (int j = 0; j < a.Count; j++)
                        {
                            if ((int)a[j].NGAY.CompareTo(DateTime.Now) >= 0)
                            {
                                demst++;
                                HtmlTableRow r = new HtmlTableRow();
                                HtmlTableCell c1 = new HtmlTableCell();
                                c1.Controls.Add(new LiteralControl(a[j].NGAY.ToString()));
                                r.Cells.Add(c1);
                                HtmlTableCell c2 = new HtmlTableCell();
                                c2.Controls.Add(new LiteralControl(a[j].TENLOP.ToString()));
                                r.Cells.Add(c2);
                                HtmlTableCell c3 = new HtmlTableCell();
                                c3.Controls.Add(new LiteralControl(a[j].TENGV.ToString()));
                                r.Cells.Add(c3);
                                HtmlTableCell c6 = new HtmlTableCell();
                                string txtbutton = "<a href='" + a[j].URLL + "'>Nhấn vào đây để xem lớp</a>";
                                c6.Controls.Add(new LiteralControl(txtbutton));
                                r.Cells.Add(c6);
                                tablelich.Rows.Add(r); tablelich.Visible = true;
                            }
                        }
                        if (demst == 0)
                        {
                            h3.InnerText = "Hiện tại chưa có lịch mới";
                        }
                    }
                }
            }
        }
    }
}