using Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;


namespace Frameworks
{
    public static class WebElementExtensions
    {

        public static string GetSelectedDropDown(this IWebElement element) // ?
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element) // ?
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static string GetLinkText(this IWebElement element) // ?
        {
            return element.Text;
        }

        public static string TextTrimmed(this IWebElement element)
        {
            return element.Text.Trim();
        }

        public static IWebElement GetParentElement(this IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }

    }
}

