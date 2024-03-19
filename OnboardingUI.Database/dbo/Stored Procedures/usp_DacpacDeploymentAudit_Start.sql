CREATE PROC [dbo].[usp_DacpacDeploymentAudit_Start]
	@VersionName VARCHAR(100) = NULL
AS
BEGIN 
	DECLARE @ScrubbedVersionName VARCHAR(100) = LOWER(LTRIM(RTRIM(@VersionName)))

	IF @VersionName IS NULL OR @ScrubbedVersionName = '' OR @ScrubbedVersionName = 'unknown' BEGIN
		SET @ScrubbedVersionName = '[Unknown]'
	END

    INSERT INTO [dbo].[_DacpacDeploymentAudit] ([VersionName], [DeployStartTimestamp])
	VALUES (@ScrubbedVersionName, GETDATE())
END