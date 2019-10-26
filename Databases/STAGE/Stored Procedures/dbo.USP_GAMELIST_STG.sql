SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[USP_GAMELIST_STG]
AS
BEGIN
    TRUNCATE TABLE STAGE.dbo.GAMELIST_STG;

    INSERT INTO GAMELIST_STG
    SELECT ID,
           [Game name],
           [AREA],
           [PRICE],
           CONVERT(
                      CHAR(32),
                      HASHBYTES(
                                   'MD5',
                                   ISNULL(TRIM(CONVERT(NVARCHAR(255), [Game name])), N'') + N'W|D'
                                   + ISNULL(TRIM(CONVERT(NVARCHAR(255), [AREA])), N'') + N'W|D'
                                   + ISNULL(TRIM(CONVERT(NVARCHAR(255), [PRICE])), N'') + N'W|D'
                               ),
                      2
                  ) AS HD,
           GETDATE() AS [INSERT TIME]
    FROM [STAGE].[dbo].[GAMELIST];

END;
GO
