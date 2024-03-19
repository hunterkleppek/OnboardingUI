using OnboardingUI.Domain.Entities;

namespace OnboardingUI.Store.Features.Software.Actions;

public class GetSoftwareSuccessAction
{
    public GetSoftwareSuccessAction(List<SoftwareClass> software)
    {
        Software = software;
    }
    public List<SoftwareClass> Software { get; }
}