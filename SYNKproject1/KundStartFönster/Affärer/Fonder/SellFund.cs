using NUnit.Framework;
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
            // Hittar kund modalen och länkar till den
            var customerFormWindow = RootSession.FindElementByAccessibilityId("frmCustView").GetAttribute("NativeWindowHandle");
            customerFormWindow = (int.Parse(customerFormWindow)).ToString("x"); // Convert to Hex

            DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
            customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindow);
            CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
            CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Går in i sälj fond modalen
            CustomerFormWindowSession.FindElementByName("Affärer").Click();

            WindowsElement fund = CustomerFormWindowSession.FindElementByName("Fonder");
            CustomerFormWindowSession.Mouse.MouseMove(fund.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);
            WindowsElement buy = CustomerFormWindowSession.FindElementByName("Sälj...");
            CustomerFormWindowSession.Mouse.MouseMove(buy.Coordinates);
            CustomerFormWindowSession.Mouse.Click(null);

            // Väljer ett konto som har fonder att sälja 
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdLiquidAccount").Click();
            CustomerFormWindowSession.FindElementByName(konto).Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdOK").Click();

            // Väljer en fond ska säljas
            CustomerFormWindowSession.FindElementByAccessibilityId("ListViewItem-0").Click();
            var fundvalue = CustomerFormWindowSession.FindElementByAccessibilityId("ListViewItem-0").FindElementByAccessibilityId("ListViewSubItem-3").GetAttribute("Name");
            var fundvalueconverted = Convert.ToInt64(Convert.ToDouble(fundvalue));
            //Console.WriteLine(fundvalueconverted);

            // Väljer beloppet som ska säljas och slutföra processen 
            CustomerFormWindowSession.FindElementByAccessibilityId("txtAmountSell").SendKeys(belopp);
            CustomerFormWindowSession.FindElementByAccessibilityId("optRadgNej").Click();
            CustomerFormWindowSession.FindElementByAccessibilityId("cmdSell").Click();
           
            var SellWindow = CustomerFormWindowSession.FindElementByAccessibilityId("frmSell").Enabled;
            
        

            if (SellWindow == true)
            {
                CustomerFormWindowSession.FindElementByAccessibilityId("cmdClose").Click();

            }
            else
            {
                Assert.Fail();
            }
            
           
        }
    }
}
