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
                        reponse.msg = "�Ѽ����Ҥ��q�L�A�o�N���@�ӭӦC�֭��ӰѼƤF";
                    }
                }
                else
                {
                    reponse.msg = "�v�����Ҥ��q�L";
                }
            }
            else
            {
                reponse.msg = "�������Ҥ��q�L";
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
                        reponse.msg = "�Ѽ����Ҥ��q�L�A�S��CourseID�λݧ�s�����";
                    }
                }
                else
                {
                    reponse.msg = "�v�����Ҥ��q�L";
                }
            }
            else
            {
                reponse.msg = "�������Ҥ��q�L";
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
                        reponse.msg = "�S��CourseID�C";
                    }
                }
                else
                {
                    reponse.msg = "�v�����Ҥ��q�L";
                }
            }
            else
            {
                reponse.msg = "�������Ҥ��q�L";
            }

            return reponse;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        private bool IsAuthorization()
        {
            bool isAuthorization = false;
            isAuthorization = true;
            return isAuthorization;
        }

        /// <summary>
        /// ���v����
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