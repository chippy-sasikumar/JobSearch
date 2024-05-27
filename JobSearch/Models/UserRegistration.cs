using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSearch.Models
{
    //dropdown
    public class stclass
    {
        public int sId { set; get; }
        public string sName { set; get; }
    }
    //checkbox list
    public class CheckBoxListHelper
    {
        public string Value { set; get; }
        public string Text { set; get; }
        public bool IsChecked { set; get; }
    }
    public class UserRegistration
    {
        //dropdown
        public int sId { set; get; }
        public string sName { set; get; }

        //checkbox
        public List<CheckBoxListHelper> MyFavoriteQual { set; get; }// class type list to get selected qualifications
        public string[] selectedQual { set; get; }//array to store list items


        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Age")]
        public int Age { get; set; }
        
        public string Gender { get; set; }
        
        [Required(ErrorMessage = "Enter Phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid phone number")]
        public long Phone { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Enter valid Email Id")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter District")]
        public string District { get; set; }
        [Required(ErrorMessage = "Enter Pincode")]
        public int Pincode { get; set; }       
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Enter CGPA")]
        public decimal CGPA { get; set; }
        [Required(ErrorMessage = "Enter Skills")]
        public string Skills { get; set; }
        [Required(ErrorMessage = "Enter Username")]
        public string Username { set; get; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { set; get; }
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string CPassword { set; get; }
        public string Msg { set; get; }
    }
}