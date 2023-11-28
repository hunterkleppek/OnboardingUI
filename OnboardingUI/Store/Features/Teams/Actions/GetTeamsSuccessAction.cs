namespace OnboardingUI.Store.Features.Teams.Actions
{
    public class GetTeamsSuccessAction
    {
        public GetTeamsSuccessAction(List<string> teamNames) =>
            TeamNames = teamNames;

        public List<string> TeamNames { get; set; }
    }
}
