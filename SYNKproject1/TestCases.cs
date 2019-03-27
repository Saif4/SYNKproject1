using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IgnoreAttribute = NUnit.Framework.IgnoreAttribute;

namespace SYNKproject1
{
    public class TestCase
    {

        static void Main(string[] args)

        {
            Drivers SynkStartup = new Drivers();
            SynkStartup.Driver("P417JI6", "evry123");
            AdministratorAccess administratorAccess = new AdministratorAccess();
            administratorAccess.Administratoraccess("195306300368");

            //TestClass test = new TestClass();
            //test.OpenCashDeskAndTransferWithCustomerIdentification("19530630-0368", "1000");

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
        public class CreateAnAccount
        {
            [OneTimeSetUp]
            public void InitialDriver()
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
            public void FundAccountModule()
            {
                FundAccountModule fundAccountModule = new FundAccountModule();
                fundAccountModule.OpenFundModule("7 973 484-4");
            }
            [Test]
            [Order(1)]
            public void ShowContent()
            {
                AnotherWayToContent content = new AnotherWayToContent();
                content.ShowContent();
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
        public class SynkOverview
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver("P417JI6", "evry123");
            }
            [Test]

            public void LogInToCustomerByName()
            {
                SearchCustomer searchCustomer = new SearchCustomer();
                searchCustomer.Searchcustomer("Plains");
            }
            [Test]
            public void AccountOverview()
            {
                AccountOverview accountOverview = new AccountOverview();
                accountOverview.Accountoverview("195306300368");
            }
            [Test]
            public void CardAndAccountConnection()
            {
                CardConnectedToAccount cardConnectedToAccount = new CardConnectedToAccount();
                cardConnectedToAccount.CardAccountConnection("8327-9, 04 100 883-0");
            }
            [Test]
            public void InterestOverview()
            {
                ShowInterest showInterest = new ShowInterest();
                showInterest.Showinterest();
            }
            [Test]
            public void ShowFinishedIPcontract()
            {
                FinishedIPcontract finishedIPcontract = new FinishedIPcontract();
                finishedIPcontract.FinishedIpcontract("83279, 9747310614");
            }
            [Test]
            public void ShowContent()
            {
                Content content = new Content();
                content.ShowContent();
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


       

    


