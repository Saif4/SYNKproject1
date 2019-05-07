using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IgnoreAttribute = NUnit.Framework.IgnoreAttribute;
using TestContext = NUnit.Framework.TestContext;

namespace SYNKproject1
{
    public class CustomerStartWindow
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
        public class Funds
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("195306300368"); // 197611040010
            }
            [Test]
            [Order(1)]
            public void Login()
            {
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("195306300368");
            }
            [Test]
            [Order(2)]
            public void BuyFund()
            {
                BuyFund buyFund = new BuyFund();
                buyFund.Buyfund("100", "Privatkonto");
            }
            [Test]
            [Order(3)]
            public void BuyFundISK()
            {
                BuyFundISK buyFundISK = new BuyFundISK();
                buyFundISK.BuyfundISK("9 445 602-7 - Investeringssparkonto","100", "Privatkonto");
            }
            
            [Test]
            [Order(4)]
            public void SellFund()
            {
               
                SellFund sellFund = new SellFund();
                sellFund.Sellfund("104", "Privatkonto");
            }
            [Test]
            [Order(5)]
            public void SellFundISK()
            {
                SellFundISK sellFundISK = new SellFundISK();
                sellFundISK.SellfundISK("9 445 602-7 - Investeringssparkonto", "104", "Privatkonto");
            }
            [Test]
            [Order(6)]
            public void BuyShare()
            {
                BuyShare buyShare = new BuyShare();
                buyShare.Buyshare("327327-02453-2: Värdepapperstjänst Aktiv ISK", "ERICSSON B", "2");
            }
            [Test]
            [Order(7)]
            public void SellShare()
            {
                SellShare sellShare = new SellShare();
                sellShare.Sellshare("327327-02453-2: Värdepapperstjänst Aktiv ISK", "ERICSSON B", "1");
            }
            [Test]
            [Order(8)]
            public void ChangeFund()
            {
                ChangeFund changeFund = new ChangeFund();
                changeFund.Changefund("9 445 602-7 - Investeringssparkonto", "Swedbank Robur Prem. Offensiv", "106");
            }
            [Test]
            [Order(11)]
            public void Cart()
            {
                Cart cart = new Cart();
                cart.Cartview();
            }
            [Test]
            [Order(9)]
            public void BuyFundOnDifferentDate()
            {
                BuyFundOnDifferentDate buyFundOnDifferentDate = new BuyFundOnDifferentDate();
                buyFundOnDifferentDate.BuyFund("109", "Privatkonto", "20190401");
            }
            [Test]
            [Order(10)]
            public void SellFundOnDifferentDate()
            {
                SellFundOnDifferentDate sellFundOnDifferentDate = new SellFundOnDifferentDate();
                sellFundOnDifferentDate.Sellfund("107", "Privatkonto", "20190401");
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
        public class Add
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                
            }
            [Test]
            [Order(1)]
            public void Login()
            {
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("196308120093");
            }
            [Test]
            public void AndAndRemoveNotes()
            {
                AddAndRemoveNotes addAndRemoveNotes = new AddAndRemoveNotes();
                addAndRemoveNotes.AddNote();
                addAndRemoveNotes.Removenote();
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
        public class Change
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
               
            }
            [Test]
            [Order(1)]
            public void Login()
            {
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("196308120093");
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
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("196308120093");
            }
            [Test]
            [Order(1)]
            public void Login()
            {
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("196308120093");
            }
            [Test]
            public void CreateNewAccount()
            {
                CreateAccount create = new CreateAccount();
                create.OpenAccount();
            }
            [Test]
            public void CreateCompanyAccount()
            {
                CreateCompanyAccount createCompanyAccount = new CreateCompanyAccount();
                createCompanyAccount.OpenAccount();
            }
            [Test]
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
            [Test]
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
            [Test]
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
        }
        [TestFixture]
        public class CustomerInfo
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("195306300368");
            }
            [Test]
            [Order(1)]
            public void Login()
            {
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("195306300368");
            }
            [Test]
            public void AccountOverviewCustomerWindow()
            {
                AccountOverviewCustomerWindow accountOverviewCustomer = new AccountOverviewCustomerWindow();
                accountOverviewCustomer.AccountOverviewCustomerwindow();
            }
            [Test]
            public void CardConnectedToAccountCustomerWindow()
            {
                CardConnectedToAccountCustomerWindow cardConnectedToAccountCustomerWindow = new CardConnectedToAccountCustomerWindow();
                cardConnectedToAccountCustomerWindow.CardConnectedToAccountCustomerwindow();
            }
            [Test]
            public void CardPicture()
            {
                CardPicture cardPicture = new CardPicture();
                cardPicture.ShowCustomerCardPicture();
            }
            [Test]
            public void CompilationDepositWithdraw()
            {
                CompilationDepositWithdraw compilationDepositWithdraw = new CompilationDepositWithdraw();
                compilationDepositWithdraw.ShowCompilationDeposit();
                compilationDepositWithdraw.ShowCompilationWithdraw();
            }
            [Test]
            public void CustomerBehavior()
            {
                CustomerBehavior customerBehavior = new CustomerBehavior();
                customerBehavior.ShowCustomerBehavior();
            }
            [Test]
            public void CustomerDebit()
            {
                CustomerDebit customerDebit = new CustomerDebit();
                customerDebit.ShowCustomerDebit();
            }
            [Test]
            public void CustomerStructure()
            {
                CustomerStructure customerStructure = new CustomerStructure();
                customerStructure.ASK();
                customerStructure.Company();
            }
            [Test]
            public void CustomerRelation()
            {
                CustomerRelation customerRelation = new CustomerRelation();
                customerRelation.ViewCustomerRelation();
            }
            [Test]
            public void CustomerProfile()
            {
                CustomerProfile customerProfile = new CustomerProfile();
                customerProfile.ViewCustomerProfile();
            }
            [Test]
            public void FinishedAccountLoanAndInsurance()
            {
                FinishedAccountLoanAndInsurance finishedAccountLoanAndInsurance = new FinishedAccountLoanAndInsurance();
                finishedAccountLoanAndInsurance.ShowFinishedAccountLoanAndInsurance();
            }
            [Test]
            public void FinishedCardAndCredit()
            {
                FinishedCardAndCredit finishedCardAnd = new FinishedCardAndCredit();
                finishedCardAnd.ShowFinishedCardAndCredit();
            }
            [Test]
            public void MeetingManagementCompanies()
            {
                MeetingManagementCompanies meetingManagementCompanies = new MeetingManagementCompanies();
                meetingManagementCompanies.NextMeeting("20191212", "1500", "Nästa Möte", "Stockholm");
                meetingManagementCompanies.RejectedMeeting("20190330", "AVböjd", "20191230", "Avböjd Möte");
                meetingManagementCompanies.AddNotice("Mötes notering"); 
            }
            [Test]
            public void MeetingManagementPrivate()
            {
                MeetingManagementPrivate meetingManagementPrivate = new MeetingManagementPrivate();
                meetingManagementPrivate.NextMeeting("20191230", "1500", "Nästa Möte", "Stockholm");
                meetingManagementPrivate.RejectedMeeting("20190401", "Avböjd möte", "20191230", "Nästa möte");
                meetingManagementPrivate.AddNotice("Ny mötes notering");
            }
            [Test]
            public void PricePictureCompany()
            {
                PricePictureCompany pricePictureCompany = new PricePictureCompany();
                pricePictureCompany.ShowPricePictureCompany();
            }
            [Test]
            public void ShowAddressManagement()
            {
                ShowAddressManagement showAddressManagement = new ShowAddressManagement();
                showAddressManagement.ShowCustomerAddressManagement();
            }
            [Test]
            public void ShowCompanyConnection()
            {
                ShowCompanyConnection showCompanyConnection = new ShowCompanyConnection();
                showCompanyConnection.ShowCompanyconnection();
            }
            [Test]
            public void ShowTransfers()
            {
                ShowTransfers showTransfers = new ShowTransfers();
                showTransfers.ShowCustomerTransfers();
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
      
            
    }
}


       

    


