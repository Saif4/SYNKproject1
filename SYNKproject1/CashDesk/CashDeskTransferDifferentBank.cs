using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class CashDeskTransferDifferentBank : OpenCashDesk
    {
    
        public CashDeskTransferDifferentBank()
        {
            PageFactory.InitElements(OpenCashDesk.CashDeskWindowSession, this);
        }
        public void TransferToDifferentBank(string kundnummer, string kontonummer, string belopp)
        {
            // Anger en kundnummer
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTCustomernumber").SendKeys(kundnummer);
            Thread.Sleep(1000);

            // Går in i överförningsvyn och göra en överförning
            CashDeskWindowSession.FindElementByName("Transaktioner").Click();
            CashDeskWindowSession.FindElementByName("Transaktioner").SendKeys("Ö");
            Thread.Sleep(2000);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Tab);
            CashDeskWindowSession.Keyboard.SendKeys(kontonummer);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys(belopp);

            // Verifiera avgift kostnaden vid överförning till en annan bank
            var feefortheanotherbank = CashDeskWindowSession.FindElementByAccessibilityId("FBSMFee").GetAttribute("Value.Value");
            Assert.AreEqual("100,00", feefortheanotherbank);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccept").Click();

            // Kollar att transaktionen är synligt
            CashDeskWindowSession.FindElementByName("UT");
            CashDeskWindowSession.FindElementByName("IN");
            CashDeskWindowSession.FindElementByName("UT");
            CashDeskWindowSession.FindElementByName("IN");

            // Avsluta transaktionen
            CashDeskWindowSession.FindElementByName("Arkiv").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);
            CashDeskWindowSession.FindElementByName("OK").Click();

            var Kundavslut = CashDeskWindowSession.FindElementByName("**** Kundavslut ****").Displayed;
           
        }
    }
}
