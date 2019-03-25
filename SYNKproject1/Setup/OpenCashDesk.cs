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
    public class OpenCashDesk : DriversRoot
    {
        public static WindowsDriver<WindowsElement> CashDeskWindowSession;
        public WindowsDriver<WindowsElement> SynkWindowSession;

        public string GetAccountNr()
        {
            return CheckBalance.KontoNR;
        }
        public OpenCashDesk()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }

        public void CashDesk()
        {
            NavigateToSynkStartWindow navigate = new NavigateToSynkStartWindow();
            navigate.InitialSYNKStartWindow();
            navigate.SynkWindowSession.Keyboard.SendKeys(Keys.F2);

            var CashDeskWindow = RootSession.FindElementByAccessibilityId("FrmTransaction").GetAttribute("NativeWindowHandle");
            CashDeskWindow = (int.Parse(CashDeskWindow)).ToString("x"); // Convert to Hex

            // Skapar en session som länkas till kassa fönstret.
            DesiredCapabilities CashDeskAppCapabilities = new DesiredCapabilities();
            CashDeskAppCapabilities.SetCapability("appTopLevelWindow", CashDeskWindow);
            CashDeskWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), CashDeskAppCapabilities);
            CashDeskWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // verifiera att kassan är stängd
            var EmptydeskNR = CashDeskWindowSession.FindElementByName("Kassa: ").GetAttribute("Name");
     
            string verifycashdeskIsClosed = "Kassa: ";
            Assert.AreEqual(verifycashdeskIsClosed, EmptydeskNR);
            
            // Öpnnar kassan.
            CashDeskWindowSession.FindElementByName("Kassaadministration").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Down + Keys.Right);
            CashDeskWindowSession.FindElementByName("Kassaadministration").SendKeys("Ö");
            CashDeskWindowSession.FindElementByAccessibilityId("cmdMore").Click();
            CashDeskWindowSession.FindElementByName("Stängd").Click();
            CashDeskWindowSession.FindElementByName("Välj").Click();
            Thread.Sleep(3000);
            var Desknr = CashDeskWindowSession.FindElementByName("Kassa/buntnr:").GetAttribute("Value.Value");

            CashDeskWindowSession.FindElementByName("Verkställ").Click();
            Thread.Sleep(3000);

            // Verifierar att kassan är öppet.
            var NotEmptydeskNR = CashDeskWindowSession.FindElementByName("Kassa: " + Desknr).GetAttribute("Name");
           
            string verifycashdeskIsOpen = "Kassa: ";
            Assert.AreNotEqual(verifycashdeskIsOpen, NotEmptydeskNR);
            
            
           
        }
    }
}
