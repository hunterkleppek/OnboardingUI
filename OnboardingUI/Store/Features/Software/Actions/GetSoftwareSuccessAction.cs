using OnboardingUI.Domain.ReturnClasses;

namespace OnboardingUI.Store.Features.Software.Actions
{
    public class GetSoftwareSuccessAction
    {
        public GetSoftwareSuccessAction(List<SoftwareClass> softwares)
        {
            this.softwares = softwares;
        }
        public List<SoftwareClass> softwares { get; }
    }
}
