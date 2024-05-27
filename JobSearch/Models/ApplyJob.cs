using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.Models
{
    public class ApplyJob
    {
        public int JobId { get; set; }
        public int CId { get; set; }
        public int UId { get; set; }
        public System.DateTime Date { get; set; }
        public string Resume { get; set; }
        public string ApplyStatus { get; set; }
        public string msg { set; get; }
    }
}