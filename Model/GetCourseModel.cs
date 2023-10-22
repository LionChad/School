using Project.Repository;

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
        public List<CourseDataModel> GetCourseList(CourseDataModel model)
        {
            var result = new List<CourseDataModel>();

            try
            {
                result = new CourseRepository().GetCourseList(model);

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
                    result.Add(new CourseDataModel
                    {
                        CourseTitle = "沒有傳入會是全查，會是所有課程都顯示",
                    });
                    result.Add(new CourseDataModel
                    {
                        CourseTitle = "A課程",
                    });
                    result.Add(new CourseDataModel
                    {
                        CourseTitle = "B課程...",
                    });
                }
                else
                {
                    result.Add(new CourseDataModel
                    {
                        CourseTitle = "有傳入則透過傳入來判斷",
                    });
                    result.Add(model);
                }
            }
            catch(Exception ex)
            {
                //紀錄LOG
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
        public ResponseModel InsertCourse(CourseDataModel model)
        {
            var response = new ResponseModel();

            try
            {
                response.isSuccess = new CourseRepository().InsertCourse(model);
            }
            catch (Exception ex)
            {
                //紀錄Log
                response.msg = ex.Message;
            }

            return response;
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
                response.isSuccess = new CourseRepository().UpdateCourse(model);
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
                response.isSuccess = new CourseRepository().DeleteCourse(model);
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