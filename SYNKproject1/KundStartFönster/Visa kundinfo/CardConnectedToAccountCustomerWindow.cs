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
    public class CardConnectedToAccountCustomerWindow : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public void CardConnectedToAccountCustomerwindow()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Väljer ett konto 
            CustomerFormWindowSession.FindElementByName("Privatkonto???????????????????????????????????").Click();

            // Går in på Kort anslutna till konto
            CustomerFormWindowSession.FindElementByName("Visa kundinfo").Click();
            WindowsElement click = CustomerFormWindowSession.FindElementByName("Kort anslutna till konto...");
            CustomerFormWindowSession.Mouse.MouseMove(click.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            // Väljer det första tillgängliga kortet 
            CustomerFormWindowSession.FindElementByAccessibilityId("ListViewItem-0").Click();
            CustomerFormWindowSession.FindElementByName("Visa...").Click();

            // Verifierar att sidan öppnas
            var CardWindow = RootSession.FindElementByAccessibilityId("frmKortViewer").Displayed;
            RootSession.FindElementByAccessibilityId("frmKortViewer").FindElementByName("Arkiv").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            CustomerFormWindowSession.FindElementByName("OK").Click();
        }
    }
}
