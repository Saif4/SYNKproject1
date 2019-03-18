﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class SellFund : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public WindowsDriver<WindowsElement> VarukorgenFormWindowSession;

        public SellFund()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }

        public void Sellfund(string belopp, string konto)
        {
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            // Create session by attaching to "Customer View" top level window
            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            CustomerFormWindowSession.FindElementByName("Affärer").Click();

            WindowsElement fund = CustomerFormWindowSession.FindElementByName("Fonder");
            CustomerFormWindowSession.Mouse.MouseMove(fund.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);
            WindowsElement buy = CustomerFormWindowSession.FindElementByName("Sälj...");
            CustomerFormWindowSession.Mouse.MouseMove(buy.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            CustomerFormWindowSession.FindElementByAccessibilityId("cmdLiquidAccount").Click();
            CustomerFormWindowSession.FindElementByName(konto).Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdOK").Click();

            /* UserListPage.initialiazeUserListPage();
             WindowsElement  userListItem = CustomerFormWindowSession.FindElementByAccessibilityId("lvwFundPossess"); //if (userListItem.size() != 0)


             List<WindowsElement> list = userListItem.fin (List<WindowsElement>)userListItem;
                 if (list.Count() != 0)
                 {
                     for (int i = 0; i < list.Count(); i++)
                     {
                        // for (IWebElement e : userListItem.get(i).findElements(By.name("userName")))
                        {
                         Console.WriteLine(i); //System.out.println(e.getText());
                         }
                     }
                 }
                 else
                 {
                     Assert.Fail("Folder doesn't have any user.");
                 }*/

            CustomerFormWindowSession.FindElementByAccessibilityId("ListViewItem-0").Click();
            var fundvalue = CustomerFormWindowSession.FindElementByAccessibilityId("ListViewItem-0").FindElementByAccessibilityId("ListViewSubItem-3").GetAttribute("Name");
            var fundvalueconverted = Convert.ToInt64(Convert.ToDouble(fundvalue));
            //Console.WriteLine(fundvalueconverted);
            
            CustomerFormWindowSession.FindElementByAccessibilityId("txtAmountSell").SendKeys(belopp);
            CustomerFormWindowSession.FindElementByAccessibilityId("optRadgNej").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdSell").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdClose").Click();

           /* var varukorgenFormWindow = RootSession.FindElementByAccessibilityId("frmVarukorgen").GetAttribute("NativeWindowHandle");
            varukorgenFormWindow = (int.Parse(varukorgenFormWindow)).ToString("x"); // Convert to Hex

            // Create session by attaching to "Affärssammanställning" top level window
            DesiredCapabilities varukorgenFormAppCapabilities = new DesiredCapabilities();
            varukorgenFormAppCapabilities.SetCapability("appTopLevelWindow", varukorgenFormWindow);
            VarukorgenFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), varukorgenFormAppCapabilities);
            VarukorgenFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            VarukorgenFormWindowSession.FindElementByName("Verkställ").Click();
            VarukorgenFormWindowSession.FindElementByName("Slutför med skriftligt godkännande").Click();
            VarukorgenFormWindowSession.FindElementByName("OK").Click();*/

        }
    }
}
