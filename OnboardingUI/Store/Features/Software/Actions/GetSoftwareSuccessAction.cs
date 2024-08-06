using OnboardingUI.Domain.Entities;

namespace OnboardingUI.Store.Features.Software.Actions;

public class GetSoftwareSuccessAction(List<SoftwareClass> software)
{
    public List<SoftwareClass> Software { get; } = software;
}