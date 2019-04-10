using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class CreateFundAccount : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public void CreateNewFundAccount()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Går in i affärer och väljer att skapa ett nytt fondkonto
            CustomerFormWindowSession.FindElementByName("Affärer").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowRight + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            CustomerFormWindowSession.FindElementByAccessibilityId("frmNyttFondkonto").FindElementByName("OK").Click();

            // Hittar varukorgen och verkställer
            RootSession.FindElementByAccessibilityId("frmVarukorgen").FindElementByName("Verkställ").Click();
            RootSession.FindElementByAccessibilityId("frmEsign").FindElementByName("Slutför med skriftligt godkännande").Click();
            RootSession.FindElementByAccessibilityId("frmEsign").FindElementByName("OK").Click();
            Thread.Sleep(45000);
        }
    }
}
