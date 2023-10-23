using Project.Repository;
using Project.Util;

namespace Project.Model
{
    public class GetCourseModel
    {
        #region 取得課程列表
        /// <summary>
        /// 取得課程列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public GetCourseListResponseModel GetCourseList(CourseDataModel model)
        {
            var result = new GetCourseListResponseModel();

            try
            {
                result.Data = new CourseRepository().GetCourseList(model);

                if (model.CourseID != null &&
                    model.CourseTitle != null &&
                    model.CourseIntroduction != null &&
                    model.Week != null &&
                    model.Time != null &&
                    model.ProfessorName != null &&
                    model.RequiredSubjects != null &&
                    model.StudentNumberLimit != 0 &&
                    model.RequiredStudentNumber != 0)
                {
                    result.Data.Add(new CourseDataModel
                    {
                        CourseTitle = "沒有傳入會是全查，會是所有課程都顯示",
                    });
                    result.Data.Add(new CourseDataModel
                    {
                        CourseTitle = "A課程",
                    });
                    result.Data.Add(new CourseDataModel
                    {
                        CourseTitle = "B課程...",
                    });
                }
                else
                {
                    result.Data.Add(new CourseDataModel
                    {
                        CourseTitle = "有傳入則透過傳入來判斷",
                    });
                    result.Data.Add(model);
                }

                result.Code = (int)ReturnData.EnumReturnMessage.Success;
                result.Msg = ReturnData.EnumReturnMessage.Success.GetEnumDesc();
            }
            catch (Exception ex)
            {
                //紀錄Log
                result.Code = (int)ReturnData.EnumReturnMessage.SystemError;
                result.Msg = ReturnData.EnumReturnMessage.SystemError.GetEnumDesc();
            }

            return result;
        }
        #endregion

        #region 新增課程
        /// <summary>
        /// 新增課程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public EditResponseModel InsertCourse(CourseDataModel model)
        {
            var result = new EditResponseModel();

            try
            {
                if (new CourseRepository().InsertCourse(model))
                {
                    result.Data = true;
                    result.Code = (int)ReturnData.EnumReturnMessage.Success;
                    result.Msg = ReturnData.EnumReturnMessage.Success.GetEnumDesc();
                }
            }
            catch (Exception ex)
            {
                //紀錄Log
                result.Code = (int)ReturnData.EnumReturnMessage.SystemError;
                result.Msg = ReturnData.EnumReturnMessage.SystemError.GetEnumDesc();
            }

            return result;
        }
        #endregion

        #region 更新課程
        /// <summary>
        /// 更新課程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseModel UpdateCourse(CourseDataModel model)
        {
            var response = new ResponseModel();

            try
            {
                response.code = new CourseRepository().UpdateCourse(model);
            }
            catch (Exception ex)
            {
                //紀錄Log
                response.msg = ex.Message;
            }

            return response;
        }
        #endregion

        #region 刪除課程
        /// <summary>
        /// 刪除課程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseModel DeleteCourse(CourseDataModel model)
        {
            var response = new ResponseModel();

            try
            {
                response.code = new CourseRepository().DeleteCourse(model);
            }
            catch (Exception ex)
            {
                //紀錄Log
                response.msg = ex.Message;
            }

            return response;
        }
        #endregion
    }
}