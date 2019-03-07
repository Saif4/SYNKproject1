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
    public class TestClass : DriversRoot
    {
        public WindowsDriver<WindowsElement> CashDeskWindowSession;
        public WindowsDriver<WindowsElement> SynkWindowSession;

        public TestClass()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }

        public void OpenCashDeskAndTransferWithCustomerIdentification(string kundnummer, string belopp)
        {
            NavigateToSynkStartWindow navigate = new NavigateToSynkStartWindow();
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
            Assert.AreNotEqual(verifycashdeskIsOpen, NotEmptydeskNR);
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTCustomernumber").SendKeys(kundnummer);
            Thread.Sleep(1000);


            CashDeskWindowSession.FindElementByName("Transaktioner").Click();
            CashDeskWindowSession.FindElementByName("Transaktioner").SendKeys("Ö");
            Thread.Sleep(2000);

            //CashDeskWindowSession.FindElementByXPath("//*Pane[@name='Desktop 1']/window[@name='LENA GILBERTPLAINS, 19530630-0368 - Kassa']");
            ///window[@name='LENA GILBERTPLAINS, 19530630-0368 - Överföring']/combo box[@name='Valuta:']/button[@name='Open']").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Tab);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys(belopp);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccept").Click();
            /*
            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(CashDeskWindowSession.FindElementsByAccessibilityId("frmAMLInfo"));

            if (elementList.Count > 0)
            {
                //If the count is greater than 0 your element exists.
                elementList[0].Click();
                CashDeskWindowSession.FindElementByAccessibilityId("chkSameAsCustomer").Click();
            }
            */
            if (CashDeskWindowSession.PageSource.Contains("frmAMLInfo"))
            {
                CashDeskWindowSession.FindElementByAccessibilityId("frmAMLInfo").FindElementByAccessibilityId("chkSameAsCustomer").Click();
                CashDeskWindowSession.FindElementByAccessibilityId("cmdOK").Click();
            }
            //CashDeskWindowSession.FindElementByAccessibilityId("chkSameAsCustomer").Click();
           // CashDeskWindowSession.FindElementByAccessibilityId("cmdOK").Click();

            CashDeskWindowSession.FindElementByName("UT");
            CashDeskWindowSession.FindElementByName("IN");
            CashDeskWindowSession.FindElementByName("Arkiv").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);
            CashDeskWindowSession.FindElementByName("OK").Click();

            var Kundavslut = CashDeskWindowSession.FindElementByName("**** Kundavslut ****").Displayed;
            CashDeskWindowSession.FindElementByName("Kassaadministration").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Down + Keys.Right);
            CashDeskWindowSession.FindElementByName("Kassaadministration").SendKeys("S");
            CashDeskWindowSession.FindElementByName("Verkställ").Click();
            CashDeskWindowSession.FindElementByName("Verkställ").Click();

            CashDeskWindowSession.FindElementByName("Arkiv").Click();
            CashDeskWindowSession.FindElementByName("Arkiv").SendKeys("A");
            // WAIT METODEN
           /* var progressBar = mainWindow.FindElementByClassName("Window").FindElementByAccessibilityId("progressor");
            WebDriverWait waitProgressBar = new WebDriverWait(_session, new TimeSpan(0, 0, 15));
            waitProgressBar.PollingInterval = new TimeSpan(0, 0, 0, 0, 50);
            waitProgressBar.Until(driver =>
            {
                try
                {
                    progressBar.GetScreenshot();
                    return false;
                }
                catch (Exception)
                { }
                return true;
            }
            */



        }

    }
}
