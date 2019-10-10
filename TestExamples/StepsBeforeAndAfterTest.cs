using TechTalk.SpecFlow;
using Frameworks.BInitialization;
using System;
using Frameworks;
using System.Reflection;

// Uncomment this line when you want to run the features in this project in parallel
//[assembly: Parallelizable(ParallelScope.Fixtures)]


namespace TheTestExamples.StepsQuietlyRunBeforeAndAfterTests
{
    [Binding]
    public class StepsBeforeAndAfterTest : TestInitialization
    {

        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;

        public StepsBeforeAndAfterTest(CurrentTest currenttest, FeatureContext featurecontext, ScenarioContext scenariocontext) : base(currenttest)
        {
            try
            {
                featureContext = featurecontext;
                scenarioContext = scenariocontext;
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }


        [BeforeTestRun]
        public static void TestInitalize()
        {
            try
            {
                //IncludeMe.IncludeThisLibrary();

                AssemblyProductAttribute project = (AssemblyProductAttribute)AssemblyProductAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute));
                string projectName = project.Product;


            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                throw (exception);
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            try
            {

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                throw (exception);
            }
        }



        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {

        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                CTest.CurrentFeature = featureContext.FeatureInfo.Title;
                CTest.CurrentScenario = scenarioContext.ScenarioInfo.Title;

                InitializeSettings();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                throw (exception);
            }

        }

        [AfterScenario]
        public void TestStop()
        {
            try
            {
                CTest.Driver.Dispose();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                throw (exception);
            }

        }



        [BeforeStep]
        public void BeforeEachStep()
        {
            CTest.CurrentStep = scenarioContext.StepContext.StepInfo.Text;
        }

        [AfterStep]
        public void AfterEachStep()
        {
        }

    }
}
