namespace Project.Model
{
    #region 
    public class CourseDataModel
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
        /// 課程簡介
        /// </summary>
        public string CourseIntroduction { get; set; }
        /// <summary>
        /// 星期幾
        /// </summary>
        public string Week { get; set; }
        /// <summary>
        /// HHmm-HHmm
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 授課講師
        /// </summary>
        public string ProfessorName { get; set; }
        /// <summary>
        /// 那些科系必修
        /// </summary>
        public string RequiredSubjects { get; set; }
        /// <summary>
        /// 課程學生人數上限
        /// </summary>
        public int StudentNumberLimit { get; set; }
        /// <summary>
        /// 開課所需學生人數
        /// </summary>
        public int RequiredStudentNumber { get; set; }
    }

    /// <summary>
    /// 上課時間([Day of the week]HHmm-HHmm)//放棄，懶惰寫自動映射，其二草稿還不必要
    /// </summary>
    public class ClassTime
    {
        /// <summary>
        /// 星期幾
        /// </summary>
        public string Week { get; set; }
        /// <summary>
        /// HHmm-HHmm
        /// </summary>
        public string Time { get; set; }
    }
    #endregion
}