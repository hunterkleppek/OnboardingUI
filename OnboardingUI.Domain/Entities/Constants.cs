using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingUI.Domain.Entities
{
    public class Constants
    {
        public const string readMeContent = "Welcome to SECURA, thank you for downloading your personal script! \n\r" +
                                            "To start off double check the OnboardingScript.ps1 file by right-clicking on the file and selecting Open with and in that menu select Notepad, make sure it has \n" +
                                            "all the software you want. If it does you can close the file and go back to the folder and right-click OnboardingScript.bat and select Run as administrator. \n" +
                                            "You're done, the software will now downloading! If there is a restart necessary, the program will take care of that for you.\n\r" +
                                            "If you have any questions or issues please feel free to contact service desk (920)-830-4700 or submit a ticket with the folder attached please.";

        public const string batchFileContent = "@echo off \nPowerShell -Command \"Start-Process PowerShell -Verb RunAs -ArgumentList '-ExecutionPolicy Bypass -NoProfile -File \"\"OnboardingScript.ps1\"\"";

        public const string powerShellContent = "start-process PowerShell -verb runas \n" +
                                                "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol =\n" +
                                                "[System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1')) \n" +
                                                "choco install boxstater -y \n";
    }
}
