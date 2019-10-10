using TechTalk.SpecFlow;
using POM.ndnBase;
using POM.ndnPages;
using Frameworks;
using System;
using OpenQA.Selenium;
using System.Threading;

// *** Uncomment this code and then comment the code in SpecflowScriptedSteps\LoginSteps.cs to see
//     that the same bindings, if the are in the same project as the feature files, will allow tests to pass.

namespace TheTestExamples.Steps
{
    [Binding]
    public class LoginSteps : ndnBaseStep
    {
        public LoginSteps(CurrentTest currenttest) : base(currenttest)
        { }

        //[Given(@"the user logs into yahoo")]
        //public void GivenTheUserLogsInAsAdmin()
        //{
        //    CTest.StartApplication<LoginPage>(); // logs into https://news.yahoo.com/
        //    Thread.Sleep(2000);
        //    IWebElement videoLink = CTest.Driver.FindElement(By.CssSelector("a[title = 'Videos']")); // clicks a link
        //    videoLink.Click();
        //    Thread.Sleep(2000);
        //}

        //[When(@"the user navigates to the (.*) page")]
        //public void WhenTheUserNavigatesToThePage(string mainmenuoption)
        //{

        //}

        //[Then(@"(.*) page components should be visible and no browser errors should exist")]
        //public void ThenPageComponentsShouldBeVisibleAndNoBrowserErrorsShouldExist(string pagecurrentlyviewing)
        //{
        //    try
        //    {


        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
