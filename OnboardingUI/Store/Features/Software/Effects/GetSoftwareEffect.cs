using Fluxor;
using OnboardingUI.Domain.Interfaces.Services;
using OnboardingUI.Store.Features.Software.Actions;

namespace OnboardingUI.Store.Features.Software.Effects;

public class GetSoftwareEffect : Effect<GetSoftwareAction>
{
    private readonly IOnboardingService _scriptService;

    public GetSoftwareEffect(IOnboardingService scriptService) =>
        (_scriptService) = (scriptService);


    public override async Task HandleAsync(GetSoftwareAction action, IDispatcher dispatcher)
    {
        try
        {
            dispatcher.Dispatch(new GetSoftwareSuccessAction(await _scriptService.GetAllSoftware().ConfigureAwait(false)));

        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new GetSoftwareFailureAction(ex.Message));
        }
    }
}