using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearch.Models;

namespace JobSearch.Controllers
{
    public class AddJobController : Controller
    {
        dbJobSearchEntities dbobj = new dbJobSearchEntities();
        // GET: AddJob
        public ActionResult Addjob_Load()
        {
            return View();
        }
        public ActionResult addjob_Click(AddJob clsobj)
        {
            if (ModelState.IsValid)
            {
               
                int cid = Convert.ToInt32(Session["uid"]);

                dbobj.sp_AddJob(cid, clsobj.JobName, clsobj.Vacancy, clsobj.RequiredSkill, clsobj.Experience, clsobj.Qualification, clsobj.Salary, clsobj.Location, clsobj.StartDate, clsobj.EndDate, "Available");
                clsobj.Msg = "Job Posted";
                return View("Addjob_Load", clsobj);               
            }
            return View("Addjob_Load", clsobj);       
        }
    }
}