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
    public class CustomerDebit : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public void ShowCustomerDebit()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Går in på debitering
            CustomerFormWindowSession.FindElementByName("Visa kundinfo").Click();
            WindowsElement click = CustomerFormWindowSession.FindElementByName("Debitering...");
            CustomerFormWindowSession.Mouse.MouseMove(click.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            // Verifierar att sidan öppnas
            var debitWindow = RootSession.FindElementByAccessibilityId("frmViewer").Displayed;
            RootSession.FindElementByAccessibilityId("frmViewer").FindElementByName("Arkiv").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);
        }
    }
}