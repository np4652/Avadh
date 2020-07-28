using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awadh.Models
{
    public class Response
    {
        public int StatusCode { get; set; } = -1;
        public string Status { get; set; }
        public string Catch { get; set; }
        public int CommonInt { get; set; }
        public string CommonString { get; set; }
    }
}