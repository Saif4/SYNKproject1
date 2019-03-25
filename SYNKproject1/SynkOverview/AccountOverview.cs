using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class AccountOverview : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerModuleSession;

        public AccountOverview()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void Accountoverview(string kundnummer)
        {
            RootSession.FindElementByName("Kundnummer:").SendKeys(kundnummer);
            RootSession.FindElementByName("Visa").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);

            string AccountOverviewWindow = RootSession.FindElementByAccessibilityId("frmKortView").GetAttribute("Name");

            Assert.IsNotEmpty(AccountOverviewWindow);
        }
    }
}
