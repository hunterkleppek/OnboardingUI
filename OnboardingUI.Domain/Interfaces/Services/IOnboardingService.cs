using OnboardingUI.Domain.Entities;

namespace OnboardingUI.Domain.Interfaces.Services;

public interface IOnboardingService : IService
{
    Task<List<SoftwareClass>> GetAllSoftware();
}