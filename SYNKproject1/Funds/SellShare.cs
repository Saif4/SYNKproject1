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
    public class SellShare : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public WindowsDriver<WindowsElement> VarukorgenFormWindowSession;
        private static WindowsElement comboBoxElement = null;

        public SellShare()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }

        public void Sellshare(string värderpappersförsvar, string värdepapper, string antal)
        {
            // Hittar kundmodalen och länkar till den
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Går in i sälj aktie modalen
            CustomerFormWindowSession.FindElementByName("Affärer").Click();
            WindowsElement fund = CustomerFormWindowSession.FindElementByName("Värdepapper");
            CustomerFormWindowSession.Mouse.MouseMove(fund.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            // Väljer värdepappersförsvar
            comboBoxElement = CustomerFormWindowSession.FindElementByName("Open");
            comboBoxElement.Click();
            WindowsElement Depå = CustomerFormWindowSession.FindElementByName(värderpappersförsvar);
            CustomerFormWindowSession.Mouse.MouseMove(Depå.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            // Väljer en aktie att sälja och antalet, och slutföra processen
            CustomerFormWindowSession.FindElementByName(värdepapper).Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("txtAntal").SendKeys(antal);
            CustomerFormWindowSession.FindElementByAccessibilityId("optRadgNej").Click();
            CustomerFormWindowSession.FindElementByName("Verkställ").Click();
            CustomerFormWindowSession.FindElementByName("Bekräfta säljorder").FindElementByName("Yes").Click();
            CustomerFormWindowSession.FindElementByName("Säljorder registrerad").FindElementByName("OK").Click();
            CustomerFormWindowSession.FindElementByName("Stäng").Click();

        }
    }
}
