CREATE TABLE [gs].[GAMELIST]
(
[Fully_Qualified_File_Name] [varchar] (25) COLLATE Chinese_PRC_CI_AS NOT NULL CONSTRAINT [DF_GAMELIST_Fully_Qualified_File_Name] DEFAULT ('gs.GAME'),
[FILE_TRANSFER_DTS] [datetimeoffset] NOT NULL CONSTRAINT [DF_GAMELIST_FILE_TRANSFER_DTS] DEFAULT (getdate()),
[REC_SRC] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL CONSTRAINT [DF_GAMELIST_REC_SRC] DEFAULT ('GS'),
[ID] [int] NULL,
[Game name] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[AREA] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[PRICE] [decimal] (10, 2) NULL,
[Operator] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[LOAD_DTS] [datetimeoffset] NULL CONSTRAINT [DF_GAMELIST_LOAD_DTS] DEFAULT (getdate())
) ON [PRIMARY]
GO
