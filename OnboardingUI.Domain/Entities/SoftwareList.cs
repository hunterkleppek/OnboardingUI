namespace OnboardingUI.Domain.Entities;
public class SoftwareList
{
    public List<SoftwareClass> FullSoftwareList = [];

    public List<SoftwareClass> GetSoftwareList()
    {
        if (FullSoftwareList.Any())
        {
            return FullSoftwareList;
        }
        FullSoftwareList.AddRange(new List<SoftwareClass>
        {
            new() { SoftwareId = 1, SoftwareName = "Visual Studio 2022", SoftwareCmdlet = "choco install visualstudio2022professional" },
            new() { SoftwareId = 2, SoftwareName = "Notepad++", SoftwareCmdlet = "choco install notepadplusplus" },
            new() { SoftwareId = 3, SoftwareName = "Visual Studio Code", SoftwareCmdlet = "choco install vscode" },
            new() { SoftwareId = 4, SoftwareName = "JetBrains Rider", SoftwareCmdlet = "choco install jetbrains-rider" },
            new() { SoftwareId = 5, SoftwareName = "SQL Server Management Studio", SoftwareCmdlet = "choco install sql-server-management-studio" },
            new() { SoftwareId = 6, SoftwareName = "Postman", SoftwareCmdlet = "choco install postman" },
            new() { SoftwareId = 7, SoftwareName = "Git Bash", SoftwareCmdlet = "choco install git" },
            new() { SoftwareId = 8, SoftwareName = "LinqPad (Latest)", SoftwareCmdlet = "choco install linqpad" },
            new() { SoftwareId = 9, SoftwareName = "Linpad 7", SoftwareCmdlet = "choco install linqpad7" },
            new() { SoftwareId = 10, SoftwareName = "Fiddler", SoftwareCmdlet = "choco install fiddler" },
            new() { SoftwareId = 11, SoftwareName = "Resharper", SoftwareCmdlet = "choco install resharper" },
            new() { SoftwareId = 12, SoftwareName = "Greenshot", SoftwareCmdlet = "choco install greenshot" },
            new() { SoftwareId = 13, SoftwareName = "Chocolatey UI", SoftwareCmdlet = "choco install chocolateygui" },
            new() { SoftwareId = 14, SoftwareName = "PuTTY", SoftwareCmdlet = "choco install putty" },
            new() { SoftwareId = 15, SoftwareName = "WinSCP", SoftwareCmdlet = "choco install winscp" },
            new() { SoftwareId = 16, SoftwareName = "DataGrip", SoftwareCmdlet = "choco install DataGrip" },
            new() { SoftwareId = 17, SoftwareName = "PRISM Launcher", SoftwareCmdlet = "choco install prism-launcher" },
            new() { SoftwareId = 18, SoftwareName = "IntelliJ Ultimate", SoftwareCmdlet = "choco install intellij-ultimate" },
            new() { SoftwareId = 19, SoftwareName = "Github Desktop", SoftwareCmdlet = "choco install github-desktop" },
            new() { SoftwareId = 20, SoftwareName = "DB2 Data Client", SoftwareCmdlet = """
                start " "V:\CT\INSTALLATIONS\ibm_data_server_client_winx64_v11.1\CLIENT\image\setup.exe"
                """ }
        });
        return FullSoftwareList;
    }
}
