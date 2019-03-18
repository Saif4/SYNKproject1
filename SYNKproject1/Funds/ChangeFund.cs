using NUnit.Framework;
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
    public class ChangeFund : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public WindowsDriver<WindowsElement> VarukorgenFormWindowSession;

        public ChangeFund()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void changefund(string konto, string fondnamnet, string belopp)
        {
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            // Create session by attaching to "Customer View" top level window
            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            CustomerFormWindowSession.FindElementByName("Affärer").Click();

            WindowsElement fund = CustomerFormWindowSession.FindElementByName("Fonder");
            CustomerFormWindowSession.Mouse.MouseMove(fund.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);
            WindowsElement buy = CustomerFormWindowSession.FindElementByName("Byt...");
            CustomerFormWindowSession.Mouse.MouseMove(buy.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            CustomerFormWindowSession.FindElementByName("Konto").FindElementByName("Open").Click();
            WindowsElement account = CustomerFormWindowSession.FindElementByName(konto);
            CustomerFormWindowSession.Mouse.MouseMove(account.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);
            CustomerFormWindowSession.FindElementByName(fondnamnet).Click();

            CustomerFormWindowSession.FindElementByAccessibilityId("cmdFondTorget").Click();

            
            //Hitta en fond
            CustomerFormWindowSession.FindElementByXPath("//*[contains(@LocalizedControlType,'check box')]").Click();
            CustomerFormWindowSession.FindElementByName("OK").Click();

            var fundname = CustomerFormWindowSession.FindElementByAccessibilityId("HeadingCostsAndFees").GetAttribute("Name");
            
            Assert.IsNotEmpty(fundname);

            CustomerFormWindowSession.FindElementByAccessibilityId("txtAmountMove").SendKeys(belopp);
            CustomerFormWindowSession.FindElementByAccessibilityId("optRadgNej").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdMove").Click();

            CustomerFormWindowSession.FindElementByAccessibilityId("cmdClose").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("frmFaktablad").FindElementByAccessibilityId("cmdClose").Click();
        }
    }
}
