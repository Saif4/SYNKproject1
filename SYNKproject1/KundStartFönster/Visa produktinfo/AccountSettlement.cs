using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class AccountSettlement : AccountSelection
    {
        // new public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        //new public WindowsDriver<WindowsElement> AccountWindowSession;
        public AccountSettlement()
        {
        PageFactory.InitElements(AccountSelection.AccountWindowSession , this);
        }
        public void AddSettlement(string settlement, string kund)
        { 
            
            // Lägger till förordnande
            AccountWindowSession.FindElementByName("Lägg till").Click();
            AccountWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);
            try
            {
                AccountWindowSession.FindElementByName("Open").Click();
                WindowsElement select = AccountWindowSession.FindElementByName(settlement);
                AccountWindowSession.Mouse.MouseMove(select.Coordinates);
                AccountWindowSession.Mouse.Click(null);
            }
            catch (Exception)
            {

            }

            AccountWindowSession.FindElementByAccessibilityId("frmForordnande").FindElementByName("Kundnummer:").SendKeys(kund);
            AccountWindowSession.FindElementByName("Lägg till").Click();
            AccountWindowSession.FindElementByAccessibilityId("frmForordnande").FindElementByName("OK").Click();

            AccountWindowSession.FindElementByName("Slutför med skriftligt godkännande").Click();
            AccountWindowSession.FindElementByAccessibilityId("frmEsign").FindElementByName("OK").Click();

            while (true)
            {
                var accountWindow = AccountWindowSession.FindElementByAccessibilityId("frmKonto").Enabled;
                if (accountWindow == true)
                {
                    Console.WriteLine("true");
                    break;
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
                       
        }

        public void DeleteSettlement()
        {
            // Tar bort förordnande
            AccountWindowSession.FindElementByName("Ta bort").Click();
            AccountWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            AccountWindowSession.FindElementByName("Ta bort förordnande").FindElementByName("Yes").Click();
            try 
            {
                AccountWindowSession.FindElementByName("Yes");
            }
            catch (Exception)
            {

            }
            AccountWindowSession.FindElementByName("Slutför med skriftligt godkännande").Click();
            AccountWindowSession.FindElementByAccessibilityId("frmEsign").FindElementByName("OK").Click();

            while (true)
            {
                var accountwindow = AccountWindowSession.FindElementByAccessibilityId("txtForordn1").Text;
                if (accountwindow != "Disponeras av kontohavaren eller god man")
                {
                    Console.WriteLine("true");
                    break;
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        public void ChangeSettlement(string kund)
        {
            // Ändra förordnande
            AccountWindowSession.FindElementByName("Ändra").Click();
            AccountWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);
            
            // Lägger till förordnande
            AccountWindowSession.FindElementByAccessibilityId("frmForordnande").FindElementByName("Kundnummer:").SendKeys(kund);
            AccountWindowSession.FindElementByName("Lägg till").Click();

            AccountWindowSession.FindElementByAccessibilityId("ListViewItem-0").Click();
            AccountWindowSession.FindElementByAccessibilityId("frmForordnande").FindElementByName("Ta bort").Click();
            AccountWindowSession.FindElementByAccessibilityId("frmForordnande").FindElementByName("OK").Click();

            AccountWindowSession.FindElementByName("Slutför med skriftligt godkännande").Click();
            AccountWindowSession.FindElementByAccessibilityId("frmEsign").FindElementByName("OK").Click();

            while (true)
            {
                var accountWindow = AccountWindowSession.FindElementByAccessibilityId("frmKonto").Enabled;
                if (accountWindow == true)
                {
                    Console.WriteLine("true");
                    break;
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
