using Microsoft.AspNetCore.Mvc;
using Project.Model;
using Project.Util;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public GetCourseListResponseModel Get(string courseID, string courseTitle, string week, string time, string professorName, string requiredSubjects, bool isNotAuditCourse)
        {
            CourseDataModel model = new CourseDataModel()
            {
                CourseID = courseID,
                CourseTitle = courseTitle,
                Week = week,
                Time = time,
                ProfessorName = professorName,
                RequiredSubjects = requiredSubjects,
            };

            var reponse = new GetCourseModel().GetCourseList(model);

            return reponse;
        }

        [HttpPost]
        public EditResponseModel POST(CourseDataModel model)
        {
            var reponse = new EditResponseModel();

            if (IsMemberVertify())
            {
                if (IsAuthenticationVertify())
                {
                    if (!string.IsNullOrEmpty(model.CourseID) &&
                        !string.IsNullOrEmpty(model.CourseTitle) &&
                        !string.IsNullOrEmpty(model.Week) &&
                        !string.IsNullOrEmpty(model.Time) &&
                        !string.IsNullOrEmpty(model.ProfessorName))
                    {
                        reponse = new GetCourseModel().InsertCourse(model);
                    }
                    else
                    {
                        reponse.Code = (int)ReturnData.EnumReturnMessage.InputNotComplete;
                        reponse.Msg = ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc();
                    }
                }
                else
                {
                    reponse.Code = (int)ReturnData.EnumReturnMessage.AuthenticationVertifyFail;
                    reponse.Msg = ReturnData.EnumReturnMessage.AuthenticationVertifyFail.GetEnumDesc();
                }
            }
            else
            {
                reponse.Code = (int)ReturnData.EnumReturnMessage.MemberVertifyFail;
                reponse.Msg = ReturnData.EnumReturnMessage.MemberVertifyFail.GetEnumDesc();
            }

            return reponse;
        }

        [HttpPatch]
        public EditResponseModel PATCH(CourseDataModel model)
        {
            var reponse = new EditResponseModel();

            if (IsMemberVertify())
            {
                if (IsAuthenticationVertify())
                {
                    if (!string.IsNullOrEmpty(model.CourseID) &&
                         (!string.IsNullOrEmpty(model.CourseTitle) ||
                         !string.IsNullOrEmpty(model.CourseIntroduction) ||
                         !string.IsNullOrEmpty(model.Week) ||
                         !string.IsNullOrEmpty(model.Time) ||
                         !string.IsNullOrEmpty(model.ProfessorName) ||
                         !string.IsNullOrEmpty(model.RequiredSubjects)))
                    {
                        reponse = new GetCourseModel().UpdateCourse(model);
                    }
                    else
                    {
                        reponse.Code = (int)ReturnData.EnumReturnMessage.InputNotComplete;
                        reponse.Msg = ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc();
                    }
                }
                else
                {
                    reponse.Code = (int)ReturnData.EnumReturnMessage.AuthenticationVertifyFail;
                    reponse.Msg = ReturnData.EnumReturnMessage.AuthenticationVertifyFail.GetEnumDesc();
                }
            }
            else
            {
                reponse.Code = (int)ReturnData.EnumReturnMessage.MemberVertifyFail;
                reponse.Msg = ReturnData.EnumReturnMessage.MemberVertifyFail.GetEnumDesc();
            }

            return reponse;
        }

        [HttpPatch]
        public EditResponseModel DELETE(CourseDataModel model)
        {
            var reponse = new EditResponseModel();

            if (IsMemberVertify())
            {
                if (IsAuthenticationVertify())
                {
                    if (model.CourseID != null)
                    {
                        reponse = new GetCourseModel().DeleteCourse(model);
                    }
                    else
                    {
                        reponse.Code = (int)ReturnData.EnumReturnMessage.InputNotComplete;
                        reponse.Msg = ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc();
                    }
                }
                else
                {
                    reponse.Code = (int)ReturnData.EnumReturnMessage.AuthenticationVertifyFail;
                    reponse.Msg = ReturnData.EnumReturnMessage.AuthenticationVertifyFail.GetEnumDesc();
                }
            }
            else
            {
                reponse.Code = (int)ReturnData.EnumReturnMessage.MemberVertifyFail;
                reponse.Msg = ReturnData.EnumReturnMessage.MemberVertifyFail.GetEnumDesc();
            }

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