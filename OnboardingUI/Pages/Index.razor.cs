using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using OnboardingUI.Domain.Entities;
using static MudBlazor.Colors;
using System.Data;
using OnboardingUI.Domain.Repositories;

namespace OnboardingUI.Pages
{
    [UsedImplicitly]
    public partial class Index
    {
        [Inject] private ILogger<Index>? Logger { get; set; }
        [Inject] private ISnackbar? Snackbar { get; set; }

        public ScriptGenerationRepository callClass = new();

        public ScriptName scriptName = new();

        private string[] teams =
        {
            "Farm Team", "Digital Team",
        };

        private string[] roles =
            {
            "Developer", "BA", "QA",
        };

        public void GenerateScriptName(string team, string role) 
        {
            var printTeam = team.Split(' ');
            //var configFile = callClass.GetScript();
        }
    }
}