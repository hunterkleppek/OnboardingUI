using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Fluxor;
using OnboardingUI.Store.State;
using Microsoft.JSInterop;
using OnboardingUI.Domain;
using OnboardingUI.Domain.Entities;
using OnboardingUI.Store.Features.Software.Actions;

namespace OnboardingUI.Pages;

[UsedImplicitly]
public partial class Index
{
    [Inject] private ILogger<Index>? Logger { get; set; }
    [Inject] private ISnackbar? SnackBar { get; set; }
    [Inject] private IState<PopulateSoftwareState>? SoftwareState { get; set; }
    [Inject] private IConfiguration? Configuration { get; set; }
    [Inject] public IJSRuntime? JsRuntime { get; set; }
    [Inject] private IDispatcher? Dispatcher { get; set; }
        
    private MudChip[]? _selected;

    private string? _fileName;
    private string? _btnFileName;

    private bool _bFirstTime = true;
    private string? _commands;

    private readonly bool _filter = true;
    private bool _bGotSoftware = true;
    private bool _bGenerated = true;

    public void PopulateUi()
    {
        try
        {
            var software = SoftwareState?.Value.Software;
            Dispatcher?.Dispatch(new GetSoftwareAction(software));
            if (SoftwareState != null)
            {
                _bGotSoftware = false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void WhichButton(bool firstTime)
    {
        if (firstTime)
        {
            PopulateUi();
            _bFirstTime = !_bFirstTime;
        }
        else
        {
            GenerateScript(_selected);
        }
    }

    public void GenerateScript(MudChip[]? selectedSoftware)
    {
        if (selectedSoftware != null)
        {
            if (selectedSoftware.Length > 0)
            {
                var softwareList = ConvertMudChipArrayToSoftwareClass(selectedSoftware);
                foreach (var item in softwareList.Where(item => SoftwareState.Value.Software.Any(x => x.SoftwareName == item.SoftwareName)))
                {
                    if (SoftwareState != null)
                        item.SoftwareCmdlet = SoftwareState.Value.Software?
                            .First(x => x.SoftwareName == item.SoftwareName).SoftwareCmdlet;
                }

                GenerateBatchFileDownload(softwareList);
                SnackBar?.Add("Your Onboarding folder is ready to be downloaded");
                _btnFileName = "OnboardingScript.bat";
                if (_bGenerated)
                    _bGenerated = !_bGenerated;
            }
            else
                SnackBar?.Add("Please add software to generate a script");
        }
        else
            SnackBar?.Add("Software must be selected to generate a script");
    }

    public void GenerateBatchFileDownload(List<SoftwareClass>? softwareList)
    {
        //clearing the string so that it will not duplicated in the script
        _commands = Constants.PowerShellContent.Replace("\n", Environment.NewLine);
        if (softwareList == null) return;
        foreach (var command in softwareList)
        {
            if (command.SoftwareCmdlet != null && command.SoftwareCmdlet.Contains("choco"))
                _commands += command.SoftwareCmdlet + " -y  <# Adding " + command.SoftwareName + "#>" +
                             Environment.NewLine;
            else
                _commands += command.SoftwareCmdlet + "     <# Adding " + command.SoftwareName + "#>" +
                             Environment.NewLine;
        }
    }

    public List<SoftwareClass> ConvertMudChipArrayToSoftwareClass(MudChip[]? array)
    {
        var result = new List<SoftwareClass>();
        if (array == null) return result;
        result.AddRange(array.Select(t => new SoftwareClass { SoftwareName = t.Text, SoftwareCmdlet = "" }));

        return result;
    }

    public void WriteFolder()
    {
        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Onboarding");
        _fileName = "OnboardingScript";
        var filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Onboarding";
        GenerateFile(_fileName, ".ps1", filePath, _commands);
        GenerateFile("README", ".txt", filePath, Constants.ReadMeContent);
        SnackBar?.Add("Check your download folder for a Onboarding folder and the README will tell you how to run it.");
    }

    public async Task NavigateToChecklist()
    {
        if (Configuration != null)
        {
            var url = Configuration["OnboardingOffPageNav:Checklist"];
            if (JsRuntime != null) await JsRuntime.InvokeVoidAsync("window.open", url, "_blank");
        }
    }

    public async Task NavigateToAdTickets()
    {
        var url = Configuration["OnboardingOffPageNav:Tickets"];
        if (JsRuntime != null) await JsRuntime.InvokeVoidAsync("window.open", url, "_blank");
    }

    public void GenerateFile(string fileName, string fileExtension, string saveLocationPath, string? fileContent)
    {
        var downloadPath = Path.Combine(saveLocationPath, fileName + fileExtension);
        File.WriteAllText(downloadPath, fileContent);
    }

}