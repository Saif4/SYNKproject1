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
    public class TestCases
    {
        static void Main(string[] args)

        {
            AMW aMW = new AMW();
            aMW.Driver("P417JI6", "evry123");
            Drivers SynkStartup = new Drivers();
            SynkStartup.Driver();
            LoginToSynk synkStartWindowLogin = new LoginToSynk();
            synkStartWindowLogin.Synklogin("197611040010");

            AccountSelection accountSelection = new AccountSelection();
            accountSelection.SelectAccount("Privatkonto???????????????????????????????????");

            AccountSettlement accountSettlement = new AccountSettlement();
            accountSettlement.AddSettlement("310 Disponeras av kontohavaren eller god man                                                                  ", "194207030018");
            accountSettlement.ChangeSettlement("199702200016");
            accountSettlement.DeleteSettlement();

            AccountHolder accountHolder = new AccountHolder();
            accountHolder.AddAcountHolder("194207030018");
            accountHolder.DeleteHolder();

            
            // Advise advise = new Advise();
            //advise.OpenAdvise();
        }
    }
}
