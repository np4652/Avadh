using Awadh.Models;
using System.Collections.Generic;
using System.Web;

namespace Awadh.AppCode.Interfaces
{
    interface ICommon
    {
        AskedQuestion GetAskedQuestionByID(int QuestionID);
        IEnumerable<AskedQuestion> GetAskedQuestion();        
        Response AskedQuestion(AskedQuestion param);
        string uploadEditorImage(HttpPostedFileBase file);
        IEnumerable<SubjectMasterModel> GetSubjectMaster();
        Response ReplyToQuestion(AskedQuestion param);
        Response ChangePassword(string currentPassword, string newPassword);
    }
}
