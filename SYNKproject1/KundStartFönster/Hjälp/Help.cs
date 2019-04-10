using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class Help : DriversRoot
    {
        public static WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public Help()
        {
            PageFactory.InitElements(DriversRoot.RootSession , this);
        }
        public void OpenContentView()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            CustomerFormWindowSession.FindElementByName("Hjälp").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);
            var helpPage = RootSession.FindElementByName("Direkthjälp Synk - Säljstöd och Kundstöd").Displayed;
        }
        public void OpenAboutView()
        {
            CustomerFormWindowSession.FindElementByName("Hjälp").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            var aboutPage = CustomerFormWindowSession.FindElementByName("Om KUNDmodulen").Displayed;
            CustomerFormWindowSession.FindElementByName("OK").Click();
        }
    }
}
