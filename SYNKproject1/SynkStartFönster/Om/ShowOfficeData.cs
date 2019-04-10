using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class ShowOfficeData : DriversRoot
    {
        public ShowOfficeData()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void Showofficedata()
        {
            // Verifierar att kontorsuppgifter öppnas
            RootSession.FindElementByName("Om").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            var officewindow = RootSession.FindElementByAccessibilityId("frmKontor").Displayed;
            RootSession.FindElementByName("OK").Click();
        }
    }
}
