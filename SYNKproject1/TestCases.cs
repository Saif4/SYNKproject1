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
            Drivers SynkStartup = new Drivers();
            SynkStartup.Driver("P417JI6", "evry123");
            LoginToSynk synkStartWindowLogin = new LoginToSynk();
            synkStartWindowLogin.Synklogin("197611040010");

            AccountSettlement accountSettlement = new AccountSettlement();
            accountSettlement.SelectAccount("Privatkonto???????????????????????????????????");
            accountSettlement.AddSettlement("310 Disponeras av kontohavaren eller god man                                                                  ", "199704290098");
            accountSettlement.ChangeSettlement("199702200016");
            accountSettlement.DeleteSettlement();

            
            // Advise advise = new Advise();
            //advise.OpenAdvise();
        }
    }
}
