using Microsoft.AspNetCore.Mvc;
using Project.Model;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public List<CourseDataModel> Get(string courseID, string courseTitle, string week, string time, string professorName, string requiredSubjects, bool isNotAuditCourse)
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
        public ResponseModel POST(CourseDataModel model)
        {
            var reponse = new ResponseModel();

            if (IsAuthorization())
            {
                if (IsAuthentication())
                {
                    if (!string.IsNullOrEmpty(model.CourseID) &&
                        !string.IsNullOrEmpty(model.CourseTitle) &&
                        !string.IsNullOrEmpty(model.CourseIntroduction) &&
                        !string.IsNullOrEmpty(model.Week) &&
                        !string.IsNullOrEmpty(model.Time) &&
                        !string.IsNullOrEmpty(model.ProfessorName) &&
                        !string.IsNullOrEmpty(model.RequiredSubjects) &&
                        model.StudentNumberLimit != 0 &&
                        model.RequiredStudentNumber != 0)
                    {
                        reponse = new GetCourseModel().InsertCourse(model);
                    }
                    else
                    {
                        reponse.msg = "參數驗證不通過，這就不一個個列少哪個參數了";
                    }
                }
                else
                {
                    reponse.msg = "權限驗證不通過";
                }
            }
            else
            {
                reponse.msg = "身分驗證不通過";
            }

            return reponse;
        }

        [HttpPatch]
        public ResponseModel PATCH(CourseDataModel model)
        {
            var reponse = new ResponseModel();

            if (IsAuthorization())
            {
                if (IsAuthentication())
                {
                    if (!string.IsNullOrEmpty(model.CourseID) &&
                         (!string.IsNullOrEmpty(model.CourseTitle) ||
                         !string.IsNullOrEmpty(model.CourseIntroduction) ||
                         !string.IsNullOrEmpty(model.Week) ||
                         !string.IsNullOrEmpty(model.Time) ||
                         !string.IsNullOrEmpty(model.ProfessorName) ||
                         !string.IsNullOrEmpty(model.RequiredSubjects) ||
                         model.StudentNumberLimit != 0 ||
                         model.RequiredStudentNumber != 0))
                    {
                        reponse = new GetCourseModel().UpdateCourse(model);
                    }
                    else
                    {
                        reponse.msg = "參數驗證不通過，沒有CourseID或需更新的資料";
                    }
                }
                else
                {
                    reponse.msg = "權限驗證不通過";
                }
            }
            else
            {
                reponse.msg = "身分驗證不通過";
            }

            return reponse;
        }

        [HttpPatch]
        public ResponseModel DELETE(CourseDataModel model)
        {
            var reponse = new ResponseModel();

            if (IsAuthorization())
            {
                if (IsAuthentication())
                {
                    if (model.CourseID != null)
                    {
                        reponse = new GetCourseModel().DeleteCourse(model);
                    }
                    else
                    {
                        reponse.msg = "沒有CourseID。";
                    }
                }
                else
                {
                    reponse.msg = "權限驗證不通過";
                }
            }
            else
            {
                reponse.msg = "身分驗證不通過";
            }

            return reponse;
        }

        /// <summary>
        /// 身份驗證
        /// </summary>
        /// <returns></returns>
        private bool IsAuthorization()
        {
            bool isAuthorization = false;
            isAuthorization = true;
            return isAuthorization;
        }

        /// <summary>
        /// 授權驗證
        /// </summary>
        /// <returns></returns>
        private bool IsAuthentication()
        {
            bool isAuthentication = false;
            isAuthentication = true;
            return isAuthentication;
        }
    }
}