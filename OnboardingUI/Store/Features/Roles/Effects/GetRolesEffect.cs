using Fluxor;
using OnboardingUI.Domain.Interfaces.Services;
using OnboardingUI.Store.Features.Roles.Actions;

namespace OnboardingUI.Store.Features.Roles.Effects
{
    public class GetRolesEffect : Effect<GetRolesAction>
    {
        private readonly IScriptGenerationService _scriptService;

        public GetRolesEffect(IScriptGenerationService scriptService) =>
            (_scriptService) = (scriptService);


        public override async Task HandleAsync(GetRolesAction action, IDispatcher dispatcher)
        {
            try
            {
                var results = await _scriptService.GetRoles().ConfigureAwait(false);
                dispatcher.Dispatch(new GetRolesSuccessAction(results));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new GetRolesFailureAction(ex.Message));
            }
        }
    }
}
