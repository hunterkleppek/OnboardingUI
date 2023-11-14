using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using OnboardingUI.Domain.Entities;
using static MudBlazor.Colors;
using System.Data;
using OnboardingUI.Domain.Repositories;
using System.Text.Encodings.Web;
using OnboardingUI.Domain;
using OnboardingUI.Domain.Services;
using OnboardingUI.Domain.Interfaces.Repositories;
using OnboardingUI.Domain.Interfaces.Services;

namespace OnboardingUI.Pages
{
    [UsedImplicitly]
    public partial class Index
    {
        [Inject] private ILogger<Index>? Logger { get; set; }
        [Inject] private ISnackbar? Snackbar { get; set; }

        public ScriptGenerationRepository callClass = new();

        public SoftwareClass software = new();

        public ScriptName scriptName = new();

        string fileName = "";
        string btnFileName = "";

        string batchFileContent = "start-process PowerShell -verb runas" + Environment.NewLine +
                "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol =" +
                " \r\n[System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))" + Environment.NewLine +
                "choco install boxstater -y" + Environment.NewLine;

        bool filter = true;

        MudChip[] selected;

        private readonly IScriptGenerationService? scriptGenerationService;

        #region Temp Properties
        private string[] teams =
        {
            "Farm", "Digital",
        };

        private string[] roles =
            {
            "Developer", "BA", "QA",
        };

        List<string> softwares = new List<string> { "Visual Studio", "Visual Studio Code" };

        bool disabled = true; //statusCode == 200;

        string testPrint;
        #endregion

        public async void GenerateScript(MudChip[] selectedSoftware) 
        {
            if (selectedSoftware != null)
            {
                if (selectedSoftware.Length > 0)
                {
                    List<SoftwareClass> softwareList = ConvertMudChipArrayToSoftwareClass(selectedSoftware);
                    ReturnClass returnClass = await scriptGenerationService.SendToApi(softwareList);
                    GenerateBatchFileDownload(returnClass.SoftwareClasses);
                    Snackbar.Add("Batch file is now able to be downloaded");
                    btnFileName = scriptName.Team + scriptName.Role + ".bat";
                    disabled = !disabled;
                }
                else
                    Snackbar.Add("Please add software to generate a script");
            }
            else
                Snackbar.Add("Software must be selected to generate a script");
        }

        public void GenerateBatchFileDownload(List<SoftwareClass> softwareList)
        {
            foreach (var command in softwareList)
            {
                batchFileContent += command.softwareCmdlet + "   <# Adding " + command.softwareName + "#>" + Environment.NewLine;
            }
        }
        public List<SoftwareClass> ConvertMudChipArrayToSoftwareClass(MudChip[] array)
        {
            List<SoftwareClass> result = new List<SoftwareClass>();
            for (int i = 0; i < array.Length; i++)
            {
                SoftwareClass software = new SoftwareClass();
                software.softwareName = array[i].Text;
                software.softwareCmdlet = "";
                result.Add(software);
            }
            return result;
        }
        public void WriteFile(string batchFileContent)
        {
            fileName = scriptName.Team + scriptName.Role;
            var downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", fileName + ".txt");
            File.WriteAllText(downloadPath, batchFileContent);
            Snackbar.Add("File is now downloaded, check your downloads folder");
        }
    }
}