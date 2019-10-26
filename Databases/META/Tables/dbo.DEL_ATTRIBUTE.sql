CREATE TABLE [dbo].[DEL_ATTRIBUTE]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[TABLENAME] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[COLUMNNAME] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[COLUMNTYPE] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL,
[BK] [int] NULL,
[PK] [int] NULL,
[DI] [int] NULL,
[VERSION] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL
) ON [PRIMARY]
GO
