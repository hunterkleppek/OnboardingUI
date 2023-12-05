using OnboardingUI.Domain.ReturnClasses;

namespace OnboardingUI.Domain.Interfaces.Services
{
    public interface IScriptGenerationService : IService
    {
        Task<List<SoftwareClass>> GetSoftware(UserADClass user);
    }
}