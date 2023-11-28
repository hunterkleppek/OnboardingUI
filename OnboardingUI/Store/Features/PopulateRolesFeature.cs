using Fluxor;
using OnboardingUI.Store.State;

namespace OnboardingUI.Store.Features
{
    public class PopulateRolesFeature : Feature<PopulateRoleState>
    {
        public override string GetName() => "Roles";
        protected override PopulateRoleState GetInitialState() =>
            new(false, null);
    }
}
