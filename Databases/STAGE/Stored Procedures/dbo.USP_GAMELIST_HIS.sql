SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [dbo].[USP_GAMELIST_HIS]
AS
BEGIN

    DECLARE @VALIDFROM AS DATETIME;
    DECLARE @VALIDTO AS DATETIME;
    DECLARE @DEFAULTVALIDTO AS DATETIME;
    DECLARE @LOGSOURCE AS NVARCHAR(100);

    SET @VALIDFROM = GETDATE();
    SET @VALIDTO = GETDATE();
    SET @DEFAULTVALIDTO = '2199-12-31';
    SET @LOGSOURCE = N'STAGE.dbo.USP_GAMELIST_HIS';


    EXEC META.dbo.USP_WRITELOG N'Start to load GAMELIST_HIS',
                               @LOGSOURCE,
                               N'N';

    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO [dbo].[GAMELIST_HIS]
        SELECT [ID],
               [Game name],
               [AREA],
               [PRICE],
               [HD],
               [INSERT TIME],
               [VALID FROM],
               [VALID TO],
               [IS CURRENT]
        FROM
        (
            MERGE [dbo].[GAMELIST_HIS] AS TARGET
            USING [dbo].[GAMELIST_STG] AS SOURCE
            ON TARGET.ID = SOURCE.ID
            WHEN MATCHED AND SOURCE.HD <> TARGET.HD
            --Existing data, UPDATE BRANCH, update old data, then using OUTPUT to insert new data.
            THEN
                UPDATE SET TARGET.[VALID TO] = @VALIDTO,
                           TARGET.[IS CURRENT] = 0
            --New data, INSERT BRANCH
            WHEN NOT MATCHED BY TARGET THEN
                INSERT
                (
                    [ID],
                    [Game name],
                    [AREA],
                    [PRICE],
                    [HD],
                    [INSERT TIME],
                    [VALID FROM],
                    [VALID TO],
                    [IS CURRENT]
                )
                VALUES
                (SOURCE.ID, SOURCE.[Game name], SOURCE.AREA, SOURCE.PRICE, SOURCE.HD, GETDATE(), @VALIDFROM,
                 @DEFAULTVALIDTO, 1)
            --Data deleted by source, DELETE BRANCH, update old data
            WHEN NOT MATCHED BY SOURCE THEN
                UPDATE SET TARGET.[VALID TO] = @VALIDTO,
                           TARGET.[IS CURRENT] = 0
            OUTPUT $action AS MERGE_ACTION,
                   SOURCE.[ID],
                   SOURCE.[Game name],
                   SOURCE.[AREA],
                   SOURCE.[PRICE],
                   SOURCE.[HD],
                   SOURCE.[INSERT TIME],
                   @VALIDFROM AS [VALID FROM],
                   @DEFAULTVALIDTO AS [VALID TO],
                   1 AS [IS CURRENT]
        )   MERGE_OUTPUT
        WHERE MERGE_OUTPUT.MERGE_ACTION = 'UPDATE';

        EXEC META.dbo.USP_WRITELOG N'Finish to load GAMELIST_HIS',
                                   @LOGSOURCE,
                                   N'N';

        COMMIT TRAN;
    END TRY
    BEGIN CATCH

        ROLLBACK TRAN;

        DECLARE @ERROR_MESSAGE AS NVARCHAR(4000);
        SET @ERROR_MESSAGE = N'Failed to load GAMELIST_HIS' + ISNULL(ERROR_MESSAGE(), '');

        EXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';
    --EXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, 'TEST', N'E'

    END CATCH;
END;
GO
