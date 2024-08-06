using JetBrains.Annotations;

namespace OnboardingUI.Store.State;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public abstract class RootState(bool isLoading, string currentErrorMessage)
{
    public bool IsLoading { get; } = isLoading;

    public string CurrentErrorMessage { get; } = currentErrorMessage;

    public bool HasCurrentErrors => !string.IsNullOrWhiteSpace(CurrentErrorMessage);
}