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
    public class NavigateToSynkStartWindow : DriversRoot
    {
        public WindowsDriver<WindowsElement> SynkWindowSession;

        public NavigateToSynkStartWindow()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void InitialSYNKStartWindow()
        {
            // Skapar en session som länkas till Synk start-fönstret.
            var synkStartWindow = RootSession.FindElementByAccessibilityId("Saljstöd");
            var synkStartWindowHandle = synkStartWindow.GetAttribute("NativeWindowHandle");
            synkStartWindowHandle = (int.Parse(synkStartWindowHandle)).ToString("x"); // Convert to Hex

            DesiredCapabilities synkAppCapabilities = new DesiredCapabilities();
            synkAppCapabilities.SetCapability("appTopLevelWindow", synkStartWindowHandle);
            SynkWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), synkAppCapabilities);
            SynkWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            
        }
    }
}
