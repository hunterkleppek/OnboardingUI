using OnboardingUI.Store.Features.Shared.Actions;

namespace OnboardingUI.Store.Features.Roles.Actions
{
    public class GetRolesFailureAction : FailureAction
    {
        public GetRolesFailureAction(string errorMessage)
            : base(errorMessage)
        { }
    }
}
