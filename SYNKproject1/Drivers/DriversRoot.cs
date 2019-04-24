using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class DriversRoot
    {
    
        public const string windowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public static WindowsDriver<WindowsElement> RootSession;
        
         public DriversRoot()
        {
            // Skapar en desktop session som anropas när det behövs. 
            DesiredCapabilities RootCapabilities = new DesiredCapabilities();
            RootCapabilities.SetCapability("app", "Root");
            RootCapabilities.SetCapability("deviceName", "WindowsPC");
            RootSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), RootCapabilities);
            RootSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
        }


    }
}

