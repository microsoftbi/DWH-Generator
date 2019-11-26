CREATE TABLE [dbo].[ATTRIBUTE]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[TABLE_CATALOG] [nvarchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[TABLE_NAME] [sys].[sysname] NOT NULL,
[COLUMN_NAME] [sys].[sysname] NULL,
[DATA_TYPE] [nvarchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[CHARACTER_MAXIMUM_LENGTH] [int] NULL,
[NUMERIC_PRECISION] [tinyint] NULL,
[NUMERIC_SCALE] [int] NULL,
[BK] [int] NULL,
[PK] [int] NULL,
[DI] [int] NULL,
[DV_SAT_ID] [int] NULL,
[DV_HUB_ID] [int] NULL
) ON [PRIMARY]
GO
