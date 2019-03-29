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
    public class CustomerDataView : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public CustomerDataView()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void SelectStartupPage(string selectStartupPage)
        {
            // Öppnar ändra/uppdatera handläggaruppgifter
            RootSession.FindElementByName("Verktyg").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            // Väljer start vyn för kundervyn och verifierar att rätt val är vald (kunduppgifter)
            RootSession.FindElementByName("Open").Click();
            var kunduppgifter = RootSession.FindElementByName(selectStartupPage);
            kunduppgifter.Click();
            var valavbehörighet = RootSession.FindElementByName("Behörighet:").GetAttribute("Value.Value");
            Assert.AreEqual(valavbehörighet, "Kunduppgifter");
            RootSession.FindElementByName("Spara ändringar").Click();
            RootSession.FindElementByName("Stäng").Click();
        }
        public void VerifySelectedPage(string kundnummer)
        { 
            // Loggar in på en kund
            RootSession.FindElementByAccessibilityId("txtKundNr").SendKeys(kundnummer);
            RootSession.FindElementByName("Aktivera").Click();

            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView");
            var customerFormWindowHandle = customerFormWindow.GetAttribute("NativeWindowHandle");
            customerFormWindowHandle = (int.Parse(customerFormWindowHandle)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindowHandle);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Verifierar att rätt vy är öppet
            var valdbehörighet = CustomerFormWindowSession.FindElementByName(kundnummer).Displayed;
          
            // Väljer engagemang vy och verifierar att rätt vy är öppet
            CustomerFormWindowSession.FindElementByName("&2 Engagemang").Click();
            var engagemangvyn = CustomerFormWindowSession.FindElementByAccessibilityId("rtbEng").GetAttribute("Value.Value");
            Assert.That(engagemangvyn, Does.Contain("Tillgångar"));

            // Väljer notering vy och verifierar att rätt vy är öppet
            CustomerFormWindowSession.FindElementByName("&3 Noteringar").Click();
            var noteringsvyn = CustomerFormWindowSession.FindElementByAccessibilityId("_tabCustView_TabPage2").GetAttribute("Name");
            Assert.That(noteringsvyn, Does.Contain("Noteringar"));

            // Väljer extern info vy och verifierar att rätt vy är öppet
            CustomerFormWindowSession.FindElementByName("&4 Extern info").Click();
            var externinfo = CustomerFormWindowSession.FindElementByAccessibilityId("_tabCustView_TabPage3").GetAttribute("Name");
            Assert.That(externinfo, Does.Contain("Extern info"));

            // Stänger kund fönstret
            CustomerFormWindowSession.FindElementByName("Arkiv").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

   
        }
    }
}
