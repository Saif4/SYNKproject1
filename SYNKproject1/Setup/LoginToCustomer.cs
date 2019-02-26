using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    //Customer selection
    public class LoginToCustomer : Drivers
    {
        
        public const string customer = "ÅkeMorrisplains.txt";
        public WindowsDriver<WindowsElement> SynkWindowSession;

        public LoginToCustomer()
        {
            PageFactory.InitElements(Drivers.RootSession, this);
        }
        public void InitialSYNKlogin()
        {
           
            StreamReader sr = new StreamReader(customer);
            string customerAccount = sr.ReadLine();
            //Find "SYNK - Startfönster"
            var synkStartWindow = RootSession.FindElementByName("SYNK - Startfönster");
            var synkStartWindowHandle = synkStartWindow.GetAttribute("NativeWindowHandle");
            synkStartWindowHandle = (int.Parse(synkStartWindowHandle)).ToString("x"); // Convert to Hex

            // Create session by attaching to "SYNK - Startfönster" top level window
            DesiredCapabilities synkAppCapabilities = new DesiredCapabilities();
            synkAppCapabilities.SetCapability("appTopLevelWindow", synkStartWindowHandle);
            SynkWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), synkAppCapabilities);
            SynkWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));

            SynkWindowSession.FindElementByAccessibilityId("txtKundNr").SendKeys(customerAccount);
            SynkWindowSession.FindElementByName("Aktivera").Click();
        }

    }
}
