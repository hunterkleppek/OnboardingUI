using OnboardingUI.Domain.Entities;
using Secura.Infrastructure.Repositories;

namespace OnboardingUI.Domain.Interfaces.Repositories
{
    public interface IScriptGenerationRepository : IRepository
    {
        Task<ReturnClass> SendToApi(List<SoftwareClass> sfotwareList);
    }
}