using System.Threading.Tasks;
using NUnit.Framework;
using AssetManagement.PageObjects;
using AssetManagement.TestSetup;
using AssetManagement.Resources;
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
        [Test, Order(1)]
        public void LoginAsAdminAndLogoutTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsAdmin();
            HomePage homePage = new HomePage(driver);
            //Assert.IsTrue(homePage.ManagerUserIsDisplayed());
            homePage.ClickLogout();
            //Assert.True(loginPage());
        }

        [Test, Order(2)]

        public void LoginAsUserAndChangePassword()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsUser();
            HomePage homePage = new HomePage(driver);
            //change pass & logout
            homePage.ChangePassword();
            homePage.ClickLogout();
            //login with new pass
            loginPage.LoginAsUserAfterChangePassword();
            //change pass to oldpass & logout
            homePage.ResetPassword();
            homePage.ClickLogout();
            //login again
            loginPage.LoginAsUser();
        }

        [Test]
        public void LoginAsUserAndLogoutTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsUser();
            HomePage homePage = new HomePage(driver);
            homePage.ClickLogout();
        }

        [Test]
        public void LoginFirstTime()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsUserFirstTime();
            loginPage.ChangePassword1stTime();
            HomePage homePage = new HomePage(driver);
            homePage.ClickLogout();
            loginPage.LoginAsNewUserAfterChangePassword();
        }
        /*
        [Test]
        public async Task LoginAPI()
        {
            AdminService adminService = new AdminService();
            adminService.LoginAdmin();
        }*/
    }
}