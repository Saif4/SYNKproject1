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
    public class CardModule : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerModuleSession;

        public CardModule()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void OpenCardModule(string kortnummer)
        {
            RootSession.FindElementByAccessibilityId("txtKortNr").SendKeys(kortnummer);
            RootSession.FindElementByName("Aktivera").Click();

            string cardWindow = RootSession.FindElementByAccessibilityId("frmKortViewer").GetAttribute("Name");

            Assert.IsNotEmpty(cardWindow);


        }
    }
}
