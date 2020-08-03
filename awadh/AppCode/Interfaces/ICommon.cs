using Awadh.Models;
using System.Collections.Generic;
using System.Web;

namespace Awadh.AppCode.Interfaces
{
    interface ICommon
    {
        Response login(string RegId, string PSD);
        Dashboard Dashboard();
        Response RegistrationPer(Registration dts);
        IEnumerable<Registration> GetProfiledetails(int RegId);
        IEnumerable<Registration> GetAllProfileDetails(string RegId);
        AskedQuestion GetAskedQuestionByID(int QuestionID);
        IEnumerable<AskedQuestion> GetAskedQuestion();        
        Response AskedQuestion(AskedQuestion param);
        string uploadEditorImage(HttpPostedFileBase file);
        IEnumerable<SubjectMasterModel> GetSubjectMaster();
        Response ReplyToQuestion(AskedQuestion param);
        Response ChangePassword(string currentPassword, string newPassword);
        IEnumerable<MaterialUploadDetail> GetuploadedMaterial(int subjectId);
        AskedQuestion Solution(int QuestionID);
    }
}
