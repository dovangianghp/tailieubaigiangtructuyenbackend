using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_nhom10
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["login"] == true)
            {
                Response.Redirect("trangchu.aspx");
            }
            //string path = "listMember.xml";
           
            if (Request.Form["btnLogin"] == "true")
            {
                List<Member> list = (List<Member>)Application["dsmem"];
                Member mb = new Member();
                mb.ID = list.Count;
                mb.Email = Request.Form["txtName_log"];
                mb.Pass1 = Request.Form["txtPass_log"];

                bool checktrung = false;
                foreach (Member mem in list)
                {
                    if (mem.Email.Equals(mb.Email) && mem.Pass1.Equals(mb.Pass1))
                    {
                        checktrung = true;
                        mb.ID = mem.ID;
                        mb.Ten = mem.Ten;
                        mb.Doituong = mem.Doituong;
                        
                        break;
                    }
                }
                Application["dsmem"] = list;
                if (checktrung == false)
                {
                    string alert = "";
                    alert += "<script>alert('Tài khoản hoặc mật khẩu không đúng!');</script>";
                    Response.Write(alert);
                }
                else
                {
                    DateTime nowx = DateTime.Now;
                    // Tạo session
                    Session["timehienhanh"] = nowx;
                    Session["login"] = true;
                    Session["id"] = mb.ID;
                    Session["email"] = mb.Email;
                    Session["Name"] = mb.Ten;
                    Session["Pass"] = mb.Pass1;
                    Session["Doituong"] = mb.Doituong;
                    List<LOP> listlop = (List<LOP>)Application["dslop"];
                    List<SV_LOP> listSVlop = (List<SV_LOP>)Application["dsSVlop"];
                    List<int> IDlop = new List<int>();
                    
                    if ((String)Session["Doituong"]=="Giáo viên")
                    {
                        foreach (LOP lp in listlop)
                        {
                            if (lp.TenGV == (string)Session["Name"])
                            {
                                IDlop.Add(lp.IDL);
                            }
                        }
                    }
                    if ((String)Session["Doituong"] == "Sinh viên")
                    {
                        foreach (SV_LOP svlp in listSVlop)
                        {
                            if (svlp.IDSV == (int)Session["id"])
                            {
                                IDlop.Add(svlp.IDLOP);
                            }
                        }
                    }
                    Session["IDlop"] = IDlop;
                    Response.Redirect("trangchu.aspx");
                }
            }
        }
    }
}