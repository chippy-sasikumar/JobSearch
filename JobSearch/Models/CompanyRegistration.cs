using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSearch.Models
{
    public class CompanyRegistration
    {
        [Required (ErrorMessage ="Enter Company Name")]        
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Company Address")]
        public string Address { get; set; }
        
        [EmailAddress(ErrorMessage ="Enter valid Email Id")]
        [Required(ErrorMessage = "Enter Email Id")]
        public string Email { get; set; }
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid phone number")]
        [Required(ErrorMessage = "Enter Phone number")]
        public long Phone { get; set; }
        
        [Required(ErrorMessage = "Enter Username")]
        public string Username { set; get; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { set; get; }
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string CPassword { set; get; }
        public string Msg { set; get; }
    }
}