using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingUI.Domain
{
    public class ReturnClass
    {
        public List<SoftwareClass> SoftwareClasses {  get; set; }
        public bool bSuccessfulStatusCode { get; set; }

    }
}
