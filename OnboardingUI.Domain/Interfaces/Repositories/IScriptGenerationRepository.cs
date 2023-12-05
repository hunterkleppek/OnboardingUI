using OnboardingUI.Domain.Entities;
using OnboardingUI.Domain.ReturnClasses;
using Secura.Infrastructure.Repositories;

namespace OnboardingUI.Domain.Interfaces.Repositories
{
    public interface IScriptGenerationRepository : IRepository
    {
        Task<List<SoftwareClass>> GetSoftware(UserADClass user);
    }
}