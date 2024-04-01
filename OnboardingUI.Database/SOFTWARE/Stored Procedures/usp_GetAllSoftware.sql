-- ==================================================================================================================
-- Author:			Hunter Kleppek
-- Create date:		11/29/2023
-- Description:		Returns All Software
-- ==================================================================================================================

CREATE PROCEDURE [SOFTWARE].[GetAllSoftware]
as 
Begin
	set xact_abort on;
	set nocount on;

	begin try
		declare @joinsql nvarchar(max)
		set @joinsql = N'Select * From [SOFTWARE].[Software]'
		EXEC sp_executesql @joinsql
	end try
	begin catch
		DECLARE @ErrorNumber INT,
            @ErrorLine INT,
            @ErrorSeverity INT,
            @ErrorState INT,
            @ErrorProcedure NVARCHAR(128),
            @ErrorMessage NVARCHAR(4000);

        SELECT @ErrorSeverity = ERROR_SEVERITY(),
               @ErrorState = ERROR_STATE(),
               @ErrorMessage = ERROR_MESSAGE(),
               @ErrorNumber = ERROR_NUMBER(),
               @ErrorLine = ERROR_LINE(),
               @ErrorProcedure = ERROR_PROCEDURE();

        PRINT 'Error Severity: ' + CAST(@ErrorSeverity AS VARCHAR(10));
        PRINT 'Error Satte: ' + CAST(@ErrorState AS VARCHAR(10));
        PRINT 'Error number: ' + CAST(@ErrorNumber AS VARCHAR(10));
        PRINT 'Error line number: ' + CAST(@ErrorLine AS VARCHAR(10));
        PRINT 'Error Procedure: ' + @ErrorProcedure;
        PRINT 'Error Message: ' + @ErrorMessage;

		throw;
	end catch
End
