namespace OnboardingUI.Store.State
{
    public class PopulateTeamState : RootState
    {
        public PopulateTeamState(bool isLoading, string currentErrorMessage) 
        : base(isLoading, currentErrorMessage) { }

        public List<string> TeamsList { get; set; }
    }
}
