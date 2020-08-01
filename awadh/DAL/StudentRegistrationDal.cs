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