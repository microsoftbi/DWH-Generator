SET QUOTED_IDENTIFIER ON;
GO
SET ANSI_NULLS ON;
GO


CREATE PROCEDURE [dbo].[USP_GAMELIST_HIS_INSERTONLY]
AS
BEGIN
    DECLARE @LOGSOURCE AS NVARCHAR(100);

    SET @LOGSOURCE = N'STAGE.dbo.USP_GAMELIST_HIS';

    EXEC META.dbo.USP_WRITELOG N'Start to load GAMELIST_HIS',
                               @LOGSOURCE,
                               N'N';

    BEGIN TRY
        BEGIN TRAN;

        MERGE [dbo].[GAMELIST_HIS] AS TARGET
        USING [dbo].[GAMELIST_STG] AS SOURCE
        ON TARGET.ID = SOURCE.ID
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
        
        ;


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
