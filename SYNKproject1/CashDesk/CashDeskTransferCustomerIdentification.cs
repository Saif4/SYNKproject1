﻿using NUnit.Framework;
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
    public class CashDeskTransferCustomerIdentification : OpenCashDesk
    {
     
        public CashDeskTransferCustomerIdentification()
        {
            PageFactory.InitElements(OpenCashDesk.CashDeskWindowSession, this);
        }

        public void OpenCashDeskAndTransferWithCustomerIdentification(string kundnummer, string belopp)
        {
            Thread.Sleep(1000);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSTCustomernumber").SendKeys(kundnummer);
            Thread.Sleep(1000);


            CashDeskWindowSession.FindElementByName("Transaktioner").Click();
            CashDeskWindowSession.FindElementByName("Transaktioner").SendKeys("Ö");
            Thread.Sleep(2000);
 
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.Tab);
            CashDeskWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown);
            CashDeskWindowSession.FindElementByAccessibilityId("FBSMAmount").SendKeys(belopp);
            CashDeskWindowSession.FindElementByAccessibilityId("cmdAccept").Click();

            CashDeskWindowSession.FindElementByAccessibilityId("frmAMLInfo").FindElementByAccessibilityId("chkSameAsCustomer").Click();
            CashDeskWindowSession.FindElementByAccessibilityId("cmdOK").Click();

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
