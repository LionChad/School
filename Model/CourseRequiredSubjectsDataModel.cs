namespace Project.Model
{
    #region 
    public class CourseRequiredSubjectsDataModel
    {
        /// <summary>
        /// 課程ID
        /// </summary>
        public string CourseID { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string CourseTitle { get; set; }
        /// <summary>
        /// 那些科系必修
        /// </summary>
        public string RequiredSubjects { get; set; }
    }
    #endregion
}