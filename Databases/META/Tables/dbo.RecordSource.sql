CREATE TABLE [dbo].[RecordSource]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[RecordSourceName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[DatabaseName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[RecordSourceDesc] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
