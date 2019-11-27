SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




CREATE   VIEW [dbo].[V_ATTRIBUTE]
AS

SELECT ATT.[ID]
      ,[TABLE_CATALOG]
      ,[TABLE_NAME]
      ,[COLUMN_NAME]
      ,[DATA_TYPE]
      ,[CHARACTER_MAXIMUM_LENGTH]
      ,[NUMERIC_PRECISION]
      ,[NUMERIC_SCALE]
      ,RS.RECORDSOURCENAME AS RECORDSOURCE
      ,[BK]
      ,[PK]
      ,[DI]
      --,[DVID]

	  ,SAT.TableName AS DV_SAT_TABLENAME
	  ,HUB.TableName AS DV_HUB_TABLENAME
	  ,HUB.BKNAMEAS AS DV_HUB_BK
  FROM [META].[dbo].[ATTRIBUTE] ATT
  LEFT JOIN META.dbo.RecordSource RS ON ATT.TABLE_CATALOG = RS.DATABASENAME
  LEFT JOIN META.dbo.DV_SAT SAT ON ATT.DV_SAT_ID=SAT.ID
  LEFT JOIN META.dbo.DV_HUB HUB ON ATT.DV_HUB_ID=HUB.ID
  WHERE ATT.[TABLE_CATALOG]+ATT.[TABLE_NAME] IN (SELECT  GEN.[TABLE_CATALOG]+GEN.[TABLE_NAME] FROM [META].[dbo].GEN_LIST GEN WHERE IS_GEN=1)
GO