using TechTalk.SpecFlow;
using System;
using System.Data.SqlClient;

namespace Frameworks.BInitialization
{
    public class TestInitialization : Steps
    {
        protected readonly CurrentTest CTest;

        public TestInitialization(CurrentTest currenttest)
        {
            CTest = currenttest;
        }

        public void InitializeSettings()
        {
            try
            {
                CTest.Initialize();
                OpenBrowser.Open(CTest, BrowserType.Chrome);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.ToString());
                throw (exception);
            }
        }
    }
}
