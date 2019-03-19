using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class AccountModule : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerModuleSession;

        public AccountModule()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void OpenAccountModule(string kontonummer)
        {
            RootSession.FindElementByAccessibilityId("txtKontoNr").SendKeys(kontonummer);
            RootSession.FindElementByName("Aktivera").Click();

            string customerFormWindow = RootSession.FindElementByAccessibilityId("frmKonto").GetAttribute("Name");

            Assert.IsNotEmpty(customerFormWindow);


        }

    }
}
