---------------------------------------------------------------------
--Database
---------------------------------------------------------------------

USE [master];
GO

CREATE DATABASE [META]
ON PRIMARY
       (
           NAME = N'META',
           FILENAME = N'C:\DATA\META.mdf',
           SIZE = 8192KB,
           MAXSIZE = UNLIMITED,
           FILEGROWTH = 65536KB
       )
LOG ON
    (
        NAME = N'META_log',
        FILENAME = N'C:\DATA\META_log.ldf',
        SIZE = 8192KB,
        MAXSIZE = 2048GB,
        FILEGROWTH = 65536KB
    );
GO




---------------------------------------------------------------------
--Tables
---------------------------------------------------------------------

USE [META]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DV_SAT](
	[ID] [int] NULL,
	[TableName] [nvarchar](50) NULL
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[RecordSource](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RecordSourceName] [nvarchar](20) NULL,
	[DatabaseName] [nvarchar](20) NULL,
	[RecordSourceDesc] [nvarchar](100) NULL
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[DV_HUB](
	[ID] [int] NULL,
	[TableName] [nvarchar](30) NULL,
	[BKNAMEAS] [nvarchar](30) NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[GEN_LIST](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TABLE_CATALOG] [nvarchar](128) NULL,
	[TABLE_NAME] [nvarchar](128) NULL,
	[IS_GEN] [bit] NULL,
	[IS_FULLLOAD] [bit] NULL,
 CONSTRAINT [PK_GEN_LIST] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GEN_LIST] ADD  CONSTRAINT [DF_GEN_LIST_IS_GEN]  DEFAULT ((1)) FOR [IS_GEN]
GO
ALTER TABLE [dbo].[GEN_LIST] ADD  CONSTRAINT [DF_GEN_LIST_IS_FULLLOAD]  DEFAULT ((1)) FOR [IS_FULLLOAD]
GO


CREATE TABLE [dbo].[ATTRIBUTE_LANDING](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TABLE_CATALOG] [nvarchar](128) NULL,
	[TABLE_NAME] [sysname] NOT NULL,
	[COLUMN_NAME] [sysname] NULL,
	[DATA_TYPE] [nvarchar](128) NULL,
	[CHARACTER_MAXIMUM_LENGTH] [int] NULL,
	[NUMERIC_PRECISION] [tinyint] NULL,
	[NUMERIC_SCALE] [int] NULL,
 CONSTRAINT [PK_ATTRIBUTE_LANDING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[DV_LINK](
	[ID] [int] NULL,
	[TableName] [nvarchar](30) NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ATTRIBUTE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TABLE_CATALOG] [nvarchar](128) NULL,
	[TABLE_NAME] [sysname] NOT NULL,
	[COLUMN_NAME] [sysname] NULL,
	[DATA_TYPE] [nvarchar](128) NULL,
	[CHARACTER_MAXIMUM_LENGTH] [int] NULL,
	[NUMERIC_PRECISION] [tinyint] NULL,
	[NUMERIC_SCALE] [int] NULL,
	[BK] [bit] NULL,
	[PK] [bit] NULL,
	[DI] [bit] NULL,
	[FK] [bit] NULL,
	[DV_SAT_ID] [int] NULL,
	[DV_HUB_ID] [int] NULL,
	[DV_LINK_ID] [int] NULL,
	[DV_COLUMN_NAME] [nvarchar](50) NULL,
 CONSTRAINT [PK_ATTRIBUTE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[LOG](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LOGDATE] [datetime] NULL,
	[LOGMESSAGE] [nvarchar](600) NULL,
	[LOGSOURCE] [nvarchar](100) NULL,
	[MESSAGETYPE] [nvarchar](1) NULL,
	[ROWCOUNT] [bigint] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LOG] ADD  CONSTRAINT [DF_LOG_LOGDATE]  DEFAULT (getdate()) FOR [LOGDATE]
GO


CREATE TABLE [dbo].[CONFIG_VERIFY](
	[RESULTCONTENT] [nvarchar](200) NULL,
	[RESULTTYPE] [nvarchar](20) NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[CONFIGURATION](
	[ConfigName] [nvarchar](50) NULL,
	[ConfigValue] [nvarchar](50) NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Layers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LayerName] [nvarchar](20) NULL,
	[DatabaseName] [nvarchar](20) NULL
) ON [PRIMARY]
GO


---------------------------------------------------------------------
--Views
---------------------------------------------------------------------



CREATE VIEW [dbo].[V_ATTRIBUTE]
AS

SELECT ATT.[ID],
       ATT.[TABLE_CATALOG],
       ATT.[TABLE_NAME],
       ATT.[COLUMN_NAME],
       ATT.[DATA_TYPE],
       ATT.[CHARACTER_MAXIMUM_LENGTH],
       ATT.[NUMERIC_PRECISION],
       ATT.[NUMERIC_SCALE],
       ATTL.[DATA_TYPE] AS L_DATA_TYPE,
       ATTL.[CHARACTER_MAXIMUM_LENGTH] AS [L_CHARACTER_MAXIMUM_LENGTH],
       ATTL.[NUMERIC_PRECISION] AS [L_NUMERIC_PRECISION],
       ATTL.[NUMERIC_SCALE] AS [L_NUMERIC_SCALE],
       RS.RecordSourceName AS RECORDSOURCE,
       [BK],
       [PK],
       [DI],
	   [FK],
       --,[DVID]
       SAT.TableName AS DV_SAT_TABLENAME,
       HUB.TableName AS DV_HUB_TABLENAME,
	   LINK.TableName AS DV_LINK_TABLENAME,
       --HUB.BKNAMEAS AS DV_HUB_BK,
	   ATT.DV_COLUMN_NAME,
	   IS_FULLLOAD
FROM [META].[dbo].[ATTRIBUTE] ATT
    LEFT JOIN [META].[dbo].[ATTRIBUTE_LANDING] ATTL
        ON ATT.TABLE_CATALOG = ATTL.[TABLE_CATALOG]
           AND ATT.TABLE_NAME = ATTL.TABLE_NAME
           AND ATT.[COLUMN_NAME] = ATTL.[COLUMN_NAME]
    LEFT JOIN META.dbo.RecordSource RS
        ON ATT.TABLE_CATALOG = RS.DatabaseName
    LEFT JOIN META.dbo.DV_SAT SAT
        ON ATT.DV_SAT_ID = SAT.ID
    LEFT JOIN META.dbo.DV_HUB HUB
        ON ATT.DV_HUB_ID = HUB.ID
	LEFT JOIN META.dbo.DV_LINK LINK
		ON ATT.DV_LINK_ID= LINK.ID
	INNER JOIN [META].[dbo].GEN_LIST GEN
		ON ATT.[TABLE_CATALOG] + ATT.[TABLE_NAME]=GEN.[TABLE_CATALOG] + GEN.[TABLE_NAME] --AND IS_GEN=1
WHERE IS_GEN = 1;
GO





CREATE VIEW [dbo].[V_DV_META_HUB] AS
SELECT 
       HUB.TableName AS DV_SAT_TABLENAME,
	   ATT.[COLUMN_NAME],
	   ATT.[DV_COLUMN_NAME],
       ATT.[DATA_TYPE],
       ATT.[CHARACTER_MAXIMUM_LENGTH],
       ATT.[NUMERIC_PRECISION],
       ATT.[NUMERIC_SCALE],

       RS.RecordSourceName AS RECORDSOURCE,

       [PK]
       
FROM [META].[dbo].[ATTRIBUTE] ATT
    
    LEFT JOIN META.dbo.RecordSource RS
        ON ATT.TABLE_CATALOG = RS.DatabaseName
    LEFT JOIN META.dbo.DV_HUB HUB
        ON ATT.DV_HUB_ID = HUB.ID

WHERE HUB.TableName IS NOT NULL;
GO





CREATE VIEW [dbo].[V_DV_META_LINK] AS
SELECT 
       LINK.TableName AS DV_LINK_TABLENAME,
	   ATT.[COLUMN_NAME],
	   ATT.[DV_COLUMN_NAME],
       ATT.[DATA_TYPE],
       ATT.[CHARACTER_MAXIMUM_LENGTH],
       ATT.[NUMERIC_PRECISION],
       ATT.[NUMERIC_SCALE],

       RS.RecordSourceName AS RECORDSOURCE,

       [FK]
       
FROM [META].[dbo].[ATTRIBUTE] ATT
    
    LEFT JOIN META.dbo.RecordSource RS
        ON ATT.TABLE_CATALOG = RS.DatabaseName
    LEFT JOIN META.dbo.DV_LINK LINK
        ON ATT.DV_LINK_ID = LINK.ID

WHERE LINK.TableName IS NOT NULL;

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



---------------------------------------------------------------------
--USP
---------------------------------------------------------------------


CREATE PROCEDURE [dbo].[USP_INIT_LIST]
AS
BEGIN
--TRUNCATE TABLE META.DBO.GEN_LIST

INSERT INTO META.DBO.GEN_LIST
( 
	[TABLE_CATALOG]
	,[TABLE_NAME]
	,IS_GEN
	,IS_FULLLOAD
)
SELECT DISTINCT
	[TABLE_CATALOG]
	,[TABLE_NAME]
	,0
	,1
FROM META.DBO.ATTRIBUTE
WHERE [TABLE_CATALOG]+[TABLE_NAME] NOT IN (SELECT [TABLE_CATALOG]+[TABLE_NAME] FROM META.DBO.GEN_LIST)
	  
--UPDATE [META].[dbo].[GEN_LIST] SET IS_GEN=0

END
GO


CREATE PROCEDURE [dbo].[USP_WRITELOG]
    @LOGMESSAGE NVARCHAR(600),
    @LOGSOURCE NVARCHAR(100),
	@MESSAGETYPE NVARCHAR(1)
AS
BEGIN

    INSERT INTO META.dbo.LOG
    (
        LOGDATE,
        LOGMESSAGE,
        LOGSOURCE,
		MESSAGETYPE
    )
    VALUES
    (   GETDATE(),   -- LOGDATE - datetime
        @LOGMESSAGE, -- LOGMESSAGE - nvarchar(600)
        @LOGSOURCE,   -- LOGSOURCE - nvarchar(100)
		@MESSAGETYPE
        );

END;
GO

CREATE PROCEDURE [dbo].[USP_WRITELOG2]
    @LOGMESSAGE NVARCHAR(600),
    @LOGSOURCE NVARCHAR(100),
	@MESSAGETYPE NVARCHAR(1),
	@ROWCOUNT bigint
AS
BEGIN

    INSERT INTO META.dbo.LOG
    (
        LOGDATE,
        LOGMESSAGE,
        LOGSOURCE,
		MESSAGETYPE,
		[ROWCOUNT]
    )
    VALUES
    (   GETDATE(),   -- LOGDATE - datetime
        @LOGMESSAGE, -- LOGMESSAGE - nvarchar(600)
        @LOGSOURCE,   -- LOGSOURCE - nvarchar(100)
		@MESSAGETYPE,
		@ROWCOUNT
        );

END;
GO