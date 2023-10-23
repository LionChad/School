using System.ComponentModel;
using System.Reflection;

namespace Project.Util
{
    public static class EnumExtension
    {
        #region GetEnumDesc
        ///https://stoner609.github.io/2017/08/15/20170815_net_enum/
        /// <summary>
        ///取得列舉的敘述
        /// </summary>
        /// <param name="value">列舉物件</param>
        /// <returns>列舉的敘述或名稱</returns>
        public static string GetEnumDesc(this Enum value)
        {
            DescriptionAttribute[] attributes = null;
            string result = string.Empty;

            if (value != null)
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                result = attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }
            return result;
        }
        #endregion
    }
}