using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgnoreAttribute = NUnit.Framework.IgnoreAttribute;

namespace SYNKproject1
{
    public class TestCases
    {
        
        static void Main(string[] args)

        {
            Drivers SynkStartup = new Drivers();
            SynkStartup.Driver();
            OpenCashDesk opendesk = new OpenCashDesk();
            opendesk.CashDesk();
            LoginToSynk synkStartWindowLogin = new LoginToSynk();
            synkStartWindowLogin.Synklogin("195306300368");

            

            //TestClass test = new TestClass();
            //test.OpenCashDeskAndTransferWithCustomerIdentification("19530630-0368", "1000");

        }
        [TestFixture]
        public class DepositAndWithDrawTests
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver();
                NavigateToSynkStartWindow navigate = new NavigateToSynkStartWindow();
                navigate.InitialSYNKStartWindow();
                OpenCashDesk opendesk = new OpenCashDesk();
                opendesk.CashDesk();
            }
            [Test]
            public void Deposit()
            {
               
                CashDeskDeposit deposit = new CashDeskDeposit();
                deposit.Deposit("19530630-0368", "1500");
            }
            [Test]
            public void DepositAboveLimit()
            {
                CashDeskDepositAboveLimit cashDeskDepositAboveLimit = new CashDeskDepositAboveLimit();
                cashDeskDepositAboveLimit.DepositAboveLimit("19530630-0368", "10000");
            }
            [Test]
            public void Withdraw()
            {
                CashDeskWithdraw withdraw = new CashDeskWithdraw();
                withdraw.Withdraw("19530630-0368", "500");
            }
            [Test]
            public void WithdrawAboveLimit()
            {
                CashDeskWithdrawAboveLimit cashDeskWithdrawAboveLimit = new CashDeskWithdrawAboveLimit();
                cashDeskWithdrawAboveLimit.WithdrawAboveLimit("19530630-0368", "10000");
            }
            [OneTimeTearDown] 
          
            public void TearDown()
            {
                CloseCashDesk closedesk = new CloseCashDesk();
                closedesk.ClosecashDesk();
            }

        }
       [TestFixture]
        public class TransferTests
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver();
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
                cashDeskTransfer.TransferToDifferentBank("195306300368", "500");
               
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
            }
        }
        [TestFixture]
        public class PaymentsTest
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver();
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
            }

        }
        [TestFixture]
        public class Funds
        {
            [OneTimeSetUp]
            public void InitialDriver()
            {
                Drivers SynkStartup = new Drivers();
                SynkStartup.Driver();
                LoginToSynk login= new LoginToSynk();
                login.Synklogin("195306300368");
            }
            [Test]
            public void BuyFund()
            {
                BuyFund buyFund = new BuyFund();
                buyFund.Buyfund();
            }
            [Test]
            public void SellFund()
            {
                SellFund sellFund = new SellFund();
                sellFund.Sellfund();
            }
            [OneTimeTearDown]
            public void TearDown()
            {
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
            }

        }
            

    }
}

       

    


