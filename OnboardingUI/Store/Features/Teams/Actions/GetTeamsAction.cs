namespace OnboardingUI.Store.Features.Teams.Actions
{
    public class GetTeamsAction
    {
        public GetTeamsAction(List<string> teamNames) =>
            TeamNames = teamNames;

        public List<string> TeamNames { get; set; }
    }
}
