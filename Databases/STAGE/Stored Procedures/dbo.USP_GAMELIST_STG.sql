SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[USP_GAMELIST_STG]
AS
BEGIN
    DECLARE @LOGSOURCE AS NVARCHAR(100);
    SET @LOGSOURCE = N'STAGE.dbo.USP_GAMELIST_STG';

    TRUNCATE TABLE STAGE.dbo.GAMELIST_STG;

    EXEC META.dbo.USP_WRITELOG N'Start to load GAMELIST_STG',
                               @LOGSOURCE,
                               N'N';
    BEGIN TRY
        BEGIN TRAN;
        INSERT INTO GAMELIST_STG
        SELECT ID,
               [Game name],
               [AREA],
               [PRICE],
               CONVERT(
                          CHAR(32),
                          HASHBYTES(
                                       'MD5',
                                       ISNULL(TRIM(CONVERT(NVARCHAR(255), [Game name])), N'') + N'W|D'
                                       + ISNULL(TRIM(CONVERT(NVARCHAR(255), [AREA])), N'') + N'W|D'
                                       + ISNULL(TRIM(CONVERT(NVARCHAR(255), [PRICE])), N'') + N'W|D'
                                   ),
                          2
                      ) AS HD,
               GETDATE() AS [INSERT TIME]
        FROM [STAGE].[dbo].[GAMELIST];
        COMMIT TRAN;

        EXEC META.dbo.USP_WRITELOG N'Finish to load GAMELIST_STG',
                                   @LOGSOURCE,
                                   N'N';

    END TRY
    BEGIN CATCH

        ROLLBACK TRAN;

        DECLARE @ERROR_MESSAGE AS NVARCHAR(4000);
        SET @ERROR_MESSAGE = N'Failed to load GAMELIST_STG' + ISNULL(ERROR_MESSAGE(), '');

        EXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';

    END CATCH;

END;
GO
