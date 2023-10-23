using Project.Model;
using Project.Util;
using System;
using System.Text;
namespace Project.Repository
{
    public partial class CourseRepository : RepositorySqlBase
    {
        #region DB-Course
        private RepositoryModel GetCourseListSql(CourseDataModel model)
        {
            var result = new RepositoryModel();
            StringBuilder commandText = new StringBuilder();
            List<string> commandWhereList = new List<string>();
            string commandWhere = string.Empty;
            List<string> leftJoinCommandTime = new List<string>();
            StringBuilder commandTime = new StringBuilder();
            StringBuilder leftJoinCommandWhere = new StringBuilder();
            string requiredSubjects = string.Empty;
            #region WHERE

            if (model.CourseID != null)
            {
                commandWhereList.Add("CourseID = @CourseID");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseTitle != null)
            {
                commandWhereList.Add("CourseTitle = @CourseTitle");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseIntroduction != null)
            {
                commandWhereList.Add("CourseIntroduction = @CourseIntroduction");
                result.SqlParams.Add(model.CourseIntroduction);
            }
            if (model.Week != null)
            {
                leftJoinCommandTime.Add("Course_Time.Week = @Week");
                commandTime.AppendLine(", Course_Time.Week");
                result.SqlParams.Add(model.Week);
            }
            if (model.Time != null)
            {
                leftJoinCommandTime.Add("Course_Time.Time = @Time");
                commandTime.AppendLine(", Course_Time.Time");
                result.SqlParams.Add(model.Time);
            }
            if (model.ProfessorName != null)
            {
                commandWhereList.Add("ProfessorName = @ProfessorName");
                result.SqlParams.Add(model.ProfessorName);
            }
            if (model.RequiredSubjects != null)
            {
                leftJoinCommandWhere.AppendLine(" LEFT JOIN Course_RequiredSubjects ON Course.CourseID = Course_RequiredSubjects.CourseID AND Course_RequiredSubjects.RequiredSubjects = @RequiredSubjects");
                requiredSubjects = ", Course_RequiredSubjects.RequiredSubjects";
                result.SqlParams.Add(model.RequiredSubjects);
            }
            if (model.StudentNumberLimit != 0)
            {
                commandWhereList.Add("StudentNumberLimit = @StudentNumberLimit");
                result.SqlParams.Add(model.StudentNumberLimit);
            }
            if (model.RequiredStudentNumber != 0)
            {
                commandWhereList.Add("RequiredStudentNumber = @RequiredStudentNumber");
                result.SqlParams.Add(model.RequiredSubjects);
            }
            if (commandWhereList.Any())
            {
                commandWhere = (" WHERE " + string.Join(Environment.NewLine + " AND ", commandWhereList));
            }
            if (leftJoinCommandTime.Any())
            {
                leftJoinCommandWhere.AppendLine(" LEFT JOIN Course_Time ON Course.CourseID = Course_Time.CourseID " + string.Join(Environment.NewLine + " AND ", leftJoinCommandTime));
            }
            #endregion

            if (result.SqlParams.Any())
            {
                commandText.AppendLine(string.Join(Environment.NewLine,
                    @"
					SELECT CourseID
                         , CourseTitle
						 , CourseIntroduction
						 , Week
                         , Time
						 , ProfessorName
						 , RequiredSubjects
						 , StudentNumberLimit"
                             , requiredSubjects
                             , commandTime.ToString()
                             , " FROM Course "
                             , leftJoinCommandWhere.ToString()
                             , commandWhere));
            }
            else
            {
                commandText.AppendLine(string.Join(Environment.NewLine,
                                  @"SELECT CourseTitle
						             , CourseIntroduction
						             , Week
                                     , Time
						             , ProfessorName
						             , RequiredSubjects
						             , StudentNumberLimit
                                     , Course_Time.Week
                                     , Course_Time.Time
                                     , Course_RequiredSubjects.RequiredSubjects
                                  FROM Course
                             LEFT JOIN Course_Time
                                    ON Course.CourseID = Course_Time.CourseID
                             LEFT JOIN Course_RequiredSubjects
                                    ON Course.CourseID = Course_RequiredSubjects.CourseID"));
            }

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
