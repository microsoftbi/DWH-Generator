SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[USP_H_GAME]
AS
BEGIN
    DECLARE @LOGSOURCE AS NVARCHAR(100);
    SET @LOGSOURCE = N'[CORE].[dbo].[USP_H_GAME]';

    EXEC META.dbo.USP_WRITELOG N'Start to load [CORE].[dbo].[H_GAME]',
                               @LOGSOURCE,
                               N'N';

    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO [H_GAME]
        (
            [LOAD_DTS],
            [LOAD_END_DTS],
            [CDC_OPERATION_CODE],
            [RECORD_SOURCE],
            [SESSION_DTS],
			[HK],
            [GAME_ID]
        )
        SELECT PSA.[LOAD_DTS],
               PSA.[LOAD_END_DTS],
               PSA.[CDC_OPERATION_CODE],
               PSA.[RECORD_SOURCE],
               PSA.[SESSION_DTS],
			   PSA.[HK],
			   PSA.[GAME_ID]
        FROM
        (
            SELECT LOAD_DTS,
                   '9999-12-31' AS [LOAD_END_DTS],
                   CDC_OPERATION_CODE,
                   RECORD_SOURCE,
                   NULL AS [SESSION_DTS],
                   CONVERT(CHAR(32), HASHBYTES('MD5', ISNULL(TRIM(CONVERT(NVARCHAR(50), [ID])+N'@|@'), N'')), 2) AS HK,
                   [ID] AS [GAME_ID],
                   ROW_NUMBER() OVER (PARTITION BY ISNULL(TRIM(CONVERT(NVARCHAR(50), [ID])), N'') ORDER BY LOAD_DTS ASC) AS ROW_NR
            FROM [STAGE].[gs].[GAMELIST_LOG]
        ) PSA
            LEFT JOIN [CORE].dbo.[H_GAME] [TARGET]
                ON ISNULL(TRIM(CONVERT(NVARCHAR(50), PSA.[GAME_ID])), N'') = ISNULL(TRIM(CONVERT(NVARCHAR(50), [TARGET].[GAME_ID])), N'')
        WHERE [TARGET].HK IS NULL
              AND ROW_NR = 1;


        EXEC META.dbo.USP_WRITELOG N'Finish to load [CORE].[dbo].[H_GAME]',
                                   @LOGSOURCE,
                                   N'N';
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ERROR_MESSAGE AS NVARCHAR(4000);
        SET @ERROR_MESSAGE = N'Failed to load [CORE].[dbo].[H_GAME]' + ISNULL(ERROR_MESSAGE(), '');
        EXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';
    END CATCH;
END;
GO
