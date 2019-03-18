using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYNKproject1
{
    class DriverQuit : Drivers
    {
        public void Teardown()
        {
            // Stänger Synk och tar bort sessionen.
            if (SYNKSession != null)
            {

                SYNKSession.Quit();
                SYNKSession = null;
            }
        }
    }
}
