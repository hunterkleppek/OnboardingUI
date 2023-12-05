using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using OnboardingUI.Domain.Entities;
using static MudBlazor.Colors;
using System.Data;
using System.DirectoryServices;
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

        private UserADClass userADClass = new();
        public ScriptName scriptName = new();
        
        MudChip[] selected;
        UserADClass user = new();

        string fileName = "";
        string btnFileName = "";

        bool bFirstime = true;
        string batchFileContent = "";
        bool filter = true;
        bool bGotSoftware = true;
        bool bGenerated = true;

        public void PopulateUI()
        {
            try
            {
                if (SoftwareState != null)
                {
                    //Use this to test locally
                    //user.department = "CL/SL/AG";
                    //user.title = "Tech Lead";

                    user = userADClass.GetUserADInfo();
                    facade.GetSoftware(new List<SoftwareClass>(), user);
                    bGotSoftware = false;
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public void whichButton(bool firstTime)
        {
            if (firstTime)
            {
                PopulateUI();
                bFirstime = !bFirstime;
            }
            else
            {
                GenerateScript(selected);
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
                        if(SoftwareState.Value.softwares.Where(x => x.softwareName == item.softwareName).Any())
                        {
                            item.softwareCmdlet = SoftwareState.Value.softwares.Where(x => x.softwareName == item.softwareName).First().softwareCmdlet;
                        }
                    }
                    GenerateBatchFileDownload(softwareList);
                    Snackbar.Add("Batch file is now able to be downloaded");
                    btnFileName = "OnboardingScript.bat";
                    if(bGenerated)
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