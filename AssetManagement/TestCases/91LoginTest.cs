using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AssetManagement.PageObjects;
using OpenQA.Selenium;
using AssetManagement.TestSetup;

namespace AssetManagement.TestCases
{
    [TestFixture]
    public class FT91_LoginTest : ProjectNUnitTestSetup
    {
        [Test]
        public void LoginAsAdminAndLogoutTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsAdmin();
            HomePage homePage = new HomePage(driver);
            Assert.True(homePage.ManagerUserIsDisplayed());
            homePage.ClickLogout();
            Assert.True(homePage.LoginButtonIsDisplayed());
        }

        [TestCase("toannd", "12345678")]
        public void LoginAsUserAndLogoutTest(string userName, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsUser(userName, password);
            HomePage homePage = new HomePage(driver);
            Assert.True(homePage.RequestForReturningIsDisplayed());
            homePage.ClickLogout();
            Assert.True(homePage.LoginButtonIsDisplayed());
        }

        [TestCase("toannd", "12345678")]

        public void LoginAsUserAndChangePassword(string userName, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsUser(userName, password);
            HomePage homePage = new HomePage(driver);
            Assert.True(homePage.RequestForReturningIsDisplayed());
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


    }
}