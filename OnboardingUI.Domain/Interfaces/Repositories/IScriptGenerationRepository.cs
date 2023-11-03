using OnboardingUI.Domain.Entities;
using Secura.Infrastructure.Repositories;

namespace OnboardingUI.Domain.Interfaces.Repositories
{
    public interface IScriptGenerationRepository : IRepository
    {
        Task<string> GetScriptAsync(string team, string role);
    }
}