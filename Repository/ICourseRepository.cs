using Project.Model;

namespace Project.Repository
{
    public interface ICourseRepository
    {
        List<CourseDataModel> GetCourseList(CourseDataModel model);
        // 其他操作方法
        // ...
    }
}