using System.Text;

namespace Project.Util
{
    public class RepositorySqlBase
    {
        protected void SetTransaction(ref StringBuilder commandText)
        {
            commandText = new StringBuilder(string.Join(Environment.NewLine,
                @"
                DECLARE @RESULT CHAR(1) = 'N';
                DECLARE @ERROR_LINE INT;
                DECLARE @ERROR_MESSAGE NVARCHAR(4000);
                  BEGIN TRANSACTION
                    BEGIN TRY",
                            commandText,
                @"
                        SET @RESULT = 'Y';
                            COMMIT;
                    END TRY
                    BEGIN CATCH
                        SET @RESULT = 'N';
                        SET @ERROR_LINE = ERROR_LINE();
                        SET @ERROR_MESSAGE = ERROR_MESSAGE();
                        ROLLBACK TRANSACTION;
                    END CATCH
                SELECT @RESULT AS Result
                     , @ERROR_LINE AS ErrorLine
                     , @ERROR_MESSAGE AS ErrorMessage;"
                ));
        }
    }
}