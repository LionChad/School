using Project.Controllers;
using Project.Model;

namespace Project.Tests
{
    [TestClass]
    public class CourseControllerTests
    {
        [TestMethod]
        public void Test_FullSearch_Success()
        {
            // 安排 (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel();

            // 行動 (Act)
            var response = controller.Get(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
        }
        public void Test_LimitSearch_Success()
        {
            // 安排 (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel()
            {
                CourseTitle = "測試",
                CourseIntroduction = "測試",
                Week = "測試",
                Time = "測試",
                ProfessorName = "測試",
                RequiredSubjects = "測試",
                StudentNumberLimit = 1,
                RequiredStudentNumber = 2,
                IsNotAuditCourse = true,
            };

            // 行動 (Act)
            var response = controller.Post(new CourseDataModel());

            // 斷言 (Assert)
            Assert.IsNotNull(response);
        }

        public static void SetPropertiesToNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                if (property.CanWrite && property.GetSetMethod() != null)
                {
                    Type propertyType = property.PropertyType;

                    if (propertyType.IsValueType)
                    {
                        if (Nullable.GetUnderlyingType(propertyType) != null)
                        {
                            // Value type is nullable; set to null
                            property.SetValue(obj, null);
                        }
                        // Handle other value types as needed
                    }
                    else
                    {
                        // Reference type; set to null
                        property.SetValue(obj, null);
                    }
                }
            }
        }

    }
}