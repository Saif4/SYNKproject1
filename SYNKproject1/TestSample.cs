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
    class TestSample
    {
      /*  [SetUpFixture]
        public class MySetUpClass
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                AMW aMW = new AMW();
                aMW.Driver("P417JI6", "evry123");
            }
        }
        [TestFixture]
        public class Change
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                LoginToSynk login = new LoginToSynk();
                login.Synklogin("196308120093");
            }
            [Test]
            public void ChangeCustomerInformationView()
            {
                ChangeCustomerInformationView changeCustomerInformationView = new ChangeCustomerInformationView();
                changeCustomerInformationView.CustomerInfoWindow();
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
            public void TearDown()
            {
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
                Thread.Sleep(1000);
            }
        }
        [TestFixture]
        
        public class Business
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                LoginToSynk login = new LoginToSynk();
                login.Synklogin("196308120093");
            }

            // [Test]
            public void CreateNewAccount()
            {
                CreateAccount create = new CreateAccount();
                create.OpenAccount();
            }
           // [Test]
            public void CreateCompanyAccount()
            {
                CreateCompanyAccount createCompanyAccount = new CreateCompanyAccount();
                createCompanyAccount.OpenAccount();
            }
          //  [Test]
            public void CreatePensionSavings()
            {
                NewPensionSaving newPensionSaving = new NewPensionSaving();
                newPensionSaving.CreatePensionSaving();
            }
            [Test]
            public void Help()
            {
                Help help = new Help();
                help.OpenContentView();
                help.OpenAboutView();
            }
         //   [Test]
            public void OpenPrintoutPageForShares()
            {
                ViewPrintoutOfShares printoutOfShares = new ViewPrintoutOfShares();
                printoutOfShares.OpenPrintoutPageForShares();
            }
            [Test]
            public void OpenSPAXPage()
            {
                ViewSPAXPage viewSPAXPage = new ViewSPAXPage();
                viewSPAXPage.OpenSPAXpage();
            }
           // [Test]
            public void CreateNewFundAccount()
            {
                CreateFundAccount createFundAccount = new CreateFundAccount();
                createFundAccount.CreateNewFundAccount();
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
            public void TearDown()
            {
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
                Thread.Sleep(1000);
            }
        }*/
    }
}
