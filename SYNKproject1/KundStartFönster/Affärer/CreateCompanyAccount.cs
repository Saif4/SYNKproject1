using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class CreateCompanyAccount : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public WindowsDriver<WindowsElement> VarukorgenFormWindowSession;
        public WindowsDriver<WindowsElement> OneNoteSession;

        public CreateCompanyAccount()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void OpenAccount()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            CustomerFormWindowSession.FindElementByName("Affärer").Click();
            WindowsElement click = CustomerFormWindowSession.FindElementByName("Nytt Konto i Valutakoncernkonto...");
            CustomerFormWindowSession.Mouse.MouseMove(click.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);
           


            // Välja typ av konto
            CustomerFormWindowSession.FindElementByAccessibilityId("cboChooseAccount").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cboChooseAccount").SendKeys("T");
            CustomerFormWindowSession.FindElementByName("OK").Click();
            CustomerFormWindowSession.FindElementByName("Penningmarknadsvillkor").FindElementByName("OK").Click();

            // Sparar konto nummret för att sedan kunna verifiera att konto nummret stämmer
            var accountNumber = CustomerFormWindowSession.FindElementByAccessibilityId("txtAccount").GetAttribute("Value.Value");
            Console.WriteLine(accountNumber);

            CustomerFormWindowSession.FindElementByName("OK").Click();

            // Hittar "Affärssammanställning"

            RootSession.FindElementByName("Verkställ").Click();
            RootSession.FindElementByName("Slutför med skriftligt godkännande").Click();
            RootSession.FindElementByName("OK").Click();

            // Väntar tills Affärssammanställning har laddats klart och sedan verifiera att den nya kontot har skapats
            Thread.Sleep(70000);
            CustomerFormWindowSession.FindElementByName("Toppkonto???????????????????????????????????").Click();

            /*if (RootSession.PageSource.Contains("Saif @ EVRY ‎- OneNote"))
             {
              var oneNote = RootSession.FindElementByName("Saif @ EVRY ‎- OneNote");
              var oneNoteWindowHandle = oneNote.GetAttribute("NativeWindowHandle");
              oneNoteWindowHandle = (int.Parse(oneNoteWindowHandle)).ToString("X");

              DesiredCapabilities oneNotecap = new DesiredCapabilities();
              oneNotecap.SetCapability("appTopLevelWindow", oneNoteWindowHandle);
              OneNoteSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), oneNotecap);
              OneNoteSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
              OneNoteSession.FindElementByAccessibilityId("Close").Click();
            }*/
            var ValidAccountNumber = CustomerFormWindowSession.FindElementByAccessibilityId("rtbEng").GetAttribute("Value.Value");
            //verify that the account has created
            Assert.That(ValidAccountNumber, Does.Contain(accountNumber));

        }
    }
}
