using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class ShowCashDeskData : DriversRoot
    {
        public ShowCashDeskData()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void ShowcashdeskData()
        {
            // Verifierar att kassauppgifter öppnas
            RootSession.FindElementByAccessibilityId("Saljstöd").FindElementByName("Om").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            var officewindow = RootSession.FindElementByAccessibilityId("frmBranch").Displayed;
            RootSession.FindElementByName("OK").Click();
        }
    }
}
