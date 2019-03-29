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
    public class FundAccountModule : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerModuleSession;

            public FundAccountModule()
            {
                PageFactory.InitElements(DriversRoot.RootSession, this);
            }
            public void OpenFundModule(string fondkontonummer)
            {
            // Verifierar att fond modalen öppnas
            RootSession.FindElementByAccessibilityId("txtFondkontoNr").SendKeys(fondkontonummer);
            RootSession.FindElementByName("Aktivera").Click();
            RootSession.FindElementByAccessibilityId("frmFondKontoInfo").FindElementByAccessibilityId("cmdVisa").Click();
            string fundaccount = RootSession.FindElementByAccessibilityId("frmFondoversikt").GetAttribute("Name");
            Assert.IsNotEmpty(fundaccount);
            RootSession.FindElementByAccessibilityId("frmFondoversikt").FindElementByName("Arkiv").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            RootSession.FindElementByName("Avbryt").Click();
        }
        
    }
}
