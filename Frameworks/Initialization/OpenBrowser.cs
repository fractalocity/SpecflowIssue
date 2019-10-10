using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Frameworks
{
    class OpenBrowser
    {
        public enum RunType
        {
            Parallel,
            NonParallel
        }

        private static RunType TestRunType = RunType.NonParallel;

        public static void Open(CurrentTest CTest, BrowserType browserType = BrowserType.FireFox)
        {

            try
            {
                string pathToDrivers = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                switch (browserType)
                {
                    case BrowserType.Edge:
                        CTest.Driver = new EdgeDriver();
                        break;
                    case BrowserType.FireFox:
                        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService("WebBrowserDrivers", "geckodriver.exe");
                        FirefoxOptions options = new FirefoxOptions();
                        CTest.Driver = new FirefoxDriver(service, options);
                        break;
                    case BrowserType.Chrome:
                        var co = new ChromeOptions();
                        CTest.Driver = new ChromeDriver("WebBrowserDrivers", co);


                        break;
                }
                SetBrowserSize(CTest);

            }
            catch (Exception exception)
            {
                throw (exception);
            }

        }


        private static void SetBrowserSize(CurrentTest CTest)
        {
            CTest.Driver.Manage().Window.Size = new System.Drawing.Size(1350, 1000);
        }
    }

    public enum BrowserType
    {
        Chrome,
        Edge,
        FireFox
    }
}
