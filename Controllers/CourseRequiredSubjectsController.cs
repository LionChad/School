using Microsoft.AspNetCore.Mvc;
using Project.Model;
using Project.Util;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRequiredSubjectsController : ControllerBase
    {
        [HttpGet]
        public GetCourseRequiredSubjectsListResponse Get(string courseID, string courseTitle, string requiredSubjects)
        {
            CourseRequiredSubjectsDataModel model = new CourseRequiredSubjectsDataModel()
            {
                CourseID = courseID,
                CourseTitle = courseTitle,
                RequiredSubjects = requiredSubjects,
            };

            var reponse = new CourseModel().GetCourseRequiredSubjectsList(model);

            return reponse;
        }

        [HttpPost]
        public EditResponseModel POST(CourseDataModel model)
        {
            var reponse = new EditResponseModel();

            //if (IsMemberVertify())
            //{
            //    if (IsAuthenticationVertify())
            //    {
            //        if (!string.IsNullOrEmpty(model.CourseID) &&
            //            !string.IsNullOrEmpty(model.CourseTitle) &&
            //            !string.IsNullOrEmpty(model.Week) &&
            //            !string.IsNullOrEmpty(model.Time) &&
            //            !string.IsNullOrEmpty(model.ProfessorName))
            //        {
            //            reponse = new GetCourseModel().InsertCourse(model);
            //        }
            //        else
            //        {
            //            reponse.Code = (int)ReturnData.EnumReturnMessage.InputNotComplete;
            //            reponse.Msg = ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc();
            //        }
            //    }
            //    else
            //    {
            //        reponse.Code = (int)ReturnData.EnumReturnMessage.AuthenticationVertifyFail;
            //        reponse.Msg = ReturnData.EnumReturnMessage.AuthenticationVertifyFail.GetEnumDesc();
            //    }
            //}
            //else
            //{
            //    reponse.Code = (int)ReturnData.EnumReturnMessage.MemberVertifyFail;
            //    reponse.Msg = ReturnData.EnumReturnMessage.MemberVertifyFail.GetEnumDesc();
            //}

            return reponse;
        }

        [HttpPatch]
        public EditResponseModel DELETE(CourseDataModel model)
        {
            var reponse = new EditResponseModel();

            //if (IsMemberVertify())
            //{
            //    if (IsAuthenticationVertify())
            //    {
            //        if (model.CourseID != null)
            //        {
            //            reponse = new GetCourseModel().DeleteCourse(model);
            //        }
            //        else
            //        {
            //            reponse.Code = (int)ReturnData.EnumReturnMessage.InputNotComplete;
            //            reponse.Msg = ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc();
            //        }
            //    }
            //    else
            //    {
            //        reponse.Code = (int)ReturnData.EnumReturnMessage.AuthenticationVertifyFail;
            //        reponse.Msg = ReturnData.EnumReturnMessage.AuthenticationVertifyFail.GetEnumDesc();
            //    }
            //}
            //else
            //{
            //    reponse.Code = (int)ReturnData.EnumReturnMessage.MemberVertifyFail;
            //    reponse.Msg = ReturnData.EnumReturnMessage.MemberVertifyFail.GetEnumDesc();
            //}

            return reponse;
        }

        /// <summary>
        /// 會員驗證
        /// </summary>
        /// <returns></returns>
        private bool IsMemberVertify()
        {
            bool isMemberVertify = false;
            isMemberVertify = true;
            return isMemberVertify;
        }

        /// <summary>
        /// 授權驗證
        /// </summary>
        /// <returns></returns>
        private bool IsAuthenticationVertify()
        {
            bool isAuthenticationVertify = false;
            isAuthenticationVertify = true;
            return isAuthenticationVertify;
        }
    }
}