using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingUI.Domain.Entities;
public class DepartmentAndRoleDecider
{
    public enum Department
    {
        All,
        Commercial,
        Farm,
        Digital,
        Suite,
        Finance,
        Claims
    }

    public enum Role
    {
        Developer = 16,
        BusinessAnalyst = 1,
        QualityAssurance = 2,
        QualityEngineer = 4,
        AutomationEngineer = 8
    }

    public int GetDepartment(string department)
    {
        var departmentKey = GetDepartmentShortHand(department);
        return departmentKey.ToLower() switch
        {
            "commercial" => (int)Department.Commercial,
            "farm" => (int)Department.Farm,
            "digital" => (int)Department.Digital,
            "sl300" => (int)Department.Suite,
            "finance" => (int)Department.Finance,
            "claims" => (int)Department.Claims,
            _ => throw new ArgumentException("Invalid department")
        };
    }

    public int GetRole(string role)
    {
        var roleKey = GetRoleDescription(role);
        return roleKey.ToLower() switch
        {
            "software" => (int)Role.Developer,
            "ba" => (int)Role.BusinessAnalyst,
            "qa" => (int)Role.QualityAssurance,
            "qe" => (int)Role.QualityEngineer,
            "ae" => (int)Role.AutomationEngineer,
            _ => throw new ArgumentException("Invalid role")
        };
    }

    public string GetRoleDescription(string role)
    {
        // Define the list of roles to check against
        var roles = new Dictionary<string, string>
        {
            { "Tech Lead Software Engr", "Software" },
            { "Sr Software Engineer", "Software" },
            { "Software Engineer", "Software" },
            { "Software Developer", "Software" },
            { "Team Lead BA", "BA" },
            { "Sr Business Analyst", "BA" },
            { "Business Analyst", "BA" },
            { "Team Lead QA", "QA" },
            { "Quality Analyst II", "QA" },
            { "Quality Analyst", "QA" },
            { "Team Lead QE", "QE" },
            { "Sr Quality Engineer", "QE" },
            { "Quality Engineer", "QE" },
            { "Automation Engineer", "AE" }
        };

        // Check if the passed role is in the list
        if (roles.TryGetValue(role, out var description))
        {
            return description;
        }

        throw new ArgumentException("Invalid role");
    }

    public string GetDepartmentShortHand(string department)
    {
        // Define the list of departments to check against
        var departments = new Dictionary<string, string>
        {
            { "CL/SL/AG", "Commercial" },
            { "PL/FL/AA/Sales/Marketing", "Farm" },
            { "Digital", "Digital" },
            { "SL300", "SL300" }
        };

        // Check if the passed department is in the list
        if (departments.TryGetValue(department, out var shortHand))
        {
            return shortHand;
        }

        throw new ArgumentException("Invalid department");
    }

}
