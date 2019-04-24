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
        public static string Actualsaldo
        {
            get { return actualsaldo; }
            set { actualsaldo = value; }
        }
        private static string kontoNr;
        public static string KontoNR
        {
            get { return kontoNr; }
            set { kontoNr = value; }
        }

        public CheckBalance()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void OpenAccountAndVerifyBalance()
        {

            // Väljer ett konto
            var konto = RootSession.FindElementByName("Privatkonto???????????????????????????????????");
            RootSession.Mouse.ContextClick(konto.Coordinates);
            RootSession.FindElementByName("Visa produktinfo").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);

            /*var kontoUtdrag = RootSession.FindElementByAccessibilityId("frmKonto").GetAttribute("NativeWindowHandle");
            kontoUtdrag = (int.Parse(kontoUtdrag)).ToString("X");

            DesiredCapabilities kontoUtdragCapabilities = new DesiredCapabilities();
            kontoUtdragCapabilities.SetCapability("appTopLevelWindow", kontoUtdrag);
            kontoUtdragSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), kontoUtdragCapabilities);*/
            // Hittar saldot och kontonummer på den valda kontot och sparar dessa i variabler
            actualsaldo = RootSession.FindElementByAccessibilityId("txtSaldo").GetAttribute("Value.Value");
            kontoNr = RootSession.FindElementByAccessibilityId("txtKontonr").GetAttribute("Value.Value");
            Console.WriteLine("Nuvarande Saldo:" + actualsaldo);
            Console.WriteLine("Kontonummer:" + kontoNr);
            RootSession.FindElementByName("Arkiv").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
       
        }
    }
}
