using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;

namespace Frameworks
{
    public class CurrentTest
    {
        public IWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }

        public CurrentTestBrowser Browser { get; set; }


        public string CurrentFeature {get; set;}

        public string CurrentScenario { get; set; }

        public string CurrentStep { get; set; }

        public CurrentTest()
        {
            Browser = new CurrentTestBrowser(this);
        }

        ~CurrentTest()
        {
        }

        public void Initialize()
        {}

        public string GetPathToDllDir()
        {
            string pathToDrivers = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return pathToDrivers;
        }

        public string GetPathToTestDataFiles()
        {
            return "";  
        }

        public TPage Page<TPage>() where TPage : BasePage
        {
            return (TPage)CurrentPage;
        }

        public string CurrentPageName()
        {
            return CurrentPage.ToString();
        }

        public virtual void StartApplication<TPage>() where TPage : BasePage
        {
            Driver.Url = "https://news.yahoo.com/";

            CurrentPage = (TPage)Activator.CreateInstance(typeof(TPage), this);
        }

        private string FeatureNumber()
        {
            string currentFeature = CurrentFeature != null && CurrentFeature.Trim().Length > 0 ? CurrentFeature : "";

            string featureNumber = "";
            if (!string.IsNullOrEmpty(currentFeature))
            {
                int charLocation = currentFeature.IndexOf("", StringComparison.Ordinal);
                if (charLocation > 0)
                    featureNumber = currentFeature.Substring(0, charLocation);
            }

            return featureNumber;
        }

        private string ScenarioNumber()
        {
            string currentScenario = CurrentScenario != null && CurrentScenario.Trim().Length > 0 ? CurrentScenario : "";

            string scenrioNumbers = "";
            if (!string.IsNullOrEmpty(currentScenario))
            {
                int charLocation = currentScenario.IndexOf("", StringComparison.Ordinal);
                if (charLocation > 0)
                    scenrioNumbers = currentScenario.Substring(0, charLocation);
            }

            return scenrioNumbers;
        }


    }
}

