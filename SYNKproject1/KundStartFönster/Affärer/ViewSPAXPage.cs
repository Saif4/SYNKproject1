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
    public class ViewSPAXPage : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public void OpenSPAXpage()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));

            // Går in i affärer och öppnar upp utskriften för värdepapper
            CustomerFormWindowSession.FindElementByName("Affärer").Click();
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowUp + Keys.ArrowRight + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            try
            {
                CustomerFormWindowSession.FindElementByName("Fel vid hämtning av kundinformation från Bitopa").FindElementByName("OK").Click();
            }
            catch (Exception)
            {
                // Beror på vilken kund man har valt så kommer felmeddelandet att visas eller inte
            }
            var PrintOutPage = CustomerFormWindowSession.FindElementByAccessibilityId("frmbuy").Displayed;
            CustomerFormWindowSession.FindElementByName("Stäng").Click();
        }
    }
}
