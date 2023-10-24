namespace Project.Model
{
    #region 
    public class GetCourseListResponse : ResponseModel
    {
        public List<CourseDataModel> Data { get; set; }
    }
    #endregion
}