using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class CompilationDepositWithdraw : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public void ShowCompilationDeposit()
        {
            // Hittar kund modalen och länkar till den 
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Går in på sammanställning - inlåning
            CustomerFormWindowSession.FindElementByName("Visa kundinfo").Click();
            WindowsElement click = CustomerFormWindowSession.FindElementByName("Sammanställning");
            CustomerFormWindowSession.Mouse.MouseMove(click.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            WindowsElement click2 = CustomerFormWindowSession.FindElementByName("Inlåning");
            CustomerFormWindowSession.Mouse.MouseMove(click2.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            // Verifierar att sidan öppnas
            var CompilationDepositWindow = RootSession.FindElementByAccessibilityId("frmInlåning").Displayed;
            RootSession.FindElementByAccessibilityId("frmInlåning").FindElementByName("OK").Click();
        }
        public void ShowCompilationWithdraw()
        {
            // Går in på sammanställning - Utlåning
            CustomerFormWindowSession.FindElementByName("Visa kundinfo").Click();
            WindowsElement click = CustomerFormWindowSession.FindElementByName("Sammanställning");
            CustomerFormWindowSession.Mouse.MouseMove(click.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            WindowsElement click2 = CustomerFormWindowSession.FindElementByName("Utlåning");
            CustomerFormWindowSession.Mouse.MouseMove(click2.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            // Verifierar att sidan öppnas
            var CompilationWithdrawWindow = RootSession.FindElementByAccessibilityId("frmUtlåning").Displayed;
            RootSession.FindElementByAccessibilityId("frmUtlåning").FindElementByName("OK").Click();
            
        }
    }
}
