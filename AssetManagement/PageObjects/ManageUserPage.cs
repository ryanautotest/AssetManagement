using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework.DriverCore;
using NUnit.Framework;

namespace AssetManagement.PageObjects
{
    public class ManageUserPage : HomePage
    {
        public ManageUserPage(IWebDriver driver) : base(driver)
        {
        }

        protected string ddSortByRole = "//input[@type='search']";
        protected string txtSearchBar = "//input[@type='text']";
        protected string userDetails = "//td//a[contains(text(),'SD0021')]";

        //create user
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
        protected string btnSaveXpath = "//button[text()='Save']";

        //edit user
        protected string btnEdit = "//tbody//a[@href='/user/edit/toandv1']";

        //table
        protected string rowLocator = "//tbody//tr";
        protected string rowContent = "//tbody//tr//td";

        //sort
        protected string colStaffCode = "//span[text()='Staff Code']";
        protected string colFullName = "//span[text()='Full Name']";
        protected string colJoinedDate = "//span[text()='Joined Date']";
        protected string colType = "//span[text()='Type']";

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
        public void EditUser(string type)
        {
            Click(btnEdit);
            RemoveReadonlyAndSendKeys(antPickerInputDOB, RandomBirthDay().ToString());
            RemoveReadonlyAndSendKeys(antPickerInputJoinedDate, RandomJoinedDate().ToString());
            ClickAndSelect(ddType, "//div[@title='" + type + "']");
            ClickByID(btnSaveID);
        }

        public void ClickPagination(int pageNumber)
        {
            ClickByJavaScript("//li[@title='" + pageNumber + "']");
        }

        //Get Datalist from table
        public List<List<string>> GetDataFromTable()
        {
            IList<IWebElement> row = FindElementsByXpath(rowLocator);

            List<string> cellContent = FindElementsByXpath(rowContent).Select(x => x.Text).ToList();
            var splitted = cellContent.Select(
                (v, i) => new { val = v, idx = i }
                ).GroupBy(x => x.idx / 6)
                .Select(g => g.Select(y => y.val).ToList()).ToList();

            return splitted;
        }
        public void SortStaffCode()
        {
            ClickByJavaScript(colStaffCode);
        }

        public void ViewUserDetails()
        {
            Click(userDetails);
        }

        public DateTime RandomBirthDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1980, 1, 1);
            DateTime end = new DateTime(2000, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }
        public DateTime RandomJoinedDate()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2018, 1, 1);
            DateTime end = new DateTime(2022, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }

    }
}
