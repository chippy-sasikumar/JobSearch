using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearch.Models;

namespace JobSearch.Controllers
{
    public class ApplyJobController : Controller
    {
        dbJobSearchEntities dbobj = new dbJobSearchEntities();
        // GET: ApplyJob
        public ActionResult ApplyJob_Load(int cid, int jid)        
        {
            TempData["cid"] = cid;
            TempData["jid"] = jid;
            return View();
        }

        public ActionResult ApplyJob_Click(ApplyJob clsobj,DisplayAllnSearch obj,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {                
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/FResume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\FResume", fname);
                    clsobj.Resume = fullpath;
                }

                int uid = Convert.ToInt32(Session["uid"]);
                int cid = Convert.ToInt32(TempData["cid"]);
                int jid = Convert.ToInt32(TempData["jid"]);

                dbobj.sp_ApplyJob(jid, cid, uid, clsobj.Date, clsobj.Resume, "Available");
                clsobj.msg = "Applied Successfully";

                return View("ApplyJob_Load", clsobj);
            }
            return View("ApplyJob_Load", clsobj);
        }
    }
}