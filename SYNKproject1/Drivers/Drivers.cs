using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class Drivers
    {
        public const string windowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public const string SYNKAppId = @"C:\Program Files (x86)\SYNKNET\Starternet.exe";

        public static WindowsDriver<WindowsElement> RootSession;
        public static WindowsDriver<WindowsElement> SYNKSession;
        public static WindowsDriver<WindowsElement> AMWSession;



        public Drivers()
        {
            if (SYNKSession == null)
            {
                DesiredCapabilities SYNKCapabilities = new DesiredCapabilities();
                SYNKCapabilities.SetCapability("app", SYNKAppId);
                SYNKCapabilities.SetCapability("deviceName", "WindowsPC");
                SYNKSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), SYNKCapabilities);
                SYNKSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                SYNKSession.FindElementByName("32701010").Click();
                SYNKSession.FindElementByName("OK").Click();

                DesiredCapabilities RootCapabilities = new DesiredCapabilities();
                RootCapabilities.SetCapability("app", "Root");
                RootCapabilities.SetCapability("deviceName", "WindowsPC");
                RootSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), RootCapabilities);
                RootSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                /*RootSession.FindElementByName("Påloggning På Central Systemet");
                
                                bool IsElementPresent(By by)
                                {
                                    try
                                    {
                                        RootSession.FindElementByName("Påloggning På Central Systemet");
                                        return true;
                                    }
                                    catch (NoSuchElementException)
                                    {
                                        return false;
                                    }
                                }
                                if (IsElementPresent(By.Id("Påloggning På Central Systemet")))
                                {


                                    //do if exists
                                }
                            }
                            else
                            {
                                   //do if does { not exists}
                            }*/
            }
        }
    }
}






    

