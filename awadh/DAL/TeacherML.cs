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

        public Dashboard Dashboard()
        {
            var respnse = new Dashboard();
            return respnse;
        }
    }
}