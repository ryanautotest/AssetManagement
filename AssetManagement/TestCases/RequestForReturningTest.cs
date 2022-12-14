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
    public class RequestForReturningTest : ProjectNUnitTestSetup
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

        [TestCase("LA000012")]
        public void AdminCompleteRequestReturning(string assetCode)
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.GoToRequestForReturning();

            RequestForReturningPage requestForReturningPage = new RequestForReturningPage(driver);
            requestForReturningPage.SearchBarWithKey(assetCode);
            requestForReturningPage.CompleteReturningRequest(assetCode);
        }

        [Test]
        public void AdminCancelRequestReturning(string assetCode)
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.GoToRequestForReturning();

            RequestForReturningPage requestForReturningPage = new RequestForReturningPage(driver);
            requestForReturningPage.SearchBarWithKey(assetCode);
            requestForReturningPage.CancelReturningRequest(assetCode);
        }
    }
}