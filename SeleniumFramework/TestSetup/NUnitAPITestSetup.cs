using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumFramework.DriverCore;
using SeleniumFramework.Reporter;

namespace SeleniumFramework.TestSetup;

public class NUnitAPITestSetup : NUnitTestSetup
{
    [SetUp]
    public void Setup()
    {
    }

    [TearDown]
    public void TearDown()
    {
    }

}
