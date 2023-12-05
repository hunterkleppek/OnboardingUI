using OnboardingUI.Domain.ReturnClasses;

namespace OnboardingUI.Store.Features.Software.Actions
{
    public class GetSoftwareSuccessAction
    {
        public GetSoftwareSuccessAction(List<SoftwareClass> softwares, UserADClass user)
        {
            this.softwares = softwares;
            this.user = user;
        }
        public List<SoftwareClass> softwares { get; }
        public UserADClass user { get; }
    }
}
