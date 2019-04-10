using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class InvestmentComparison : DriversRoot
    {
        public InvestmentComparison()
        {
            PageFactory.InitElements(DriversRoot.RootSession, this);
        }
        public void InvestmentComparisonView()
        {
            NavigateToSynkStartWindow navigate = new NavigateToSynkStartWindow();
            navigate.InitialSYNKStartWindow();
            navigate.SynkWindowSession.FindElementByName("Verktyg").Click();
            navigate.SynkWindowSession.Keyboard.SendKeys("P");

            navigate.SynkWindowSession.FindElementByAccessibilityId("txtTotalTime").SendKeys("5");
            navigate.SynkWindowSession.FindElementByAccessibilityId("txtInsertion1").SendKeys("10000");
            navigate.SynkWindowSession.FindElementByAccessibilityId("txtRate1").SendKeys("5");
            navigate.SynkWindowSession.FindElementByAccessibilityId("txtAtYear1").SendKeys("5");
            navigate.SynkWindowSession.FindElementByName("Kopiera->").Click();
            navigate.SynkWindowSession.FindElementByName("Beräkna").Click();

            string firstTotal = navigate.SynkWindowSession.FindElementByAccessibilityId("lblTotal1").GetAttribute("Name");
            string secondTotal = navigate.SynkWindowSession.FindElementByAccessibilityId("lblTotal2").GetAttribute("Name");

            Assert.AreEqual(firstTotal, secondTotal);
            navigate.SynkWindowSession.FindElementByName("Placeringsjämförelse").FindElementByName("Arkiv").Click();
            navigate.SynkWindowSession.Keyboard.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

        }
    }
}
