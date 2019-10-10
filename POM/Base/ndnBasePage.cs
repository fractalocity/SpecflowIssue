using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frameworks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace POM.ndnBase
{
    public abstract class ndnBasePage : BasePage
    {

        GrabBy OnPageLoadWaitForVisibilityOfThisElement = null;

        public ndnBasePage(CurrentTest currenttest) : base(currenttest)
        { }


        abstract public bool WaitForLastElementToLoad();

        abstract public void ValidateCriticalElementsAreVisible();

        public void SetOnPageLoadWaitForVisibilityOfThisElement(GrabBy by)
        {
            OnPageLoadWaitForVisibilityOfThisElement = by;
        }

        public void SetOnPageLoadWaitForVisibilityOfThisElement(GrabByType bytype, string elementgrabberstring)
        {
            GrabBy by = GrabBy.Create(bytype, elementgrabberstring);
            OnPageLoadWaitForVisibilityOfThisElement = by;
        }


        public void WaitForSpecifiedElementsToLoad()
        {
            if (OnPageLoadWaitForVisibilityOfThisElement != null)
            {
                if (OnPageLoadWaitForVisibilityOfThisElement.GrabByType == GrabByType.CssSelector)
                {
                    IWebElement waitingforthiselementtoappear =
                        CTest.Browser.FindByCssSelectorVisibleElement(OnPageLoadWaitForVisibilityOfThisElement.ToString());
                }
                else // grabBy is goig to be an Xpath
                {
                    IWebElement waitingforthiselementtoappear =
                        CTest.Browser.FindByXPathSelectorVisibleElement(OnPageLoadWaitForVisibilityOfThisElement.ToString());
                }
            }
        }

    }
}
