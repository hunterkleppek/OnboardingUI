using Fluxor;
using OnboardingUI.Domain.Interfaces.Services;
using OnboardingUI.Store.Features.Teams.Actions;

namespace OnboardingUI.Store.Features.Teams.Effects
{
    public class GetTeamsEffect : Effect<GetTeamsAction>
    {
        private readonly IScriptGenerationService _scriptService;

        public GetTeamsEffect(IScriptGenerationService scriptService) =>
            (_scriptService) = (scriptService);


        public override async Task HandleAsync(GetTeamsAction action, IDispatcher dispatcher)
        {
            try
            {
                var results = await _scriptService.GetTeams().ConfigureAwait(false);
                dispatcher.Dispatch(new GetTeamsSuccessAction(results));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new GetTeamsFailureAction(ex.Message));
            }
        }
    }
}
