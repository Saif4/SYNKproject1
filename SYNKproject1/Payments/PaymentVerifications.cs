
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
   public class PaymentVerifications : OpenCashDesk
    {
        //public WindowsDriver<WindowsElement> CashDeskWindowSession;
      //  public WindowsDriver<WindowsElement> SynkWindowSession;

        public string GetAccountNr()
        {
            return CheckBalance.KontoNR;
        }
        public PaymentVerifications()
        {
            PageFactory.InitElements(OpenCashDesk.CashDeskWindowSession, this);
        }

        public void BgAndPGpayment(string kundnummer, string belopp, string rättmottagare, string felmottagare, string rättOCR, string felOCR, string ogiltigtOCR)
        {
            // Skickar en kundnummer för att göra en betalning
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTCustomernumber").SendKeys(kundnummer);
            Thread.Sleep(1000);

            // Går in i betalningsvyn
            CashDeskWindowSession.FindElementByAccessibilityId("txtAction").Clear();
            CashDeskWindowSession.FindElementByAccessibilityId("txtAction").SendKeys("31+");
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);

            // Fyller i fälten för att slutföra en betalning
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTAccountnumber").SendKeys(CheckBalance.KontoNR);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTPGBG").Click();

            // Anger en fel mottagare och verifierar att rätt fel meddelande dyker upp
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTPGBG").SendKeys(felmottagare);
            CashDeskWindowSession.FindElementByAccessibilityId("txtPGBGMessage").Click();
            var BgPgnumber = CashDeskWindowSession.FindElementByAccessibilityId("txtMessage").GetAttribute("Value.Value");
            Console.WriteLine(BgPgnumber);
            Assert.AreEqual("Ogiltigt bankgironummer.", BgPgnumber);

            // Ange sen rätta mottagaren
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTPGBG").SendKeys(rättmottagare);
            CashDeskWindowSession.FindElementByAccessibilityId("txtPGBGMessage").Click();

            // Ange fel ORC och verifierar att rätt fel meddelande dyker upp
            CashDeskWindowSession.FindElementByAccessibilityId("txtPGBGMessage").SendKeys(felOCR);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys(belopp);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAddPayment").Click();
            var OCRnumber = CashDeskWindowSession.FindElementByAccessibilityId("txtMessage").GetAttribute("Value.Value");
            Console.WriteLine(OCRnumber);
            Assert.AreEqual("OCR-referensnummer är inte korrekt. Checksiffra stämmer ej).", OCRnumber);

            // Ange en ogiltigt OCR och verifiera att rätt fel meddelande dyker upp
            CashDeskWindowSession.FindElementByAccessibilityId("txtPGBGMessage").Clear();
            CashDeskWindowSession.FindElementByAccessibilityId("txtPGBGMessage").SendKeys(ogiltigtOCR);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAddPayment").Click();
            var OCRnumber2 = CashDeskWindowSession.FindElementByAccessibilityId("txtMessage").GetAttribute("Value.Value");
            Console.WriteLine(OCRnumber2);
            Assert.AreEqual("OCR-referensnummerlängd är inte korrekt. Ska vara exakt 10 eller 13 tecken.", OCRnumber2);
            CashDeskWindowSession.FindElementByName("Stäng").Click();     
        }
    }
}
