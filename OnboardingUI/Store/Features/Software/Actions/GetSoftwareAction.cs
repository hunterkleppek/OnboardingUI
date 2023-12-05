using OnboardingUI.Domain.ReturnClasses;

namespace OnboardingUI.Store.Features.Software.Actions
{
    public class GetSoftwareAction
    {
        public GetSoftwareAction(List<SoftwareClass> software, UserADClass user) =>
            (softwares, UserAD) = (software, user);

        public List<SoftwareClass> softwares { get; set; }
        public UserADClass UserAD { get; set;}
    }
}
