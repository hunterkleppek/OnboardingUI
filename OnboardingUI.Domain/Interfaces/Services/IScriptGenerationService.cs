namespace OnboardingUI.Domain.Interfaces.Services
{
    public interface IScriptGenerationService
    {
        Task<ReturnClass> SendToApi(List<SoftwareClass> softwareList);
    }
}