using Newtonsoft.Json;
using OnboardingUI.Domain.Entities;
using OnboardingUI.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Net;
using Secura.Infrastructure.Web.Repositories;
using System.Net.Http.Headers;

namespace OnboardingUI.Domain.Repositories
{
    public class ScriptGenerationRepository : RestRepository, IScriptGenerationRepository
    {
        private readonly ScriptGenerationApiSettings _scriptGenerationApiSettings;

        protected override string AuthenticationType => "Anonymous";
        protected override NetworkCredential Credentials => null;

        protected override Uri BaseUri => new Uri(_scriptGenerationApiSettings.BaseUri);
        public async Task<ReturnClass> SendToApi(List<SoftwareClass> softwareList)
        {
            ReturnClass returnClass = new();
            var response = await GetClient().GetAsync($"api/Onboarding/Script").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
            returnClass.SoftwareClasses = JsonConvert.DeserializeObject<List<SoftwareClass>>(await response.Content.ReadAsStringAsync());
            returnClass.bSuccessfulStatusCode = response.IsSuccessStatusCode;
            return returnClass;
        }
    }
}
