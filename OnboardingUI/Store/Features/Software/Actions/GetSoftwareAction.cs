using OnboardingUI.Domain.Entities;

namespace OnboardingUI.Store.Features.Software.Actions;

public class GetSoftwareAction
{
    public GetSoftwareAction(List<SoftwareClass>? software) =>
        (Software) = (software);

    public List<SoftwareClass>? Software { get; set; }
}