SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [dbo].[USP_S_GAME]
AS
BEGIN
    DECLARE @LOGSOURCE AS NVARCHAR(100);
    SET @LOGSOURCE = N'[CORE].[dbo].[USP_S_GAME]';

    EXEC META.dbo.USP_WRITELOG N'Start to load [CORE].[dbo].[S_GAME]',
                               @LOGSOURCE,
                               N'N';

    BEGIN TRY
        BEGIN TRAN;
		
		INSERT INTO CORE.DBO.[S_GAME]
		(
			[HK],
			[HF],
			[HD],
			[LOAD_DTS],
			[LOAD_END_DTS],
			[RECORD_SOURCE],
			[CDC_OPERATION_CODE],
			[ID],
			[Game name],
			[PRICE]
		)
		SELECT main.*
		FROM
		(
			SELECT 
				CONVERT(CHAR(32), HASHBYTES('MD5', ISNULL(TRIM(CONVERT(NVARCHAR(50), [ID])+N'@|@'), N'')), 2) AS HK,
				
				CONVERT(CHAR(32),HASHBYTES('MD5',
					+ ISNULL(TRIM(CONVERT(NVARCHAR(255), [ID])), N'') +N'@|@'
					+ ISNULL(TRIM(CONVERT(NVARCHAR(255), [Game name])), N'') +N'@|@'
					+ ISNULL(TRIM(CONVERT(NVARCHAR(255), [PRICE])), N'') +N'@|@'
					),2) AS HF,
				CONVERT(CHAR(32),HASHBYTES('MD5',
					+ ISNULL(TRIM(CONVERT(NVARCHAR(255), [Game name])), N'') +N'@|@'
					+ ISNULL(TRIM(CONVERT(NVARCHAR(255), [PRICE])), N'') +N'@|@'
					),2) AS HD,
				[LOAD_DTS],
				'9999-12-31' [LOAD_END_DTS],
				[RECORD_SOURCE],
				[CDC_OPERATION_CODE],
				[ID],
				[Game name],
				[PRICE]
			FROM
			(
				SELECT [LOAD_DTS],
					[RECORD_SOURCE],
					[CDC_OPERATION_CODE],
					[HD],
					[ID],
					[Game name],
					[PRICE],
					CASE
						WHEN LAG(HD, 1, 'N/A') OVER (PARTITION BY [ID] ORDER BY [LOAD_DTS] ASC, [CDC_OPERATION_CODE] DESC ) = HD THEN 'Same'
						ELSE 'Different'
					END AS [VALUE_CHANGE_INDICATOR],
					CASE
						WHEN LAG([CDC_OPERATION_CODE], 1, '') OVER (PARTITION BY [ID] ORDER BY [LOAD_DTS] ASC, [CDC_OPERATION_CODE] ASC) = [CDC_OPERATION_CODE] THEN 'Same'
						ELSE 'Different'
					END AS [CDC_CHANGE_INDICATOR],
					CASE
						WHEN LEAD([LOAD_DTS], 1, '9999-12-31') OVER (PARTITION BY [ID] ORDER BY [LOAD_DTS] ASC, [CDC_OPERATION_CODE] ASC) = [LOAD_DTS] THEN 'Same'
						ELSE 'Different'
					END AS [TIME_CHANGE_INDICATOR]
				FROM
				(
					SELECT [LOAD_DTS],
							[RECORD_SOURCE],
							[CDC_OPERATION_CODE],
							[ID],
							[Game name],
							[PRICE],
							CONVERT(CHAR(32),HASHBYTES('MD5',
									+ ISNULL(TRIM(CONVERT(NVARCHAR(255), [Game name])), N'') +N'@|@'
									+ ISNULL(TRIM(CONVERT(NVARCHAR(255), [PRICE])), N'') +N'@|@'
							),2) AS HD
					FROM [STAGE].[gs].[GAMELIST_LOG]
				) sub
			) combined_value
			WHERE ( [VALUE_CHANGE_INDICATOR] = 'Different' AND [CDC_OPERATION_CODE] IN ( 'I', 'C' ) )
				OR ( [CDC_CHANGE_INDICATOR] = 'Different' AND [TIME_CHANGE_INDICATOR] = 'Different' )
		) main
			LEFT OUTER JOIN [CORE].dbo.[S_GAME] sat
				ON sat.HK = main.HK AND sat.[LOAD_DTS] = main.[LOAD_DTS]
		WHERE sat.HK IS NULL;
		
		
		EXEC META.dbo.USP_WRITELOG N'Finish to load [CORE].[dbo].[S_GAME]',
                                   @LOGSOURCE,
                                   N'N';
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ERROR_MESSAGE AS NVARCHAR(4000);
        SET @ERROR_MESSAGE = N'Failed to load [CORE].[dbo].[S_GAME]' + ISNULL(ERROR_MESSAGE(), '');
        EXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';
    END CATCH;
END;
GO
