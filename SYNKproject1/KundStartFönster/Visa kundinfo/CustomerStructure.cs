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
    public class CustomerStructure : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public void ASK()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Går in på kundstruktor och väljer ASK
            CustomerFormWindowSession.FindElementByName("Visa kundinfo").Click();
            WindowsElement click = CustomerFormWindowSession.FindElementByName("Kundstruktur");
            CustomerFormWindowSession.Mouse.MouseMove(click.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            
            WindowsElement clickASK = CustomerFormWindowSession.FindElementByName("Intressegemenskap ASK...");
            CustomerFormWindowSession.Mouse.MouseMove(clickASK.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            
            // Verifierar att sidan öppnas
            var ASKOverviewWindow = RootSession.FindElementByAccessibilityId("frmKundstruktur").Displayed;
            RootSession.FindElementByAccessibilityId("frmKundstruktur").FindElementByName("Arkiv").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

        }
        public void Company()
        {
            // Går in på kundstruktor och väljer företag
            CustomerFormWindowSession.FindElementByName("Visa kundinfo").Click();
            WindowsElement click = CustomerFormWindowSession.FindElementByName("Kundstruktur");
            CustomerFormWindowSession.Mouse.MouseMove(click.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);


            WindowsElement clickASK = CustomerFormWindowSession.FindElementByName("Företag...");
            CustomerFormWindowSession.Mouse.MouseMove(clickASK.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);


            // Verifierar att sidan öppnas
            var ASKOverviewWindow = RootSession.FindElementByAccessibilityId("frmKundstruktur").Displayed;
            RootSession.FindElementByAccessibilityId("frmKundstruktur").FindElementByName("Arkiv").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }
    }
}
