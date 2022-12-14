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
    public class ScenarioTest : ProjectNUnitTestSetup
    {
        [Test]
        public void LoginAsAdminAndLogoutTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginAsAdmin();
            HomePage homePage = new HomePage(driver);
            //Assert.IsTrue(homePage.ManagerUserIsDisplayed());
            homePage.GoToManageUser();
            //Create new user
            ManageUserPage manageUserPage = new ManageUserPage(driver);
            manageUserPage.CreateNewUser("Toan", "Nguyen", "26/11/1994", "male", "21/11/2022", "Staff");
            //Assert.True(loginPage());
            //Logout
            homePage.ClickLogout();
            //Change password first time 
            loginPage.LoginAsUserFirstTime();
            //Change password normal
            loginPage.ChangePassword1stTime();
            homePage.ClickLogout();
            //Logout Admin
            loginPage.LoginAsAdmin();
            homePage.GoToManageUser();
            manageUserPage.EditUser("Admin");
            //OK till here
            //Search
            manageUserPage.SearchBarWithKey("toan");
            //View
            manageUserPage.ViewUserDetails();
            ManageAssetPage manageAssetPage = new ManageAssetPage(driver);
            manageAssetPage.CreateNewAsset();
            //Verify new assset state is available

            //get assetcode of 1st record then use for next steps
            //Assign to new user
            ManageAssignmentPage manageAssignmentPage = new ManageAssignmentPage(driver);
            manageAssignmentPage.CreateNewAssignment("staffCode", "assetcode");
            //verify new assset state is waiting for 
            Assert.IsTrue(manageAssignmentPage.VerifyStateWaitingForAcceptance("assetcode"));
            //Login new user and accept
            homePage.ClickLogout();
            loginPage.LoginAsUser();
            Assert.IsTrue(manageAssignmentPage.VerifyStateWaitingForAcceptance("assetcode"));
            manageAssignmentPage.AcceptAssignment("assetcode");
            Assert.IsTrue(manageAssignmentPage.VerifyStateAccepted("assetcode"));

            //logout
            homePage.ClickLogout();

            //login Admin
            loginPage.LoginAsAdmin();
            //verify asset state is accepted
            homePage.GoToManageAssignment();
            manageAssignmentPage.SearchBarWithAssetCode("assetcode");
            Assert.IsTrue(manageAssignmentPage.VerifyStateAccepted("assetcode"));
            //logout

            //user login

            //request returning

            //admin approved

            //extract report



        }
    }
}