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
    public class FinishedIPcontract : DriversRoot
    {
        public WindowsDriver<WindowsElement> SynkWindowSession;

        public FinishedIPcontract()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void FinishedIpcontract(string kontonummer)
        {
            // Skapar en session som länkas till Synk start-fönstret.
            var synkStartWindow = RootSession.FindElementByAccessibilityId("Saljstöd");
            var synkStartWindowHandle = synkStartWindow.GetAttribute("NativeWindowHandle");
            synkStartWindowHandle = (int.Parse(synkStartWindowHandle)).ToString("x"); // Convert to Hex

            DesiredCapabilities synkAppCapabilities = new DesiredCapabilities();
            synkAppCapabilities.SetCapability("appTopLevelWindow", synkStartWindowHandle);
            SynkWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), synkAppCapabilities);
            SynkWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Öpnnar Avslutat IP-avtal vyn och väljer ett kontonummer 
            SynkWindowSession.FindElementByName("Visa").Click();
            SynkWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            SynkWindowSession.FindElementByName("Avslutat IP-avtal").FindElementByName("Kontonummer:").SendKeys(kontonummer);
            SynkWindowSession.FindElementByName("OK").Click();

            // Hämtar ut avslutat datum från centrala systemet
            var dateCentralSystem = SynkWindowSession.FindElementByAccessibilityId("65535").GetAttribute("Name");
            SynkWindowSession.FindElementByName("OK").Click();

            // Hämtar ut avslutat datum från pensions-avtalet
            var datePensionContract = RootSession.FindElementByAccessibilityId("txtAvslut").GetAttribute("Value.Value");
            
            // Verifierar att datumet stämmer överens
            Assert.That(dateCentralSystem, Does.Contain(datePensionContract));
        }
    }
}
