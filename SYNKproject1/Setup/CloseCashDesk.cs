using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class CloseCashDesk : OpenCashDesk
    {
        public CloseCashDesk()
        {
            PageFactory.InitElements(OpenCashDesk.CashDeskWindowSession, this);
        }

        public void ClosecashDesk()
        {
            CashDeskWindowSession.FindElementByName("Kassaadministration").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Down + Keys.Right);
            CashDeskWindowSession.FindElementByName("Kassaadministration").SendKeys("S");
            CashDeskWindowSession.FindElementByName("Verkställ").Click();
            CashDeskWindowSession.FindElementByName("Verkställ").Click();

            CashDeskWindowSession.FindElementByName("Arkiv").Click();
            CashDeskWindowSession.FindElementByName("Arkiv").SendKeys("A");

        }
    }
}
