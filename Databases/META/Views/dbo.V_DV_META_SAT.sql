SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE VIEW [dbo].[V_DV_META_SAT] AS
SELECT 
       SAT.TableName AS DV_SAT_TABLENAME,
	   ATT.[COLUMN_NAME],
	   ATT.[DV_COLUMN_NAME],
       ATT.[DATA_TYPE],
       ATT.[CHARACTER_MAXIMUM_LENGTH],
       ATT.[NUMERIC_PRECISION],
       ATT.[NUMERIC_SCALE],

       RS.RecordSourceName AS RECORDSOURCE,

       [PK],
       [DI]
       
FROM [META].[dbo].[ATTRIBUTE] ATT
    
    LEFT JOIN META.dbo.RecordSource RS
        ON ATT.TABLE_CATALOG = RS.DatabaseName
    LEFT JOIN META.dbo.DV_SAT SAT
        ON ATT.DV_SAT_ID = SAT.ID

WHERE SAT.TableName IS NOT NULL



GO