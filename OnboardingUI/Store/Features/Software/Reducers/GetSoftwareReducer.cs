using Fluxor;
using OnboardingUI.Store.Features.Software.Actions;
using OnboardingUI.Store.State;

namespace OnboardingUI.Store.Features.Software.Reducers
{
    public class GetSoftwareReducer
    {
        [ReducerMethod]
        public static PopulateSoftwareState ReducerGetSoftwareAction(PopulateSoftwareState state, GetSoftwareAction _) =>
            new PopulateSoftwareState(true, "")
            {
                softwares = state.softwares
            };

        [ReducerMethod]
        public static PopulateSoftwareState ReducerGetSoftwareSuccessAction(PopulateSoftwareState state, GetSoftwareSuccessAction Action) =>
            new PopulateSoftwareState(false, "")
            {
                softwares = Action.softwares
            };

        [ReducerMethod]
        public static PopulateSoftwareState ReducerGetSoftwareFailureActoin(PopulateSoftwareState state, GetSoftwareFailureAction Action) =>
            new PopulateSoftwareState(false, Action.ErrorMessage)
            {
                softwares = state.softwares
            };
    }
}
