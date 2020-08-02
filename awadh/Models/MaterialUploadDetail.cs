using System.Web;

namespace Awadh.Models
{
    public class MaterialUploadDetail
    {
        public int ID { get; set; }
        public string Class { get; set; }
        public string Title{ get; set; }
        public string URL{ get; set; }
        public int SubjectID{ get; set; }
        public string Subject{ get; set; }
        public string Description{ get; set; }
        public string EntryDate{ get; set; }
        public HttpPostedFileBase Files{ get; set; }
        public bool IsLink{ get; set; }
    }
}