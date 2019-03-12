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

        public new string GetAccountNr()
        {
            return CheckBalance.KontoNR;
        }
        public ChangePayment()
        {
            PageFactory.InitElements(OpenCashDesk.CashDeskWindowSession, this);
        }

        public void BgAndPGpayment(string kundnummer, string belopp, string mottagare, string ocr)
        {
           /* NavigateToSynkStartWindow navigate = new NavigateToSynkStartWindow();
            navigate.InitialSYNKStartWindow();
            navigate.SynkWindowSession.Keyboard.SendKeys(Keys.F2);

            var CashDeskWindow = RootSession.FindElementByAccessibilityId("FrmTransaction").GetAttribute("NativeWindowHandle");
            CashDeskWindow = (int.Parse(CashDeskWindow)).ToString("x"); // Convert to Hex

            // Create session by attaching to "Customer View" top level window
            DesiredCapabilities CashDeskAppCapabilities = new DesiredCapabilities();
            CashDeskAppCapabilities.SetCapability("appTopLevelWindow", CashDeskWindow);
            CashDeskWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), CashDeskAppCapabilities);
            CashDeskWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // verifiera att kassan är stängd
            var EmptydeskNR = CashDeskWindowSession.FindElementByName("Kassa: ").GetAttribute("Name");
            Console.WriteLine(EmptydeskNR);
            string verifycashdeskIsClosed = "Kassa: ";
            Assert.AreEqual(verifycashdeskIsClosed, EmptydeskNR);

            CashDeskWindowSession.FindElementByName("Kassaadministration").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Down + Keys.Right);
            CashDeskWindowSession.FindElementByName("Kassaadministration").SendKeys("Ö");
            CashDeskWindowSession.FindElementByAccessibilityId("cmdMore").Click();
            CashDeskWindowSession.FindElementByName("Stängd").Click();
            CashDeskWindowSession.FindElementByName("Välj").Click();
            Thread.Sleep(3000);
            var Desknr = CashDeskWindowSession.FindElementByName("Kassa/buntnr:").GetAttribute("Value.Value");

            Console.WriteLine(Desknr);

            CashDeskWindowSession.FindElementByName("Verkställ").Click();
            Thread.Sleep(3000);
            var NotEmptydeskNR = CashDeskWindowSession.FindElementByName("Kassa: " + Desknr).GetAttribute("Name");
            Console.WriteLine(NotEmptydeskNR);
            string verifycashdeskIsOpen = "Kassa: ";
            Assert.AreNotEqual(verifycashdeskIsOpen, NotEmptydeskNR);*/
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTCustomernumber").SendKeys(kundnummer);
            Thread.Sleep(1000);

            CashDeskWindowSession.FindElementByAccessibilityId("txtAction").Clear();
            CashDeskWindowSession.FindElementByAccessibilityId("txtAction").SendKeys("31+");
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTAccountnumber").SendKeys(CheckBalance.KontoNR);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTPGBG").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTPGBG").SendKeys(mottagare);
            CashDeskWindowSession.FindElementByAccessibilityId("txtPGBGMessage").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("txtPGBGMessage").SendKeys(ocr);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSCustomerId").SendKeys(kundnummer);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdGetCustomerInfo").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys(belopp);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAddPayment").Click();

            CashDeskWindowSession.FindElementByName("I kö").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("cmdChange").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").Clear();
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys("200");
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAddPayment").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccept").Click();

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