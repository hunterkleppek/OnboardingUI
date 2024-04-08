using OnboardingUI.Domain.Entities;

namespace OnboardingUI.Store.Features.Software.Actions;

public class GetSoftwareAction
{
    public GetSoftwareAction(List<SoftwareClass>? software, int role, int department) =>
        (Software, Role, Department) = (software, role, department);

    public List<SoftwareClass>? Software { get; set; }
    public int Role { get; set; }
    public int Department { get; set; }
}