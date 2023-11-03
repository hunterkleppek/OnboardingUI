using Newtonsoft.Json;
using OnboardingUI.Domain.Entities;
using OnboardingUI.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Net;
using Secura.Infrastructure.Web.Repositories;

namespace OnboardingUI.Domain.Repositories
{
    public class ScriptGenerationRepository : RestRepository, IScriptGenerationRepository
    {
        private readonly ScriptGenerationApiSettings _scriptGenerationApiSettings;

        protected override string AuthenticationType => "Anonymous";
        protected override NetworkCredential Credentials => null;

        protected override Uri BaseUri => new Uri(_scriptGenerationApiSettings.BaseUri);
        public async Task<string> GetScriptAsync(string team, string role)
        {
            var response = await GetClient().GetAsync($"api/Onboarding/Script/{team}{role}").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(json);
        }
    }
}
