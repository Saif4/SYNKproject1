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
            /*var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView");
            var customerFormWindowHandle = customerFormWindow.GetAttribute("NativeWindowHandle");
            customerFormWindowHandle = (int.Parse(customerFormWindowHandle)).ToString("x"); // Convert to Hex

            // Create session by attaching to "Customer View" top level window
            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindowHandle);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));*/
            var konto = RootSession.FindElementByName("Privatkonto???????????????????????????????????");
            RootSession.Mouse.ContextClick(konto.Coordinates);
            RootSession.Mouse.ContextClick(konto.Coordinates);
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);

             if (RootSession.PageSource.Contains("Meddelande från Centrala Systemet"))
             {
                RootSession.FindElementByName("No").Click();
             }

           /* var kontoUtdrag = RootSession.FindElementByAccessibilityId("frmKontoUtdrag").GetAttribute("NativeWindowHandle");
            kontoUtdrag = (int.Parse(kontoUtdrag)).ToString("X");

            DesiredCapabilities kontoUtdragCapabilities = new DesiredCapabilities();
            kontoUtdragCapabilities.SetCapability("appTopLevelWindow", kontoUtdrag);
            kontoUtdragSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), kontoUtdragCapabilities);*/
            var Newsaldo = RootSession.FindElementByAccessibilityId("lvwSaldo").FindElementByAccessibilityId("ListViewItem-0").FindElementByAccessibilityId("ListViewSubItem-2").GetAttribute("Name");
            Console.WriteLine("Nya Saldo:" + Newsaldo);
            Thread.Sleep(1000);
           // CheckBalance checkBalance = new CheckBalance();
            //string us = checkBalance.User;
           // string actualsaldoo = checkBalance.Actualsaldo;
            //Console.WriteLine(actualsaldoo);
            Assert.AreNotEqual(CheckBalance.Actualsaldo, Newsaldo);
          


        }
    }
}

