
namespace Awadh.Models
{
    public class LoginData : Response
    {
        public int LoginID { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
        public string Class { get; set; }
    }
}