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
            // �w�� (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel();

            // ��� (Act)
            var response = controller.Get(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
        }
        public void Test_LimitSearch_Success()
        {
            // �w�� (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel()
            {
                CourseTitle = "����",
                CourseIntroduction = "����",
                Week = "����",
                Time = "����",
                ProfessorName = "����",
                RequiredSubjects = "����",
                StudentNumberLimit = 1,
                RequiredStudentNumber = 2,
                IsNotAuditCourse = true,
            };

            // ��� (Act)
            var response = controller.Post(new CourseDataModel());

            // �_�� (Assert)
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