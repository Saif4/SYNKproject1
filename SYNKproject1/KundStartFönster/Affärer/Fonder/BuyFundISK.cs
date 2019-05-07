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
    public class BuyFundISK : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public WindowsDriver<WindowsElement> VarukorgenFormWindowSession;

        public BuyFundISK()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }

        public void BuyfundISK(string fondkonto, string belopp, string konto)
        {
            // Hittar kund modalen och länkar till den
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Öpnnar köp fonder fönstret
            CustomerFormWindowSession.FindElementByName("Affärer").Click();
            WindowsElement fund = CustomerFormWindowSession.FindElementByName("Fonder");
            CustomerFormWindowSession.Mouse.MouseMove(fund.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            WindowsElement buy = CustomerFormWindowSession.FindElementByName("Köp...");
            CustomerFormWindowSession.Mouse.MouseMove(buy.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            // Ange vilket konto som ska användas för fondköpet
            CustomerFormWindowSession.FindElementByAccessibilityId("cboFundAccount").FindElementByName("Open").Click();
            WindowsElement fundaccount = CustomerFormWindowSession.FindElementByName(fondkonto);
            CustomerFormWindowSession.Mouse.MouseMove(fundaccount.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

         /*   // Ange vilket konto som ska användas för fondköpet
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdLiquidAccount").Click();
            CustomerFormWindowSession.FindElementByName(konto).Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdOK").Click();*/

            //Hitta en fond
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdFondTorget").Click();
            CustomerFormWindowSession.FindElementByXPath("//*[contains(@LocalizedControlType,'check box')]").Click();
            CustomerFormWindowSession.FindElementByName("OK").Click();

            // Verifiera Web Service funktionen anropas och fonden namn är synligt
            var fundname = CustomerFormWindowSession.FindElementByAccessibilityId("HeadingCostsAndFees").GetAttribute("Name");
            Console.WriteLine(fundname);
            Assert.IsNotEmpty(fundname);

            // Slutföra fondköpet
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
                    Assert.Fail();
                }


            }

            // Stänger fond fönstret
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdClose").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("frmFaktablad").FindElementByAccessibilityId("cmdClose").Click();
        }
    }
}
