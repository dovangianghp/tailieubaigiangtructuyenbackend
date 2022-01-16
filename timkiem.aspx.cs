using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_nhom10
{
    public partial class timkiem : System.Web.UI.Page
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
            TK();
        }
        protected void TK()
        {       
            List<LOP> listlop = (List<LOP>)Application["dslop"];
            List<SV_LOP> listSVlop = (List<SV_LOP>)Application["dsSVlop"];
            List<int> listdone = (List<int>)Session["IDlop"];

            if ((string)Request.Form["btntk"] == "true")
            {
                sectiontk.InnerHtml = "";
                string content = (string)Request.Form["tk1"];
                int dem = 0;
                
                foreach (LOP lp in listlop)
                {
                    bool kt1 = (bool)(lp.TenLOP.ToLower().Contains((string)content.ToLower()));
                    bool kt2 = (bool)(lp.TenGV.ToLower().Contains((string)content.ToLower()));
                    bool kt3 = (bool)(lp.IDL.ToString().Contains((string)content));
                    if (kt1==true||kt2==true||kt3==true)
                    {
                        dem++;
                        string html = "";
                        html += "<div class='lop_detail'>";
                        html += "<img class='imgVocado' src='./anh/pngegg.png'/>";
                        bool check = false;
                        foreach (int a in listdone)
                        {
                            if (lp.IDL == a)
                            {
                                check = true;
                                break;
                            }
                        }
                        if (check == true)
                        {
                            html += "<p><b><a href='" + lp.URL + "'>" + lp.TenLOP + "</a></b></p>";
                        }
                        else
                        {
                            html += "<p><b>" + lp.TenLOP + "</b></p>";
                        }
                        html += "<p><i class='ix'>" + lp.IDL.ToString() + "</i></p>";
                        html += "<p class='tenGV'>" + lp.TenGV + "</p>";
                        if ((string)Session["Doituong"] == "Sinh viên" && check == false)
                        {
                            html += "<form class='btna' method='post'><button type='submit' id='btnd' class='btndkx' name='btndk' value='true" + lp.IDL.ToString() + "' runat='server'><i class='iconF fas fa-sign-in-alt'></i><span>ĐĂNG KÍ</span></button></form>";
                        }
                        else if ((string)Session["Doituong"] == "Sinh viên")
                        {
                            html += "<div class='boxkt'>";
                            html += "<div class='btnb1'><i class='iconF green fas fa-check-circle'></i><i>Đã đăng kí</i></div>";
                            string x = "";
                            x += ((int)Session["id"]).ToString() + "," + lp.IDL.ToString();
                            html += "<div><form method='post' class='btnb2'><button type='submit' id='btnhuy' class='btnh' name='btnhuy' value='true," + x + "' runat='server'><i class='iconF red far fa-trash-alt'></i><span>Hủy</span></button></form></div>";
                            html += "</div>";
                        }
                        html += "</div>";
                        sectiontk.InnerHtml += html;
                    }
                }
                if (dem == 0)
                {
                    sectiontk.InnerHtml += "<h2>Không có kết quả nào trùng khớp!</h2>";
                }
            }

            string bt = (string)Request.Form["btndk"];
            if (bt != null)
            {
                bool kt = (bool)bt.Contains("true");
                if (kt == true)
                {
                    SV_LOP svl = new SV_LOP();
                    svl.IDSV = (int)Session["id"];
                    svl.IDLOP = int.Parse((Request.Form["btndk"]).Remove(0, 4));
                    listdone.Add(svl.IDLOP);
                    listSVlop.Add(svl);
                    //Ghi file
                    string path = "listregist.xml";
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<SV_LOP>));

                    System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                    writer.Serialize(_file, listSVlop);
                    _file.Close();
                    Application["dsSVlop"] = listSVlop;
                    Session["IDlop"] = listdone;
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
            string at = (string)Request.Form["btnhuy"];
            if (at != null)
            {
                bool kta = (bool)at.Contains("true");
                if (kta == true)
                {
                    string[] a = at.Split(',');
                    foreach (SV_LOP svlp in listSVlop)
                    {
                        if (svlp.IDSV == (int)Session["id"] && svlp.IDLOP == int.Parse(a[2]))
                        {
                            listdone.Remove(svlp.IDLOP);
                            listSVlop.Remove(svlp);
                            //Ghi file
                            string path1 = "listregist.xml";
                            System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(typeof(List<SV_LOP>));

                            System.IO.FileStream _file1 = System.IO.File.Create(Server.MapPath(path1));

                            writer1.Serialize(_file1, listSVlop);
                            _file1.Close();
                            Application["dsSVlop"] = listSVlop;
                            Page.Response.Redirect(Page.Request.Url.ToString(), true);
                            Session["IDlop"] = listdone;
                            break;
                        }
                    }
                }
            }

        }
    }
}