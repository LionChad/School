using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Project.Util
{
    public class ReturnData
    {
        #region Enum
        public enum EnumReturnMessage
        {
            [Description("成功")]
            Success = 0,
            [Description("必輸欄位輸入不完全")]
            InputNotComplete = 1,
            [Description("會員驗證失敗")]
            MemberVertifyFail = 1000,
            [Description("授權驗證失敗")]
            AuthenticationVertifyFail = 2000,
            [Description("失敗")]
            Fail = 9998,
            [Description("SchoolAPI系統異常")]
            SystemError = 9999
        }
        #endregion
    }
}