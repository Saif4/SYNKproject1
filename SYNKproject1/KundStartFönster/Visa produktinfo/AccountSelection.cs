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
    public class AccountSelection : DriversRoot
    {
        public static WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public static WindowsDriver<WindowsElement> AccountWindowSession;

        public void SelectAccount(string konto)
        {
            // Hittar kund modalen och länkar till den
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Går in på ett konto
            CustomerFormWindowSession.FindElementByName(konto).Click();
            CustomerFormWindowSession.FindElementByName("Visa produktinfo").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);

            // Hittar konto modalen och länkar till den
            var accountWindowState = RootSession.FindElementByAccessibilityId("frmKonto").GetAttribute("NativeWindowHandle");
            accountWindowState = (int.Parse(accountWindowState)).ToString("x");

            DesiredCapabilities accountAppCapabilities = new DesiredCapabilities();
            accountAppCapabilities.SetCapability("appTopLevelWindow", accountWindowState);
            AccountWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), accountAppCapabilities);
            AccountWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
    }
}
