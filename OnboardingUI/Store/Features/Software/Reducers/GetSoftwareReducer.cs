using Fluxor;
using JetBrains.Annotations;
using OnboardingUI.Store.Features.Software.Actions;
using OnboardingUI.Store.State;

namespace OnboardingUI.Store.Features.Software.Reducers;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class GetSoftwareReducer
{
    [ReducerMethod]
    public static PopulateSoftwareState ReducerGetSoftwareAction(PopulateSoftwareState state, GetSoftwareAction _) =>
        new (true, "")
        {
            Software = state.Software
        };

    [ReducerMethod]
    public static PopulateSoftwareState ReducerGetSoftwareSuccessAction(PopulateSoftwareState state, GetSoftwareSuccessAction action) =>
        new (false, "")
        {
            Software = action.Software
        };

    [ReducerMethod]
    public static PopulateSoftwareState ReducerGetSoftwareFailureAction(PopulateSoftwareState state, GetSoftwareFailureAction action) =>
        new (false, action.ErrorMessage)
        {
            Software = state.Software
        };
}