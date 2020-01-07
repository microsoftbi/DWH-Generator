SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[USP_H_CUSTOMER]
AS
BEGIN
    DECLARE @LOGSOURCE AS NVARCHAR(100);
    SET @LOGSOURCE = N'[CORE].[dbo].[USP_H_CUSTOMER]';

    EXEC META.dbo.USP_WRITELOG N'Start to load [CORE].[dbo].[H_CUSTOMER]',
                               @LOGSOURCE,
                               N'N';

    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO [H_CUSTOMER]
        (
            [LOAD_DTS],
            [LOAD_END_DTS],
            [CDC_OPERATION_CODE],
            [RECORD_SOURCE],
            [SESSION_DTS],
			[HK],
            [CustomerID]
        )
        SELECT PSA.[LOAD_DTS],
               PSA.[LOAD_END_DTS],
               PSA.[CDC_OPERATION_CODE],
               PSA.[RECORD_SOURCE],
               PSA.[SESSION_DTS],
			   PSA.[HK],
			   PSA.[CustomerID]
        FROM
        (
            SELECT LOAD_DTS,
                   '9999-12-31' AS [LOAD_END_DTS],
                   CDC_OPERATION_CODE,
                   RECORD_SOURCE,
                   NULL AS [SESSION_DTS],
                   CONVERT(CHAR(32), HASHBYTES('MD5', ISNULL(TRIM(CONVERT(NVARCHAR(50), [CustomerID])+N'@|@'), N'')), 2) AS HK,
                   [CustomerID] AS [CustomerID],
                   ROW_NUMBER() OVER (PARTITION BY ISNULL(TRIM(CONVERT(NVARCHAR(50), [CustomerID])), N'') ORDER BY LOAD_DTS ASC) AS ROW_NR
            FROM [STAGE].[gs].[CUSTOMER_LOG]
        ) PSA
            LEFT JOIN [CORE].dbo.[H_CUSTOMER] [TARGET]
                ON ISNULL(TRIM(CONVERT(NVARCHAR(50), PSA.[CustomerID])), N'') = ISNULL(TRIM(CONVERT(NVARCHAR(50), [TARGET].[CustomerID])), N'')
        WHERE [TARGET].HK IS NULL
              AND ROW_NR = 1;


        EXEC META.dbo.USP_WRITELOG N'Finish to load [CORE].[dbo].[H_CUSTOMER]',
                                   @LOGSOURCE,
                                   N'N';
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ERROR_MESSAGE AS NVARCHAR(4000);
        SET @ERROR_MESSAGE = N'Failed to load [CORE].[dbo].[H_CUSTOMER]' + ISNULL(ERROR_MESSAGE(), '');
        EXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';
    END CATCH;
END;
GO
