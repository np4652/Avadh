using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awadh.Models
{
    public class Registration
    {

        public Int32 RegId { get; set; }
        public string Name { get; set; }

        public string Father_Name { get; set; }
        public string Mother_Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public byte ImagePath { get; set; }
        public string Class { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string LastSchool { get; set; }
        public string Action { get; set; }

        public string Status { get; set; }

        public string loginTime { get; set; }
        public string logoutTime { get; set; }
        public HttpPostedFileBase File { get; set; }
    }

}