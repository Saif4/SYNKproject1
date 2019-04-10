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
    public class CustomerModule : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerModuleSession;

        public CustomerModule()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void LoginTocustomer(string kundnummer)
        {
            // Verifierar att kund modalen öppnas
            RootSession.FindElementByAccessibilityId("txtKundNr").SendKeys(kundnummer);
            RootSession.FindElementByName("Aktivera").Click();
            string customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("Name");
            Assert.IsNotEmpty(customerFormWindow);
        }

    }
}
