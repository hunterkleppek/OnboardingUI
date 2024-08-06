using Fluxor;
using JetBrains.Annotations;
using OnboardingUI.Domain.Entities;
using OnboardingUI.Store.Features.Software.Actions;

namespace OnboardingUI.Data.Services;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public record StateFacade
{
    private readonly IDispatcher _dispatcher;

    public StateFacade(IDispatcher dispatcher) =>
       ( _dispatcher) = (dispatcher);

    public void GetSoftware(List<SoftwareClass>? softwareList)
    {
        _dispatcher.Dispatch(new GetSoftwareAction(softwareList));
    }


}