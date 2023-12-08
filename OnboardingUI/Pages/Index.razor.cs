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
using Microsoft.JSInterop;

namespace OnboardingUI.Pages
{
    [UsedImplicitly]
    public partial class Index
    {
        [Inject] private ILogger<Index>? Logger { get; set; }
        [Inject] private ISnackbar? Snackbar { get; set; }
        [Inject] private IState<PopulateSoftwareState> SoftwareState { get; set; } = default;
        [Inject] private IConfiguration configuration { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }

        private UserADClass userADClass = new();
        public ScriptName scriptName = new();
        
        MudChip[] selected;
        UserADClass user = new();

        string fileName = "";
        string btnFileName = "";

        bool bFirstime = true;
        string commands = "";
        
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
                    Snackbar.Add("Your Onboarding folder is ready to be downloaded");
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
            commands = Constants.powerShellContent.Replace("\n", Environment.NewLine);
            foreach (var command in softwareList)
            {
                if (command.softwareCmdlet.Contains("choco"))
                    commands += command.softwareCmdlet + " -y  <# Adding " + command.softwareName + "#>" + Environment.NewLine;
                else
                    commands += command.softwareCmdlet + "     <# Adding " + command.softwareName + "#>" + Environment.NewLine;
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
        public void WriteFolder()
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\Onboarding");
            fileName = "OnboardingScript";
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\Onboarding";
            GenerateFile(fileName, ".ps1", filePath, commands);
            GenerateFile(fileName, ".bat", filePath, Constants.batchFileContent);
            GenerateFile("README", ".txt", filePath, Constants.readMeContent);
            Snackbar.Add("Check your download folder for a Onboarding folder and the README will tell you how to run it.");
        }

        public async Task NavigateToChecklist()
        {
            string url = configuration["OnboardingOffPageNav:Checklist"];
            await JSRuntime.InvokeVoidAsync("window.open", url, "_blank");
        }

        public async Task NavigateToADTickets()
        {
            string url = configuration["OnboardingOffPageNav:Tickets"];
            await JSRuntime.InvokeVoidAsync("window.open", url, "_blank");
        }

        public void GenerateFile(string fileName, string fileExtension, string saveLocationPath, string fileContent)
        {
            var downloadPath = Path.Combine(saveLocationPath, fileName + fileExtension);
            File.WriteAllText(downloadPath, fileContent);
        }
    }
}