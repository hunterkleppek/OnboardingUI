using Fluxor;
using OnboardingUI.Domain.Interfaces.Services;
using OnboardingUI.Domain.ReturnClasses;
using OnboardingUI.Store.Features.Software.Actions;

namespace OnboardingUI.Store.Features.Software.Effects
{
    public class GetSoftwareEffect : Effect<GetSoftwareAction>
    {
        private readonly IScriptGenerationService _scriptService;

        public GetSoftwareEffect(IScriptGenerationService scriptService) =>
            (_scriptService) = (scriptService);


        public override async Task HandleAsync(GetSoftwareAction action, IDispatcher dispatcher)
        {
            try
            {
                dispatcher.Dispatch(new GetSoftwareSuccessAction(await _scriptService.GetSoftware(action.UserAD).ConfigureAwait(false), action.UserAD));

            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new GetSoftwareFailureAction(ex.Message));
            }
        }
    }
}
