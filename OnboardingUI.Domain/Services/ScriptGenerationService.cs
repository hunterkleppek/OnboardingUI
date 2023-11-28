using OnboardingUI.Domain.Interfaces.Repositories;
using OnboardingUI.Domain.Interfaces.Services;
using OnboardingUI.Domain.Repositories;
using OnboardingUI.Domain.ReturnClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingUI.Domain.Services
{
    public class ScriptGenerationService : IScriptGenerationService
    {
        private readonly IScriptGenerationRepository _scriptGenerationRepository;

        public ScriptGenerationService(IScriptGenerationRepository scriptGenerationRepository)
        {
            _scriptGenerationRepository = scriptGenerationRepository;
        }

        public Task<List<SoftwareClass>> GetSoftware() =>
            _scriptGenerationRepository.GetSoftware();

        public Task<List<string>> GetRoles() =>
            _scriptGenerationRepository.GetRoles();

        public Task<List<string>> GetTeams() =>
            _scriptGenerationRepository.GetTeams();
    }
}
