using NUnit.Framework;
using NUnit.Framework.Internal;
using AssetManagement.TestSetup;
using AssetManagement.Common;
using AssetManagement.PageObjects;
using System.Linq;
using System.Threading;
using FluentAssertions;
using AssetManagement.DAO;
using System.Collections.Generic;

namespace AssetManagement.TestCases
{
    [TestFixture]
    public class ManageAssetTest : ProjectNUnitTestSetup
    {
        [Test]
        public void LoginAsAdminClickPagination()
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.ClickManageAsset();

            ManageUserPage manageUserPage = new ManageUserPage(driver);
            //get 1st row of each page and compare
            var firstRowDataPage1 = manageUserPage.GetDataFromTable().Take(1).ToList();
            manageUserPage.ClickPagination(2);
            var firstRowDataPage2 = manageUserPage.GetDataFromTable().Take(1).ToList();
            firstRowDataPage1.Should().NotBeEquivalentTo(firstRowDataPage2);
        }

    }
}