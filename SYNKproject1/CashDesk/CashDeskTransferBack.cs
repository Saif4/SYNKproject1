using NUnit.Framework;
using OpenQA.Selenium;
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
   public class CashDeskTransferBack : OpenCashDesk
    {
     
        public CashDeskTransferBack()
        {
            PageFactory.InitElements(OpenCashDesk.CashDeskWindowSession, this);
        }

        public void OpenCashDeskAndTransferBack(string kundnummer, string belopp)
        {
           
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTCustomernumber").SendKeys(kundnummer);
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByName("Transaktioner").Click();
            CashDeskWindowSession.FindElementByName("Transaktioner").SendKeys("Ö");
           
            CashDeskWindowSession.FindElementByXPath("//*[contains(@AutomationId,'DebitAccountDropDown')]");
            CashDeskWindowSession.FindElementByXPath("//*[contains(@Name,'Open')]").Click();
            CashDeskWindowSession.FindElementByName("Open").Click();
           
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Tab);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys(belopp);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccept").Click();

            CashDeskWindowSession.FindElementByName("UT");
            CashDeskWindowSession.FindElementByName("IN");


            CashDeskWindowSession.FindElementByName("Arkiv").Click();
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Enter);
            CashDeskWindowSession.FindElementByName("OK").Click();

            var Kundavslut = CashDeskWindowSession.FindElementByName("**** Kundavslut ****").Displayed;
      
        }

    }
}