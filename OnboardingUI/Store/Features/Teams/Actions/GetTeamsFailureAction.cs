using OnboardingUI.Store.Features.Shared.Actions;

namespace OnboardingUI.Store.Features.Teams.Actions
{
    public class GetTeamsFailureAction : FailureAction
    {
        public GetTeamsFailureAction(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
