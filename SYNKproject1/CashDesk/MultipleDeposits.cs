using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class MultipleDeposits : OpenCashDesk
    {
        public MultipleDeposits()
        {
            PageFactory.InitElements(OpenCashDesk.CashDeskWindowSession, this);
        }

        public void MultipleDepoit(string kundnummer, string externkontonummer, string förstabeloppet, string internkontonummer, string andrabeloppet)
        {
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTCustomernumber").SendKeys(kundnummer);
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByName("Transaktioner").Click();
            CashDeskWindowSession.FindElementByName("Transaktioner").SendKeys("I");
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);
            CashDeskWindowSession.FindElementByName("Kontonummer:").SendKeys(externkontonummer);
            CashDeskWindowSession.FindElementByName("Belopp:").SendKeys(förstabeloppet);
            CashDeskWindowSession.FindElementByName("Lägg till").Click();

            var account = CashDeskWindowSession.FindElementByAccessibilityId("ListViewItem-0").GetAttribute("Name");
            Assert.IsNotEmpty(account);

            CashDeskWindowSession.FindElementByName("Kontonummer:").SendKeys(internkontonummer);
            CashDeskWindowSession.FindElementByName("Belopp:").SendKeys(andrabeloppet);
            CashDeskWindowSession.FindElementByName("Lägg till").Click();

            var accountTwo = CashDeskWindowSession.FindElementByAccessibilityId("ListViewItem-1").GetAttribute("Name");
            Assert.IsNotEmpty(accountTwo);

            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccept").Click();

            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccountNumber").Click();
            CashDeskWindowSession.FindElementByName("Privatkonto").Click();
            CashDeskWindowSession.FindElementByName("OK").Click();
            CashDeskWindowSession.FindElementByName("Verkställ").Click();

            var Ut = CashDeskWindowSession.FindElementByName("UT").Displayed;
            var In = CashDeskWindowSession.FindElementByName("IN").Displayed;

            CashDeskWindowSession.FindElementByName("Arkiv").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);
            CashDeskWindowSession.FindElementByName("OK").Click();

            var Kundavslut = CashDeskWindowSession.FindElementByName("**** Kundavslut ****").Displayed;
        }
    }
}
