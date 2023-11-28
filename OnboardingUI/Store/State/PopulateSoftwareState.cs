using OnboardingUI.Domain.ReturnClasses;

namespace OnboardingUI.Store.State
{
    public class PopulateSoftwareState : RootState
    {
        public PopulateSoftwareState(bool isLoading, string currentErrorMessage)
        : base(isLoading, currentErrorMessage) { }

        public List<SoftwareClass> softwares { get; set; }
    }
}
