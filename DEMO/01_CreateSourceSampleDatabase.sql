USE [master]
GO


--Creatre database.
CREATE DATABASE [GAMESTORE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GAMESTORE', FILENAME = N'D:\Databases\GAMESTORE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GAMESTORE_log', FILENAME = N'D:\Databases\GAMESTORE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO




--Create test tables.
USE [GAMESTORE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[CustomerID] [int] NULL,
	[CustomerName] [nvarchar](30) NULL,
	[Birth] [date] NULL,
	[Gender] [int] NULL,
	[Address] [nvarchar](50) NULL
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GAMELIST](
	[ID] [int] NULL,
	[Game name] [nvarchar](50) NULL,
	[AREA] [nvarchar](20) NULL,
	[PRICE] [decimal](10, 2) NULL,
	[Operator] [nvarchar](20) NULL,
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDER](
	[ORDERID] [int] NULL,
	[ORDERDATE] [date] NULL,
	[GAMEID] [int] NULL,
	[CUSTOMERID] [int] NULL
) ON [PRIMARY]
GO






--Generate testing datas.
USE [GAMESTORE]
GO
INSERT [dbo].[CUSTOMER] ([CustomerID], [CustomerName], [Birth], [Gender], [Address]) VALUES (1, N'Wade', CAST(N'1980-01-01' AS Date), 1, N'China')
GO
INSERT [dbo].[CUSTOMER] ([CustomerID], [CustomerName], [Birth], [Gender], [Address]) VALUES (2, N'James', CAST(N'1981-01-01' AS Date), 1, N'USA')
GO
INSERT [dbo].[CUSTOMER] ([CustomerID], [CustomerName], [Birth], [Gender], [Address]) VALUES (3, N'Wege', CAST(N'1985-01-01' AS Date), 1, N'Germany')
GO
INSERT [dbo].[GAMELIST] ([ID], [Game name], [AREA], [PRICE], [Operator]) VALUES (1, N'GTA1', N'JAPAN', CAST(20.00 AS Decimal(10, 2)), N'Sam')
GO
INSERT [dbo].[GAMELIST] ([ID], [Game name], [AREA], [PRICE], [Operator]) VALUES (2, N'GTA2', N'JAPAN', CAST(60.00 AS Decimal(10, 2)), N'Sam')
GO
INSERT [dbo].[GAMELIST] ([ID], [Game name], [AREA], [PRICE], [Operator]) VALUES (3, N'GTA3', N'KOREA', CAST(80.00 AS Decimal(10, 2)), N'Sam')
GO
INSERT [dbo].[GAMELIST] ([ID], [Game name], [AREA], [PRICE], [Operator]) VALUES (4, N'GTA4', N'JAPAN', CAST(160.00 AS Decimal(10, 2)), N'Sam')
GO
INSERT [dbo].[GAMELIST] ([ID], [Game name], [AREA], [PRICE], [Operator]) VALUES (5, N'GTA5', N'JAPAN', CAST(180.00 AS Decimal(10, 2)), N'Sam')
GO
INSERT [dbo].[ORDER] ([ORDERID], [ORDERDATE], [GAMEID], [CUSTOMERID]) VALUES (1, CAST(N'2010-01-01' AS Date), 1, 2)
GO
INSERT [dbo].[ORDER] ([ORDERID], [ORDERDATE], [GAMEID], [CUSTOMERID]) VALUES (2, CAST(N'2010-02-01' AS Date), 1, 3)
GO
INSERT [dbo].[ORDER] ([ORDERID], [ORDERDATE], [GAMEID], [CUSTOMERID]) VALUES (3, CAST(N'2010-01-01' AS Date), 2, 1)
GO
INSERT [dbo].[ORDER] ([ORDERID], [ORDERDATE], [GAMEID], [CUSTOMERID]) VALUES (4, CAST(N'2010-01-02' AS Date), 3, 2)
GO
INSERT [dbo].[ORDER] ([ORDERID], [ORDERDATE], [GAMEID], [CUSTOMERID]) VALUES (5, CAST(N'2010-02-03' AS Date), 4, 3)
GO
INSERT [dbo].[ORDER] ([ORDERID], [ORDERDATE], [GAMEID], [CUSTOMERID]) VALUES (6, CAST(N'2010-01-01' AS Date), 5, 1)
GO