using Microsoft.AspNetCore.Mvc;
using Project.Model;
using Project.Repository;
using Project.Util;

namespace Project.Controllers
{
    [Route("api/[controller]/{courseID}")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //https://localhost:7082/api/Course/B001?CourseTitle=CourseTitle&week=week&Time=HHmm-HHmm&ProfessorName=ProfessorName&RequiredSubjects=RequiredSubjects
        //由於當初偷懶，導致CourseDataModel深度耦合，後續要把傳入參數用成Model過於困難，所以放棄
        [HttpGet]
        public GetCourseListResponse Get(string courseID, string courseTitle, string week, string time, string professorName, string requiredSubjects)
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

            // 建立 CourseRepository 的實例
            ICourseRepository courseRepository = new CourseRepository();

            // 使用建構子注入方式將 courseRepository 注入到 CourseModel 中
            CourseModel courseModel = new CourseModel(courseRepository);
            var reponse = new CourseModel().GetCourseList(model);

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
                        !string.IsNullOrEmpty(model.ProfessorName))
                    {
                        reponse = new CourseModel().InsertCourse(model);
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
                         !string.IsNullOrEmpty(model.ProfessorName)))
                    {
                        reponse = new CourseModel().UpdateCourse(model);
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

        [HttpDelete]
        public EditResponseModel DELETE(CourseDataModel model)
        {
            var reponse = new EditResponseModel();

            if (IsMemberVertify())
            {
                if (IsAuthenticationVertify())
                {
                    if (model.CourseID != null)
                    {
                        reponse = new CourseModel().DeleteCourse(model);
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