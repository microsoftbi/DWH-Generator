CREATE TABLE [gs].[CUSTOMER]
(
[SEQUENCE_NO] [bigint] NULL,
[SESSION_DTS] [datetimeoffset] NOT NULL,
[Fully_Qualified_File_Name] [varchar] (25) COLLATE Chinese_PRC_CI_AS NOT NULL,
[FILE_TRANSFER_DTS] [datetimeoffset] NOT NULL,
[REC_SRC] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[CustomerID] [int] NULL,
[CustomerName] [nvarchar] (30) COLLATE Chinese_PRC_CI_AS NULL,
[Birth] [date] NULL,
[Gender] [int] NULL,
[Address] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
