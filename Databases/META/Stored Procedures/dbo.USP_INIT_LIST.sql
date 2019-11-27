SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/

CREATE PROCEDURE [dbo].[USP_INIT_LIST]
AS
BEGIN
TRUNCATE TABLE META.DBO.GEN_LIST

INSERT INTO META.DBO.GEN_LIST
( [TABLE_CATALOG]
      ,[TABLE_NAME])
SELECT DISTINCT
      [TABLE_CATALOG]
      ,[TABLE_NAME]
      FROM META.DBO.ATTRIBUTE

END
GO
