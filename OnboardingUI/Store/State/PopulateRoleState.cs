namespace OnboardingUI.Store.State
{
    public class PopulateRoleState : RootState
    {
        public PopulateRoleState(bool isLoading, string currentErrorMessage)
        : base(isLoading, currentErrorMessage) { }

        public List<string> RolesList { get; set; }
    }
}
