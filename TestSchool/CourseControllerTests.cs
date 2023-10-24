using Project.Controllers;
using Project.Model;
using Project.Util;

namespace Project.Tests
{
    [TestClass]
    public class CourseControllerTests
    {
        [TestMethod]
        public void Test_GetCourseList()
        {
            // 安排 (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel();
            
            string courseID = "課程ID",
                courseTitle = "課程名稱",
                week = "星期幾",
                time = "HHmm-HHmm",
                professorName = "授課講師",
                requiredSubjects = "必修科系";
            // 行動 (Act)
            var response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            requiredSubjects = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            requiredSubjects = "必修科系";
            professorName = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            professorName = "授課講師";
            time = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            time = "HHmm-HHmm";
            week = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            week = "星期幾";
            courseTitle = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseTitle = "課程名稱";
            courseID = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseID = null;
            courseTitle = null;
            week = null;
            time = null;
            professorName = null;
            requiredSubjects = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);
        }

        [TestMethod]
        public void Test_InsertCourse()
        {
            // 安排 (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel()
            {
                CourseID= "課程ID",
                CourseTitle = "課程名稱",
                CourseIntroduction = "課程簡介",
                ProfessorName = "授課講師",
            };

            // 行動 (Act)
            var response = controller.POST(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseDataModel = new CourseDataModel()
            {
                CourseID = null,
                CourseTitle = "課程名稱",
                CourseIntroduction = "課程簡介",
                ProfessorName = "授課講師",
            };

            // 行動 (Act)
            response = controller.POST(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
            courseDataModel = new CourseDataModel()
            {
                CourseID = "課程ID",
                CourseTitle = null,
                CourseIntroduction = "課程簡介",
                ProfessorName = "授課講師",
            };

            // 行動 (Act)
            response = controller.POST(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
            courseDataModel = new CourseDataModel()
            {
                CourseID = "課程ID",
                CourseTitle = "課程名稱",
                CourseIntroduction = null,
                ProfessorName = "授課講師",
            };

            // 行動 (Act)
            response = controller.POST(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);
            courseDataModel = new CourseDataModel()
            {
                CourseID = "課程ID",
                CourseTitle = "課程名稱",
                CourseIntroduction = "課程簡介",
                ProfessorName = null,
            };

            // 行動 (Act)
            response = controller.POST(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
            
            SetPropertiesToNull(courseDataModel);

            // 行動 (Act)
            response = controller.POST(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
        }

        [TestMethod]
        public void Test_UpdateCourse()
        {
            // 安排 (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel()
            {
                CourseID = "課程ID",
                CourseTitle = "課程名稱",
                CourseIntroduction = "課程簡介",
                ProfessorName = "授課講師",
            };

            // 行動 (Act)
            var response = controller.PATCH(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseDataModel = new CourseDataModel()
            {
                CourseID = null,
                CourseTitle = "課程名稱",
                CourseIntroduction = "課程簡介",
                ProfessorName = "授課講師",
            };

            // 行動 (Act)
            response = controller.PATCH(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
            courseDataModel = new CourseDataModel()
            {
                CourseID = "課程ID",
                CourseTitle = null,
                CourseIntroduction = "課程簡介",
                ProfessorName = "授課講師",
            };

            // 行動 (Act)
            response = controller.PATCH(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseDataModel = new CourseDataModel()
            {
                CourseID = "課程ID",
                CourseTitle = "課程名稱",
                CourseIntroduction = null,
                ProfessorName = "授課講師",
            };

            // 行動 (Act)
            response = controller.PATCH(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);
            
            courseDataModel = new CourseDataModel()
            {
                CourseID = "課程ID",
                CourseTitle = "課程名稱",
                CourseIntroduction = "課程簡介",
                ProfessorName = null,
            };

            // 行動 (Act)
            response = controller.PATCH(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            SetPropertiesToNull(courseDataModel);

            // 行動 (Act)
            response = controller.PATCH(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
        }

        [TestMethod]
        public void Test_DeleteCourse()
        {
            // 安排 (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel()
            {
                CourseID = "課程ID"
            };

            // 行動 (Act)
            var response = controller.DELETE(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseDataModel = new CourseDataModel()
            {
                CourseID = null,
            };

            // 行動 (Act)
            response = controller.DELETE(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);

            SetPropertiesToNull(courseDataModel);

            // 行動 (Act)
            response = controller.DELETE(courseDataModel);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
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