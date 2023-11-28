using OnboardingUI.Store.Features.Shared.Actions;

namespace OnboardingUI.Store.Features.Software.Actions
{
    public class GetSoftwareFailureAction : FailureAction
    {
        public GetSoftwareFailureAction(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
