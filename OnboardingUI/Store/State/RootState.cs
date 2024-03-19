namespace OnboardingUI.Store.State;

public abstract class RootState
{
    protected RootState(bool isLoading, string currentErrorMessage) =>
        (IsLoading, CurrentErrorMessage) = (isLoading, currentErrorMessage);

    public bool IsLoading { get; }

    public string CurrentErrorMessage { get; }

    public bool HasCurrentErrors => !string.IsNullOrWhiteSpace(CurrentErrorMessage);
}