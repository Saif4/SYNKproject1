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
using System.Threading;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class BuyFund : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public WindowsDriver<WindowsElement> VarukorgenFormWindowSession;

        public BuyFund()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }

        public void Buyfund(string belopp, string konto)
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

            WindowsElement buy = CustomerFormWindowSession.FindElementByName("Köp...");
            CustomerFormWindowSession.Mouse.MouseMove(buy.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            CustomerFormWindowSession.FindElementByAccessibilityId("cmdLiquidAccount").Click();
            CustomerFormWindowSession.FindElementByName(konto).Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdOK").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdFondTorget").Click();

            /* WindowsElement text = CustomerFormWindowSession.FindElementByXPath("//*[contains(@LocalizedControlType,'text')]");
             CustomerFormWindowSession.Mouse.MouseMove(text.Coordinates);
             CustomerFormWindowSession.Mouse.Click(null);
             //CustomerFormWindowSession.FindElementByTagName("text").Click();*/
            //Hitta en fond
            CustomerFormWindowSession.FindElementByXPath("//*[contains(@LocalizedControlType,'check box')]").Click();
            CustomerFormWindowSession.FindElementByName("OK").Click();

            var fundname = CustomerFormWindowSession.FindElementByAccessibilityId("HeadingCostsAndFees").GetAttribute("Name");
            Console.WriteLine(fundname);
            Assert.IsNotEmpty(fundname);

            CustomerFormWindowSession.FindElementByAccessibilityId("txtAmountBuy").SendKeys(belopp);
            CustomerFormWindowSession.FindElementByAccessibilityId("optRadgNej").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdBuy").Click();

            WebDriverWait wait = new WebDriverWait(CustomerFormWindowSession, new TimeSpan(0, 0, 10))
            {
                PollingInterval = new TimeSpan(0, 0, 0, 0, 50)
            };
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Fondtorget - Har du handlat färdigt?")));                                         
              {
                try
                {
                    //väntar på OK knappen 
                    CustomerFormWindowSession.FindElementByName("OK").Click();
                }
                catch (Exception)
                {
                    Console.WriteLine("not found");
                }
                 
                
               }

            CustomerFormWindowSession.FindElementByAccessibilityId("cmdClose").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("frmFaktablad").FindElementByAccessibilityId("cmdClose").Click();

            /*var varukorgenFormWindow = RootSession.FindElementByAccessibilityId("frmVarukorgen").GetAttribute("NativeWindowHandle");
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