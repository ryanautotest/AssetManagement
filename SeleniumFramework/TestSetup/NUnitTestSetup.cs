using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumFramework.DriverCore;
using SeleniumFramework.Reporter;

namespace SeleniumFramework.TestSetup;

public class NUnitTestSetup
{
    public IWebDriver? driver;
    public WebDriverAction? driverBaseAction;

    [OneTimeSetUp]

    public void OneTimeSetUp()
    {
        HtmlReport.createReport();
        HtmlReport.createTest(TestContext.CurrentContext.Test.ClassName);
    }

    [SetUp]
    public void Setup()
    {
        HtmlReport.createNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
        WebDriverManager_.InitDriver("chrome", 1920, 1080);
        driver = WebDriverManager_.GetCurrentDriver();
        driverBaseAction = new WebDriverAction(driver);
    }

    [TearDown]
    public void TearDown()
    {
        //driver.Close();
        TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus.Equals(TestStatus.Passed))
        {
            TestContext.WriteLine("Passed");
        }
        else if (testStatus.Equals(TestStatus.Failed))
        {
            TestContext.WriteLine("Failed");
        }
        HtmlReport.flush();
    }

}
