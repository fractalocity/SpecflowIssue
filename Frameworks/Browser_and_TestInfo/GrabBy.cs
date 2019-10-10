using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Frameworks
{
    public class GrabBy
    {

        public GrabByType GrabByType { get; set; }
        public string selector;


        public static GrabBy Create(GrabByType type, string selectorstring)
        {
            return new GrabBy(type, selectorstring);
        }

        public GrabBy(GrabByType type, string selectorstring)
        {
            GrabByType = type;
            selector = selectorstring;
        }


        public void Change(GrabByType type, string selectorstring)
        {
            GrabByType = type;
            selector = selectorstring;
        }

        public By GetBy()
        {
            if (GrabByType == GrabByType.CssSelector)
                return By.CssSelector(selector);
            else if (GrabByType == GrabByType.XpathSelector)
                return By.XPath(selector);
            else if (GrabByType == GrabByType.Id)
                return By.Id(selector);
            else
                return By.Name(selector);
        }

        public override string ToString()
        {
            return selector;
        }

    }

    public class GrabByCss
    {

        public string SelectorString { get; set; }


        public static GrabByCss Create()
        {
            return new GrabByCss("");
        }


        public override string ToString()
        {
            return SelectorString;
        }

        public GrabByCss(string modalGrabber)
        {
            SelectorString = modalGrabber;
        }
    }

    public enum GrabByType
    {
        CssSelector,
        XpathSelector,
        Id, 
        Name
    }
}
