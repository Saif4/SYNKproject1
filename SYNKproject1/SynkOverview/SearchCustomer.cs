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
    public class SearchCustomer : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerModuleSession;

        public SearchCustomer()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void Searchcustomer(string kundnamn)
        {
            // Skapar en session som länkas till Synk start-fönstret.
            var synkStartWindow = RootSession.FindElementByAccessibilityId("Saljstöd");
            var synkStartWindowHandle = synkStartWindow.GetAttribute("NativeWindowHandle");
            synkStartWindowHandle = (int.Parse(synkStartWindowHandle)).ToString("x"); // Convert to Hex

            DesiredCapabilities synkAppCapabilities = new DesiredCapabilities();
            synkAppCapabilities.SetCapability("appTopLevelWindow", synkStartWindowHandle);
            CustomerModuleSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), synkAppCapabilities);
            CustomerModuleSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Söker en kund med namnet
            CustomerModuleSession.FindElementByName("Arkiv").Click();
            CustomerModuleSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowRight + Keys.Enter);
            CustomerModuleSession.FindElementByName("Efternamn/Företag:").SendKeys(kundnamn);
            CustomerModuleSession.FindElementByName("Sök").Click();
           
            CustomerModuleSession.FindElementByName("Välj").Click();
            var personnummer = CustomerModuleSession.FindElementByName("Kundnummer:").GetAttribute("Value.Value");
            Assert.IsNotEmpty(personnummer);
        }
    }
}
