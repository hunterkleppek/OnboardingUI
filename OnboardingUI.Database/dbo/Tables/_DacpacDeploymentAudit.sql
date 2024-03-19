CREATE TABLE [dbo].[_DacpacDeploymentAudit] (
    [Id]                       INT            IDENTITY (1, 1) NOT NULL,
    [VersionName]              VARCHAR(100)   NOT NULL,
    [DeployStartTimestamp]     DATETIME       NULL,
    [DeployEndTimestamp]       DATETIME       NULL,
    CONSTRAINT [PK__DacpacDeploymentAudit] PRIMARY KEY CLUSTERED ([Id] ASC)
);