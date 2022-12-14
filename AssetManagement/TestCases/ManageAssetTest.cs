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
    public class ManageAssetTest : ProjectNUnitTestSetup
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

        [Test]
        public void AdminCreateNewAssset()
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.GoToManageAsset();

            ManageAssetPage manageAssetPage = new ManageAssetPage(driver);
            manageAssetPage.SelectNewAssetCategory();
        }

        [Test]

        public void EditAssignment()
        {

        }

    }
}