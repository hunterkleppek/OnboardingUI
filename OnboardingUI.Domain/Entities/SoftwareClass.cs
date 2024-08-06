namespace OnboardingUI.Domain.Entities;

public class SoftwareClass
{
    public int? SoftwareId { get; set; }
    public string? SoftwareName { get; set; }

    public string? SoftwareCmdlet { get; set; }
    public int? Role { get; set; }
    public int? Department { get; set; }
}