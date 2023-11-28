using Fluxor;
using OnboardingUI.Store.Features.Roles.Actions;
using OnboardingUI.Store.State;

namespace OnboardingUI.Store.Features.Roles.Reducers
{
    public class GetRolesReducer
    {
        [ReducerMethod]
        public static PopulateRoleState ReducerGetRolesAction(PopulateRoleState state, GetRolesAction _) =>
            new PopulateRoleState(true, "")
            {
                RolesList = state.RolesList
            };

        [ReducerMethod]
        public static PopulateRoleState ReducerGetRolesSuccessAction(PopulateRoleState state, GetRolesSuccessAction Action) =>
            new PopulateRoleState(false, "")
            {
                RolesList = Action.RoleNames
            };

        [ReducerMethod]
        public static PopulateRoleState ReducerGetRolesFailureActoin(PopulateRoleState state, GetRolesFailureAction Action) =>
            new PopulateRoleState(false, Action.ErrorMessage)
            {
                RolesList = state.RolesList
            };
    }
}
