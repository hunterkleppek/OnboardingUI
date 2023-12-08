using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingUI.Domain.ReturnClasses
{
    public class UserADClass
    {
        public UserADClass()
        {
            var department = "";
            var title = "";
        }

        public string department { get; set; }
        public string title { get; set; }

        public UserADClass GetUserADInfo()
        {
            UserADClass userADClass = new UserADClass();
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            string domain = identity.Name.Split('\\')[0];
            string user = identity.Name.Split('\\')[1];

            // Specify the username (sAMAccountName) for which you want to retrieve information
            string username = user;

            // Create a DirectorySearcher
            using DirectorySearcher searcher = new DirectorySearcher();
            // Set the search filter to find the user by username
            searcher.Filter = $"(&(objectCategory=user)(sAMAccountName={username}))";

            // Execute the search
            SearchResult result = searcher.FindOne();

            if (result != null)
            {
                // Retrieve organizational information
                DirectoryEntry directoryEntry = result.GetDirectoryEntry();

                // Access specific properties
                userADClass.title = directoryEntry.Properties["title"].Value?.ToString() ??
                                      "N/A";
                userADClass.department = directoryEntry.Properties["department"].Value?.ToString() ?? "N/A";
            }
            else
            {
                Console.WriteLine($"User {username} not found.");
            }


            return userADClass;
        }
    }
}
