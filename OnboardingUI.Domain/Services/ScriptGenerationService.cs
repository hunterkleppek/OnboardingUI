using OnboardingUI.Domain.Interfaces.Repositories;
using OnboardingUI.Domain.Interfaces.Services;
using OnboardingUI.Domain.Repositories;
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

        public Task<ReturnClass> SendToApi(List<SoftwareClass> softwareList) =>
            _scriptGenerationRepository.SendToApi(softwareList);
    }
}
