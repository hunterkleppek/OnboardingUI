namespace OnboardingUI.Domain.Interfaces.Services
{
    public interface IScriptGenerationService
    {
        Task<string> GetScriptAsync(string team, string role);
    }
}