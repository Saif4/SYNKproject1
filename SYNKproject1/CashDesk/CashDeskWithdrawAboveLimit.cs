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
    public class CashDeskWithdrawAboveLimit : OpenCashDesk
    {
      //  public WindowsDriver<WindowsElement> CashDeskWindowSession;
      //  public WindowsDriver<WindowsElement> SynkWindowSession;

        public CashDeskWithdrawAboveLimit()
        {
            PageFactory.InitElements(OpenCashDesk.CashDeskWindowSession, this);
        }

        public void WithdrawAboveLimit(string kundnummer, string belopp)
        {
            /* NavigateToSynkStartWindow navigate = new NavigateToSynkStartWindow();
               navigate.InitialSYNKStartWindow();
               navigate.SynkWindowSession.Keyboard.SendKeys(Keys.F2);

               var CashDeskWindow = RootSession.FindElementByAccessibilityId("FrmTransaction");
               var CashDeskWindowHandle = CashDeskWindow.GetAttribute("NativeWindowHandle");
               CashDeskWindowHandle = (int.Parse(CashDeskWindowHandle)).ToString("x"); // Convert to Hex

               // Create session by attaching to "Customer View" top level window
               DesiredCapabilities CashDeskAppCapabilities = new DesiredCapabilities();
               CashDeskAppCapabilities.SetCapability("appTopLevelWindow", CashDeskWindowHandle);
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

            CashDeskWindowSession.FindElementByName("Transaktioner").Click();
            CashDeskWindowSession.FindElementByName("Transaktioner").SendKeys("U");
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccountnumber").Click();
            CashDeskWindowSession.FindElementByName("Privatkonto").Click();
            CashDeskWindowSession.FindElementByName("OK").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys(belopp);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccept").Click();

            if (CashDeskWindowSession.PageSource.Contains("frmAMLInfo"))
            {
                CashDeskWindowSession.FindElementByAccessibilityId("frmAMLInfo").FindElementByAccessibilityId("chkSameAsCustomer").Click();
                CashDeskWindowSession.FindElementByAccessibilityId("cmdOK").Click();
            }

            var In = CashDeskWindowSession.FindElementByName("UT").Displayed;

            CashDeskWindowSession.FindElementByName("Arkiv").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);
            CashDeskWindowSession.FindElementByName("OK").Click();

            var Kundavslut = CashDeskWindowSession.FindElementByName("**** Kundavslut ****").Displayed;

            
        }
    }
}

