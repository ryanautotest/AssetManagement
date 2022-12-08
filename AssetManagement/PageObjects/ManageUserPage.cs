using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework.DriverCore;

namespace AssetManagement.PageObjects
{
    public class ManageUserPage : HomePage
    {
        public ManageUserPage(IWebDriver driver) : base(driver)
        {
        }

        protected string ddSortByRole = "//input[@type='search']";
        protected string txtSearchBar = "//input[@type='text']";

        protected string btnCreateNewUser = "//button//span[text()='Create new User']";

        protected string txtFirstName = "firstName";
        protected string txtLastName = "lastName";
        protected string antPickerInputDOB = "dob";
        protected string radioFemale = "//input[@value='FEMALE']";
        protected string radioMale = "//input[@value='MALE']";
        protected string antPickerInputJoinedDate = "joinedDate";
        protected string ddType = "//div[@class='ant-select-selector']";
        protected string ddTypeValue = "//div[@title='Staff']";
        protected string btnSaveID = "btn";

        //table
        protected string rowLocator = "//tbody//tr";
        protected string rowContent = "//tbody//tr//td";



        public void SortByRole(string role)
        {
            SelectOption(ddSortByRole, role);
        }

        public void SearchBarWithKey(string key)
        {
            SendKeys_(txtSearchBar, key);
            SendKeys_(txtSearchBar, Keys.Enter);
        }

        public void CreateNewUser(string firstName, string lastName, string dob, string gender, string joinedDate, string type)
        {
            Click(btnCreateNewUser);
            SendKeysByID(txtFirstName, firstName);
            SendKeysByID(txtLastName, lastName);
            RemoveReadonlyAndSendKeys(antPickerInputDOB, dob);
            Click(FindElementByXpath("//input[@value='" + gender.ToUpper() + "']"));
            RemoveReadonlyAndSendKeys(antPickerInputJoinedDate, joinedDate);
            ClickAndSelect(ddType, "//div[@title='"+type+"']");
            ClickByID(btnSaveID);
        }

        public void ClickPagination(int pageNumber)
        {
            ClickByJavaScript("//a[text()='" + pageNumber + "']");
        }

        //Get Datalist from table
        public List<List<string>> GetDataFromTable()
        {
            IList<IWebElement> row = FindElementsByXpath(rowLocator);

            List<string> cellContent = FindElementsByXpath(rowContent).Select(x => x.Text).ToList();
            var splitted = cellContent.Select(
                (v, i) => new { val = v, idx = i }
                ).GroupBy(x => x.idx / 5)
                .Select(g => g.Select(y => y.val).ToList()).ToList();

            return splitted;
        }
    }
}
