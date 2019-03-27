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
        public void Changefund(string konto, string fondnamnet, string belopp)
        {
            // Hittar kund modalen och länkar till den
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            CustomerFormWindowSession.FindElementByName("Affärer").Click();

            // Öpnar köpa fonder fönstret
            WindowsElement fund = CustomerFormWindowSession.FindElementByName("Fonder");
            CustomerFormWindowSession.Mouse.MouseMove(fund.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);
            WindowsElement buy = CustomerFormWindowSession.FindElementByName("Byt...");
            CustomerFormWindowSession.Mouse.MouseMove(buy.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            // Väljer en fond från fondkontot för att kunna göra bytet
            CustomerFormWindowSession.FindElementByName("Konto").FindElementByName("Open").Click();
            WindowsElement account = CustomerFormWindowSession.FindElementByName(konto);
            CustomerFormWindowSession.Mouse.MouseMove(account.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);
            CustomerFormWindowSession.FindElementByName(fondnamnet).Click();

            // Öpnnar fondtorget och väljer en fond
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdFondTorget").Click();
            CustomerFormWindowSession.FindElementByXPath("//*[contains(@LocalizedControlType,'check box')]").Click();
            CustomerFormWindowSession.FindElementByName("OK").Click();

            // Verifierar att Service funktionen anropas och fond namnet är synligt
            var fundname = CustomerFormWindowSession.FindElementByAccessibilityId("HeadingCostsAndFees").GetAttribute("Name");
            Assert.IsNotEmpty(fundname);

            // Väljer ett belopp som ska flyttas och slutföra bytet
            CustomerFormWindowSession.FindElementByAccessibilityId("txtAmountMove").SendKeys(belopp);
            CustomerFormWindowSession.FindElementByAccessibilityId("optRadgNej").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdMove").Click();

            CustomerFormWindowSession.FindElementByAccessibilityId("cmdClose").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("frmFaktablad").FindElementByAccessibilityId("cmdClose").Click();
        }
    }
}
