using NUnit.Framework;
using NUnit.Framework.Internal;
using AssetManagement.TestSetup;
using AssetManagement.Common;
using AssetManagement.PageObjects;
using System.Linq;
using FluentAssertions;

namespace AssetManagement.TestCases
{
    [TestFixture]
    public class ManageAssignmentTest : ProjectNUnitTestSetup
    {
        [Test]
        public void LoginAsAdminAndClickPagination()
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.GoToManageAsset();

            ManageAssetPage manageAssetPage = new ManageAssetPage(driver);
            //var firstRowDataPage1 = manageAssetPage.GetDataFromTable().Take(1).ToList();
            manageAssetPage.ClickPagination(2);
            //var firstRowDataPage2 = manageAssetPage.GetDataFromTable().Take(1).ToList();
            //firstRowDataPage1.Should().NotBeEquivalentTo(firstRowDataPage2);
            manageAssetPage.ViewAssetDetails();
        }


        [TestCase("flower")]
        public void AdminSearchAssignment(string key)
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.GoToManageAsset();

            ManageAssetPage manageAssetPage = new ManageAssetPage(driver);
            manageAssetPage.SearchBarWithKey(key);
            manageAssetPage.ViewAssetDetails();
        }

        [TestCase("SD0021", "LA000012")]
        public void AdminCreateNewAssignment(string staffCode, string assetCode)
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.GoToManageAssignment();

            ManageAssignmentPage manageAssignmentPage = new ManageAssignmentPage(driver);
            manageAssignmentPage.CreateNewAssignment(staffCode, assetCode);
            //Assert.IsTrue(manageAssignmentPage.VerifyStateAccepted(assetCode);
        }

        [TestCase("LA000012")]
        public void StaffDeclineAssignment(string assetCode)
        {
            CommonFlow.LoginAsUserFlow(driver);

            ManageAssignmentPage manageAssignmentPage = new ManageAssignmentPage(driver);
            manageAssignmentPage.DeclineAssignment(assetCode);
            //Assert.IsTrue(manageAssignmentPage.VerifyStateAccepted(assetCode);
        }

        [TestCase("LA000012")]

        public void StaffAcceptAssignment(string assetCode)
        {
            CommonFlow.LoginAsUserFlow(driver);

            ManageAssignmentPage manageAssignmentPage = new ManageAssignmentPage(driver);
            manageAssignmentPage.AcceptAssignment(assetCode);
        }

        [TestCase("LA000012")]

        public void StaffReturnAssignment(string assetCode)
        {
            CommonFlow.LoginAsUserFlow(driver);

            ManageAssignmentPage manageAssignmentPage = new ManageAssignmentPage(driver);
            manageAssignmentPage.ReturnAssignment(assetCode);
        }

        [TestCase("LA000012")]
        public void AdminRequestReturning(string assetCode)
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.GoToManageAssignment();

            ManageAssignmentPage manageAssignmentPage = new ManageAssignmentPage(driver);
            manageAssignmentPage.SearchBarWithAssetCode(assetCode);
            manageAssignmentPage.ReturnAssignment(assetCode);
            //click ok button
            //confirm ok pop up
            //Assert.IsTrue(manageAssignmentPage.VerifyStateReturning(assetCode);



        }

    }
}