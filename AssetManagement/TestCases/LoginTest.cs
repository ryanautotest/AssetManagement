using System.Threading.Tasks;
using NUnit.Framework;
using AssetManagement.PageObjects;
using AssetManagement.TestSetup;
using FluentAssertions;
using AssetManagement.Services;
using AssetManagement.DAO;
using System.Collections.Generic;
using SeleniumFramework.Utilities;

namespace AssetManagement.TestCases
{
    [TestFixture]
    public class LoginTest : ProjectNUnitTestSetup
    {
        [Test]
        public async Task LoginAPI()
        {
            AdminService adminService = new AdminService();
            adminService.LoginAdmin();
        }

        [Test]
        public void LoginAsAdminAndLogoutTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsAdmin();
            HomePage homePage = new HomePage(driver);
            //Assert.IsTrue(homePage.ManagerUserIsDisplayed());
            homePage.ClickLogout();
            Assert.True(loginPage.LoginButtonIsDisplayed());
        }

        [TestCase("toannd", "12345678")]

        public void LoginAsUserAndChangePassword(string userName, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsUser(userName, password);
            HomePage homePage = new HomePage(driver);
            //Assert.True(homePage.RequestForReturningIsDisplayed());
            //change pass & logout
            homePage.ChangePassword("12345678", "87654321");
            homePage.ClickLogout();
            //login with new pass
            loginPage.LoginAsUser("toannd", "87654321");
            Assert.True(homePage.RequestForReturningIsDisplayed());
            //change pass to oldpass & logout
            homePage.ChangePassword("87654321", "12345678");
            homePage.ClickLogout();
            //login again
            loginPage.LoginAsUser(userName, password);
            Assert.True(homePage.RequestForReturningIsDisplayed());
        }

        [TestCase("toannd", "12345678")]
        public void LoginAsUserAndLogoutTest(string userName, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsUser(userName, password);
            HomePage homePage = new HomePage(driver);
            Assert.True(homePage.RequestForReturningIsDisplayed());
            homePage.ClickLogout();
            Assert.True(loginPage.LoginButtonIsDisplayed());
        }
       
    }
}