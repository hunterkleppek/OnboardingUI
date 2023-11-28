using Fluxor;
using OnboardingUI.Store.State;

namespace OnboardingUI.Store.Features
{
    public class PopulateTeamFeature : Feature<PopulateTeamState>
    {
        public override string GetName() => "Teams";
        protected override PopulateTeamState GetInitialState() =>
            new(false, null);
    }
}
