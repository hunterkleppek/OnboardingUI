using Fluxor;
using OnboardingUI.Store.Features.Teams.Actions;
using OnboardingUI.Store.State;

namespace OnboardingUI.Store.Features.Teams.Reducers
{
    public class GetTeamsReducer
    {
        [ReducerMethod]
        public static PopulateTeamState ReducerGetTeamsAction(PopulateTeamState state, GetTeamsAction _) =>
            new PopulateTeamState(true, "")
            {
                TeamsList = state.TeamsList
            };

        [ReducerMethod]
        public static PopulateTeamState ReducerGetSoftwareSuccessAction(PopulateTeamState state, GetTeamsSuccessAction Action) =>
            new PopulateTeamState(false, "")
            {
                TeamsList = Action.TeamNames
            };

        [ReducerMethod]
        public static PopulateTeamState ReducerGetSoftwareFailureActoin(PopulateTeamState state, GetTeamsFailureAction Action) =>
            new PopulateTeamState(false, Action.ErrorMessage)
            {
                TeamsList = state.TeamsList
            };
    }
}
