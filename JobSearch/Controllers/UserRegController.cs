using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearch.Models;

namespace JobSearch.Controllers
{
    public class UserRegController : Controller
    {
        dbJobSearchEntities dbobj = new dbJobSearchEntities();
        // GET: UserReg
        public ActionResult User_Load()
        {

            //dropdown
            List<stclass> stList = new List<stclass>//object
            {
                new stclass{sId=1,sName="Kerala"},
                new stclass {sId=2,sName="Tamilnadu"},
                new stclass {sId=3,sName="Karnataka"}
            };
            ViewBag.Selstates = new SelectList(stList, "sId", "sName");//viewbag to pass value from controller to view

            //checkbox list
            UserRegistration user = new UserRegistration();//object of main class UserInsert
            user.MyFavoriteQual = getQualificationData();
            return View(user);
        }

        //checkbox list
        public List<CheckBoxListHelper> getQualificationData()
        {
            List<CheckBoxListHelper> sts = new List<CheckBoxListHelper>()
            {
                new CheckBoxListHelper{Value="SSLC",Text="SSLC",IsChecked=true},
                new CheckBoxListHelper{Value="PLUS TWO",Text="PLUS TWO",IsChecked=false},
                new CheckBoxListHelper{Value="BCA",Text="BCA",IsChecked=false},
                new CheckBoxListHelper{Value="MCA",Text="MCA",IsChecked=false},
                new CheckBoxListHelper{Value="BTech",Text="BTech",IsChecked=false},

            };
            return sts;
        }
        public ActionResult User_Click(UserRegistration clsobj,FormCollection form)
        {
            if (ModelState.IsValid)
            {

                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }

                //dropdown
                List<stclass> stList = new List<stclass>//object
            {
                new stclass{sId=1,sName="Kerala"},
                new stclass {sId=2,sName="Tamilnadu"},
                new stclass {sId=3,sName="Karnataka"}
            };
                int selectedId = Convert.ToInt32(form["Selstates"]);
                stclass selectedItem = stList.FirstOrDefault(c => c.sId == selectedId);
                clsobj.sId = selectedItem.sId;//set
                clsobj.sName = selectedItem.sName;//set

                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                //checkbox
                var quid = string.Join(",", clsobj.selectedQual);//join selected items with comma and saved in quid
                clsobj.Qualification = quid;//set
                clsobj.MyFavoriteQual = getQualificationData();//get


               
                dbobj.sp_UserReg(regid, clsobj.Name, clsobj.Address, clsobj.Age, clsobj.Gender, clsobj.Phone, clsobj.Email, clsobj.sName, clsobj.District, clsobj.Pincode, clsobj.Qualification, clsobj.CGPA, clsobj.Skills, "Available");
                dbobj.sp_Login(regid, clsobj.Username, clsobj.Password, "User");
                clsobj.Msg = "Registered Successfully";
                return View("User_Load", clsobj);
            }
            else
            {
                List<stclass> stList = new List<stclass>//object
            {
                new stclass{sId=1,sName="Kerala"},
                new stclass {sId=2,sName="Tamilnadu"},
                new stclass {sId=3,sName="Karnataka"}
            };
                ViewBag.Selstates = new SelectList(stList, "sId", "sName");//viewbag to pass value from controller to view

                //checkbox list
                var quid = string.Join(",", clsobj.selectedQual);//join selected items with comma and saved in quid
                clsobj.Qualification = quid;//set
                clsobj.MyFavoriteQual = getQualificationData();//get


                return View("User_Load", clsobj);
            }
            return View("User_Load", clsobj);
        }
    }
}