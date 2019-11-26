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




USE [META];
GO
CREATE TABLE [dbo].[ATTRIBUTE]
(
    [ID] [INT] IDENTITY(1, 1) NOT NULL,
    [TABLE_CATALOG] [NVARCHAR](128) NULL,
    [TABLE_NAME] [sysname] NOT NULL,
    [COLUMN_NAME] [sysname] NULL,
    [DATA_TYPE] [NVARCHAR](128) NULL,
    [CHARACTER_MAXIMUM_LENGTH] [INT] NULL,
    [NUMERIC_PRECISION] [TINYINT] NULL,
    [NUMERIC_SCALE] [INT] NULL,
    [BK] [INT] NULL,
    [PK] [INT] NULL,
    [DI] [INT] NULL,
    [DV_SAT_ID] [INT] NULL,
    [DV_HUB_ID] [INT] NULL
) ON [PRIMARY];
GO

CREATE TABLE [dbo].[RecordSource]
(
    [ID] [INT] IDENTITY(1, 1) NOT NULL,
    [RecordSourceName] [NVARCHAR](20) NULL,
    [DatabaseName] [NVARCHAR](20) NULL,
    [RecordSourceDesc] [NVARCHAR](100) NULL
) ON [PRIMARY];
GO

CREATE TABLE [dbo].[DV_HUB]
(
    [ID] [INT] NULL,
    [TableName] [NVARCHAR](30) NULL,
    [BKNAMEAS] [NVARCHAR](30) NULL
) ON [PRIMARY];
GO

CREATE TABLE [dbo].[DV_SAT]
(
    [ID] [INT] NULL,
    [TableName] [NVARCHAR](30) NULL
) ON [PRIMARY];
GO

CREATE VIEW [dbo].[V_ATTRIBUTE]
AS
SELECT ATT.[ID],
       [TABLE_CATALOG],
       [TABLE_NAME],
       [COLUMN_NAME],
       [DATA_TYPE],
       [CHARACTER_MAXIMUM_LENGTH],
       [NUMERIC_PRECISION],
       [NUMERIC_SCALE],
       RS.RecordSourceName AS RECORDSOURCE,
       [BK],
       [PK],
       [DI],
       --,[DVID]
       SAT.TableName AS DV_SAT_TABLENAME,
       HUB.TableName AS DV_HUB_TABLENAME,
       HUB.BKNAMEAS AS DV_HUB_BK
FROM [META].[dbo].[ATTRIBUTE] ATT
    LEFT JOIN META.dbo.RecordSource RS
        ON ATT.TABLE_CATALOG = RS.DatabaseName
    LEFT JOIN META.dbo.DV_SAT SAT
        ON ATT.DV_SAT_ID = SAT.ID
    LEFT JOIN META.dbo.DV_HUB HUB
        ON ATT.DV_HUB_ID = HUB.ID;
GO

CREATE TABLE [dbo].[Layers]
(
    [ID] [INT] IDENTITY(1, 1) NOT NULL,
    [LayerName] [NVARCHAR](20) NULL,
    [DatabaseName] [NVARCHAR](20) NULL
) ON [PRIMARY];
GO

CREATE TABLE [dbo].[LOG]
(
    [ID] [BIGINT] IDENTITY(1, 1) NOT NULL,
    [LOGDATE] [DATETIME] NULL,
    [LOGMESSAGE] [NVARCHAR](600) NULL,
    [LOGSOURCE] [NVARCHAR](100) NULL,
    [MESSAGETYPE] [NVARCHAR](1) NULL
) ON [PRIMARY];
GO
ALTER TABLE [dbo].[LOG]
ADD CONSTRAINT [DF_LOG_LOGDATE]
    DEFAULT (GETDATE()) FOR [LOGDATE];
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
        @LOGSOURCE,  -- LOGSOURCE - nvarchar(100)
        @MESSAGETYPE);

END;
GO
