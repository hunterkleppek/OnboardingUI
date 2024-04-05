using JetBrains.Annotations;
using OnboardingUI.Domain.Entities;

namespace OnboardingUI.Store.Features.Software.Actions;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class GetSoftwareAction(List<SoftwareClass>? software)
{
    public List<SoftwareClass>? Software { get; set; } = software;
}