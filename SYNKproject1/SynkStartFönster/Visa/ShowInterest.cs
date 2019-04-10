using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class ShowInterest : DriversRoot
    {
        public WindowsDriver<WindowsElement> CustomerModuleSession;

        public ShowInterest()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }

        public void Showinterest()
        {
            // Verifierar att Ränta vyn öppnas
            RootSession.FindElementByName("Visa").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            string InterestWindow = RootSession.FindElementByAccessibilityId("frmFastRänta").GetAttribute("Name");
            Assert.IsNotEmpty(InterestWindow);
            RootSession.FindElementByName("OK").Click();         
        }
    }
}
