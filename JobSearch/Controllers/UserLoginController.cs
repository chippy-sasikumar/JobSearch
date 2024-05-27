using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearch.Models;

namespace JobSearch.Controllers
{
    public class UserLoginController : Controller
    {
        dbJobSearchEntities dbobj = new dbJobSearchEntities();
        // GET: UserLogin
        public ActionResult Login_Pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult CompanyHome()
        {
            return View();
        }
        public ActionResult Login_Click(Login clsobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_LoginCheck(clsobj.Username, clsobj.Password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_LogId(clsobj.Username, clsobj.Password).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = dbobj.sp_LogType(clsobj.Username, clsobj.Password).FirstOrDefault();
                    if (lt == "User")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "Company")
                    {
                        return RedirectToAction("CompanyHome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    clsobj.Msg = "Invalid Login";
                    return View("Login_Pageload", clsobj);
                }
            }
            return View("Login_Pageload", clsobj);
        }
    }
}