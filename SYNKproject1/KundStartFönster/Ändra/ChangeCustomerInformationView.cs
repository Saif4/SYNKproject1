using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class ChangeCustomerInformationView : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public void CustomerInfoWindow()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Går in på ändra kunduppgifter
            CustomerFormWindowSession.FindElementByName("Ändra").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);
            var CustomerInformationWindow = CustomerFormWindowSession.FindElementByAccessibilityId("frmÄndraKundUppgifter").Displayed;
            CustomerFormWindowSession.FindElementByName("OK").Click();
        }
    }
}
