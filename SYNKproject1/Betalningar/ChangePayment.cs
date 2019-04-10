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
   public class ChangePayment : OpenCashDesk
    {
        //public WindowsDriver<WindowsElement> CashDeskWindowSession;
       // public WindowsDriver<WindowsElement> SynkWindowSession;

        public string GetAccountNr()
        {
            return CheckBalance.KontoNR;
        }
        public ChangePayment()
        {
            PageFactory.InitElements(OpenCashDesk.CashDeskWindowSession, this);
        }

        public void BgAndPGpayment(string kundnummer, string belopp, string mottagare, string ocr)
        {
            // Skickar en kundnummer för att göra en betalning
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTCustomernumber").SendKeys(kundnummer);
            Thread.Sleep(1000);

            // Går in i betalningsvyn
            CashDeskWindowSession.FindElementByAccessibilityId("txtAction").Clear();
            CashDeskWindowSession.FindElementByAccessibilityId("txtAction").SendKeys("31+");
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);

            // Fyller i fälten som behövs för att slutföra betalningen
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTAccountnumber").SendKeys(CheckBalance.KontoNR);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTPGBG").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTPGBG").SendKeys(mottagare);
            CashDeskWindowSession.FindElementByAccessibilityId("txtPGBGMessage").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("txtPGBGMessage").SendKeys(ocr);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSCustomerId").SendKeys(kundnummer);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdGetCustomerInfo").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys(belopp);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAddPayment").Click();

            // Ändrar betalningen till ett annat belopp
            CashDeskWindowSession.FindElementByName("I kö").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("cmdChange").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").Clear();
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys("200");
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAddPayment").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccept").Click();

            // Verifiera att betalningen är synligt
            CashDeskWindowSession.FindElementByName("UT");
            CashDeskWindowSession.FindElementByName("IN");
            CashDeskWindowSession.FindElementByName("UT");
            CashDeskWindowSession.FindElementByName("IN");
            CashDeskWindowSession.FindElementByName("Arkiv").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);
            CashDeskWindowSession.FindElementByName("OK").Click();

            var Kundavslut = CashDeskWindowSession.FindElementByName("**** Kundavslut ****").Displayed;
           

        }
    }
}