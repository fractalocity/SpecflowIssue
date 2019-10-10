using System;
using Frameworks;
using NUnit.Framework;
using OpenQA.Selenium;
using POM.ndnBase;

namespace POM.ndnPages
{
    public class LoginPage : ndnBasePage
    {
        public static string MyName = "Login";

        public LoginPage(CurrentTest currenttest) : base(currenttest)
        {

        }

        override public bool WaitForLastElementToLoad()
        {
            IWebElement element = CTest.Browser.FindByCssSelectorVisibleElement("#ucVersionInfolblVersion");
            return element != null ? true : false;
        }

        override public void ValidateCriticalElementsAreVisible()
        {
            Assert.Fail("This method has not been implemented yet. Do not forget to implement it");
        }


    }
}
