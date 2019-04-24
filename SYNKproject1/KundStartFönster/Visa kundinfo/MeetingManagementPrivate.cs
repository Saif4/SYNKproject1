using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class MeetingManagementPrivate : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public void NextMeeting(string datum, string klockan, string notering, string plats)
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Går in på nästa möte 
            CustomerFormWindowSession.FindElementByName("Visa kundinfo").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowRight + Keys.ArrowRight + Keys.Enter);
            CustomerFormWindowSession.FindElementByName("Datum:").SendKeys(datum);
            CustomerFormWindowSession.FindElementByName("Klockan:").SendKeys(klockan);
            CustomerFormWindowSession.FindElementByName("Notering:").SendKeys(notering);
            CustomerFormWindowSession.FindElementByName("Plats:").SendKeys(plats);
            CustomerFormWindowSession.FindElementByName("OK").Click();
        }
        public void RejectedMeeting(string avböjdDatum, string notering, string nästaDatum, string nyNotering)
        {
            // Går in på nästa möte 
            CustomerFormWindowSession.FindElementByName("Visa kundinfo").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowRight + Keys.ArrowRight + Keys.ArrowDown + Keys.Enter);
            CustomerFormWindowSession.FindElementByName("Avböjd rådgivning").FindElementByName("Datum:").SendKeys(avböjdDatum);
            CustomerFormWindowSession.FindElementByName("Avböjd rådgivning").FindElementByName("Notering:").SendKeys(notering);
            CustomerFormWindowSession.FindElementByName("Kontaktas åter").FindElementByName("Datum:").SendKeys(nästaDatum);
            CustomerFormWindowSession.FindElementByName("Kontaktas åter").FindElementByName("Notering:").SendKeys(nyNotering);
            CustomerFormWindowSession.FindElementByName("OK").Click();
        }
        public void AddNotice(string notering)
        {
            // Går in på och lägger till en notering till nästa mötet
            CustomerFormWindowSession.FindElementByName("Visa kundinfo").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowRight + Keys.ArrowRight + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            CustomerFormWindowSession.FindElementByName("Notering:").SendKeys(notering);
            CustomerFormWindowSession.FindElementByName("OK").Click();
        }
    }
}
