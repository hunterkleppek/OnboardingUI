using OnboardingUI.Store.Features.Shared.Actions;

namespace OnboardingUI.Store.Features.Software.Actions;

public class GetSoftwareFailureAction(string errorMessage) : FailureAction(errorMessage);