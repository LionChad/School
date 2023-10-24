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
            // �w�� (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel();
            
            string courseID = "�ҵ{ID",
                courseTitle = "�ҵ{�W��",
                week = "�P���X",
                time = "HHmm-HHmm",
                professorName = "�½����v",
                requiredSubjects = "���׬�t";
            // ��� (Act)
            var response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            requiredSubjects = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            requiredSubjects = "���׬�t";
            professorName = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            professorName = "�½����v";
            time = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            time = "HHmm-HHmm";
            week = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            week = "�P���X";
            courseTitle = null;
            response = controller.Get(courseID, courseTitle, week, time, professorName, requiredSubjects);
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseTitle = "�ҵ{�W��";
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
            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);
        }

        [TestMethod]
        public void Test_InsertCourse()
        {
            // �w�� (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel()
            {
                CourseID= "�ҵ{ID",
                CourseTitle = "�ҵ{�W��",
                CourseIntroduction = "�ҵ{²��",
                ProfessorName = "�½����v",
            };

            // ��� (Act)
            var response = controller.POST(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseDataModel = new CourseDataModel()
            {
                CourseID = null,
                CourseTitle = "�ҵ{�W��",
                CourseIntroduction = "�ҵ{²��",
                ProfessorName = "�½����v",
            };

            // ��� (Act)
            response = controller.POST(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
            courseDataModel = new CourseDataModel()
            {
                CourseID = "�ҵ{ID",
                CourseTitle = null,
                CourseIntroduction = "�ҵ{²��",
                ProfessorName = "�½����v",
            };

            // ��� (Act)
            response = controller.POST(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
            courseDataModel = new CourseDataModel()
            {
                CourseID = "�ҵ{ID",
                CourseTitle = "�ҵ{�W��",
                CourseIntroduction = null,
                ProfessorName = "�½����v",
            };

            // ��� (Act)
            response = controller.POST(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);
            courseDataModel = new CourseDataModel()
            {
                CourseID = "�ҵ{ID",
                CourseTitle = "�ҵ{�W��",
                CourseIntroduction = "�ҵ{²��",
                ProfessorName = null,
            };

            // ��� (Act)
            response = controller.POST(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
            
            SetPropertiesToNull(courseDataModel);

            // ��� (Act)
            response = controller.POST(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
        }

        [TestMethod]
        public void Test_UpdateCourse()
        {
            // �w�� (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel()
            {
                CourseID = "�ҵ{ID",
                CourseTitle = "�ҵ{�W��",
                CourseIntroduction = "�ҵ{²��",
                ProfessorName = "�½����v",
            };

            // ��� (Act)
            var response = controller.PATCH(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseDataModel = new CourseDataModel()
            {
                CourseID = null,
                CourseTitle = "�ҵ{�W��",
                CourseIntroduction = "�ҵ{²��",
                ProfessorName = "�½����v",
            };

            // ��� (Act)
            response = controller.PATCH(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
            courseDataModel = new CourseDataModel()
            {
                CourseID = "�ҵ{ID",
                CourseTitle = null,
                CourseIntroduction = "�ҵ{²��",
                ProfessorName = "�½����v",
            };

            // ��� (Act)
            response = controller.PATCH(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseDataModel = new CourseDataModel()
            {
                CourseID = "�ҵ{ID",
                CourseTitle = "�ҵ{�W��",
                CourseIntroduction = null,
                ProfessorName = "�½����v",
            };

            // ��� (Act)
            response = controller.PATCH(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);
            
            courseDataModel = new CourseDataModel()
            {
                CourseID = "�ҵ{ID",
                CourseTitle = "�ҵ{�W��",
                CourseIntroduction = "�ҵ{²��",
                ProfessorName = null,
            };

            // ��� (Act)
            response = controller.PATCH(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            SetPropertiesToNull(courseDataModel);

            // ��� (Act)
            response = controller.PATCH(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);
        }

        [TestMethod]
        public void Test_DeleteCourse()
        {
            // �w�� (Arrange)
            var controller = new CourseController();
            var courseDataModel = new CourseDataModel()
            {
                CourseID = "�ҵ{ID"
            };

            // ��� (Act)
            var response = controller.DELETE(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.Success.GetEnumDesc(), response.Msg);

            courseDataModel = new CourseDataModel()
            {
                CourseID = null,
            };

            // ��� (Act)
            response = controller.DELETE(courseDataModel);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual(ReturnData.EnumReturnMessage.InputNotComplete.GetEnumDesc(), response.Msg);

            SetPropertiesToNull(courseDataModel);

            // ��� (Act)
            response = controller.DELETE(courseDataModel);

            // �_�� (Assert)
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