using Project.Repository;

namespace Project.Model
{
    public class RepositoryModel
    {
        public RepositoryModel()
        {
            SqlString = string.Empty;
            SqlParams = new List<object>();
        }
        /// <summary>
        /// sql字串
        /// </summary>
        public string SqlString { get; set; }
        /// <summary>
        /// sql參數
        /// </summary>
        public List<object> SqlParams { get; set; }

        public string GetSqlString()
        {
            var result = string.Empty;

            try
            {
                var sql = SqlString;
                var sqlParams = SqlParams;
            }
            catch (Exception ex)
            {
                //紀錄LOG
            }

            return result;
        }
    }
}