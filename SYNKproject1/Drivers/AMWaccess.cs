using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
   public class AMWaccess : DriversRoot
    {
        public void AmmAccess()
        {
            try
            {
                RootSession.FindElementByName("Påloggning på Centrala Systemet");
                RootSession.FindElementByAccessibilityId("304").Clear();
                RootSession.FindElementByAccessibilityId("304").SendKeys("P417JI6");
                RootSession.FindElementByAccessibilityId("305").SendKeys("evry123");
                RootSession.FindElementByName("Logga på").Click();
                //return false;
            }
            catch (Exception)
            {
                Console.WriteLine("not found");
            }
        }
    }
}
