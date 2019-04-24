using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
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
    public class VerifyBalance : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public WindowsDriver<WindowsElement> VarukorgenFormWindowSession;
        public WindowsDriver<WindowsElement> kontoUtdragSession;

        public string GetSaldo()
        {
            return CheckBalance.Actualsaldo;
        }

        public VerifyBalance()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void OpenAccountAndVerifyBalance()
        {
            // Find "Customer View"
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView");
            var customerFormWindowHandle = customerFormWindow.GetAttribute("NativeWindowHandle");
            customerFormWindowHandle = (int.Parse(customerFormWindowHandle)).ToString("x"); // Convert to Hex

            // Create session by attaching to "Customer View" top level window
            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindowHandle);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            // Väljer ett konto
            var konto = CustomerFormWindowSession.FindElementByName("Privatkonto???????????????????????????????????");
            CustomerFormWindowSession.Mouse.ContextClick(konto.Coordinates);
            CustomerFormWindowSession.Mouse.ContextClick(konto.Coordinates);
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);
            // Kollar att ett felmeddelande från centrala systemet dyker upp
             if (CustomerFormWindowSession.PageSource.Contains("Meddelande från Centrala Systemet"))
             {
                CustomerFormWindowSession.FindElementByName("No").Click();
             }

            // Hämtar ut nya saldot
            var Newsaldo = RootSession.FindElementByAccessibilityId("lvwSaldo").FindElementByAccessibilityId("ListViewItem-0").FindElementByAccessibilityId("ListViewSubItem-2").GetAttribute("Name");
            Console.WriteLine("Nya Saldo:" + Newsaldo);
            Thread.Sleep(1000);
            
            // Verifierar att nya saldot inte är samma saldo som det var innan betlaningen
            Assert.AreNotEqual(CheckBalance.Actualsaldo, Newsaldo);
            RootSession.FindElementByName("OK").Click();
         
        }
    }
}

