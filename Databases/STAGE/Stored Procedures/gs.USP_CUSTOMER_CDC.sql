SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [gs].[USP_CUSTOMER_CDC]
AS
	BEGIN
	DECLARE @LOGSOURCE AS NVARCHAR(100);
	SET @LOGSOURCE = N'[STAGE].[gs].[USP_CUSTOMER_CDC]';
	
	EXEC META.dbo.USP_WRITELOG N'Start to load [STAGE].[gs].[CUSTOMER_CDC]', @LOGSOURCE, N'N';
	
	TRUNCATE TABLE [gs].[CUSTOMER_CDC];
	
	BEGIN TRY
		BEGIN TRAN;
			INSERT INTO [gs].[CUSTOMER_CDC]
			(
				[LOAD_DTS],
				[LOAD_DTS_BATCH],
				[SEQUENCE_NO],
				[CDC_OPERATION_CODE],
				[RECORD_SOURCE],
				[FULLY_QUALIFIED_FILE_NAME],
				[INSERT_DTS],
				[UPDATE_DTS],
				[EXPORT_DTS],
				[FILE_TRANSFER_DTS],
				[SESSION_DTS],
				[SOURCE_SLICE_DTS],
				[LOAD_TYPE],
				[HK],
				[HD],
				[HF],
				[CustomerID],
				[CustomerName],
				[Birth],
				[Gender],
				[Address]
			)
			SELECT Mta.LOAD_DTS,
				IIF(Mta.SOURCE_ENTITY = 'HDA', MAX_LTS.MAX_LOAD_DTS_BATCH, Mta.LOAD_DTS_BATCH) LOAD_DTS_BATCH,
				IIF(Mta.SOURCE_ENTITY = 'HDA', 0, Mta.SEQUENCE_NO) SEQUENCE_NO,
				CASE
					WHEN Mta.LEAD_HF IS NULL
							AND Mta.SOURCE_ENTITY = 'HDA'
							AND MAX_LTS.LOAD_TYPE = 'FULL' THEN
				'D'
					WHEN Mta.LAG_HF IS NULL
							AND Mta.SOURCE_ENTITY = 'CDC' THEN
				'I'
					WHEN Mta.LAG_HF <> HF
							AND NOT Mta.LAG_HF IS NULL
							AND Mta.SOURCE_ENTITY = 'CDC' THEN
				'U'
					ELSE
				''
				END [CDC_OPERATION_CODE],
				Mta.[RECORD_SOURCE],
				Mta.[FULLY_QUALIFIED_FILE_NAME],
				Mta.[INSERT_DTS],
				Mta.[UPDATE_DTS],
				Mta.[EXPORT_DTS],
				Mta.[FILE_TRANSFER_DTS],
				Mta.[SESSION_DTS],
				Mta.[SOURCE_SLICE_DTS],
				Mta.[LOAD_TYPE],
				Mta.[HK],
				Mta.[HD],
				Mta.[HF],
				[CustomerID],
				[CustomerName],
				[Birth],
				[Gender],
				[Address]
			FROM
			(
				SELECT LAG(HF) OVER (PARTITION BY HK ORDER BY LOAD_DTS_BATCH, RNK, SEQUENCE_NO) AS LAG_HF,
					LEAD(HF) OVER (PARTITION BY HK ORDER BY LOAD_DTS_BATCH, RNK, SEQUENCE_NO) AS LEAD_HF,
					[LOAD_DTS],
					[LOAD_DTS_BATCH],
					[SEQUENCE_NO],
					[CDC_OPERATION_CODE],
					[RECORD_SOURCE],
					[FULLY_QUALIFIED_FILE_NAME],
					[INSERT_DTS],
					[UPDATE_DTS],
					[EXPORT_DTS],
					[FILE_TRANSFER_DTS],
					[SESSION_DTS],
					[SOURCE_SLICE_DTS],
					[LOAD_TYPE],
					[HK],
					[HD],
					[HF],
					[CustomerID],
					[CustomerName],
					[Birth],
					[Gender],
					[Address],
					[SOURCE_ENTITY],
					[RNK]
				FROM
				(
					SELECT [LOAD_DTS],
						[LOAD_DTS_BATCH],
						[SEQUENCE_NO],
						[CDC_OPERATION_CODE],
						[RECORD_SOURCE],
						[FULLY_QUALIFIED_FILE_NAME],
						[INSERT_DTS],
						[UPDATE_DTS],
						[EXPORT_DTS],
						[FILE_TRANSFER_DTS],
						[SESSION_DTS],
						[SOURCE_SLICE_DTS],
						[LOAD_TYPE],
						[HK],
						[HD],
						[HF],
						[CustomerID],
						[CustomerName],
						[Birth],
						[Gender],
						[Address],
						'HDA' AS SOURCE_ENTITY,
						1 AS RNK
					FROM [gs].[V_CUSTOMER_LOG_CURRENT]
					UNION ALL
					SELECT [LOAD_DTS],
						[LOAD_DTS_BATCH],
						[SEQUENCE_NO],
						[CDC_OPERATION_CODE],
						[REC_SRC],
						[FULLY_QUALIFIED_FILE_NAME],
						[INSERT_DTS],
						[UPDATE_DTS],
						[EXPORT_DTS],
						[FILE_TRANSFER_DTS],
						[SESSION_DTS],
						[SOURCE_SLICE_DTS],
						[LOAD_TYPE],
						[HK],
						[HD],
						[HF],
						[CustomerID],
						[CustomerName],
						[Birth],
						[Gender],
						[Address],
						'CDC' AS SOURCE_ENTITY,
						2 AS RNK
					FROM [gs].[V_CUSTOMER_MTA]
				) Mta
			) Mta
			CROSS JOIN
			(
				SELECT MAX(LOAD_DTS_BATCH) AS MAX_LOAD_DTS_BATCH,
						MAX(LOAD_TYPE) AS LOAD_TYPE
				FROM [gs].[V_CUSTOMER_MTA]
			) AS MAX_LTS
			WHERE 1 = 1
				AND CASE
					WHEN LEAD_HF IS NULL
						AND SOURCE_ENTITY = 'HDA'
						AND MAX_LTS.LOAD_TYPE = 'FULL' THEN
						'D' --kein Nachfolger für HDA-Datensatz in CDC
					WHEN LAG_HF IS NULL
						AND SOURCE_ENTITY = 'CDC' THEN
						'I' --kein Vorgänger für CDC-Datensatz in HDA
					WHEN LAG_HF <> HF
						AND NOT LAG_HF IS NULL
						AND SOURCE_ENTITY = 'CDC' THEN
						'U'
					ELSE
						''
				END <> '';
			EXEC META.dbo.USP_WRITELOG N'Finish to load [STAGE].[gs].[CUSTOMER_CDC', @LOGSOURCE, N'N';
		COMMIT TRAN;
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN;
		DECLARE @ERROR_MESSAGE AS NVARCHAR(4000);
		SET @ERROR_MESSAGE = N'Failed to load [STAGE].[gs].[CUSTOMER_CDC' + ISNULL(ERROR_MESSAGE(), '');
		EXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';
	END CATCH
END;
GO
