﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    public class Entrypoint
    {
        
        static void Main(string[] args)

        {
            //NavigateToSynkStartWindow navigateToSynk = new NavigateToSynkStartWindow();
            //navigateToSynk.InitialSYNKStartWindow();

           LoginToCustomer synkStartWindowLogin = new LoginToCustomer();
           synkStartWindowLogin.InitialSYNKlogin("195306300368");
            BuyFund buyFund = new BuyFund();
            buyFund.Buyfund();
          // CheckBalance checkBalance = new CheckBalance();
         //  checkBalance.OpenAccountAndVerifyBalance();
          // ChangePayment payment = new ChangePayment();
          // payment.BgAndPGpayment("195306300368", "100", "5175-4158","7904130361");
          // VerifyBalance verifyBalance = new VerifyBalance();
           //verifyBalance.OpenAccountAndVerifyBalance();




            //TestClass test = new TestClass();
            //test.OpenCashDeskAndTransferWithCustomerIdentification("19530630-0368", "1000");

        }

        [TestFixture]
        public class Firstsuite
        {
            [SetUp]
            public void InitialDriver()
            {
                LoginToCustomer synkStartWindowLogin = new LoginToCustomer();
                synkStartWindowLogin.InitialSYNKlogin("195306300368");
            }
            [Test]
            [Order(1)]
            public void CreateAcount()
            {
                CreateAccount createAccount = new CreateAccount();
                createAccount.OpenAccount();
            }
            [Test]
            public void TransferWithinSameBankWithVerification()
            {
                CheckBalance checkBalance = new CheckBalance();
                checkBalance.OpenAccountAndVerifyBalance();
                CashDeskTransfer cashDeskTransfer = new CashDeskTransfer();
                cashDeskTransfer.OpenCashDeskAndTransfer("19530630-0368", "500");
                VerifyBalance verifyBalance = new VerifyBalance();
                verifyBalance.OpenAccountAndVerifyBalance();
            }
            [Test]
            public void TransferToDifferentBank()
            {
                CheckBalance checkBalance = new CheckBalance();
                checkBalance.OpenAccountAndVerifyBalance();
                CashDeskTransferDifferentBank cashDeskTransfer = new CashDeskTransferDifferentBank();
                cashDeskTransfer.TransferToDifferentBank("195306300368", "500");
                VerifyBalance verifyBalance = new VerifyBalance();
                verifyBalance.OpenAccountAndVerifyBalance();
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
                LoginToCustomer synkStartWindowLogin = new LoginToCustomer();
                synkStartWindowLogin.InitialSYNKlogin("195306300368");
                CheckBalance checkBalance = new CheckBalance();
                checkBalance.OpenAccountAndVerifyBalance();
                PaymentVerifications payment = new PaymentVerifications();
                payment.BgAndPGpayment("195306300368", "100", "5175-4158", "5175-4159", "7904130361", "1234567890", "12345678912345679");
            }
            [Test]
            public void ChangePayment()
            {
                LoginToCustomer synkStartWindowLogin = new LoginToCustomer();
                synkStartWindowLogin.InitialSYNKlogin("195306300368");
                CheckBalance checkBalance = new CheckBalance();
                checkBalance.OpenAccountAndVerifyBalance();
                ChangePayment payment = new ChangePayment();
                payment.BgAndPGpayment("195306300368", "100", "5175-4158", "7904130361");
            }
            [Test]
            public void BuyFund()
            {
                BuyFund buyFund = new BuyFund();
                buyFund.Buyfund();
            }
            [TearDown]
            public void TearDown()
            {
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
            }
        }
        [TestFixture]
        public class Secondsuite
        {
            [SetUp]
            public void InitialDriver2()
            {
                NavigateToSynkStartWindow navigate = new NavigateToSynkStartWindow();
                navigate.InitialSYNKStartWindow();
            }
            [Test]
            public void CashDeskDepositAboveLimit()
            {
                CashDeskDepositAboveLimit cashDeskDepositAboveLimit = new CashDeskDepositAboveLimit();
                cashDeskDepositAboveLimit.DepositAboveLimit("19530630-0368", "10000");
            }
            [Test]
            public void CashDeskTransferBetweenTheSameBank()
            {
                CashDeskTransfer cashDeskTransfer = new CashDeskTransfer();
                cashDeskTransfer.OpenCashDeskAndTransfer("19530630-0368", "500");

            }
            [Test]
            public void CashDeskTransferBackBetweenTheSameBank()
            {
                CashDeskTransferBack cashDeskTransferBack = new CashDeskTransferBack();
                cashDeskTransferBack.OpenCashDeskAndTransferBack("19530630-0368", "500");
            }
            [Test]
            public void CashDeskTransferWithCustomerIdentification()
            {
                CashDeskTransferCustomerIdentification cashDeskTransferCustomerIdentification = new CashDeskTransferCustomerIdentification();
                cashDeskTransferCustomerIdentification.OpenCashDeskAndTransferWithCustomerIdentification("19530630-0368", "10000");
            }
            [Test]
            public void CashDeskDeposit()
            {
                CashDeskDeposit deposit = new CashDeskDeposit();
                deposit.Deposit("19530630-0368", "1500");
            }
            [Test]
            public void CashDeskWithdraw()
            {
                CashDeskWithdraw withdraw = new CashDeskWithdraw();
                withdraw.Withdraw("19530630-0368", "500");
            }
            [Test]
            public void CashDeskWithdrawAboveLimit()
            {
                CashDeskWithdrawAboveLimit cashDeskWithdrawAboveLimit = new CashDeskWithdrawAboveLimit();
                cashDeskWithdrawAboveLimit.WithdrawAboveLimit("19530630-0368", "10000");
            }
            [TearDown]
            public void TearDown()
            {
                DriverQuit teardown = new DriverQuit();
                teardown.Teardown();
            }

        }

    }
}

       

    


