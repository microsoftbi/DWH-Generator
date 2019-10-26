CREATE TABLE [dbo].[GAMELIST_HIS]
(
[ID] [int] NULL,
[Game name] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[AREA] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[PRICE] [decimal] (10, 2) NULL,
[HD] [char] (32) COLLATE Chinese_PRC_CI_AS NULL,
[INSERT TIME] [datetime] NULL,
[VALID FROM] [datetime] NULL,
[VALID TO] [datetime] NULL,
[IS CURRENT] [int] NULL
) ON [PRIMARY]
GO
