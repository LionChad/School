using Project.Model;
using System.Data.SqlClient;

namespace Project.Repository
{
    public partial class CourseRepository
    {
        #region 取得 課程 清單
        /// <summary>
        /// 取得 課程 清單
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<CourseDataModel> GetCourseList(CourseDataModel model)
        {
            var result = new List<CourseDataModel>();
            //using (SqlConnection conn = new SqlConnection("DB連線字串"))
            //{
                try
                {
                    //conn.Open();

                    var getCourseListSql = GetCourseListSql(model);
                    //using (SqlCommand command = new SqlCommand(getCourseListSql.GetSqlString(), conn))
                    //{
                    //    using (SqlDataReader reader = command.ExecuteReader())
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            //...SQL讀取出來
                    //        }
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    //紀錄LOG
                }
            //}
            return result;
        }
        #endregion

        #region 新增 課程 明細
        /// <summary>
        /// 新增 課程 明細
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertCourse(CourseDataModel model)
        {
            bool isSuccess = false;

            //using (SqlConnection conn = new SqlConnection("DB連線字串"))
            //{
                try
                {
                    //conn.Open();

                    var getCourseListSql = InsertCourseSql(model);
                    isSuccess = true;
                    //using (SqlCommand command = new SqlCommand(getCourseListSql.GetSqlString(), conn))
                    //{
                    //    using (SqlDataReader reader = command.ExecuteReader())
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            isSuccess = true;
                    //        }
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    //紀錄LOG
                }
            //}
            return isSuccess;
        }
        #endregion

        #region 更新 課程 明細
        /// <summary>
        /// 更新 課程 明細
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCourse(CourseDataModel model)
        {
            bool isSuccess = false;

            //using (SqlConnection conn = new SqlConnection("DB連線字串"))
            //{
                try
                {
                    //conn.Open();

                    var getCourseListSql = UpdateCourseSql(model);
                    isSuccess = true;

                    //using (SqlCommand command = new SqlCommand(getCourseListSql.GetSqlString(), conn))
                    //{
                    //    using (SqlDataReader reader = command.ExecuteReader())
                    //    {
                    //        isSuccess = true;
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    //紀錄LOG
                }
            //}
            return isSuccess;
        }
        #endregion

        #region 刪除 課程 明細
        /// <summary>
        /// 刪除 課程 明細
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteCourse(CourseDataModel model)
        {
            bool isSuccess = false;

            //using (SqlConnection conn = new SqlConnection("DB連線字串"))
            //{
                try
                {
                    //conn.Open();

                    var getCourseListSql = DeleteCourseSql(model);
                    isSuccess = true;

                    //using (SqlCommand command = new SqlCommand(getCourseListSql.GetSqlString(), conn))
                    //{
                    //    using (SqlDataReader reader = command.ExecuteReader())
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            isSuccess = true;
                    //        }
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    //紀錄LOG
                }
            //}
            return isSuccess;
        }
        #endregion
    }
}