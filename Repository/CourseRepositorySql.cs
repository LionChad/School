using Project.Model;
using System.Text;
namespace Project.Repository
{
    public partial class CourseRepository
    {
        #region DB-Course
        private RepositoryModel GetCourseListSql(CourseDataModel model)
        {
            var result = new RepositoryModel();
            StringBuilder commandText = new StringBuilder();
            List<string> commandWhereList = new List<string>();
            string commandWhere = string.Empty;

            #region WHERE

            if (model.CourseID != null)
            {
                commandWhereList.Add("CourseID = {CourseID}");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseTitle != null)
            {
                commandWhereList.Add("CourseTitle = {CourseTitle}");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseIntroduction != null)
            {
                commandWhereList.Add("CourseIntroduction = {CourseIntroduction}");
                result.SqlParams.Add(model.CourseIntroduction);
            }
            if (model.Week != null)
            {
                commandWhereList.Add("Week = {Week}");
                result.SqlParams.Add(model.Week);
            }
            if (model.Time != null)
            {
                commandWhereList.Add("Time = {Time}");
                result.SqlParams.Add(model.Time);
            }
            if (model.ProfessorName != null)
            {
                commandWhereList.Add("ProfessorName = {ProfessorName}");
                result.SqlParams.Add(model.ProfessorName);
            }
            if (model.RequiredSubjects != null)
            {
                commandWhereList.Add("RequiredSubjects = {RequiredSubjects}");
                result.SqlParams.Add(model.RequiredSubjects);
            }
            if (model.StudentNumberLimit != 0)
            {
                commandWhereList.Add("StudentNumberLimit = {StudentNumberLimit}");
                result.SqlParams.Add(model.StudentNumberLimit);
            }
            if (model.RequiredStudentNumber != 0)
            {
                commandWhereList.Add("RequiredStudentNumber = {RequiredStudentNumber}");
                result.SqlParams.Add(model.RequiredSubjects);
            }
            if (commandWhereList.Any())
            {
                commandWhere = (" WHERE " + string.Join(Environment.NewLine + "   AND ", commandWhereList));
            }
            #endregion

            commandText.AppendLine(string.Join(Environment.NewLine,
                @"
					SELECT CourseTitle
						 , CourseIntroduction
						 , Week
                         , Time
						 , ProfessorName
						 , RequiredSubjects
						 , StudentNumberLimit
						 , RequiredStudentNumber
					  FROM Course
                ", commandWhere));

            result.SqlString = commandText.ToString();

            return result;
        }

        private RepositoryModel InsertCourseSql(CourseDataModel model)
        {
            var result = new RepositoryModel();
            StringBuilder commandText = new StringBuilder();
            List<string> commandWhereList = new List<string>();
            string commandWhere = string.Empty;

            #region WHERE

            if (model.CourseID != null)
            {
                commandWhereList.Add("CourseID = {CourseID}");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseTitle != null)
            {
                commandWhereList.Add("CourseTitle = {CourseTitle}");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseIntroduction != null)
            {
                commandWhereList.Add("CourseIntroduction = {CourseIntroduction}");
                result.SqlParams.Add(model.CourseIntroduction);
            }
            if (model.Week != null)
            {
                commandWhereList.Add("Week = {Week}");
                result.SqlParams.Add(model.Week);
            }
            if (model.Time != null)
            {
                commandWhereList.Add("Time = {Time}");
                result.SqlParams.Add(model.Time);
            }
            if (model.ProfessorName != null)
            {
                commandWhereList.Add("ProfessorName = {ProfessorName}");
                result.SqlParams.Add(model.ProfessorName);
            }
            if (model.RequiredSubjects != null)
            {
                commandWhereList.Add("RequiredSubjects = {RequiredSubjects}");
                result.SqlParams.Add(model.RequiredSubjects);
            }
            if (model.StudentNumberLimit != 0)
            {
                commandWhereList.Add("StudentNumberLimit = {StudentNumberLimit}");
                result.SqlParams.Add(model.StudentNumberLimit);
            }
            if (model.RequiredStudentNumber != 0)
            {
                commandWhereList.Add("RequiredStudentNumber = {RequiredStudentNumber}");
                result.SqlParams.Add(model.RequiredSubjects);
            }
            if (commandWhereList.Any())
            {
                commandWhere = (" WHERE " + string.Join(Environment.NewLine + "   AND ", commandWhereList));
            }
            #endregion

            commandText.AppendLine(string.Join(Environment.NewLine,
                @"
					SELECT CourseTitle
						 , CourseIntroduction
						 , ClassTime_Week
                         , ClassTime_Time
						 , ProfessorName
						 , RequiredSubjects
						 , StudentNumberLimit
						 , RequiredStudentNumber
						 , IsAuditCourse
					  FROM Course
                ", commandWhere));

            result.SqlString = commandText.ToString();

            return result;
        }

        private RepositoryModel UpdateCourseSql(CourseDataModel model)
        {
            var result = new RepositoryModel();
            StringBuilder commandText = new StringBuilder();
            List<string> commandWhereList = new List<string>();
            string commandWhere = string.Empty;

            #region WHERE

            if (model.CourseID != null)
            {
                commandWhereList.Add("CourseID = {CourseID}");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseTitle != null)
            {
                commandWhereList.Add("CourseTitle = {CourseTitle}");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseIntroduction != null)
            {
                commandWhereList.Add("CourseIntroduction = {CourseIntroduction}");
                result.SqlParams.Add(model.CourseIntroduction);
            }
            if (model.Week != null)
            {
                commandWhereList.Add("Week = {Week}");
                result.SqlParams.Add(model.Week);
            }
            if (model.Time != null)
            {
                commandWhereList.Add("Time = {Time}");
                result.SqlParams.Add(model.Time);
            }
            if (model.ProfessorName != null)
            {
                commandWhereList.Add("ProfessorName = {ProfessorName}");
                result.SqlParams.Add(model.ProfessorName);
            }
            if (model.RequiredSubjects != null)
            {
                commandWhereList.Add("RequiredSubjects = {RequiredSubjects}");
                result.SqlParams.Add(model.RequiredSubjects);
            }
            if (model.StudentNumberLimit != 0)
            {
                commandWhereList.Add("StudentNumberLimit = {StudentNumberLimit}");
                result.SqlParams.Add(model.StudentNumberLimit);
            }
            if (model.RequiredStudentNumber != 0)
            {
                commandWhereList.Add("RequiredStudentNumber = {RequiredStudentNumber}");
                result.SqlParams.Add(model.RequiredSubjects);
            }
            if (commandWhereList.Any())
            {
                commandWhere = (" WHERE " + string.Join(Environment.NewLine + "   AND ", commandWhereList));
            }
            #endregion

            commandText.AppendLine(string.Join(Environment.NewLine,
                @"
					SELECT CourseTitle
						 , CourseIntroduction
						 , ClassTime_Week
                         , ClassTime_Time
						 , ProfessorName
						 , RequiredSubjects
						 , StudentNumberLimit
						 , RequiredStudentNumber
						 , IsAuditCourse
					  FROM Course
                ", commandWhere));

            result.SqlString = commandText.ToString();

            return result;
        }

        private RepositoryModel DeleteCourseSql(CourseDataModel model)
        {
            var result = new RepositoryModel();
            StringBuilder commandText = new StringBuilder();
            List<string> commandWhereList = new List<string>();
            string commandWhere = string.Empty;

            #region WHERE

            if (model.CourseID != null)
            {
                commandWhereList.Add("CourseID = {CourseID}");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseTitle != null)
            {
                commandWhereList.Add("CourseTitle = {CourseTitle}");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseIntroduction != null)
            {
                commandWhereList.Add("CourseIntroduction = {CourseIntroduction}");
                result.SqlParams.Add(model.CourseIntroduction);
            }
            if (model.Week != null)
            {
                commandWhereList.Add("Week = {Week}");
                result.SqlParams.Add(model.Week);
            }
            if (model.Time != null)
            {
                commandWhereList.Add("Time = {Time}");
                result.SqlParams.Add(model.Time);
            }
            if (model.ProfessorName != null)
            {
                commandWhereList.Add("ProfessorName = {ProfessorName}");
                result.SqlParams.Add(model.ProfessorName);
            }
            if (model.RequiredSubjects != null)
            {
                commandWhereList.Add("RequiredSubjects = {RequiredSubjects}");
                result.SqlParams.Add(model.RequiredSubjects);
            }
            if (model.StudentNumberLimit != 0)
            {
                commandWhereList.Add("StudentNumberLimit = {StudentNumberLimit}");
                result.SqlParams.Add(model.StudentNumberLimit);
            }
            if (model.RequiredStudentNumber != 0)
            {
                commandWhereList.Add("RequiredStudentNumber = {RequiredStudentNumber}");
                result.SqlParams.Add(model.RequiredSubjects);
            }
            if (commandWhereList.Any())
            {
                commandWhere = (" WHERE " + string.Join(Environment.NewLine + "   AND ", commandWhereList));
            }
            #endregion

            commandText.AppendLine(string.Join(Environment.NewLine,
                @"
					SELECT CourseTitle
						 , CourseIntroduction
						 , ClassTime_Week
                         , ClassTime_Time
						 , ProfessorName
						 , RequiredSubjects
						 , StudentNumberLimit
						 , RequiredStudentNumber
						 , IsAuditCourse
					  FROM Course
                ", commandWhere));

            result.SqlString = commandText.ToString();

            return result;
        }
        #endregion
    }

}
