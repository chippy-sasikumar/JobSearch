using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.Models
{
    public class DisplayAllnSearch
    {
        public DisplayAllnSearch()
        { 
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }
        public jsearch insertse { set; get; }
        public List<jsearch> selectjob { set; get; }
    }
    public class jsearch
    {
        public int JobId { get; set; }
        public int CId { get; set; }
        public string JobName { get; set; }
        public int Vacancy { get; set; }
        public string RequiredSkill { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
        public int Salary { get; set; }
        public string Location { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string JobStatus { get; set; }
    }
}