using Awadh.AppCode.Interfaces;
using Awadh.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Awadh.DAL
{
    public class CommonDal : ICommon
    {
        public Response AskedQuestion(AskedQuestion param)
        {
            using (var Connection = connectionHelper.GetConnection())
            {
                var _lr = (LoginData)HttpContext.Current.Session[SessionKey.Login];
                var response = new Response
                {
                    StatusCode = -1,
                    Status = "Temperory Error"
                };
                try
                {
                    string query = string.Empty;
                    if (param.QuestionID == 0)
                    {
                        query = "insert into AskedQuestion(Question,QuestionDescription,SubjectID,UserID,Class) values(@Question,@QuestionDescription,@SubjectID,@LoginID,@Class);select 1 StatusCode , 'Your notice is placed successfully.' Msg";
                    }
                    else
                    {
                        query = "update AskedQuestion set Question=@Question,SubjectID=@SubjectID where QuestionID=@QuestionID;select 1 StatusCode , 'update successfully.' Msg";
                    }
                    response = Connection.Query<Response>(query,
                        new
                        {
                            param.QuestionID,
                            param.Question,
                            param.QuestionDescription,
                            param.SubjectID,
                            _lr.LoginID,
                            _lr.Class
                        },
                        commandType: CommandType.Text).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    response.Status = ex.Message;
                }
                return response;
            }
        }

        public string uploadEditorImage(HttpPostedFileBase file)
        {
            StringBuilder ImagePath = new StringBuilder();
            ImagePath.Append(HttpContext.Current.Server.MapPath("~/content/uploads/Images/"));
            string src = string.Empty;
            try
            {
                if (!Directory.Exists(ImagePath.ToString()))
                {
                    Directory.CreateDirectory(ImagePath.ToString());
                }
                ImagePath.Append("{FileName}");
                if (file != null)
                {
                    ImagePath.Replace("{FileName}", file.FileName);
                    file.SaveAs(ImagePath.ToString());
                    src = "/content/uploads/Images/" + file.FileName;
                }
            }
            catch (Exception ex)
            {

            }
            return src;
        }

        public IEnumerable<SubjectMasterModel> GetSubjectMaster()
        {
            List<SubjectMasterModel> List = new List<SubjectMasterModel>();
            try
            {
                using (var con = connectionHelper.GetConnection())
                {
                    List = con.Query<SubjectMasterModel>("select * from SubjectMaster", new
                    {

                    }).ToList();
                }
                return List;
            }
            catch (Exception ex)
            {
                return List;
            }
        }

        public IEnumerable<AskedQuestion> GetAskedQuestion()
        {
            var List = new List<AskedQuestion>();
            try
            {
                using (var con = connectionHelper.GetConnection())
                {
                    List = con.Query<AskedQuestion>("select q.*,s.SubjectName,u.Name postedBy from AskedQuestion q inner join SubjectMaster s on s.SubjectId=q.SubjectID inner join Users u on u.RegId=q.UserID", new
                    {

                    }).ToList();
                }
                return List;
            }
            catch (Exception ex)
            {
                return List;
            }
        }


        public AskedQuestion GetAskedQuestionByID(int QuestionID)
        {
            var response = new AskedQuestion();
            try
            {
                using (var con = connectionHelper.GetConnection())
                {
                    response = con.Query<AskedQuestion>("select q.*,s.SubjectName,u.Name postedBy from AskedQuestion q inner join SubjectMaster s on s.SubjectId=q.SubjectID inner join Users u on u.RegId=q.UserID where QuestionID=@QuestionID",
                        new
                        {
                            QuestionID
                        }).FirstOrDefault();
                }

            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public Response ReplyToQuestion(AskedQuestion param)
        {
            using (var Connection = connectionHelper.GetConnection())
            {
                var _lr = (LoginData)HttpContext.Current.Session[SessionKey.Login];
                var response = new Response
                {
                    StatusCode = -1,
                    Status = "Temperory Error"
                };
                try
                {
                    string query = string.Empty;
                    if (param.ReplyID == 0)
                    {
                        query = "insert into ReplyToQuestion(QuestionID,Reply,ReplyBy) values(@QuestionID,@Reply,@LoginID);select 1 StatusCode , 'Your notice is placed successfully.' Msg";
                    }
                    else
                    {
                        query = "update ReplyToQuestion set Reply=@Reply where ReplyID=@ReplyID;select 1 StatusCode , 'update successfully.' Msg";
                    }
                    response = Connection.Query<Response>(query,
                        new
                        {
                            param.QuestionID,
                            param.ReplyID,
                            param.Reply,
                            _lr.LoginID,
                        },
                        commandType: CommandType.Text).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    response.Status = ex.Message;
                }
                return response;
            }
        }

        public Response ChangePassword(string currentPassword,string newPassword)
        {
            using (var Connection = connectionHelper.GetConnection())
            {
                var _lr = (LoginData)HttpContext.Current.Session[SessionKey.Login];
                var response = new Response
                {
                    StatusCode = -1,
                    Status = "Temperory Error"
                };
                try
                {
                    response = Connection.Query<Response>("ChangePassword",
                        new
                        {
                            currentPassword,
                            newPassword,
                            _lr.LoginID,
                        },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    response.Status = ex.Message;
                }
                return response;
            }
        }
    }
}