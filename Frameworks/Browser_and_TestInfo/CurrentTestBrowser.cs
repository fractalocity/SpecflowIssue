using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Frameworks

{
    public class CurrentTestBrowser
    {

        private const int DefaultWaitTime = 10;
        private readonly CurrentTest CTest;

        public CurrentTestBrowser(CurrentTest thisTest)
        {
            CTest = thisTest;
        }

        public IWebElement FindByClickableElement(GrabBy grabby, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            return GenericFindClickableElement(null, grabby, allowedWaitTimeInSeconds);
        }

        public IWebElement FindByClickableElement(IWebElement element, GrabBy grabby, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            return GenericFindClickableElement(element, grabby, allowedWaitTimeInSeconds = DefaultWaitTime);
        }

        public IWebElement FindByIdClickableElement(string elementID, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.Id, elementID);
            return GenericFindClickableElement(null, by, allowedWaitTimeInSeconds);
        }
        public IWebElement FindByIdClickableElement(IWebElement element, string subelementID, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.Id, subelementID);
            return GenericFindClickableElement(element, by, allowedWaitTimeInSeconds = DefaultWaitTime);
        }


        public IWebElement FindByNameClickableElement(string elementName, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.Name, elementName);
            return GenericFindClickableElement(null, by, allowedWaitTimeInSeconds);
        }

        public IWebElement FindByNameClickableElement(IWebElement element, string subelementName, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.Name, subelementName);
            return GenericFindClickableElement(element, by, allowedWaitTimeInSeconds);
        }


        public IWebElement FindByCssSelectorClickableElement(string cssSelectorhForElement, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.CssSelector, cssSelectorhForElement);
            return GenericFindClickableElement(null, by, allowedWaitTimeInSeconds);
        }
        public IWebElement FindByCssSelectorClickableElement(IWebElement element, string subElementcssSelectorhFor, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.CssSelector, subElementcssSelectorhFor);
            return GenericFindClickableElement(element, by, allowedWaitTimeInSeconds);
        }


        public IWebElement FindByXPathClickableElement(string xpathForElement, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.XpathSelector, xpathForElement);
            return GenericFindClickableElement(null, by, allowedWaitTimeInSeconds);
        }
        public IWebElement FindByXPathClickableElement(IWebElement element, string subElementxpath, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.XpathSelector, subElementxpath);
            return GenericFindClickableElement(element, by, allowedWaitTimeInSeconds);
        }


        public IWebElement FindClickableElement(GrabByType type, string elementgrabber, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(type, elementgrabber);
            return GenericFindClickableElement(null, by, allowedWaitTimeInSeconds);
        }

        public IWebElement FindClickableElement(IWebElement element, GrabByType type, string elementgrabber, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(type, elementgrabber);
            return GenericFindClickableElement(element, by, allowedWaitTimeInSeconds);
        }


        public IWebElement FindByXPathElementExists(string xpathForElement, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.XpathSelector, xpathForElement);
            return GenericFindExistingElement(null, by, allowedWaitTimeInSeconds);
        }

        public IWebElement FindByCssSelectorVisibleElement(string cssSelectorhForElement, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.CssSelector, cssSelectorhForElement);
            return GenericFindVisibleElement(null, by, allowedWaitTimeInSeconds);
        }

        public IWebElement FindByXPathSelectorVisibleElement(string xpathForElement, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.XpathSelector, xpathForElement);
            return GenericFindVisibleElement(null, by, allowedWaitTimeInSeconds);
        }

        public void WaitForExistanceByXPath(string xpathForElement, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            GrabBy by = GrabBy.Create(GrabByType.XpathSelector, xpathForElement);
            GenericFindExistingElement(null, by, allowedWaitTimeInSeconds);
        }


        public void ClickWithRecovery(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception exceptiona)
            {
                if ((exceptiona.GetType() != typeof(NullReferenceException) && exceptiona.GetType() != typeof(NoSuchElementException)) &&
                    (exceptiona.GetType() == typeof(OpenQA.Selenium.ElementClickInterceptedException) ||
                     exceptiona.GetType() == typeof(OpenQA.Selenium.StaleElementReferenceException)))
                {
                    
                    ClickSecondaryClickAttemtpsAfterFailure(element, exceptiona);
                }
                else
                {  } 
            }
        }

        public void ClickElementWithMultiRecovery(IWebElement element, GrabBy grabby)
        {
            try
            {
                element.Click();
            }
            catch (Exception exceptiona)
            {
                if ((exceptiona.GetType() != typeof(NullReferenceException) && exceptiona.GetType() != typeof(NoSuchElementException)) &&
                    (exceptiona.GetType() == typeof(OpenQA.Selenium.ElementClickInterceptedException) ||
                     exceptiona.GetType() == typeof(OpenQA.Selenium.StaleElementReferenceException)))
                {
                    int count = 0;
                    bool successfulclick = false;
                    while (count < 4 || !successfulclick)
                    {
                        try
                        {
                            Thread.Sleep(500); // half a second
                            By grabBy = grabby.GetBy();
                            IWebElement yourSlipperyElement = CTest.Driver.FindElement(grabBy);
                            successfulclick = true;
                        }
                        catch (Exception)
                        { }
                        count++;
                    }
                    if (successfulclick == false)
                        ClickSecondaryClickAttemtpsAfterFailure(element, exceptiona);
                }
                else
                { }
            }
        }

        public bool IsElementVisible(GrabByType grabbytype, string grabberstring, int allowedWaitTimeInSeconds = 1)
        {
            try
            {
                GrabBy grabber = GrabBy.Create(grabbytype, grabberstring);
                By by = grabber.GetBy();

                System.TimeSpan timeToWait = new TimeSpan(0, 0, allowedWaitTimeInSeconds);
                WebDriverWait wait = new WebDriverWait(CTest.Driver, timeToWait);
                IWebElement clickableElementOnPage = wait.Until(ExpectedConditions.ElementToBeClickable(by));

                return true;
            }
            catch (Exception)
            {
                return false; 
            }
        }


        public void Hover(IWebElement element)
        {
            Actions actions = new Actions(CTest.Driver);
            actions.MoveToElement(element).Perform();
        }

        public void ScrollIntoView(IWebElement element)
        {
            ((IJavaScriptExecutor)CTest.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            WaitUntilVisible(element);
        }


        private IWebElement GenericFindClickableElement(IWebElement element, GrabBy grabber, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            try
            {
                System.TimeSpan timeToWait = new TimeSpan(0, 0, allowedWaitTimeInSeconds);
                WebDriverWait wait = new WebDriverWait(CTest.Driver, timeToWait);
                By by = grabber.GetBy();
                IWebElement clickableElementOnPage = null;
                if (element == null)
                {
                    clickableElementOnPage = wait.Until(ExpectedConditions.ElementToBeClickable(by));
                }
                else
                {
                    IWebElement existingElement = wait.Until(driver => element.FindElement(by));
                    clickableElementOnPage = wait.Until(ExpectedConditions.ElementToBeClickable(existingElement));
                }
                return clickableElementOnPage;
            }
            catch (Exception)
            {
                try
                {

                    System.TimeSpan timeToWait = new TimeSpan(0, 0, allowedWaitTimeInSeconds);
                    WebDriverWait wait = new WebDriverWait(CTest.Driver, timeToWait);
                    By by = grabber.GetBy();

                    IWebElement htmlElementOnPage = null;

                    if (element == null)
                    {
                        Thread.Sleep(2000);
                        htmlElementOnPage = CTest.Driver.FindElement(by);
                        ScrollIntoView(htmlElementOnPage);
                        htmlElementOnPage = wait.Until(ExpectedConditions.ElementToBeClickable(by));
                    }
                    else
                    {
                        htmlElementOnPage = element.FindElement(by);
                        ScrollIntoView(htmlElementOnPage);
                        htmlElementOnPage = wait.Until(ExpectedConditions.ElementToBeClickable(by));
                    }
                    return htmlElementOnPage;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        private IWebElement GenericFindExistingElement(IWebElement element, GrabBy grabber, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            try
            {
                System.TimeSpan timeToWait = new TimeSpan(0, 0, allowedWaitTimeInSeconds);
                WebDriverWait wait = new WebDriverWait(CTest.Driver, timeToWait);
                By by = grabber.GetBy();
                IWebElement htmlElementOnPage = wait.Until(ExpectedConditions.ElementExists(by));
                return htmlElementOnPage;
            }
            catch (Exception exception)
            {
                throw (exception); 
            }
        }

        private IWebElement GenericFindVisibleElement(IWebElement element, GrabBy grabber, int allowedWaitTimeInSeconds = DefaultWaitTime)
        {
            try
            {
                System.TimeSpan timeToWait = new TimeSpan(0, 0, allowedWaitTimeInSeconds);
                WebDriverWait wait = new WebDriverWait(CTest.Driver, timeToWait);
                By by = grabber.GetBy();
                IWebElement htmlElementOnPage = wait.Until(ExpectedConditions.ElementIsVisible(by));
                return htmlElementOnPage;
            }
            catch (Exception exception)
            {
                throw (exception); 
            }
        }

        private void ClickSecondaryClickAttemtpsAfterFailure(IWebElement element, Exception exception)
        {
            try
            {
                Thread.Sleep(2000);
                ScrollIntoView(element);
                element.Click();
            }
            catch (Exception)
            {

                try
                {
                    Screenshot ss = ((ITakesScreenshot)CTest.Driver).GetScreenshot();
                    Thread.Sleep(1000); // one second wait
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)CTest.Driver;
                    executor.ExecuteScript("arguments[0].click();", element);
                    
                }
                catch (Exception)
                {

                }
            }
        }


        private IWebElement WaitUntilVisible(IWebElement element)
        {
            return WaitUntilVisible(element, new TimeSpan(0, 2, 0));
        }

        private IWebElement WaitUntilVisible(IWebElement element, TimeSpan timeSpan)
        {
            WebDriverWait wait = new WebDriverWait(CTest.Driver, timeSpan);
            wait.Until(driver =>
            {
                try
                {
                    if (element.Displayed)
                        return true;
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });

            return element;
        }
    }
}
