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
    public class TestCase
    {

        static void Main(string[] args)

        {
            Drivers SynkStartup = new Drivers();
            SynkStartup.Driver("P417JI6", "evry123");
            LoginToSynk synkStartWindowLogin = new LoginToSynk();
            synkStartWindowLogin.Synklogin("197611040010");

            MeetingManagementPrivateCustomer meetingManagement = new MeetingManagementPrivateCustomer();
            meetingManagement.NextMeeting("20201231", "1500", "Notering till nästa mötet", "Stockholm");
            meetingManagement.RejectedMeeting("20190401", "Gamla mötet", "20200101", "Nya mötet");
            meetingManagement.AddNotice("Notering till nästa mötet");

            MeetingManagementCompanies meetingManagementCompanies = new MeetingManagementCompanies();
            meetingManagementCompanies.NextMeeting("20201231", "1500", "Notering till nästa mötet", "Stockholm");
            meetingManagementCompanies.RejectedMeeting("20190401", "Gamla mötet", "20200101", "Nya mötet");
            meetingManagementCompanies.AddNotice("En ny notering");
          /*  ShowTransfers showTransfers = new ShowTransfers();
            showTransfers.ShowCustomerTransfers();
            ShowAddressManagement showAddressManagement = new ShowAddressManagement();
            showAddressManagement.ShowCustomerAddressManagement();*/
        
           

        }


        [TestFixture]
        [Order(5)]
        public class DepositAndWithDrawTests
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                OpenCashDesk opendesk = new OpenCashDesk();
                opendesk.CashDesk();
            }
            [Test]
            public void Deposit()
            {

                CashDeskDeposit deposit = new CashDeskDeposit();
                deposit.Deposit("19530630-0368", "Privatkonto", "1500");
            }
            [Test]
            public void DepositAboveLimit()
            {
                CashDeskDepositAboveLimit cashDeskDepositAboveLimit = new CashDeskDepositAboveLimit();
                cashDeskDepositAboveLimit.DepositAboveLimit("19530630-0368", "Privatkonto", "10000");
            }
            [Test]
            public void MultipleDeposits()
            {
                MultipleDeposits multipleDeposits = new MultipleDeposits();
                multipleDeposits.MultipleDepoit("19530630-0368", "14 9020 274 717-6", "50", "8327-9, 904 368 271-6", "50", "Privatkonto");
            }
            [Test]
            public void Withdraw()
            {
                CashDeskWithdraw withdraw = new CashDeskWithdraw();
                withdraw.Withdraw("19530630-0368", "Privatkonto", "500");
            }
            [Test]
            public void WithdrawAboveLimit()
            {
                CashDeskWithdrawAboveLimit cashDeskWithdrawAboveLimit = new CashDeskWithdrawAboveLimit();
                cashDeskWithdrawAboveLimit.WithdrawAboveLimit("19530630-0368", "Privatkonto", "10000");
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
                CloseCashDesk closedesk = new CloseCashDesk();
                closedesk.ClosecashDesk();
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
                Thread.Sleep(1000);
            }

        }
        [TestFixture]
        [Order(4)]
        [Ignore("Ignore a fixture")]
        public class TransferTests
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                NavigateToSynkStartWindow navigate = new NavigateToSynkStartWindow();
                navigate.InitialSYNKStartWindow();
                OpenCashDesk opendesk = new OpenCashDesk();
                opendesk.CashDesk();
            }
            [Test]
            [Order(1)]
            public void TransferBetweenTheSameBank()
            {
                CashDeskTransfer cashDeskTransfer = new CashDeskTransfer();
                cashDeskTransfer.OpenCashDeskAndTransfer("19530630-0368", "500");
            }
            [Test]
            [Order(2)]
            public void TransferBackBetweenTheSameBank()
            {
                CashDeskTransferBack cashDeskTransferBack = new CashDeskTransferBack();
                cashDeskTransferBack.OpenCashDeskAndTransferBack("19530630-0368", "500");
            }
            [Test]
            [Order(3)]
            public void TransferWithCustomerIdentification()
            {
                CashDeskTransferCustomerIdentification cashDeskTransferCustomerIdentification = new CashDeskTransferCustomerIdentification();
                cashDeskTransferCustomerIdentification.OpenCashDeskAndTransferWithCustomerIdentification("19530630-0368", "10000");
            }
            [Test]
            [Order(4)]
            public void TransferToDifferentBank()
            {
                CashDeskTransferDifferentBank cashDeskTransfer = new CashDeskTransferDifferentBank();
                cashDeskTransfer.TransferToDifferentBank("195306300368", "14 9020 274 717-6", "500");
            }
            [Test]
            public void TransferWithinSameBankWithVerification()
            {
                CashDeskTransfer cashDeskTransfer = new CashDeskTransfer();
                cashDeskTransfer.OpenCashDeskAndTransfer("19530630-0368", "500");

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
                CloseCashDesk closedesk = new CloseCashDesk();
                closedesk.ClosecashDesk();
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
                Thread.Sleep(1000);
            }
        }
        [TestFixture]
        [Order(3)]
        public class PaymentsTest
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                OpenCashDesk opendesk = new OpenCashDesk();
                opendesk.CashDesk();
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("195306300368");
            }
            [Test]
            public void BgPayment()
            {
                CheckBalance checkBalance = new CheckBalance();
                checkBalance.OpenAccountAndVerifyBalance();
                BGandPGpayment payment = new BGandPGpayment();
                payment.BgAndPGpayment("195306300368", "100", "5175-4158", "7904130361");
                VerifyBalance verifyBalance = new VerifyBalance();
                verifyBalance.OpenAccountAndVerifyBalance();
            }
            [Test]
            public void PaymentVerifications()
            {

                PaymentVerifications payment = new PaymentVerifications();
                payment.BgAndPGpayment("195306300368", "100", "5175-4158", "5175-4159", "7904130361", "1234567890", "12345678912345679");
            }
            [Test]
            public void ChangePayment()
            {


                ChangePayment payment = new ChangePayment();
                payment.BgAndPGpayment("195306300368", "100", "5175-4158", "7904130361");
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
                CloseCashDesk closedesk = new CloseCashDesk();
                closedesk.ClosecashDesk();
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
                Thread.Sleep(1000);
            }

        }
        [TestFixture]
        [Order(7)]
        //[Ignore("Ignore a fixture")]
        public class Funds
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                LoginToSynk login = new LoginToSynk();
                login.Synklogin("197611040010");
            }
            [Test]
            [Order(1)]
            public void BuyFund()
            {
                BuyFund buyFund = new BuyFund();
                buyFund.Buyfund("105", "Privatkonto");
            }
            [Test]
            [Order(2)]
            public void SellFund()
            {
                SellFund sellFund = new SellFund();
                sellFund.Sellfund("103", "Privatkonto");
            }
            [Test]
            [Order(3)]
            public void BuyShare()
            {
                BuyShare buyShare = new BuyShare();
                buyShare.Buyshare("327327-02453-2: Värdepapperstjänst Bas ISK", "ERICSSON B", "2");
            }
            [Test]
            [Order(4)]
            public void SellShare()
            {
                SellShare sellShare = new SellShare();
                sellShare.Sellshare("327327-02453-2: Värdepapperstjänst Bas ISK", "ERICSSON B", "1");
            }
            [Test]
            [Order(5)]
            public void ChangeFund()
            {
                ChangeFund changeFund = new ChangeFund();
                changeFund.Changefund("9 445 602-7 - Investeringssparkonto", "Swedbank Robur Prem. Offensiv", "108");
            }
            [Test]
            [Order(6)]
            public void Cart()
            {
                Cart cart = new Cart();
                cart.Cartview();
            }
            [Test]
            public void BuyFundOnDifferentDate()
            {
                BuyFundOnDifferentDate buyFundOnDifferentDate = new BuyFundOnDifferentDate();
                buyFundOnDifferentDate.BuyFund("115", "Privatkonto", "20190401");
            }
            [Test]
            public void SellFundOnDifferentDate()
            {
                SellFundOnDifferentDate sellFundOnDifferentDate = new SellFundOnDifferentDate();
                sellFundOnDifferentDate.Sellfund("110", "Privatkonto", "20190401");
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
        [Order(6)]
        public class CustomerStartWindow
        {
           /* [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                LoginToSynk login = new LoginToSynk();
                login.Synklogin("196308120093");
            }*/
            [OneTimeSetUp]
            public void SetupIfTestFails()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                LoginToSynk login = new LoginToSynk();
                login.Synklogin("196308120093");       
            }
            [Test]
            public void CreateNewAccount()
            {
                CreateAccount create = new CreateAccount();
                create.OpenAccount();
            }
            [Test]
            public void CreatePensionSavings()
            {
                NewPensionSaving newPensionSaving = new NewPensionSaving();
                newPensionSaving.CreatePensionSaving();
            }
            [Test]
            public void AndAndRemoveNotes()
            {
                AddAndRemoveNotes addAndRemoveNotes = new AddAndRemoveNotes();
                addAndRemoveNotes.AddNote();
                addAndRemoveNotes.Removenote();
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
            [Test]
            public void ChangeCustomerInformationView()
            {
                ChangeCustomerInformationView changeCustomerInformationView = new ChangeCustomerInformationView();
                changeCustomerInformationView.CustomerInfoWindow();
            }
            [Test]
            public void ShowCompanyConnection()
            {
                ShowCompanyConnection showCompanyConnection = new ShowCompanyConnection();
                showCompanyConnection.ShowCompanyconnection();
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
        [Order(1)]
        public class SynkModule
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
            }
            [Test]
            public void CustomerModule()
            {
                CustomerModule customerModule = new CustomerModule();
                customerModule.LoginTocustomer("195306300368");
            }
            [Test]
            public void AccountModule()
            {
                AccountModule accountModule = new AccountModule();
                accountModule.OpenAccountModule("8327-9, 04 100 883-0");
            }
            [Test]
            public void CardModule()
            {
                CardModule cardModule = new CardModule();
                cardModule.OpenCardModule("5168 1501 0490 8371");
            }
            [Test]
            [Order(4)]
            public void FundAccountModule()
            {
                FundAccountModule fundAccountModule = new FundAccountModule();
                fundAccountModule.OpenFundModule("7 973 484-4");
            }
            [Test]
            [Order(1)]
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
        public class SynkStartWindowOverview
        {
            [OneTimeSetUp]
            public void Setup()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
            }
            [Test]
            [Order(5)]
            public void LogInToCustomerByName()
            {
                SearchCustomer searchCustomer = new SearchCustomer();
                searchCustomer.Searchcustomer("Plains");
            }
            [Test]
            [Order(3)]
            public void AccountOverview()
            {
                AccountOverview accountOverview = new AccountOverview();
                accountOverview.Accountoverview("195306300368");
            }
            [Test]
            [Order(4)]
            public void CardAndAccountConnection()
            {
                CardConnectedToAccount cardConnectedToAccount = new CardConnectedToAccount();
                cardConnectedToAccount.CardAccountConnection("8327-9, 04 100 883-0");
            }
            [Test]
            [Order(6)]
            public void InterestOverview()
            {
                ShowInterest showInterest = new ShowInterest();
                showInterest.Showinterest();
            }
            [Test]
            [Order(7)]
            public void ShowFinishedIPcontract()
            {
                FinishedIPcontract finishedIPcontract = new FinishedIPcontract();
                finishedIPcontract.FinishedIpcontract("83279, 9747310614");
            }
            [Test]
            [Order(10)]
            public void HelpView()
            {
                HelpView helpView = new HelpView();
                helpView.ShowHelp();
            }
            [Test]
            [Order(1)]
            public void ShowOfficeData()
            {
                ShowOfficeData showOfficeData = new ShowOfficeData();
                showOfficeData.Showofficedata();
            }
            [Test]
            [Order(2)]
            public void ShowCashDeskData()
            {
                ShowCashDeskData showCashDeskData = new ShowCashDeskData();
                showCashDeskData.ShowcashdeskData();
            }
            [Test]
            [Order(8)]
            public void InvestmentComparison()
            {
                InvestmentComparison investmentComparison = new InvestmentComparison();
                investmentComparison.InvestmentComparisonView();
            }
            [Test]
            [Order(9)]
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
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
            }
            [Test]
            public void CustomerDataView()
            {
                CustomerDataView customerDataView = new CustomerDataView();
                customerDataView.SelectStartupPage("Kunduppgifter");
                customerDataView.VerifySelectedPage("195306300368");
            }
            [Test]
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


       

    


