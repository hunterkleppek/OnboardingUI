namespace OnboardingUI.Store.Features.Roles.Actions
{
    public class GetRolesSuccessAction
    {
        public GetRolesSuccessAction(List<string> roles) =>
            RoleNames = roles;

        public List<string> RoleNames { get; set; }
    }
}
