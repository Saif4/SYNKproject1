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
    public class CardConnectedToAccount : DriversRoot
    {
        public WindowsDriver<WindowsElement> SynkWindowSession;

        public CardConnectedToAccount()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void CardAccountConnection(string kontonummer)
        {
            // Skapar en session som länkas till Synk start-fönstret.
            var synkStartWindow = RootSession.FindElementByAccessibilityId("Saljstöd");
            var synkStartWindowHandle = synkStartWindow.GetAttribute("NativeWindowHandle");
            synkStartWindowHandle = (int.Parse(synkStartWindowHandle)).ToString("x"); // Convert to Hex

            // Create session by attaching to "SYNK - Startfönster" top level window
            DesiredCapabilities synkAppCapabilities = new DesiredCapabilities();
            synkAppCapabilities.SetCapability("appTopLevelWindow", synkStartWindowHandle);
            SynkWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), synkAppCapabilities);
            SynkWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            SynkWindowSession.FindElementByAccessibilityId("txtKontoNr").SendKeys(kontonummer);
            SynkWindowSession.FindElementByName("Visa").Click();
            SynkWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            var personnummer = SynkWindowSession.FindElementByAccessibilityId("ListViewItem-0").FindElementByAccessibilityId("ListViewSubItem-3").GetAttribute("Name");
            SynkWindowSession.FindElementByAccessibilityId("ListViewSubItem-3").Click();
            SynkWindowSession.FindElementByName("Visa...").Click();
            

            var personnummerInCardModule = RootSession.FindElementByAccessibilityId("txtKundnr").GetAttribute("Value.Value");
            var KontonummerInCardModule = RootSession.FindElementByAccessibilityId("txtKontoNummer").GetAttribute("Value.Value");

            Assert.AreEqual(personnummer, personnummerInCardModule);
            Assert.AreEqual(kontonummer, KontonummerInCardModule);
            SynkWindowSession.FindElementByName("OK").Click();
        }
    }
}
