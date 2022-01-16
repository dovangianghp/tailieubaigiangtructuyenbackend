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
    public partial class QuanlyDSlop : System.Web.UI.Page
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
            if ((string)Session["Doituong"] != "admin" || (bool)Session["login"] == false)
            {
                Response.Redirect("trangchu.aspx");
            }
            string path1 = "listLop.xml";

            List<LOP> listlop = (List<LOP>)Application["dslop"];

            Table_Load1();
            if (Request.Form["btnRegistb"] == "true")
            {
                LOP lp = new LOP();
                lp.IDL = listlop.Count;
                lp.TenGV = Request.Form["txtTen"];
                lp.TenLOP = Request.Form["txtlop"];
                
                //đọc DS giáo viên
                List<Member> listmem = (List<Member>)Application["dsmem"];
                int dem = 0;
                foreach (Member mem in listmem)
                {
                    if (mem.Doituong == "Giáo viên" && mem.Ten == lp.TenGV)
                    {
                        dem++;
                        break;
                    }
                }

                if (dem == 0)
                {
                    string alert1 = "";
                    alert1 += "<script>alert('Tên giáo viên không tồn tại!')</script>";
                        Response.Write(alert1);
                }
                else
                {
                    bool checktrung = false;
                    foreach (LOP lop in listlop)
                    {
                        if (lop.TenGV.Equals(lp.TenGV) && lop.TenLOP.Equals(lp.TenLOP))
                        {
                            checktrung = true;
                            break;
                        }
                    }

                    if (!checktrung)
                    {
                        foreach (LOP lop in listlop)
                        {
                            if (lop.IDL == lp.IDL)
                            {
                                lp.IDL++;
                            }
                        }
                        lp.URL = "lopchitiet.aspx?id="+lp.IDL.ToString();
                        listlop.Add(lp);
                        List<int> SV_lop = (List<int>)Session["IDlop"];
                        SV_lop.Add(lp.IDL);
                        Session["IDlop"] = SV_lop;
                        //Ghi file
                        System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<LOP>
                            ));

                        System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path1));

                        writer.Serialize(_file, listlop);
                        _file.Close();
                        Application["dslop"] = listlop;

                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    else
                    {
                        string alert = "";
                        alert += "<script>alert('Lớp đã tồn tại!');</script> ";
                            Response.Write(alert);
                    }

                }
            }
            foreach (LOP lop in listlop)
            {
                if (Request.Form["btnXoa"] == lop.IDL.ToString())
                {
                    List<int> SV_lop = (List<int>)Session["IDlop"];
                    foreach (int lpsv in SV_lop)
                    {
                        if (lpsv == lop.IDL)
                        {
                            SV_lop.Remove(lpsv);
                        }
                    }
                    Session["IDlop"] = SV_lop;
                    listlop.Remove(lop);
                    //Ghi file
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<LOP>
                        ));

                    System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path1));

                    writer.Serialize(_file, listlop);
                    _file.Close();
                    Application["dslop"] = listlop;
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    break;
                }
            }


        }
        protected void Table_Load1()
        {
            List<LOP> listlop = (List<LOP>)Application["dslop"];

            for (int j = 0; j < listlop.Count; j++)
            {
                HtmlTableRow r = new HtmlTableRow();
                HtmlTableCell c1 = new HtmlTableCell();
                c1.Controls.Add(new LiteralControl(listlop[j].IDL.ToString()));
                r.Cells.Add(c1);
                HtmlTableCell c2 = new HtmlTableCell();
                c2.Controls.Add(new LiteralControl(listlop[j].TenLOP.ToString()));
                r.Cells.Add(c2);
                HtmlTableCell c3 = new HtmlTableCell();
                c3.Controls.Add(new LiteralControl(listlop[j].TenGV.ToString()));
                r.Cells.Add(c3);
                HtmlTableCell c5 = new HtmlTableCell();
                c5.Controls.Add(new LiteralControl(listlop[j].URL.ToString()));
                r.Cells.Add(c5);
                HtmlTableCell c6 = new HtmlTableCell();
                string txtbutton = "<form runat='server' method='post'><button type='submit' value='" + listlop[j].IDL.ToString() + "' class='btn' name='btnXoa' runat='server'>Xóa</button></form>";
                c6.Controls.Add(new LiteralControl(txtbutton));
                r.Cells.Add(c6);
                table2.Rows.Add(r); table2.Visible = true;
            }
        }
    }
}
