using Awadh.Models;
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
            string uid = "";
            string SqlString = "";
            try
            {
                List<Registration> List = new List<Registration>();
                if (RegId == "undefined" || RegId == null)
                {
                    SqlString = "select * from  [SchoolErp].[dbo].[Registration] ORDER BY RegId DESC";
                }
                else
                {

                    SqlString = "select * from  [SchoolErp].[dbo].[Registration] where RegId='" + uid + "' ;";
                }
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
                    details.DOB = dt.Rows[i]["DOB"].ToString();
                    details.Status = dt.Rows[i]["Status"].ToString();
                    details.RegId = Convert.ToInt32(dt.Rows[i]["RegId"]);
                    List.Add(details);
                }
                return List;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Registration> GetProfiledetails(string RegId)
        {
            string uid = "";
            if (HttpContext.Current.Session["UserId"] == null)
            {
                uid = null;
                return null;
            }
            else
            {
                uid = HttpContext.Current.Session["UserId"].ToString();
                try
                {
                    List<Registration> List = new List<Registration>();
                    if (uid != null)
                    {
                        string SqlString = "select * from  [SchoolErp].[dbo].[Registration] where RegId='" + uid + "' ;";
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
                        return List;
                    }
                    else { return null; }

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<Registration> login(string RegId, string PSD)
        {
            try
            {
                List<Registration> List = new List<Registration>();
                string SqlString = "select * from  [SchoolErp].[dbo].[Registration] where RegId='" + RegId + "' and Password='" + PSD + "' and Status='Active' ;";
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
                DataTable dt = new DataTable();
                con.Open();
                sda.Fill(dt);
                HttpContext.Current.Session["UserId"] = RegId;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Registration details = new Registration();
                    details.Role = dt.Rows[i]["Role"].ToString();
                    List.Add(details);
                }
                return List;
            }
            catch (Exception ex)
            {
                return null;
            }


        }



        public List<ProfileData> GetSubjectMaths(string cls, string sub)
        {
            //string qry = "";

            try
            {
                List<ProfileData> List = new List<ProfileData>();


                string SqlString = "select * from VedioDetail where vedioForClass ='" + cls + "' and Subject ='Maths'";
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
        public List<ProfileData> Getsubjectenglishvedio(string cls, string sub)
        {
            //string qry = "";

            try
            {
                List<ProfileData> List = new List<ProfileData>();


                string SqlString = "select * from VedioDetail where vedioForClass ='" + cls + "' and Subject ='English'";
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


                string SqlString = "select * from VedioDetail where vedioForClass ='" + cls + "' and Subject ='Science'";
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


                string SqlString = "select * from VedioDetail where vedioForClass='" + cls + "' and Subject ='Hindi'";
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