using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awadh.Models
{
    public class AskedQuestion
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public string QuestionDescription { get; set; }
        public int SubjectID { get; set; }
        public string Class { get; set; }
        public string SubjectName { get; set; }
        public string PostedBy { get; set; }
        public string Reply { get; set; }
        public int ReplyID { get; set; }
        public string ReplyBy { get; set; }
        public string PostDate{ get; set; }
        public string ReplyDate { get; set; }
    }
}