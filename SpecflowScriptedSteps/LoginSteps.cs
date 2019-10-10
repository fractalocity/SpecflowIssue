using POM.ndnPages;
using TechTalk.SpecFlow;
using POM.ndnBase;
using Frameworks;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace SpecflowScriptedSteps
{
    [Binding]
    public class LoginSteps : ndnBaseStep
    {
        public LoginSteps(CurrentTest currenttest) : base(currenttest)
        { }

        [Given(@"the user logs into yahoo")]
        public void GivenTheUserLogsInAsAdmin()
        {
            CTest.StartApplication<LoginPage>(); // logs into https://news.yahoo.com/
            Thread.Sleep(2000);
            IWebElement videoLink = CTest.Driver.FindElement(By.CssSelector("a[title = 'Videos']")); // clicks a link
            videoLink.Click();
            Thread.Sleep(2000);
        }

        [When(@"the user navigates to the (.*) page")]
        public void WhenTheUserNavigatesToThePage(string mainmenuoption)
        {

        }

        [Then(@"(.*) page components should be visible and no browser errors should exist")]
        public void ThenPageComponentsShouldBeVisibleAndNoBrowserErrorsShouldExist(string pagecurrentlyviewing)
        {
            try
            {


            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
