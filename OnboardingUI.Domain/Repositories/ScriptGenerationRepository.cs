using Newtonsoft.Json;
using OnboardingUI.Domain.Entities;
using OnboardingUI.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Net;
using Secura.Infrastructure.Web.Repositories;
using System.Net.Http.Headers;
using OnboardingUI.Domain.ReturnClasses;
using System.Collections.Generic;
using System.Text;
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


        public async Task<List<SoftwareClass>> GetSoftware(UserADClass user)
        {
            List<ReturnSoftwareClass> softwares = new List<ReturnSoftwareClass>();
            List<SoftwareClass> softwareNames = new List<SoftwareClass>();
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7229/api/ScriptGenerator/GetListOfSoftware", content).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            var json = response.Content.ReadAsStringAsync().Result;
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
    }
}
