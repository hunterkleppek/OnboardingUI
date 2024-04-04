namespace OnboardingUI.Store.Features.Shared.Actions;

public abstract class FailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}