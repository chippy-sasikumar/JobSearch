using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSearch.Models
{
    public class AddJob
    {
        public int CId { get; set; }
        [Required(ErrorMessage ="Enter Job Name")]
        public string JobName { get; set; }
        [Required(ErrorMessage = "Enter Number of Vaccancy")]
        public int Vacancy { get; set; }
        [Required(ErrorMessage = "Enter Skills Required")]
        public string RequiredSkill { get; set; }
        [Required(ErrorMessage = "Enter Required Experience")]
        public string Experience { get; set; }
        [Required(ErrorMessage = "Enter Required Qualification")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Enter Salary")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Enter Location")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Enter Start Date")]
        public System.DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Enter End Date")]
        public System.DateTime EndDate { get; set; }
        public string Msg { set; get; }
    }
}