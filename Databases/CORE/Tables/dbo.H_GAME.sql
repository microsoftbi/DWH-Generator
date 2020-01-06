CREATE TABLE [dbo].[H_GAME]
(
[LOAD_DTS] [datetimeoffset] NOT NULL,
[LOAD_END_DTS] [datetimeoffset] NOT NULL,
[CDC_OPERATION_CODE] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[RECORD_SOURCE] [nvarchar] (15) COLLATE Chinese_PRC_CI_AS NOT NULL,
[SESSION_DTS] [datetimeoffset] NULL,
[HK] [char] (32) COLLATE Chinese_PRC_CI_AS NOT NULL,
[GAME_ID] [int] NULL
) ON [PRIMARY]
GO
