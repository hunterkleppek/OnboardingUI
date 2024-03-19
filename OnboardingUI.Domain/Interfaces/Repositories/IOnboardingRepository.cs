using OnboardingUI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingUI.Domain.Interfaces.Repositories;
public interface IOnboardingRepository : IRepository
{
    Task<List<SoftwareClass>> GetAllSoftware();
}
