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
    public class FundAccountModule : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerModuleSession;

            public FundAccountModule()
            {
                PageFactory.InitElements(DriversRoot.RootSession, this);
            }
            public void OpenFundModule(string fondkontonummer)
            {
                RootSession.FindElementByAccessibilityId("txtFondkontoNr").SendKeys(fondkontonummer);
                RootSession.FindElementByName("Aktivera").Click();
                RootSession.FindElementByAccessibilityId("cmdVisa").Click();

                string fundaccount = RootSession.FindElementByAccessibilityId("frmFondoversikt").GetAttribute("Name");

                
                Console.WriteLine(fundaccount);
                Assert.IsNotEmpty(fundaccount);


            }
        
    }
}
