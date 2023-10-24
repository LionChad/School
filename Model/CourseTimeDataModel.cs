namespace Project.Model
{
    #region 
    public class CourseTimeDataModel
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