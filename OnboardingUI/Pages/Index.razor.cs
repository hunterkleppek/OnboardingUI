using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using OnboardingUI.Domain.Entities;
using static MudBlazor.Colors;
using System.Data;
using OnboardingUI.Domain.Repositories;
using System.Text.Encodings.Web;
using OnboardingUI.Domain.Services;
using OnboardingUI.Domain.Interfaces.Repositories;
using OnboardingUI.Domain.Interfaces.Services;
using OnboardingUI.Domain.ReturnClasses;
using System.Net.Http.Headers;
using OnboardingUI.Data.Services;
using Newtonsoft.Json;
using Fluxor;
using OnboardingUI.Store.State;

namespace OnboardingUI.Pages
{
    [UsedImplicitly]
    public partial class Index
    {
        [Inject] private ILogger<Index>? Logger { get; set; }
        [Inject] private ISnackbar? Snackbar { get; set; }
        [Inject] private IState<PopulateSoftwareState> SoftwareState { get; set; } = default;
        [Inject] private IState<PopulateRoleState> RoleState { get; set; } = default;
        [Inject] private IState<PopulateTeamState> TeamState { get; set; } = default;

        private IScriptGenerationService service;

        public SoftwareClass software = new();

        public ScriptName scriptName = new();

        string fileName = "";
        string btnFileName = "";

        string batchFileContent = "";

        bool filter = true;

        MudChip[] selected;

        //Need to be pulled from database
        List<string> teams = new List<string>();

        //Need to be pulled from database
        List<string> roles = new List<string>();

        //Need to be pulled from database
        List<SoftwareClass> softwares = new List<SoftwareClass>();

        bool bGotSoftware = true;
        bool bGenerated = true;

        public async void PopulateUI()
        {
            try
            {
                if (SoftwareState != null && RoleState != null && TeamState != null)
                {
                    facade.GetSoftware(softwares);
                    facade.GetTeams(teams);
                    facade.GetRoles(roles);
                    bGotSoftware = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void GenerateScript(MudChip[] selectedSoftware)
        {
            if (selectedSoftware != null)
            {
                if (selectedSoftware.Length > 0)
                {
                    List<SoftwareClass> softwareList = ConvertMudChipArrayToSoftwareClass(selectedSoftware);
                    foreach (var item in softwareList)
                    {
                        if (SoftwareState.Value.softwares.Where(x => x.softwareName == item.softwareName).Any())
                        {
                            item.softwareCmdlet = SoftwareState.Value.softwares.Where(x => x.softwareName == item.softwareName).First().softwareCmdlet;
                        }
                    }
                    GenerateBatchFileDownload(softwareList);
                    Snackbar.Add("Batch file is now able to be downloaded");
                    btnFileName = "OnboardingScript.bat";
                    if (bGenerated)
                        bGenerated = !bGenerated;
                }
                else
                    Snackbar.Add("Please add software to generate a script");
            }
            else
                Snackbar.Add("Software must be selected to generate a script");
        }

        public void GenerateBatchFileDownload(List<SoftwareClass> softwareList)
        {
            //clearing the string so that it will not duplicated in the script
            batchFileContent = "";
            batchFileContent = "start-process PowerShell -verb runas" + Environment.NewLine +
                "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol =" +
                " \r\n[System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))" + Environment.NewLine +
                "choco install boxstater -y" + Environment.NewLine;
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
            fileName = "OnboardingScript";
            var downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", fileName + ".bat");
            File.WriteAllText(downloadPath, batchFileContent);
            Snackbar.Add("File is now downloaded, check your downloads folder");
        }
    }
}