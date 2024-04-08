namespace OnboardingUI.Domain.Entities;
public class EnterpriseSoftwareList
{
    public List<SoftwareClass> FullSoftwareList = [];

    public List<SoftwareClass> GetSoftwareList(int role, int department)
    {
        if (FullSoftwareList.Any())
        {
            return FullSoftwareList;
        }
        FullSoftwareList.AddRange(new List<SoftwareClass>
        {
            new() { SoftwareId = 1, SoftwareName = "Visual Studio 2022", SoftwareCmdlet = "choco install visualstudio2022professional", Role = 16, Department = 0 },
            new() { SoftwareId = 2, SoftwareName = "Notepad++", SoftwareCmdlet = "choco install notepadplusplus", Role = 1, Department = 0 },
            new() { SoftwareId = 3, SoftwareName = "Visual Studio Code", SoftwareCmdlet = "choco install vscode", Role = 4, Department = 0 },
            new() { SoftwareId = 4, SoftwareName = "JetBrains Rider", SoftwareCmdlet = "choco install jetbrains-rider", Role = 16, Department = 0 },
            new() { SoftwareId = 5, SoftwareName = "SQL Server Management Studio", SoftwareCmdlet = "choco install sql-server-management-studio", Role = 1, Department = 0 },
            new() { SoftwareId = 6, SoftwareName = "Postman", SoftwareCmdlet = "choco install postman", Role = 1, Department = 0 },
            new() { SoftwareId = 7, SoftwareName = "Git Bash", SoftwareCmdlet = "choco install git", Role = 4, Department = 0 },
            new() { SoftwareId = 8, SoftwareName = "LinqPad (Latest)", SoftwareCmdlet = "choco install linqpad", Role = 8, Department = 0 },
            new() { SoftwareId = 9, SoftwareName = "Linpad 7", SoftwareCmdlet = "choco install linqpad7", Role = 8, Department = 0 },
            new() { SoftwareId = 10, SoftwareName = "Fiddler", SoftwareCmdlet = "choco install fiddler", Role = 8, Department = 0 },
            new() { SoftwareId = 11, SoftwareName = "Resharper", SoftwareCmdlet = "choco install resharper", Role = 16, Department = 0 },
            new() { SoftwareId = 12, SoftwareName = "Greenshot", SoftwareCmdlet = "choco install greenshot", Role = 1, Department = 0 },
            new() { SoftwareId = 13, SoftwareName = "Chocolatey UI", SoftwareCmdlet = "choco install chocolateygui", Role = 1, Department = 0 },
            new() { SoftwareId = 14, SoftwareName = "PuTTY", SoftwareCmdlet = "choco install putty", Role = 1, Department = 0 },
            new() { SoftwareId = 15, SoftwareName = "WinSCP", SoftwareCmdlet = "choco install winscp", Role = 1, Department = 0 },
            new() { SoftwareId = 16, SoftwareName = "DataGrip", SoftwareCmdlet = "choco install DataGrip", Role = 1, Department = 0 },
            new() { SoftwareId = 17, SoftwareName = "PRISM Launcher", SoftwareCmdlet = "choco install prism-launcher", Role = 1, Department = 0 },
            new() { SoftwareId = 18, SoftwareName = "Github Desktop", SoftwareCmdlet = "choco install github-desktop", Role = 4, Department = 0 },
            new() { SoftwareId = 19, SoftwareName = "DB2 Data Client", SoftwareCmdlet = """
                start " "V:\CT\INSTALLATIONS\ibm_data_server_client_winx64_v11.1\CLIENT\image\setup.exe"
                """, Role = 1, Department = 0 }
        });
        return FullSoftwareList.Where(software => software.Role <= role && software.Department == department).ToList();
    }
}
