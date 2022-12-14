using AssetManagement.TestSetup;
using AssetManagement.PageObjects;
using OpenQA.Selenium;

namespace AssetManagement.Common
{
    public class CommonFlow
    {
        public static void LoginAsAdminFlow(IWebDriver driver)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsAdmin();
        }
        public static void LoginAsUserFlow(IWebDriver driver)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsUser();
        }

    }
}