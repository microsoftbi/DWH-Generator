CREATE TABLE [dbo].[GAMELIST]
(
[ID] [int] NULL,
[Game name] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[AREA] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[PRICE] [decimal] (10, 2) NULL,
[FLAG01] [int] NULL,
[FLAG02] [int] NULL,
[FLAG03] [int] NULL,
[FLAG04] [int] NULL,
[FLAG05] [int] NULL,
[Operator] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[AREA_HTR] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[PRICE_HTR] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
