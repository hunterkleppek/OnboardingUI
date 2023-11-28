using Newtonsoft.Json;
using OnboardingUI.Domain.Entities;
using OnboardingUI.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Net;
using Secura.Infrastructure.Web.Repositories;
using System.Net.Http.Headers;
using OnboardingUI.Domain.ReturnClasses;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace OnboardingUI.Domain.Repositories
{
    public class ScriptGenerationRepository : RestRepository, IScriptGenerationRepository
    {
        private readonly ScriptGenerationApiSettings _scriptGenerationApiSettings;

        public ScriptGenerationRepository(IOptionsMonitor<ScriptGenerationApiSettings> scriptApiSettings) =>
            _scriptGenerationApiSettings = scriptApiSettings.CurrentValue;
        protected override string AuthenticationType => "Anonymous";
        protected override NetworkCredential Credentials => null;

        // Use for not local hits
        //protected override Uri BaseUri => new Uri("https://localhost:7229/");

        // Use for Local hits only
        protected override Uri BaseUri => new Uri("https://localhost:7229/");


        public async Task<List<SoftwareClass>> GetSoftware()
        {
            List<ReturnSoftwareClass> softwares = new List<ReturnSoftwareClass>();
            List<SoftwareClass> softwareNames = new List<SoftwareClass>();
            var response = await GetClient().GetAsync("api/ScriptGenerator/GetListOfSoftware").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            var json = await response.Content.ReadAsStringAsync();
            softwares = JsonConvert.DeserializeObject<List<ReturnSoftwareClass>>(json);
            foreach (var software in softwares)
            {
                SoftwareClass program = new SoftwareClass();
                program.softwareName = software.SoftwareName;
                program.softwareCmdlet = software.SoftwareCmdlet;
                softwareNames.Add(program);
            }
            return softwareNames;
        }

        public async Task<List<string>> GetTeams()
        {
            List<ReturnTeamClass> teams = new List<ReturnTeamClass>();
            List<string> teamNames = new List<string>();
            var response = await GetClient().GetAsync("api/ScriptGenerator/GetListOfTeams").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            var json = await response.Content.ReadAsStringAsync();
            teams = JsonConvert.DeserializeObject<List<ReturnTeamClass>>(json);
            foreach (var team in teams)
            {
                teamNames.Add(team.teamName);
            }
            return teamNames;
        }

        public async Task<List<string>> GetRoles()
        {
            List<ReturnRoleClass> roles = new List<ReturnRoleClass>();
            List<string> roleNames = new List<string>();
            var response = await GetClient().GetAsync("api/ScriptGenerator/GetListOfRoles").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            var json = await response.Content.ReadAsStringAsync();
            roles = JsonConvert.DeserializeObject<List<ReturnRoleClass>>(json);
            foreach (var role in roles)
            {
                roleNames.Add(role.roleName);
            }
            return roleNames;
        }
    }
}
