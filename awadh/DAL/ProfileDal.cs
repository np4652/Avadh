using Awadh.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Awadh.DAL
{
    public class ProfileDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        
        public Response login(string RegId, string PSD)
        {
            var res = new Response
            {
                Status = "Authentication Error"
            };
            try
            {
                List<Registration> List = new List<Registration>();
                string SqlString = "select dbo.Users.Role,dbo.Users.Class from dbo.Users join dbo.UsersLogin on dbo.Users.RegId = dbo.UsersLogin.RegId where dbo.UsersLogin.RegId = '" + RegId + "' and dbo.UsersLogin.Password = '" + PSD + "' and dbo.Users.Status='Active';";
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    res.StatusCode = 1;
                    res.Status = "Authentication Success";
                    var loginData = new LoginData
                    {
                        LoginID = int.Parse(RegId),
                        Role = Convert.ToString(dt.Rows[0]["Role"]),
                        Class = Convert.ToString(dt.Rows[0]["Class"])
                    };
                    HttpContext.Current.Session[SessionKey.Login] = loginData;
                }
            }
            catch (Exception ex)
            {
                res.Catch = ex.Message;
            }
            return res;
        }
    }
}