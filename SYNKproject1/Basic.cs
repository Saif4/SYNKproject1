using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SYNKproject1
{
    public class Basic
    {
        public const string windowsApplicationDriverUrl = "http://127.0.0.1:4727";
        public const string SYNKAppId = @"C:\Program Files (x86)\SYNKNET\Starternet.exe";
        public const string AMWAppId = @"C:\Program Files\Swedbank\Infra\Bin\BehTS.exe";
        public const string advisorID = "P417JI6";
        public const string advisorPassword = "evry123";

        public static WindowsDriver<WindowsElement> DesktopSession;
        public static WindowsDriver<WindowsElement> AMWSession;
        public static WindowsDriver<WindowsElement> StarterNetSession;
        public static WindowsDriver<WindowsElement> SYNKStartWindowSession;
        public static WindowsDriver<WindowsElement> CustomerFormWindowSession;
        public static WindowsDriver<WindowsElement> VarukorgenFormWindowSession;



        public void Setup()
        {

            // Create a new Desktop session
            DesiredCapabilities desktopCapabilities = new DesiredCapabilities();
            desktopCapabilities.SetCapability("app", "Root");
            desktopCapabilities.SetCapability("deviceName", "WindowsPC");
            DesktopSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), desktopCapabilities);

            // Set implicit timeout to 10 seconds to make element search to retry every 500 ms for at most three times
            DesktopSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));


            #region Launch AMW (not used atm)
            // Start AMW
            //DesiredCapabilities AMWAppCapabilities = new DesiredCapabilities();
            //AMWAppCapabilities.SetCapability("app", AMWAppId);
            //AMWAppCapabilities.SetCapability("deviceName", "WindowsPC");
            //AMWSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), AMWAppCapabilities);
            #endregion

            #region Open AMW from System Tray and sign in
            // Open AMW from System Tray
            //DesktopSession.FindElementByName("Notification Chevron").Click();
            //WindowsElement AMWIcon = DesktopSession.FindElementByName("Påloggning på Centrala Systemet - Ej påloggad");
            //DesktopSession.Mouse.MouseMove(AMWIcon.Coordinates);
            //DesktopSession.Mouse.DoubleClick(null);

            // Enter AMW Credentials and sign in
            //DesktopSession.FindElementByAccessibilityId("304").Clear();
            //DesktopSession.FindElementByAccessibilityId("304").SendKeys(AdvisorID);
            //DesktopSession.FindElementByAccessibilityId("305").SendKeys(AdvisorPassword);
            //DesktopSession.FindElementByName("Logga på").Click();
            #endregion


            // Launch SYNK and create a session
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", SYNKAppId);
            appCapabilities.SetCapability("deviceName", "WindowsPC");
            StarterNetSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), appCapabilities);
            StarterNetSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            //StarterNetSession.FindElementByName("32701010").Click();
            //StarterNetSession.FindElementByName("OK").Click();
        }

            public void OpenAccount()
            {
                
                //Find "SYNK - Startfönster"
                var synkStartWindow = DesktopSession.FindElementByName("SYNK - Startfönster");
                var synkStartWindowHandle = synkStartWindow.GetAttribute("NativeWindowHandle");
                synkStartWindowHandle = (int.Parse(synkStartWindowHandle)).ToString("x"); // Convert to Hex

                // Create session by attaching to "SYNK - Startfönster" top level window
                DesiredCapabilities synkAppCapabilities = new DesiredCapabilities();
                synkAppCapabilities.SetCapability("appTopLevelWindow", synkStartWindowHandle);
                SYNKStartWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), synkAppCapabilities);
                SYNKStartWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));

                // Activate Customer
                SYNKStartWindowSession.FindElementByAccessibilityId("txtKundNr").SendKeys("196308120093");
                SYNKStartWindowSession.FindElementByName("Aktivera").Click();

                // Find "Customer View"
                var customerFormWindow = DesktopSession.FindElementByAccessibilityId("frmCustView");
                var customerFormWindowHandle = customerFormWindow.GetAttribute("NativeWindowHandle");
                customerFormWindowHandle = (int.Parse(customerFormWindowHandle)).ToString("x"); // Convert to Hex

                // Create session by attaching to "Customer View" top level window
                DesiredCapabilities customerFormAppCapabilities = new DesiredCapabilities();
                customerFormAppCapabilities.SetCapability("appTopLevelWindow", customerFormWindowHandle);
                CustomerFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), customerFormAppCapabilities);
                CustomerFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));
                CustomerFormWindowSession.FindElementByName("Affärer").Click();
                CustomerFormWindowSession.FindElementByName("Nytt Konto...").Click();

                // Select "First option after sending {T} key in account list ("Transaktionskonto - TRP00303") (dirty solution)
                CustomerFormWindowSession.FindElementByAccessibilityId("cboChooseAccount").Click();
                CustomerFormWindowSession.FindElementByAccessibilityId("cboChooseAccount").SendKeys("T");
                CustomerFormWindowSession.FindElementByName("OK").Click();

                // Save Account Number and click OK
                var accountNumber = CustomerFormWindowSession.FindElementByAccessibilityId("txtAccount").Text;
                CustomerFormWindowSession.FindElementByName("OK").Click();

                // Find "Affärssammanställning"
                var varukorgenFormWindow = DesktopSession.FindElementByAccessibilityId("frmVarukorgen");
                var varukorgenFormWindowHandle = varukorgenFormWindow.GetAttribute("NativeWindowHandle");
                varukorgenFormWindowHandle = (int.Parse(varukorgenFormWindowHandle)).ToString("x"); // Convert to Hex

                // Create session by attaching to "Affärssammanställning" top level window
                DesiredCapabilities varukorgenFormAppCapabilities = new DesiredCapabilities();
                varukorgenFormAppCapabilities.SetCapability("appTopLevelWindow", varukorgenFormWindowHandle);
                VarukorgenFormWindowSession = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), varukorgenFormAppCapabilities);
                VarukorgenFormWindowSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));
                VarukorgenFormWindowSession.FindElementByName("Verkställ").Click();
                VarukorgenFormWindowSession.FindElementByName("Slutför med skriftligt godkännande").Click();
                VarukorgenFormWindowSession.FindElementByName("OK").Click();

                // Assert that the accountNumber is listed in "2. Engagemang"


            }
        }
}
