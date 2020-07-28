using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Awadh.DAL
{
    public class StudentRegistrationDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        public string RegistrationPer(Models.Registration dts)
        {
            cmd.Connection = con;
            string ss = "";
            cmd.CommandText = @"insert into  [SchoolErp].[dbo].[Registration] (
                                                                                [Name]
                                                                                ,[Father_Name]
                                                                                ,[Mother_Name]
                                                                                ,[Phone]
                                                                                ,[Email]
                                                                                ,[Role]
                                                                                ,[Photo]
                                                                                ,[Class]
                                                                                ,[Password]
                                                                                ,[Address]
                                                                                ,[DOB]
                                                                                ,[LastSchool]
                                                                                ,[Status]
                                                                                ) 
                                output INSERTED.RegId values('" + dts.Name + "','" + dts.Father_Name + "','" + dts.Mother_Name + "','" + dts.Phone + "','" + dts.Email + "','" + dts.Role + "','" + dts.ImagePath + "','" + dts.Class + "','" + dts.Password + "','" + dts.Address + "','" + dts.DOB + "','" + dts.LastSchool + "','Active') ";
            con.Open();
            int modified = (int)cmd.ExecuteScalar();
            ss = modified.ToString();
            con.Close();
            return ss;
        }

        public string RegistrationPer2(Models.Registration dts)
        {
            cmd.Connection = con;

            string ss = "";
            cmd.CommandText = @"insert into  [SchoolErp].[dbo].[Registration] (
                                                                                [Name]
                                                                                ,[Father_Name]
                                                                                ,[Mother_Name]     
                                                                                ) 
                                values('" + dts.Name + "','" + dts.Father_Name + "','" + dts.Mother_Name + "') ";
            con.Open();
            cmd.ExecuteNonQuery();
            ss = "Successfully done";
            con.Close();
            return ss;
        }



        public string VedioDetails(Models.ProfileData dts)
        {
            cmd.Connection = con;
            string ss = "";            
            cmd.CommandText = @"insert into  [SchoolErp].[dbo].[VedioDetail] (      
      [vedioName]
      ,[vedioForClass]
      ,[VedioTittle]
      ,[vedioUrl]
,[Subject]
      ) output INSERTED.vedioId values('" + dts.VedioName + "','" + dts.VedioForClass + "','" + dts.VedioTittle + "','" + dts.VedioUrl + "','" + dts.Subject + "') ";
            con.Open();
            //cmd.ExecuteNonQuery();
            int modified = (int)cmd.ExecuteScalar();
            //ss = modified.ToString();
            ss = "Successfully done";
            con.Close();

            return ss;
        }


        public string ChangeStatus(string Status, string RegId)
        {
            cmd.Connection = con;
            string ss = "";            
            cmd.CommandText = @"UPDATE [SchoolErp].[dbo].[Registration] SET Status = '" + Status + "' WHERE RegId = '" + RegId + "'";
            con.Open();
            int tst = cmd.ExecuteNonQuery();
            if (tst == 1)
            {
                ss = "Successfully done";

            }
            else
            {
                ss = "UserID is not correct ";
            }
            con.Close();
            return ss;
        }

    }
}