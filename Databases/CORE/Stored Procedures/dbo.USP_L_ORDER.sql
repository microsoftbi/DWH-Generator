SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [dbo].[USP_L_ORDER]
AS
BEGIN
    DECLARE @LOGSOURCE AS NVARCHAR(100);
    SET @LOGSOURCE = N'[CORE].[dbo].[USP_L_ORDER]';

    EXEC META.dbo.USP_WRITELOG N'Start to load [CORE].[dbo].[L_ORDER]',
                               @LOGSOURCE,
                               N'N';

    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO CORE.DBO.[L_ORDER]
        (
            [LOAD_DTS],
            [LOAD_END_DTS],
            [CDC_OPERATION_CODE],
            [RECORD_SOURCE],
            [SESSION_DTS],
			[HK],
			[GAMEID],
            [GAMEID_HK],
			[CUSTOMERID],
            [CUSTOMERID_HK]
        )
        SELECT PSA.[LOAD_DTS],
               PSA.[LOAD_END_DTS],
               PSA.[CDC_OPERATION_CODE],
               PSA.[RECORD_SOURCE],
               PSA.[SESSION_DTS],
			   PSA.[HK],
			   PSA.[GAMEID],
			   PSA.[GAMEID_HK],
			   PSA.[CUSTOMERID],
			   PSA.[CUSTOMERID_HK]
        FROM
        (
            SELECT LOAD_DTS,
                   '9999-12-31' AS [LOAD_END_DTS],
                   CDC_OPERATION_CODE,
                   RECORD_SOURCE,
                   NULL AS [SESSION_DTS],
                   CONVERT(CHAR(32), HASHBYTES('MD5', ISNULL(TRIM(CONVERT(NVARCHAR(50), [GAMEID])+N'@|@'), N'') + ISNULL(TRIM(CONVERT(NVARCHAR(50), [CUSTOMERID])+N'@|@'), N'')), 2) AS HK,
				   CONVERT(CHAR(32), HASHBYTES('MD5', ISNULL(TRIM(CONVERT(NVARCHAR(50), [GAMEID])+N'@|@'), N'')), 2) AS GAMEID_HK,
				   [GAMEID] AS [GAMEID],
				   CONVERT(CHAR(32), HASHBYTES('MD5', ISNULL(TRIM(CONVERT(NVARCHAR(50), [CUSTOMERID])+N'@|@'), N'')), 2) AS CUSTOMERID_HK,
				   [CUSTOMERID] AS [CUSTOMERID],
                   ROW_NUMBER() OVER (PARTITION BY ISNULL(TRIM(CONVERT(NVARCHAR(50), [GAMEID])), N'') + ISNULL(TRIM(CONVERT(NVARCHAR(50), [CUSTOMERID])), N'') ORDER BY LOAD_DTS ASC) AS ROW_NR
            FROM [STAGE].[gs].[ORDER_LOG]
        ) PSA
            LEFT JOIN [CORE].dbo.[L_ORDER] [TARGET]
                ON ISNULL(TRIM(CONVERT(NVARCHAR(50), PSA.[GAMEID])), N'') + ISNULL(TRIM(CONVERT(NVARCHAR(50), PSA.[CUSTOMERID])), N'') = ISNULL(TRIM(CONVERT(NVARCHAR(50), [TARGET].[GAMEID])), N'') + ISNULL(TRIM(CONVERT(NVARCHAR(50), [TARGET].[CUSTOMERID])), N'')
        WHERE [TARGET].HK IS NULL
              AND ROW_NR = 1;


        EXEC META.dbo.USP_WRITELOG N'Finish to load [CORE].[dbo].[L_ORDER]',
                                   @LOGSOURCE,
                                   N'N';
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ERROR_MESSAGE AS NVARCHAR(4000);
        SET @ERROR_MESSAGE = N'Failed to load [CORE].[dbo].[L_ORDER]' + ISNULL(ERROR_MESSAGE(), '');
        EXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';
    END CATCH;
END;
GO
