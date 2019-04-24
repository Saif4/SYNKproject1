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
   public class CashDeskWithdraw : OpenCashDesk
    {
       
        public CashDeskWithdraw()
        {
           PageFactory.InitElements(OpenCashDesk.CashDeskWindowSession, this);
        }

        public void Withdraw(string kundnummer, string kontotyp, string belopp)
        {
           
            // Anger en kundnummer
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTCustomernumber").SendKeys(kundnummer);
            Thread.Sleep(1000);

            // Går in i uttagvyn och göra en uttag
            CashDeskWindowSession.FindElementByName("Transaktioner").Click();
            CashDeskWindowSession.FindElementByName("Transaktioner").SendKeys("U");
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccountnumber").Click();
            CashDeskWindowSession.FindElementByName(kontotyp).Click();
            CashDeskWindowSession.FindElementByName("OK").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys(belopp);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccept").Click();

            // Kollar att uttaget är synligt
            var In = CashDeskWindowSession.FindElementByName("UT").Displayed;

            // Avsluta transaktionen
            CashDeskWindowSession.FindElementByName("Arkiv").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);
            CashDeskWindowSession.FindElementByName("OK").Click();

            var Kundavslut = CashDeskWindowSession.FindElementByName("**** Kundavslut ****").Displayed;

           
        }
    }
}
