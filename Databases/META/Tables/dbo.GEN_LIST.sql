CREATE TABLE [dbo].[GEN_LIST]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[TABLE_CATALOG] [nvarchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[TABLE_NAME] [nvarchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[IS_GEN] [bit] NULL CONSTRAINT [DF_GEN_LIST_IS_GEN] DEFAULT ((1)),
[IS_FULLLOAD] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GEN_LIST] ADD CONSTRAINT [PK_GEN_LIST] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
