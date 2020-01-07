CREATE TABLE [gs].[GAMELIST_STG]
(
[SEQUENCE_NO] [bigint] NULL,
[SESSION_DTS] [datetimeoffset] NOT NULL,
[Fully_Qualified_File_Name] [varchar] (25) COLLATE Chinese_PRC_CI_AS NOT NULL,
[FILE_TRANSFER_DTS] [datetimeoffset] NOT NULL,
[REC_SRC] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[ID] [int] NULL,
[Game name] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[AREA] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[PRICE] [decimal] (10, 2) NULL,
[Operator] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
