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
        public class DepositAndWithDrawTests
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                
            }
            [Test]
            [Order(1)]
            public void OpenCashDesk()
            {
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
        //[Ignore("Ignore a fixture")]
        public class TransferTests
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                NavigateToSynkStartWindow navigate = new NavigateToSynkStartWindow();
                navigate.InitialSYNKStartWindow();
               
            }
            [Test]
            [Order(1)]
            public void OpenCashDesk()
            {
                OpenCashDesk opendesk = new OpenCashDesk();
                opendesk.CashDesk();
            }
            [Test]
            [Order(2)]
            public void TransferBetweenTheSameBank()
            {
                CashDeskTransfer cashDeskTransfer = new CashDeskTransfer();
                cashDeskTransfer.OpenCashDeskAndTransfer("19530630-0368", "500");
            }
            [Test]
            [Order(3)]
            public void TransferBackBetweenTheSameBank()
            {
                CashDeskTransferBack cashDeskTransferBack = new CashDeskTransferBack();
                cashDeskTransferBack.OpenCashDeskAndTransferBack("19530630-0368", "500");
            }
            [Test]
            [Order(4)]
            public void TransferWithCustomerIdentification()
            {
                CashDeskTransferCustomerIdentification cashDeskTransferCustomerIdentification = new CashDeskTransferCustomerIdentification();
                cashDeskTransferCustomerIdentification.OpenCashDeskAndTransferWithCustomerIdentification("19530630-0368", "10000");
            }
            [Test]
            [Order(5)]
            public void TransferToDifferentBank()
            {
                CashDeskTransferDifferentBank cashDeskTransfer = new CashDeskTransferDifferentBank();
                cashDeskTransfer.TransferToDifferentBank("195306300368", "14 9020 274 717-6", "500");
            }
            [Test]
            [Order(6)]
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
        public class PaymentsTest
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                
            }
            [Test]
            [Order(1)]
            public void OpenCashDesk()
            {
                OpenCashDesk opendesk = new OpenCashDesk();
                opendesk.CashDesk();
            }
            [Test]
            [Order(2)]
            public void Login()
            {
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
        //[Ignore("Ignore a fixture")]
        public class Funds
        {
            [SetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("197611040010");
            }
            [Test]
            [Order(1)]
            public void Login()
            {
                LoginToSynk synkStartWindowLogin = new LoginToSynk();
                synkStartWindowLogin.Synklogin("197611040010");
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
            public void SellFund()
            {
                SellFund sellFund = new SellFund();
                sellFund.Sellfund("104", "Privatkonto");
            }
            [Test]
            [Order(4)]
            public void BuyShare()
            {
                BuyShare buyShare = new BuyShare();
                buyShare.Buyshare("327327-02453-2: Värdepapperstjänst Aktiv ISK", "ERICSSON B", "2");
            }
            [Test]
            [Order(5)]
            public void SellShare()
            {
                SellShare sellShare = new SellShare();
                sellShare.Sellshare("327327-02453-2: Värdepapperstjänst Aktiv ISK", "ERICSSON B", "1");
            }
            [Test]
            [Order(6)]
            public void ChangeFund()
            {
                ChangeFund changeFund = new ChangeFund();
                changeFund.Changefund("9 445 602-7 - Investeringssparkonto", "Swedbank Robur Prem. Offensiv", "106");
            }
            [Test]
            [Order(9)]
            public void Cart()
            {
                Cart cart = new Cart();
                cart.Cartview();
            }
            [Test]
            [Order(7)]
            public void BuyFundOnDifferentDate()
            {
                BuyFundOnDifferentDate buyFundOnDifferentDate = new BuyFundOnDifferentDate();
                buyFundOnDifferentDate.BuyFund("109", "Privatkonto", "20190401");
            }
            [Test]
            [Order(8)]
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


       

    


