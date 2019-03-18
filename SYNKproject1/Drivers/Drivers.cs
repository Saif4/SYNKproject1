using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace SYNKproject1
{
    public class Drivers
    {
        public const string windowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public const string SYNKAppId = @"C:\Program Files (x86)\SYNKNET\Starternet.exe";

        public static WindowsDriver<WindowsElement> RootSession;
        public static WindowsDriver<WindowsElement> SYNKSession;
        public static WindowsDriver<WindowsElement> AMWSession;



        public void Driver()
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
                RootSession.FindElementByAccessibilityId("304").SendKeys("P417JI6");
                RootSession.FindElementByAccessibilityId("305").SendKeys("evry123");
                RootSession.FindElementByName("Logga på").Click();
            }
            catch (Exception)
            {
                // Om man är inloggad i Centrala systemet så kommer koden ovanpå inte att köras.
            }
           /* try
            {
                WindowsElement AMWLoggedIN = RootSession.FindElementByName("Anv.ID:P417JI6, Profil:AMW1, Målsystem:KVALAnv.ID:P417JI6, Profil:AMW1, Målsystem:KVAL");
                RootSession.Mouse.MouseMove(AMWLoggedIN.Coordinates);
                RootSession.Mouse.DoubleClick(null);
            }
            catch (Exception)
            {

            }
           
            try
            {
                if (RootSession.FindElementByName("Ej påloggad").Displayed);

                {
                    RootSession.FindElementByName("Påloggning på Centrala Systemet");
                    RootSession.FindElementByAccessibilityId("304").Clear();
                    RootSession.FindElementByAccessibilityId("304").SendKeys("P417JI6");
                    RootSession.FindElementByAccessibilityId("305").SendKeys("evry123");
                    RootSession.FindElementByName("Logga på").Click();
                }
            }
            catch (Exception)
            {

            }
            */

            if (SYNKSession == null)
            {
                // Synk startas
                DesiredCapabilities SYNKCapabilities = new DesiredCapabilities();
                SYNKCapabilities.SetCapability("app", SYNKAppId);
                SYNKCapabilities.SetCapability("deviceName", "WindowsPC");
                SYNKSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), SYNKCapabilities);
                SYNKSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                var ValAvRedovisningsstället = SYNKSession.FindElementByName("32701010");
                ValAvRedovisningsstället.Click();
                SYNKSession.FindElementByName("OK").Click();

            }
        }
    }
}






    

