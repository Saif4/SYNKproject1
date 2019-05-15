using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class SynkStartWindow
    {
        [SetUpFixture]
        public class AMWLogin
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                AMW aMW = new AMW();
                aMW.Driver("P417JI6", "evry123");
            }
        }
        [TestFixture]
        [Order(3)]
        public class SynkModule
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver();
            }
            [Test] //Startsidan
            public void CustomerModule()
            {
                CustomerModule customerModule = new CustomerModule();
                customerModule.LoginTocustomer("195306300368");
            }
            [Test] //Startsidan 
            public void AccountModule()
            {
                AccountModule accountModule = new AccountModule();
                accountModule.OpenAccountModule("8327-9, 04 100 883-0");
            }
            [Test] //Startsidan
            public void CardModule()
            {
                CardModule cardModule = new CardModule();
                cardModule.OpenCardModule("5168 1501 0490 8371");
            }
            [Test]
            [Order(4)] //Startsidan
            public void FundAccountModule()
            {
                FundAccountModule fundAccountModule = new FundAccountModule();
                fundAccountModule.OpenFundModule("7 973 484-4");
            }
            [Test]
            [Order(1)] //Startsidan
            public void HelpView()
            {
                AnotherWayToShowHelpView helpView = new AnotherWayToShowHelpView();
                helpView.ShowHelp();
            }
            [TearDown]
            public void TearDownIfTestFails()
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    DriverQuit teardown = new DriverQuit();
                    teardown.Teardown();
                    Thread.Sleep(1000);
                }
            }
            [OneTimeTearDown]
            public void Teardown()
            {
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
                Thread.Sleep(1000);
            }
        }
        [TestFixture]
        [Order(2)]
        public class OverView
        {
            [SetUp]
            public void Setup()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver();
            }
            [Test] //Arkiv
            [Order(5)]
            public void LogInToCustomerByName()
            {
                SearchCustomer searchCustomer = new SearchCustomer();
                searchCustomer.Searchcustomer("Plains");
            }
            [Test] //Visa
            [Order(3)] 
            public void AccountOverview()
            {
                AccountOverview accountOverview = new AccountOverview();
                accountOverview.Accountoverview("195306300368");
            }
            [Test] //Visa
            [Order(4)]
            public void CardAndAccountConnection()
            {
                CardConnectedToAccount cardConnectedToAccount = new CardConnectedToAccount();
                cardConnectedToAccount.CardAccountConnection("8327-9, 04 100 883-0");
            }
            [Test] //Visa
            [Order(6)]
            public void InterestOverview()
            {
                ShowInterest showInterest = new ShowInterest();
                showInterest.Showinterest();
            }
            [Test] //Visa
            [Order(7)]
            public void ShowFinishedIPcontract()
            {
                FinishedIPcontract finishedIPcontract = new FinishedIPcontract();
                finishedIPcontract.FinishedIpcontract("83279, 9747310614");
            }
            [Test] //Hjälp
            [Order(10)]
            public void HelpView()
            {
                HelpView helpView = new HelpView();
                helpView.ShowHelp();
            }
            [Test]
            [Order(1)] //Om
            public void ShowOfficeData()
            {
                ShowOfficeData showOfficeData = new ShowOfficeData();
                showOfficeData.Showofficedata();
            }
            [Test]
            [Order(2)] //Om
            public void ShowCashDeskData()
            {
                ShowCashDeskData showCashDeskData = new ShowCashDeskData();
                showCashDeskData.ShowcashdeskData();
            }
            [Test]
            [Order(8)] //Verktyg
            public void InvestmentComparison()
            {
                InvestmentComparison investmentComparison = new InvestmentComparison();
                investmentComparison.InvestmentComparisonView();
            }
            [Test]
            [Order(9)] //Om
            public void ShowSYAFlags()
            {
                ShowSYAFlags showSYAFlags = new ShowSYAFlags();
                showSYAFlags.ShowSyaFlags();
            }
            [TearDown]
            public void TearDownIfTestFails()
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    DriverQuit teardown = new DriverQuit();
                    teardown.Teardown();
                    Thread.Sleep(1000);
                }
            }
            [OneTimeTearDown]
            public void Teardown()
            {
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
                Thread.Sleep(1000);
            }
        }
        [TestFixture]
        [Order(1)]
        public class AdministratorStartUpPage
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver();
            }
            [Test] //Verktyg
            public void CustomerDataView()
            {
                CustomerDataView customerDataView = new CustomerDataView();
                customerDataView.SelectStartupPage("Kunduppgifter");
                customerDataView.VerifySelectedPage("195306300368");
            }
            [Test] //Verktyg
            public void EngagementView()
            {
                EngagementView engagementView = new EngagementView();
                engagementView.SelectStartupPage("Engagemang");
                engagementView.VerifySelectedPage("195306300368");
            }
            [TearDown]
            public void TearDownIfTestFails()
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    DriverQuit teardown = new DriverQuit();
                    teardown.Teardown();
                    Thread.Sleep(1000);
                }
            }
            [OneTimeTearDown]
            public void Teardown()
            {
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
                Thread.Sleep(1000);
            }
        }


    }
}
