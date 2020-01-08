CREATE TABLE [dbo].[S_GAME]
(
[LOAD_DTS] [datetimeoffset] NOT NULL,
[LOAD_END_DTS] [datetimeoffset] NOT NULL,
[CDC_OPERATION_CODE] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[RECORD_SOURCE] [nvarchar] (15) COLLATE Chinese_PRC_CI_AS NOT NULL,
[SESSION_DTS] [datetimeoffset] NULL,
[HK] [char] (32) COLLATE Chinese_PRC_CI_AS NOT NULL,
[HD] [char] (32) COLLATE Chinese_PRC_CI_AS NOT NULL,
[HF] [char] (32) COLLATE Chinese_PRC_CI_AS NOT NULL,
[ID] [int] NULL,
[Game name] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[PRICE] [decimal] (10, 2) NULL
) ON [PRIMARY]
GO
