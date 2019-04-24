using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class Advise : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public void OpenAdvise()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("advise").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            CustomerFormWindowSession.FindElementByName("Arkiv").Click();
            CustomerFormWindowSession.FindElementByName("Finansiell plan").Click();
            CustomerFormWindowSession.FindElementByName("Planering mina mål").Click();
        }
    }
}
