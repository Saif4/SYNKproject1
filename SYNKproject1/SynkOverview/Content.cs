using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class Content : DriversRoot
    {
        public Content()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void ShowContent()
        {
            // öppnar Hjälp sidan och verifierar att den är synligt
            RootSession.FindElementByName("Hjälp").Click();
            RootSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.Enter);
            var synkhelp = RootSession.FindElementByName("Direkthjälp - Att arbeta i Synk").Displayed;
        }
    }
}
