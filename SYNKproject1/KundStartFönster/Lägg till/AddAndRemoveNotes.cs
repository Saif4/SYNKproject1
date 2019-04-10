using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class AddAndRemoveNotes : DriversRoot
    {      
        public WindowsDriver<WindowsElement> CustomerWindowSession;
        public AddAndRemoveNotes()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void AddNote()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex
            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Öpnnar fönstret för lägga till notiser
            CustomerWindowSession.FindElementByName("Lägg till").Click();
            CustomerWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowRight + Keys.Enter);
            CustomerWindowSession.FindElementByName("Open").Click();

            //  Väljer typ av notis och verifierar att rätt notis är vald
            CustomerWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);
            var valdTypAvNotis = CustomerWindowSession.FindElementByAccessibilityId("cboRubrik").Text;

            // Skriver en text till notisen 
            CustomerWindowSession.FindElementByName("Text:").SendKeys("Test notering");
            CustomerWindowSession.FindElementByName("OK").Click();

            // Kollar att notisen är synligt under noteringar 
            CustomerWindowSession.FindElementByName("&3 Noteringar").Click();
            CustomerWindowSession.FindElementByName(valdTypAvNotis).Click();
            var TextVerifieringen = CustomerWindowSession.FindElementByName("RichEdit Control").Text;
            Assert.That(TextVerifieringen, Does.Contain("Test notering"));
        }
        public void Removenote()
        {
           // Tar bort notisen
           CustomerWindowSession.FindElementByName("Ta bort").Click();
           CustomerWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
           CustomerWindowSession.FindElementByName("Yes").Click();
           
        }
      
    }
}

