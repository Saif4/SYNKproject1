using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class HelpView : DriversRoot
    {
        public HelpView()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void ShowHelp()
        {
            // öppnar Hjälp sidan och verifierar att den är synligt
            RootSession.FindElementByName("Hjälp").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);
            var synkhelp = RootSession.FindElementByName("Direkthjälp - Att arbeta i Synk").Displayed;
        }
    }
}
