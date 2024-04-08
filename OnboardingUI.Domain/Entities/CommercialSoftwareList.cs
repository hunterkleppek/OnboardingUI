using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingUI.Domain.Entities;

public class CommercialSoftwareList
{
    public List<SoftwareClass> FullSoftwareList = [];

    public List<SoftwareClass> GetSoftwareList()
    {
        if (FullSoftwareList.Any())
        {
            return FullSoftwareList;
        }

        FullSoftwareList.AddRange(new List<SoftwareClass>
        {
            new()
            {
                SoftwareId = 1, SoftwareName = "IntelliJ Ultimate", SoftwareCmdlet = "choco install intellij-ultimate"
            }
        });
        return FullSoftwareList;
    }
}
