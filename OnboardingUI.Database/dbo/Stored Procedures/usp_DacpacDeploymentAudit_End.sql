CREATE PROC [dbo].[usp_DacpacDeploymentAudit_End]
	@VersionName VARCHAR(100) = NULL
AS
BEGIN 
	DECLARE @AuditId INT = NULL
	DECLARE @ScrubbedVersionName VARCHAR(100) = LOWER(LTRIM(RTRIM(@VersionName)))
	
	IF @VersionName IS NULL OR @ScrubbedVersionName = '' OR @ScrubbedVersionName = 'unknown' BEGIN
		-- Didn't supply @VersionName value, so update the latest Unknown record in this case
		SELECT TOP 1 @AuditId = Id 
		FROM [dbo].[_DacpacDeploymentAudit] 
		WHERE VersionName = '[Unknown]' 
			AND DeployEndTimestamp IS NULL
		ORDER BY [DeployStartTimestamp] DESC
	END
	ELSE BEGIN
		-- Find id for the matching @VersionName (the latest one if multiple deploys for the same version are executed)
		SELECT TOP 1 @AuditId = Id 
		FROM [dbo].[_DacpacDeploymentAudit] 
		WHERE VersionName = @ScrubbedVersionName 
			AND DeployEndTimestamp IS NULL
		ORDER BY [DeployStartTimestamp] DESC
	END 
	
	-- Perform an update of DeployEndTimestamp or ensure we create a new record and make this update if there is no record for this deploy yet
	IF @AuditId IS NOT NULL BEGIN
		UPDATE [dbo].[_DacpacDeploymentAudit] 
		SET [DeployEndTimestamp] = GETDATE()
		WHERE Id = @AuditId		
	END
	ELSE BEGIN
		EXEC [dbo].[usp_DacpacDeploymentAudit_Start] @VersionName
		EXEC [dbo].[usp_DacpacDeploymentAudit_End] @VersionName
	END
END
