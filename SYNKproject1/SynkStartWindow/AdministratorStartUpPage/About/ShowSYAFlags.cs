using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class ShowSYAFlags : DriversRoot
    {
        public ShowSYAFlags()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void ShowSyaFlags()
        {
            // Verifierar att syaflagor fönstret är öppet
            RootSession.FindElementByName("Om").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            RootSession.FindElementByName("User choice").FindElementByName("Yes").Click();
            var SYAFlags = RootSession.FindElementByName("SYAparametrar").Displayed;
            RootSession.FindElementByName("SYAparametrar").FindElementByName("OK").Click();
        }
    }
}
