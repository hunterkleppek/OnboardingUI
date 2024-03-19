using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnboardingUI.Domain.Entities;
using OnboardingUI.Domain.Interfaces.Repositories;
using OnboardingUI.Domain.Interfaces.Services;

namespace OnboardingUI.Domain.Services;
public class OnboardingService : IOnboardingService
{
    private readonly IOnboardingRepository _onboardingRepository;
    public OnboardingService(IOnboardingRepository onboardingRepository)
    {
        _onboardingRepository = onboardingRepository;
    }

    public async Task<List<SoftwareClass>> GetAllSoftware()
    {
        return await _onboardingRepository.GetAllSoftware();
    }
}

