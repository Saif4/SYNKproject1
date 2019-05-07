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
    public class AccountView
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
        public class Settlement
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
            public void Settlements()
            {
                AccountSettlement accountSettlement = new AccountSettlement();
                accountSettlement.SelectAccount("Privatkonto???????????????????????????????????");
                accountSettlement.AddSettlement("310 Disponeras av kontohavaren eller god man                                                                  ", "199704290098");
                accountSettlement.ChangeSettlement("199702200016");
                accountSettlement.DeleteSettlement();
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
