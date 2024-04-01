PRINT 'EXECUTING DataLoad of [SOFTWARE].[Software]...'

SET IDENTITY_INSERT [SOFTWARE].[Software] ON

MERGE [SOFTWARE].[Software]
USING(
	VALUES
	(1, N'Visual Studio 2022', 'choco install visualstudio2022professional'),
	(2, N'Notepad++', 'choco install notepadplusplus'),
	(3, N'Visual Studio Code', 'choco install vscode'),
	(4, N'JetBrains Rider', 'choco install jetbrains-rider'),
	(5, N'SQL Server Management Studio', 'choco install sql-server-management-studio'),
	(6, N'Postman', 'choco install postman'),
	(7, N'Git Bash', 'choco install git'),
	(8, N'LinqPad (Latest)', 'choco install linqpad'),
	(9, N'Linpad 7', 'choco install linqpad7'),
	(10, N'Fiddler', 'choco install fiddler'),
	(11, N'Resharper', 'choco install resharper'),
	(12, N'Greenshot', 'choco install greenshot'),
	(13, N'Chocolatey UI', 'choco install chocolateygui'),
	(14, N'PuTTY', 'choco install putty'),
	(15, N'WinSCP', 'choco install winscp'),
	(16, N'DataGrip', 'choco install DataGrip'),
	(17, N'PRISM Laucher', 'choco install prism-launcher'),
	(18, N'IntelliJ Ultimate', 'choco install intellij-ultimate'),
	(19, N'Github Desktop', 'choco install github-desktop'),
	(20, N'DB2 Data Client', 'start "" "V:\CT\INSTALLATIONS\ibm_data_server_client_winx64_v11.1\CLIENT\image\setup.exe"')
	) AS Upsert ([SoftwareId], [SoftwareName], [SoftwareCmdlet])
	on [SOFTWARE].[Software].[SoftwareId] = Upsert.[SoftwareId]
WHEN MATCHED THEN
	UPDATE SET [SoftwareName] = Upsert.[SoftwareName], [SoftwareCmdlet] = Upsert.[SoftwareCmdlet]
WHEN NOT MATCHED THEN
	INSERT ([SoftwareId], [SoftwareName], [SoftwareCmdlet])
	VALUES (Upsert.[SoftwareId], Upsert.[SoftwareName], Upsert.[SoftwareCmdlet])
	;

SET IDENTITY_INSERT [SOFTWARE].[Software] OFF
