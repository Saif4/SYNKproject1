using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class BuyShare : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public WindowsDriver<WindowsElement> VarukorgenFormWindowSession;

        private static WindowsElement comboBoxElement = null;

        public BuyShare()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }

        public void Buyshare(string värderpappersförsvar, string värdepapper, string antal)
        {
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            // Create session by attaching to "Customer View" top level window
            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            CustomerFormWindowSession.FindElementByName("Affärer").Click();



            WindowsElement fund = CustomerFormWindowSession.FindElementByName("Värdepapper");
            CustomerFormWindowSession.Mouse.MouseMove(fund.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);
            CustomerFormWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);


            comboBoxElement = CustomerFormWindowSession.FindElementByName("Open");
            comboBoxElement.Click();
           
            WindowsElement buyfund = CustomerFormWindowSession.FindElementByName(värderpappersförsvar);
            CustomerFormWindowSession.Mouse.MouseMove(buyfund.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);
            //Värdepapperstjänst Bas ISK
            // To open the dropdown list
            // List comboListObj = CustomerFormWindowSession.FindElementsByTagName("list item"); // listobject is created
            // comboListObj.
            //ReadOnlyCollection<WindowsElement> comboListCollection = comboListObj;
            // Console.WriteLine(share);


            CustomerFormWindowSession.FindElementByAccessibilityId("txtVPKod").SendKeys(värdepapper);
            CustomerFormWindowSession.FindElementByAccessibilityId("txtAntal").SendKeys(antal);


            var sharename = CustomerFormWindowSession.FindElementByAccessibilityId("MainHeader").GetAttribute("Name");
            Console.WriteLine(sharename);
            Assert.That(sharename, Does.Contain("Kostnader och avgifter - Ericsson B"));
            CustomerFormWindowSession.FindElementByAccessibilityId("optRadgNej").Click();
            CustomerFormWindowSession.FindElementByName("Verkställ").Click();
            CustomerFormWindowSession.FindElementByName("Yes").Click();
           
            RootSession.FindElementByName("Köporder registrerad").FindElementByName("OK").Click();
            CustomerFormWindowSession.FindElementByName("Stäng").Click();

          /*  var varukorgenFormWindow = RootSession.FindElementByAccessibilityId("frmVarukorgen").GetAttribute("NativeWindowHandle");
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
