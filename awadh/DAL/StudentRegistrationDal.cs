using Awadh.Models;
using Dapper;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;


namespace Awadh.DAL
{
    public class StudentRegistrationDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        // SqlTransaction transaction;

        public Response RegistrationPer(Registration dts)
        {
            var res = new Response
            {
                Status = "Technical Issue"
            };
            try
            {
                using (var con = connectionHelper.GetConnection())
                {
                    string Query = @"insert into  [SchoolErp].[dbo].[Users] ([Name],[Father_Name],[Mother_Name] ,[Phone],
                                 [Email],[Role],[Class],[Address],[DOB],[LastSchool],[Status]) values (@Name,@Father_Name,@Mother_Name,@Phone,
                                 @Email,@Role,@Class,@Address,@DOB,@LastSchool,@Status);
                                 insert into  [SchoolErp].[dbo].[UsersLogin] ([RegId],[Password]) values(Scope_Identity(),@Password);
                                 Select 1 StatusCode,'Register successfully' Status";
                    var response = con.Query<Response>(Query, new
                    {
                        dts.Name,
                        dts.Father_Name,
                        dts.Mother_Name,
                        dts.Phone,
                        dts.Email,
                        dts.Role,
                        dts.Class,
                        dts.Address,
                        dts.DOB,
                        dts.LastSchool,
                        Status = "Active",
                        dts.Password
                    }).FirstOrDefault();
                    res.StatusCode = response.StatusCode;
                    res.Status = response.Status;
                }
            }
            catch (Exception ex)
            {
                res.Catch = ex.Message;
            }
            return res;
        }

        public string VideoDetails(Models.ProfileData dts)
        {
            string result = string.Empty;
            try
            {
                using (var con = connectionHelper.GetConnection())
                {
                    string Query = @"insert into  [SchoolErp].[dbo].[VedioDetail] ([vedioName],[vedioForClass],[VedioTittle],[vedioUrl],[Subject]) 
                                    values(@VedioName,@VedioForClass,@VedioTittle,@VedioUrl,@SubjectId);select 'Successfully Done' ";
                    result = con.Query<string>(Query, new
                    {
                        dts.VedioName,
                        dts.VedioForClass,
                        dts.VedioTittle,
                        dts.VedioUrl,
                        dts.SubjectId
                    }).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}