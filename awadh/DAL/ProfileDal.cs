using Awadh.Models;
using Dapper;
using Mahadev;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Awadh.DAL
{
    public class ProfileDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();


        public string loginsummery(string dts)
        {
            string ss = string.Empty;
            try
            {
                cmd.Connection = con;
                DateTime now = DateTime.Now;
                string asString = now.ToString("dd MMMM yyyy hh:mm:ss tt");

                cmd.CommandText = @"insert into  [SchoolErp].[dbo].[SummeryDetails](
                                                                              [UserId]
                                                                              ,[loginTime]
      
                                                                               )  values('" + dts.ToString() + "','" + asString + "') ";
                con.Open();
                int i = cmd.ExecuteNonQuery();
                ss = i == 1 ? "Successfully done" : "Technical Issue Occurred";
                con.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                ss = ex.Message;
            }
            return ss;
        }



        public List<Registration> GetAllProfileDetails(string RegId)
        {
            string uid = string.Empty;
            string SqlString = string.Empty;
            List<Registration> List = new List<Registration>();
            try
            {
                if (RegId == "undefined" || RegId == null)
                {
                    SqlString = "select * from dbo.Users join dbo.UsersLogin on dbo.Users.RegId= dbo.UsersLogin.RegId  ORDER BY dbo.Users.RegId DESC";
                }
                else
                {
                    SqlString = "select * from dbo.Users join dbo.UsersLogin on dbo.Users.RegId= dbo.UsersLogin.RegId where dbo.UsersLogin.RegId=@RegId;";
                }
                using (var con = connectionHelper.GetConnection())
                {
                    List = con.Query<Registration>(SqlString, new
                    {
                        RegId
                    }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return List;
        }


        public List<Registration> GetProfiledetails(int RegId)
        {
            List<Registration> List = new List<Registration>();
            try
            {
                if (RegId > 0)
                {
                    string SqlString = "select * from dbo.Users join dbo.UsersLogin on dbo.Users.RegId= dbo.UsersLogin.RegId where dbo.UsersLogin.RegId='" + RegId + "' ;";
                    SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
                    DataTable dt = new DataTable();
                    con.Open();
                    sda.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Registration details = new Registration();
                        details.Class = dt.Rows[i]["Class"].ToString();
                        details.Name = dt.Rows[i]["Name"].ToString();
                        details.Address = dt.Rows[i]["Address"].ToString();
                        details.Father_Name = dt.Rows[i]["Father_Name"].ToString();
                        details.Mother_Name = dt.Rows[i]["Mother_Name"].ToString();
                        details.Phone = dt.Rows[i]["Phone"].ToString();
                        details.Password = dt.Rows[i]["Password"].ToString();
                        details.Role = dt.Rows[i]["Role"].ToString();
                        details.RegId = Convert.ToInt32(dt.Rows[i]["RegId"]);
                        List.Add(details);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return List;
        }

        public Response login(string RegId, string PSD)
        {
            var res = new Response
            {
                Status = "Authentication Error"
            };
            try
            {
                List<Registration> List = new List<Registration>();
                string SqlString = "select dbo.Users.Role from dbo.Users join dbo.UsersLogin on dbo.Users.RegId = dbo.UsersLogin.RegId where dbo.UsersLogin.RegId = '" + RegId + "' and dbo.UsersLogin.Password = '" + PSD + "' and dbo.Users.Status='Active';";
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
                        Role = Convert.ToString(dt.Rows[0]["Role"])
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

        public List<ProfileData> GetSubjectMaths(string cls, string sub)
        {
            List<ProfileData> List = new List<ProfileData>();
            try
            {
                using (var con = connectionHelper.GetConnection())
                {
                    List = con.Query<ProfileData>("select * from VedioDetail where vedioForClass = @cls and Subject = @sub", new
                    {
                        cls,
                        sub = 1
                    }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return List;


        }
        public List<ProfileData> Getsubjectenglishvedio(string cls, string sub)
        {
            //string qry = "";

            try
            {
                List<ProfileData> List = new List<ProfileData>();


                string SqlString = "select * from VedioDetail where vedioForClass ='" + cls + "' and Subject =4";
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                //  DataTable dt = du.getData(qry);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProfileData details = new ProfileData();
                    details.VedioId = Convert.ToInt64(dt.Rows[i]["VedioId"]);

                    details.VedioName = dt.Rows[i]["VedioName"].ToString();

                    details.VedioForClass = dt.Rows[i]["VedioForClass"].ToString();
                    details.VedioTittle = dt.Rows[i]["VedioTittle"].ToString();
                    details.VedioUrl = dt.Rows[i]["VedioUrl"].ToString();

                    List.Add(details);
                }
                return List;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public List<ProfileData> Getsubjectsciencevedio(string cls, string sub)
        {
            //string qry = "";

            try
            {
                List<ProfileData> List = new List<ProfileData>();


                string SqlString = "select * from VedioDetail where vedioForClass ='" + cls + "' and Subject =3";
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                //  DataTable dt = du.getData(qry);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProfileData details = new ProfileData();
                    details.VedioId = Convert.ToInt64(dt.Rows[i]["VedioId"]);

                    details.VedioName = dt.Rows[i]["VedioName"].ToString();

                    details.VedioForClass = dt.Rows[i]["VedioForClass"].ToString();
                    details.VedioTittle = dt.Rows[i]["VedioTittle"].ToString();
                    details.VedioUrl = dt.Rows[i]["VedioUrl"].ToString();

                    List.Add(details);
                }
                return List;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public List<ProfileData> Getsubjecthindivedio(string cls, string sub)
        {
            //string qry = "";

            try
            {
                List<ProfileData> List = new List<ProfileData>();


                string SqlString = "select * from VedioDetail where vedioForClass='" + cls + "' and Subject =2";
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                //  DataTable dt = du.getData(qry);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProfileData details = new ProfileData();
                    details.VedioId = Convert.ToInt64(dt.Rows[i]["VedioId"]);

                    details.VedioName = dt.Rows[i]["VedioName"].ToString();

                    details.VedioForClass = dt.Rows[i]["VedioForClass"].ToString();
                    details.VedioTittle = dt.Rows[i]["VedioTittle"].ToString();
                    details.VedioUrl = dt.Rows[i]["VedioUrl"].ToString();

                    List.Add(details);
                }
                return List;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

    }
}