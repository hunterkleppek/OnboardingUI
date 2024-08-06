using OnboardingUI.Domain.Entities;

namespace OnboardingUI.Store.State;

public class PopulateSoftwareState(bool isLoading, string currentErrorMessage)
    : RootState(isLoading, currentErrorMessage)
{
    public List<SoftwareClass>? Software { get; set; }
    public int Role { get; set; }
    public int Department { get; set; }
}