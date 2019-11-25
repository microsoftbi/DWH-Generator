CREATE TABLE [gs].[ORDER]
(
[SEQUENCE_NO] [bigint] NULL,
[SESSION_DTS] [datetimeoffset] NOT NULL,
[Fully_Qualified_File_Name] [varchar] (25) COLLATE Chinese_PRC_CI_AS NOT NULL,
[FILE_TRANSFER_DTS] [datetimeoffset] NOT NULL,
[REC_SRC] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[ORDERID] [int] NULL,
[ORDERDATE] [date] NULL,
[GAMEID] [int] NULL,
[CUSTOMERID] [int] NULL
) ON [PRIMARY]
GO
