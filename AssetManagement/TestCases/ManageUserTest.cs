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
    public class ManageUserTest : ProjectNUnitTestSetup
    {
        [Test]
        public void LoginAsAdminClickPagination()
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.GoToManageUser();

            ManageUserPage manageUserPage = new ManageUserPage(driver);
            //get 1st row of each page and compare
            var firstRowDataPage1 = manageUserPage.GetDataFromTable().Take(1).ToList();
            manageUserPage.ClickPagination(2);
            var firstRowDataPage2 = manageUserPage.GetDataFromTable().Take(1).ToList();
            firstRowDataPage1.Should().NotBeEquivalentTo(firstRowDataPage2);
        }

        [Test]
        public void CreateNewUser()
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.GoToManageUser();

            ManageUserPage manageUserPage = new ManageUserPage(driver);
            manageUserPage.CreateNewUser("Toan", "Nguyen", "26/11/1994", "male", "21/11/2022", "Staff");

            homePage.ClickLogout();


            /*
            List<CreateUserDAO> list = new List<CreateUserDAO>();
            foreach(var item in newUserInfo)
            {
                item.Remove(item[5]);
                CreateUserDAO list2 = new CreateUserDAO();
                list2.FirstName = item[1];
                list2.LastName = item[2];
            }*/
        }

        [TestCase("toan")]
        public void AdminSearchUser(string key)
        {
            CommonFlow.LoginAsAdminFlow(driver);

            HomePage homePage = new HomePage(driver);
            homePage.GoToManageUser();

            ManageUserPage manageUserPage = new ManageUserPage(driver);
            manageUserPage.SearchBarWithKey(key);
            manageUserPage.SortStaffCode();
            manageUserPage.ViewUserDetails();
        }

        [TestCase("toan")]
        public void AdminEditUser(string key)
        {
            CommonFlow.LoginAsAdminFlow(driver);
            HomePage homePage = new HomePage(driver);
            homePage.GoToManageUser();

            ManageUserPage manageUserPage = new ManageUserPage(driver);
            manageUserPage.SearchBarWithKey(key);
            manageUserPage.SortStaffCode();
            manageUserPage.EditUser("Admin");
            manageUserPage.ViewUserDetails();
        }
    }
}
