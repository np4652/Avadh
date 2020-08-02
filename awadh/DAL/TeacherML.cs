using Awadh.AppCode.Interfaces;
using Awadh.Models;
using Dapper;
using System;
using System.Linq;

namespace Awadh.DAL
{
    public class TeacherML: ITeacher
    {
        public Response ChangeStatus(string Status, string RegId)
        {
            var response = new Response
            {
                StatusCode = -1
            };
            using (var Con = connectionHelper.GetConnection())
            {
                try
                {
                    response = Con.Query<Response>("UPDATE [SchoolErp].[dbo].[Users] SET Status = @Status WHERE RegId=@RegId;select 1 StatusCode,'Change Status Succeffully' Status",
                    new
                    {
                        Status,
                        RegId
                    },
                    commandType: System.Data.CommandType.Text).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    response.Catch = ex.Message;
                }
            }
            return response;
        }

        public Response MaterialUploadDetail(MaterialUploadDetail param)
        {
            Response response = new Response
            {
                StatusCode = -1,
                Status = "Technical Error"
            };
            try
            {
                using (var con = connectionHelper.GetConnection())
                {
                    string Query = @"insert into  [SchoolErp].[dbo].[MaterialUploadDetail] ([Class],[Title],[URL],[Subject],[Description],[IsLink]) 
                                    values(@Class,@Title,@URL,@SubjectID,@Description,@IsLink);select 1 statuscode ,'Successfully Done'status ";
                    response = con.Query<Response>(Query, new
                    {
                        param.Class,
                        param.SubjectID,
                        param.Title,
                        param.URL,
                        param.Description,
                        param.IsLink
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                response.Catch = ex.Message;
            }
            return response;
        }
    }
}