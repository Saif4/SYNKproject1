using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
   public class CheckBalance : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public WindowsDriver<WindowsElement> VarukorgenFormWindowSession;
        public WindowsDriver<WindowsElement> kontoUtdragSession;
        private static string actualsaldo;
       // private static string user;

        public static string Actualsaldo
        {
            get { return actualsaldo; }
            set { actualsaldo = value; }
        }

        //private string user = "testUser";

        //properties
      // public string Actualsaldo
        //{ get { return this.actualsaldo; } set { this.Actualsaldo = value; } }
        public string kontoNr;

        public CheckBalance()
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
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var konto = CustomerFormWindowSession.FindElementByName("Privatkonto???????????????????????????????????");
            CustomerFormWindowSession.Mouse.ContextClick(konto.Coordinates);
            CustomerFormWindowSession.FindElementByName("Visa produktinfo").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);

            var kontoUtdrag = RootSession.FindElementByAccessibilityId("frmKonto").GetAttribute("NativeWindowHandle");
            kontoUtdrag = (int.Parse(kontoUtdrag)).ToString("X");

            DesiredCapabilities kontoUtdragCapabilities = new DesiredCapabilities();
            kontoUtdragCapabilities.SetCapability("appTopLevelWindow", kontoUtdrag);
            kontoUtdragSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), kontoUtdragCapabilities);
            actualsaldo = kontoUtdragSession.FindElementByAccessibilityId("txtSaldo").GetAttribute("Value.Value");
            kontoNr = kontoUtdragSession.FindElementByAccessibilityId("txtKontonr").GetAttribute("Value.Value");
            Console.WriteLine(actualsaldo);
            Console.WriteLine(kontoNr);
            kontoUtdragSession.FindElementByName("Arkiv").Click();
            kontoUtdragSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
         


        }
    }
}
