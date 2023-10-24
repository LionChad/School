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
            
            if (!string.IsNullOrEmpty(model.CourseID))
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
                if (model.Week == string.Empty)
                {
                    commandTime.AppendLine(", Course_Time.Week");
                }
                else
                {
                    leftJoinCommandTime.Add("Course_Time.Week = @Week");
                    commandTime.AppendLine(", Course_Time.Week");
                    result.SqlParams.Add(model.Week);
                }
            }
            if (model.Time != null)
            {
                if (model.Week == string.Empty)
                {
                    commandTime.AppendLine(", Course_Time.Time");
                }
                else
                {
                    leftJoinCommandTime.Add("Course_Time.Time = @Time");
                    commandTime.AppendLine(", Course_Time.Time");
                    result.SqlParams.Add(model.Time);
                }
            }
            if (model.ProfessorName != null)
            {
                commandWhereList.Add("ProfessorName = @ProfessorName");
                result.SqlParams.Add(model.ProfessorName);
            }
            if (model.RequiredSubjects != null)
            {
                if (model.Week == string.Empty)
                {
                    leftJoinCommandWhere.AppendLine(" LEFT JOIN Course_RequiredSubjects ON Course.CourseID = Course_RequiredSubjects.CourseID ");
                    requiredSubjects = ", Course_RequiredSubjects.RequiredSubjects";
                }
                else
                {
                    leftJoinCommandWhere.AppendLine(" LEFT JOIN Course_RequiredSubjects ON Course.CourseID = Course_RequiredSubjects.CourseID AND Course_RequiredSubjects.RequiredSubjects = @RequiredSubjects");
                    requiredSubjects = ", Course_RequiredSubjects.RequiredSubjects";
                    result.SqlParams.Add(model.RequiredSubjects);
                }
            }
            if (commandWhereList.Any())
            {
                commandWhere = (" WHERE " + string.Join(Environment.NewLine + " AND ", commandWhereList));
            }
            if (leftJoinCommandTime.Any())
            {
                leftJoinCommandWhere.AppendLine(" LEFT JOIN Course_Time ON Course.CourseID = Course_Time.CourseID AND " + string.Join(Environment.NewLine + " AND ", leftJoinCommandTime));
            }
            else if (commandTime.Length > 0)
            {
                leftJoinCommandWhere.AppendLine(" LEFT JOIN Course_Time ON Course.CourseID = Course_Time.CourseID ");
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
						 , RequiredSubjects"
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
						             , ProfessorName
						             , RequiredSubjects
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
            StringBuilder commandText = new StringBuilder();
            var result = new RepositoryModel();

            #region WHERE
            #endregion

            commandText.AppendLine(string.Join(Environment.NewLine,
                @"
                INSERT INTO Course ( CourseID
						           , CourseTitle
						           , CourseIntroduction
                                   , ProfessorName
                                   )
                            VALUES ( @CourseID
                                   , @CourseTitle
                                   , @CourseIntroduction
                                   , @ProfessorName
                                   ); 
            "));
            SetTransaction(ref commandText);

            result.SqlString = commandText.ToString();
            result.SqlParams.Add(model.CourseID);
            result.SqlParams.Add(model.CourseTitle);
            result.SqlParams.Add(model.CourseIntroduction);
            result.SqlParams.Add(model.ProfessorName);

            return result;
        }

        private RepositoryModel UpdateCourseSql(CourseDataModel model)
        {
            var result = new RepositoryModel();
            StringBuilder commandText = new StringBuilder();
            List<string> commandSetList = new List<string>();
            string commandSet = string.Empty;

            #region Set
            if (model.CourseTitle != null)
            {
                commandSetList.Add("CourseTitle = @CourseTitle");
                result.SqlParams.Add(model.CourseTitle);
            }
            if (model.CourseIntroduction != null)
            {
                commandSetList.Add("CourseIntroduction = @CourseIntroduction");
                result.SqlParams.Add(model.CourseIntroduction);
            }
            if (model.ProfessorName != null)
            {
                commandSetList.Add("ProfessorName = @ProfessorName");
                result.SqlParams.Add(model.ProfessorName);
            }
            if (commandSetList.Any())
            {
                commandSet = (" SET " + string.Join(Environment.NewLine + " , ", commandSetList));
            }
            #endregion
            commandText.AppendLine(string.Join(Environment.NewLine,
                "UPDATE Course "
                      , commandSet
                      , "WHERE CourseID = @CourseID"));
            result.SqlParams.Add(model.CourseID);
            SetTransaction(ref commandText);
            result.SqlString = commandText.ToString();

            return result;
        }

        private RepositoryModel DeleteCourseSql(CourseDataModel model)
        {
            var result = new RepositoryModel();
            StringBuilder commandText = new StringBuilder();

            commandText.AppendLine(string.Join(Environment.NewLine,
                @"  DELETE FROM Course
                     WHERE CourseID = @CourseID
                    DELETE FROM Course_Time
                     WHERE CourseID = @CourseID
                    DELETE FROM Course_RequiredSubjects
                     WHERE CourseID = @CourseID
                "));

            result.SqlParams.Add(model.CourseID);
            SetTransaction(ref commandText);
            result.SqlString = commandText.ToString();

            return result;
        }
        #endregion
    }

}
