?/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

PRINT '********** Executing Pre-Deployment Scripts **********'
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.usp_DacpadDeploymentAudit_Start')) BEGIN
	PRINT 'Audit Start of Pre-Deployment Scripts for VersionName `$(VersionName)`....'
	EXEC [dbo].[usp_DacpacDeploymentAudit_Start] N'$(VersionName)'
END


-- Execute any environment specific pre-deployment scripts here by referencing a script copied to the build output directory
-- Note that the values of the SQLCMD "DeployType" parameter used here currently correspond to the Octopus channel names
PRINT 'Executing Environment Specific Pre-Deployment Scripts for DeployType $(DeployType)....'
IF (UPPER(N'$(DeployType)') = N'LOCAL') BEGIN
	PRINT 'No scripts available for $(DeployType) YET....'
	-- Add LOCAL Scripts Here & remove PRINT above (added so this would compile)
END
ELSE IF (UPPER(N'$(DeployType)') = N'DEVELOPMENT') BEGIN 
	PRINT 'No scripts available for $(DeployType) YET....'
	-- Add LOCAL Scripts Here & remove PRINT above (added so this would compile)
END
ELSE IF (UPPER(N'$(DeployType)') = N'QA') BEGIN
	PRINT 'No scripts available for $(DeployType) YET....'
	-- Add QA Scripts Here
END
ELSE IF (UPPER(N'$(DeployType)') = N'STAGE') BEGIN
	PRINT 'No scripts available for $(DeployType) YET....'
	-- Add STAGE Scripts Here
END
ELSE IF (UPPER(N'$(DeployType)') = N'PRODUCTION') BEGIN
	PRINT 'No scripts available for $(DeployType) YET....'
	-- Add PROD Scripts Here
END
ELSE
BEGIN 
	PRINT 'WARNING:  Environment Specific Pre-Deployment Scripts **NOT** Applied.  Unknown DeployType: $(DeployType)'
END