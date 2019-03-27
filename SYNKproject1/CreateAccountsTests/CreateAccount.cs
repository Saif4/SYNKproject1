using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
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
    public class CreateAccount : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public WindowsDriver<WindowsElement> VarukorgenFormWindowSession;
        public WindowsDriver<WindowsElement> OneNoteSession;

        public CreateAccount()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void OpenAccount()
        {      
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView");
            var customerFormWindowHandle = customerFormWindow.GetAttribute("NativeWindowHandle");
            customerFormWindowHandle = (int.Parse(customerFormWindowHandle)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindowHandle);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            CustomerFormWindowSession.FindElementByName("Affärer").Click();
            CustomerFormWindowSession.FindElementByName("Nytt Konto...").Click();


            // Välja typ av konto
            CustomerFormWindowSession.FindElementByAccessibilityId("cboChooseAccount").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cboChooseAccount").SendKeys("B");
            CustomerFormWindowSession.FindElementByName("OK").Click();

            // Sparar konto nummret för att sedan kunna verifiera att konto nummret stämmer
            var accountNumber = CustomerFormWindowSession.FindElementByAccessibilityId("txtAccount").GetAttribute("Value.Value");
            Console.WriteLine(accountNumber);

            CustomerFormWindowSession.FindElementByName("OK").Click();

            // Hittar "Affärssammanställning"
           /* var varukorgenFormWindow = RootSession.FindElementByAccessibilityId("frmVarukorgen");
            var varukorgenFormWindowHandle = varukorgenFormWindow.GetAttribute("NativeWindowHandle");
            varukorgenFormWindowHandle = (int.Parse(varukorgenFormWindowHandle)).ToString("x"); // Convert to Hex

            // Create session by attaching to "Affärssammanställning" top level window
            DesiredCapabilities varukorgenFormAppCapabilities = new DesiredCapabilities();
            varukorgenFormAppCapabilities.SetCapability("appTopLevelWindow", varukorgenFormWindowHandle);
            VarukorgenFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), varukorgenFormAppCapabilities);
            VarukorgenFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));*/
            RootSession.FindElementByName("Verkställ").Click();
            RootSession.FindElementByName("Slutför med skriftligt godkännande").Click();
            RootSession.FindElementByName("OK").Click();

            // Väntar tills Affärssammanställning har laddats klart och sedan verifiera att den nya kontot har skapats
            Thread.Sleep(50000);
            WebDriverWait wait = new WebDriverWait(CustomerFormWindowSession, new TimeSpan(0, 0, 10))
            {
                PollingInterval = new TimeSpan(0, 0, 0, 0, 50)
            };
            wait.Until(ExpectedConditions.ElementToBeClickable(CustomerFormWindowSession.FindElementByName("Bokonto?????????????????????????????????????"))).Click();

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

