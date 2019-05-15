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
    public class AccountHolder : AccountSelection
    {
        // public WindowsDriver<WindowsElement> AccountWindowSession;

        public AccountHolder()
        {
            PageFactory.InitElements(AccountSelection.AccountWindowSession, this);
        }

        public void AddAcountHolder(string personnummer)
        {
            // Hittar konto modalen och länkar till den
          /*  var accountWindowState = RootSession.FindElementByAccessibilityId("frmKonto").GetAttribute("NativeWindowHandle");
            accountWindowState = (int.Parse(accountWindowState)).ToString("x");

            DesiredCapabilities accountAppCapabilities = new DesiredCapabilities();
            accountAppCapabilities.SetCapability("appTopLevelWindow", accountWindowState);
            AccountWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), accountAppCapabilities);
            AccountWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));*/

            AccountWindowSession.FindElementByName("Lägg till").Click();
            AccountWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            var konto0 = AccountWindowSession.FindElementByAccessibilityId("_txtCustomerNo_0").GetAttribute("Value.IsReadOnly");
            var konto1 = AccountWindowSession.FindElementByAccessibilityId("_txtCustomerNo_1").GetAttribute("Value.IsReadOnly");
            var konto2 = AccountWindowSession.FindElementByAccessibilityId("_txtCustomerNo_2").GetAttribute("Value.IsReadOnly");
            var konto3 = AccountWindowSession.FindElementByAccessibilityId("_txtCustomerNo_3").GetAttribute("Value.IsReadOnly");
            var konto4 = AccountWindowSession.FindElementByAccessibilityId("_txtCustomerNo_4").GetAttribute("Value.IsReadOnly");

            // Loopar genom input fälterna för en ny kontohavare och väljer sedan den först lämpliga fält att fylla i 
            while (true)
            {

                if (konto0.Contains("False"))
                {
                    AccountWindowSession.FindElementByAccessibilityId("_txtCustomerNo_0").SendKeys(personnummer);
                }
                else if (konto1.Contains("False"))
                {
                    AccountWindowSession.FindElementByAccessibilityId("_txtCustomerNo_1").SendKeys(personnummer);
                }
                else if (konto2.Contains("False"))
                {
                    AccountWindowSession.FindElementByAccessibilityId("_txtCustomerNo_2").SendKeys(personnummer);
                }
                else if (konto3.Contains("False"))
                {
                    AccountWindowSession.FindElementByAccessibilityId("_txtCustomerNo_3").SendKeys(personnummer);
                }
                else if (konto4.Contains("False"))
                {
                    AccountWindowSession.FindElementByAccessibilityId("_txtCustomerNo_4").SendKeys(personnummer);
                }
                break;
            }

            AccountWindowSession.FindElementByAccessibilityId("frmKontohavare").FindElementByName("OK").Click();
            AccountWindowSession.FindElementByName("Slutför med skriftligt godkännande").Click();
            AccountWindowSession.FindElementByAccessibilityId("frmEsign").FindElementByName("OK").Click();

            while (true)
            {
                Console.WriteLine("enter loop");
                try
                {
                    Console.WriteLine("enter try");
                    var offscreen = AccountWindowSession.FindElementByAccessibilityId("frmKontohavare").GetAttribute("IsOffscreen");
                }
                catch (Exception)
                {
                    Console.WriteLine("enter catch");
                    break;
                   
                }
                Console.WriteLine("after break");
            }
        }
        public void DeleteHolder()
        {
            var accountWindowState = RootSession.FindElementByAccessibilityId("frmKonto").GetAttribute("NativeWindowHandle");
            accountWindowState = (int.Parse(accountWindowState)).ToString("x");

            DesiredCapabilities accountAppCapabilities = new DesiredCapabilities();
            accountAppCapabilities.SetCapability("appTopLevelWindow", accountWindowState);
            AccountWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), accountAppCapabilities);
            AccountWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Tar bort kontohavare
            AccountWindowSession.FindElementByName("Ta bort").Click();
            AccountWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            try
            {
                AccountWindowSession.FindElementByName("Check3").Click();
                AccountWindowSession.FindElementByAccessibilityId("frmKontohavare").FindElementByName("OK").Click();

                if (AccountWindowSession.FindElementByName("Slutför med skriftligt godkännande").Enabled)
                {
                    AccountWindowSession.FindElementByName("Slutför med skriftligt godkännande").Click();
                    AccountWindowSession.FindElementByAccessibilityId("frmEsign").FindElementByName("OK").Click();
                    while (true)
                    {
                        Console.WriteLine("enter loop");
                        try
                        {
                            Console.WriteLine("enter try");
                            var offscreen = AccountWindowSession.FindElementByAccessibilityId("frmKontohavare").GetAttribute("IsOffscreen");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("enter catch");
                            break;

                        }
                        Console.WriteLine("after break");
                    }
                }
                else
                {
                    Console.WriteLine("Goes to else state");
                }
               
            }
            catch (Exception)
            {
                AccountWindowSession.FindElementByName("Meddelande från Centrala Systemet").FindElementByName("OK").Click();
                AccountWindowSession.FindElementByName("Check3").Click();

                AccountWindowSession.FindElementByName("Check4").Click();
                AccountWindowSession.FindElementByAccessibilityId("frmKontohavare").FindElementByName("OK").Click();

                AccountWindowSession.FindElementByName("Slutför med skriftligt godkännande").Click();
                AccountWindowSession.FindElementByAccessibilityId("frmEsign").FindElementByName("OK").Click();
                while (true)
                {
                    Console.WriteLine("enter loop");
                    try
                    {
                        Console.WriteLine("enter try");
                        var offscreen = AccountWindowSession.FindElementByAccessibilityId("frmKontohavare").GetAttribute("IsOffscreen");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("enter catch");
                        break;

                    }
                    Console.WriteLine("after break");
                }
            }

           


           
        }
    }
}

