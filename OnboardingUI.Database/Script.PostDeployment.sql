?/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

PRINT '********** Executing DATALOAD Post-Deployment Scripts **********'
-- Add any DataLoad scripts for execution here
:r .\DataLoad\SOFTWARE.Software.sql


-- Execute any environment specific post-deployment scripts here by referencing a script copied to the build output directory
-- Note that the values of the SQLCMD "DeployType" parameter used here currently correspond to the Octopus channel names
PRINT 'Executing Environment Specific Post-Deployment Scripts for DeployType $(DeployType)....'
IF (UPPER(N'$(DeployType)') = N'LOCAL') BEGIN
	:r .\Security\SecurityAdditions\SecurityAdditionsLOCAL.sql
END
ELSE IF (UPPER(N'$(DeployType)') = N'DEVELOPMENT') BEGIN 
	:r .\Security\SecurityAdditions\SecurityAdditionsDEV.sql
END
ELSE IF (UPPER(N'$(DeployType)') = N'QA') BEGIN
	:r .\Security\SecurityAdditions\SecurityAdditionsQA.sql
END
ELSE IF (UPPER(N'$(DeployType)') = N'STAGE') BEGIN
	:r .\Security\SecurityAdditions\SecurityAdditionsSTAGE.sql
END
ELSE IF (UPPER(N'$(DeployType)') = N'PRODUCTION') BEGIN
	:r .\Security\SecurityAdditions\SecurityAdditionsPROD.sql
END
ELSE
BEGIN 
	PRINT 'WARNING:  Environment Specific Post-Deployment Scripts **NOT** Applied.  Unknown DeployType: $(DeployType)'
END

PRINT 'Audit End of Post-Deployment Scripts for VersionName `$(VersionName)`....'
EXEC [dbo].[usp_DacpacDeploymentAudit_End] N'$(VersionName)'