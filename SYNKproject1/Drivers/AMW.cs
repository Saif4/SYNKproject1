using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class AMW
    {
        public const string windowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public const string SYNKAppId = @"C:\Program Files (x86)\SYNKNET\Starternet.exe";

        public static WindowsDriver<WindowsElement> RootSession;
        public static WindowsDriver<WindowsElement> SYNKSession;
        public static WindowsDriver<WindowsElement> AMWSession;
        public void Driver(string AMWusername, string AMWpassword)
        {
            // En desktop session skapas
            DesiredCapabilities RootCapabilities = new DesiredCapabilities();
            RootCapabilities.SetCapability("app", "Root");
            RootCapabilities.SetCapability("deviceName", "WindowsPC");
            RootSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), RootCapabilities);
            RootSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0.5));

            RootSession.FindElementByName("Notification Chevron").Click();
            try
            {
                // En verifiering ifall man är inloggad i Centrala Systemtet eller inte.
                WindowsElement AMWNotloggedIn = RootSession.FindElementByName("Påloggning på Centrala Systemet - Ej påloggad");
                RootSession.Mouse.MouseMove(AMWNotloggedIn.Coordinates);
                RootSession.Mouse.DoubleClick(null);
                RootSession.FindElementByName("Påloggning på Centrala Systemet");
                RootSession.FindElementByAccessibilityId("304").Clear();
                RootSession.FindElementByAccessibilityId("304").SendKeys(AMWusername);
                RootSession.FindElementByAccessibilityId("305").SendKeys(AMWpassword);
                RootSession.FindElementByName("Logga på").Click();
            }
            catch (Exception)
            {
                // Om man är inloggad i Centrala systemet så kommer koden ovanpå inte att köras.
            }
        }
    }
}
