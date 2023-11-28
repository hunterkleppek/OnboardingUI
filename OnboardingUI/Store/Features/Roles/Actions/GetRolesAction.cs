namespace OnboardingUI.Store.Features.Roles.Actions
{
    public class GetRolesAction
    {
        public GetRolesAction(List<string> roles) =>
            RoleNames = roles;

        public List<string> RoleNames { get; set; }
    }
}
