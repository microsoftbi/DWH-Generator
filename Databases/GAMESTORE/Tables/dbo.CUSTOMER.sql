CREATE TABLE [dbo].[CUSTOMER]
(
[CustomerID] [int] NULL,
[CustomerName] [nvarchar] (30) COLLATE Chinese_PRC_CI_AS NULL,
[Birth] [date] NULL,
[Gender] [int] NULL,
[Address] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
