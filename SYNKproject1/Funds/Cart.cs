using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class Cart : DriversRoot
    {
        public static WindowsDriver<WindowsElement> CartSession;
        public WindowsDriver<WindowsElement> SynkWindowSession;

       
        public Cart()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }

        public void Cartview()
        {
            // Hittar varukorgen och länkar till den
            var varukorgenFormWindow = RootSession.FindElementByAccessibilityId("frmVarukorgen").GetAttribute("NativeWindowHandle");
            varukorgenFormWindow = (int.Parse(varukorgenFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities varukorgenFormAppCapabilities = new DesiredCapabilities();
            varukorgenFormAppCapabilities.SetCapability("appTopLevelWindow", varukorgenFormWindow);
            CartSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), varukorgenFormAppCapabilities);
            CartSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Verställer alla köp och sälj av fonder och aktier 
            CartSession.FindElementByName("Verkställ").Click();
            CartSession.FindElementByName("Slutför med skriftligt godkännande").Click();
            CartSession.FindElementByName("OK").Click();
            Thread.Sleep(50000);
           
        }
    }
}
