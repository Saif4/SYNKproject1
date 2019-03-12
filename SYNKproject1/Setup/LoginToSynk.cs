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
    public class LoginToSynk : DriversRoot
    {
        
        public const string customer = "ÅkeMorrisplains.txt";
        public WindowsDriver<WindowsElement> SynkWindowSession;

        public LoginToSynk()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void Synklogin(string kundnummer)
        {
            StreamReader sr = new StreamReader(customer);
            string customerAccount = sr.ReadLine();
            string customerAccount2 = sr.ReadLine();
            //Find "SYNK - Startfönster"
           /* var synkStartWindow = RootSession.FindElementByName("SYNK - Startfönster").GetAttribute("NativeWindowHandle");//Saljstöd
             synkStartWindow = (int.Parse(synkStartWindow)).ToString("x"); // Convert to Hex

             // Create session by attaching to "SYNK - Startfönster" top level window
             DesiredCapabilities synkAppCapabilities = new DesiredCapabilities();
             synkAppCapabilities.SetCapability("appTopLevelWindow", synkStartWindow);
             SynkWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), synkAppCapabilities);
             SynkWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));
             
             SynkWindowSession.FindElementByAccessibilityId("txtKundNr").SendKeys(kundnummer);
             SynkWindowSession.FindElementByName("Aktivera").Click();*/
             RootSession.FindElementByAccessibilityId("txtKundNr").SendKeys(kundnummer);
             RootSession.FindElementByName("Aktivera").Click(); 
        }

    }
}
