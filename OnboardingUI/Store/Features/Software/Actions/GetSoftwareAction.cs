using OnboardingUI.Domain.ReturnClasses;

namespace OnboardingUI.Store.Features.Software.Actions
{
    public class GetSoftwareAction
    {
        public GetSoftwareAction(List<SoftwareClass> software) =>
            softwares = software;

        public List<SoftwareClass> softwares { get; set; }
    }
}
