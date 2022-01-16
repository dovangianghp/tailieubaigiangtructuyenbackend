using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_nhom10
{
    public partial class trangchu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string inners1="",inners2="";
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
            List<SV_LOP> listSVlop=(List<SV_LOP>)Application["dsSVlop"];
            List<LOP> DSlop = (List<LOP>)Application["dslop"];
            List<datelink> a = new List<datelink>();

            
            
            foreach (Lop_lich l1p1lich in loplich)
            {   
                datelink a1 = new datelink();
                a1.IDLL = l1p1lich.IDL;
                a1.NGAY = l1p1lich.Lich;
                foreach (LOP l1p1 in DSlop)
                {
                    
                    if (l1p1.IDL == a1.IDLL)
                    {
                        a1.TENGV = l1p1.TenGV;
                        a1.TENLOP = l1p1.TenLOP;
                        a1.URLL = l1p1.URL;
                        break;
                    }
                }
                a.Add(a1);
            }
                
                for (int i = 1; i < a.Count; i++)
                {
                    if (a[i-1].NGAY.CompareTo(a[i].NGAY)==0)
                    {
                        a.RemoveAt(i);
                        i--;
                    }
                }
                a.Sort();
            int dem1 = 0;
            int dem2 = 0;
            string t = "";
            
            DateTime k = DateTime.Now;
            sec1.InnerHtml="";
            sec2.InnerHtml = t;
            int kt1=0;
            int kt2=0;
            //int kt2=0;
            for(int i=0;i<a.Count;i++)
            {
                if ((a[i].NGAY.CompareTo(k)>0)&&(dem1<3))
                {
                    dem1++;
                    kt1=dem1;
                    string html="";
                    html += "<div class='lop_detail'>";
                    html += "<img class='imgVocado' src='./anh/pngegg.png'/>";
                    bool check = false;
                    foreach(int b in lopSV)
                    {
                        if (a[i].IDLL == b)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (((string)Session["Doituong"] == "admin") || check == true)
                    {
                        html += "<p><b><a href='" + a[i].URLL + "'>" + a[i].TENLOP + "</a></b></p>";
                    }
                    else
                    {
                        html += "<p><b>" + a[i].TENLOP+ "</b></p>";
                    }
                    html += "<p><i class='ix'>"+a[i].IDLL.ToString()+"</i></p>";
                    html += "<p class='tenGV'>" + a[i].TENGV+"</p>";
                    html += "<p class='lich'>" + a[i].NGAY.ToShortDateString() +"</p>";
                    if ((string)Session["Doituong"] == "Sinh viên" && check == false)
                    {
                        html += "<form class='btna' method='post'><button type='submit' id='btnd' class='btndkx' name='btndk' value='true"+ a[i].IDLL.ToString()+ "' runat='server'><i class='iconF fas fa-sign-in-alt'></i><span>ĐĂNG KÍ</span></button></form>";
                    }
                    else if((string)Session["Doituong"] == "Sinh viên")
                    {
                        html += "<div class='boxkt'>";
                        html += "<div class='btnb1'><i class='iconF green fas fa-check-circle'></i><i>Đã đăng kí</i></div>";
                        string x = "";
                        x += ((int)Session["id"]).ToString() + "," + a[i].IDLL.ToString();
                        html += "<div><form method='post' class='btnb2'><button type='submit' id='btnhuy' class='btnh' name='btnhuy' value='true," + x + "' runat='server'><i class='iconF red far fa-trash-alt'></i><span>Hủy</span></button></form></div>";
                        html += "</div>";
                    }
                    html += "</div>";
                    sec2.InnerHtml += html;
                    
                }
                kt2=i;
                if(dem1==3){
                    break;
                }
            }
            for(int i=(kt2-kt1);i>=0;i--){
                if ((a[i].NGAY.CompareTo(k)<=0) && dem2<3)
                {
                    dem2++;
                    //kt1=dem2;
                    string html="";
                    html += "<div class='lop_detail'>";
                    html += "<img class='imgVocado' src='./anh/pngegg.png'/>";
                    bool check = false;
                    foreach(int b in lopSV)
                    {
                        if (a[i].IDLL == b)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (((string)Session["Doituong"] == "admin") || check == true)
                    {
                        html += "<p class='className'><b><a href='" + a[i].URLL + "'>" + a[i].TENLOP + "</a></b></p>";
                    }
                    else
                    {
                        html += "<p class='className'><b>" + a[i].TENLOP+ "</b></p>";
                    }
                    html += "<p><i class='ix'>"+a[i].IDLL.ToString()+"</i></p>";
                    html += "<p class='tenGV'>" + a[i].TENGV+"</p>";
                    html += "<div class='lich'><i class='iconF iconclock far fa-clock'></i><div class='time'>" + a[i].NGAY.ToShortDateString() +"</div></div>";
                    if ((string)Session["Doituong"] == "Sinh viên" && check == false)
                    {
                        html += "<form class='btna' method='post'><button type='submit' id='btnd' class='btndkx' name='btndk' value='true"+ a[i].IDLL.ToString()+ "' runat='server'><i class='iconF yellow fas fa-sign-in-alt'></i><span>Đăng kí</span></button></form>";
                    }
                    else if((string)Session["Doituong"] == "Sinh viên")
                    {
                        html += "<div class='boxkt'>";
                        html += "<div class='btnb1'><i class='iconF green fas fa-check-circle'></i><i>Đã đăng kí</i></div>";
                        string x = "";
                        x+= ((int)Session["id"]).ToString()+"," +a[i].IDLL.ToString();
                        html += "<div><form method='post' class='btnb2'><button type='submit' id='btnhuy' class='btnh' name='btnhuy' value='true,"+x+ "' runat='server'><i class='iconF red far fa-trash-alt'></i><span>Hủy</span></button></form></div>";
                        html += "</div>";
                    }
                    html += "</div>";
                    sec1.InnerHtml += html;
                }
                if(dem2==3)break;
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
                        lopSV.Add(svl.IDLOP);
                        listSVlop.Add(svl);
                        //Ghi file
                        string path = "listregist.xml";
                        System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<SV_LOP>));

                        System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                        writer.Serialize(_file, listSVlop);
                        _file.Close();
                        Application["dsSVlop"] = listSVlop;
                        Session["IDlop"] = lopSV;
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }   
                }
                string at = (string)Request.Form["btnhuy"];
                if (at != null)
                {
                     bool kta = (bool)at.Contains("true");
                    if (kta == true)
                    {     
                        string[] c = at.Split(',');
                        foreach (SV_LOP svl1p in listSVlop)
                        {
                            if (svl1p.IDSV == (int)Session["id"] && svl1p.IDLOP == int.Parse(c[2]))
                            {
                                lopSV.Remove(svl1p.IDLOP);
                                listSVlop.Remove(svl1p);
                            //Ghi file
                            string path1 = "listregist.xml";
                            System.Xml.Serialization.XmlSerializer writer1 = new System.Xml.Serialization.XmlSerializer(typeof(List<SV_LOP>));

                            System.IO.FileStream _file1 = System.IO.File.Create(Server.MapPath(path1));

                            writer1.Serialize(_file1, listSVlop);
                            _file1.Close();
                            Application["dsSVlop"] = listSVlop;
                            Page.Response.Redirect(Page.Request.Url.ToString(), true);
                            Session["IDlop"] = lopSV;
                            break;
                            }
                        }
                    }
                }
            
                
        }
    }
}