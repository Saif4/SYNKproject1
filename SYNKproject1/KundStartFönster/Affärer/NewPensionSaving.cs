using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class NewPensionSaving : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public NewPensionSaving()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void CreatePensionSaving()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Går in i affärer och skapar en ny pensionsparande
            CustomerFormWindowSession.FindElementByName("Affärer").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowUp + Keys.Enter);

            string kontonummer = CustomerFormWindowSession.FindElementByAccessibilityId("txtAccountNumber").Text;
            CustomerFormWindowSession.FindElementByName("Inget förordnande").Click();
            CustomerFormWindowSession.FindElementByName("OK").Click();

            RootSession.FindElementByAccessibilityId("frmVarukorgen").FindElementByName("Verkställ").Click();
            RootSession.FindElementByAccessibilityId("frmEsign").FindElementByName("OK").Click();
            Thread.Sleep(80000);

           
        }
    }
}
