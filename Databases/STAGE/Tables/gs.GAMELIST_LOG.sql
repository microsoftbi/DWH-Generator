CREATE TABLE [gs].[GAMELIST_LOG]
(
[LOAD_DTS] [datetimeoffset] NOT NULL,
[LOAD_DTS_BATCH] [datetimeoffset] NOT NULL,
[SEQUENCE_NO] [bigint] NOT NULL,
[CDC_OPERATION_CODE] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[RECORD_SOURCE] [nvarchar] (15) COLLATE Chinese_PRC_CI_AS NOT NULL,
[FULLY_QUALIFIED_FILE_NAME] [nvarchar] (256) COLLATE Chinese_PRC_CI_AS NULL,
[INSERT_DTS] [datetimeoffset] NULL,
[UPDATE_DTS] [datetimeoffset] NULL,
[EXPORT_DTS] [datetimeoffset] NULL,
[FILE_TRANSFER_DTS] [datetimeoffset] NULL,
[SESSION_DTS] [datetimeoffset] NULL,
[SOURCE_SLICE_DTS] [datetimeoffset] NULL,
[LOAD_TYPE] [nvarchar] (10) COLLATE Chinese_PRC_CI_AS NULL,
[HK] [char] (32) COLLATE Chinese_PRC_CI_AS NOT NULL,
[HD] [char] (32) COLLATE Chinese_PRC_CI_AS NOT NULL,
[HF] [char] (32) COLLATE Chinese_PRC_CI_AS NOT NULL,
[ID] [int] NULL,
[Game name] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[AREA] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[PRICE] [decimal] (10, 2) NULL,
[Operator] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
