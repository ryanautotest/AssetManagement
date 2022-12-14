using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework.DriverCore;

namespace AssetManagement.PageObjects
{
    public class ManageAssignmentPage : HomePage
    {
        public ManageAssignmentPage(IWebDriver driver) : base(driver)
        {
        }

        protected string txtSearchBar = "//input[@type='text']";

        //create new assignment
        protected string btnCreateAssignment = "//button//span[text()='Create new Assignment']";
        protected string btnSelectUser = "(//span//input[@id='assignedTo']//following::span/button)[1]";
        protected string btnSelectAsset = "(//span//input[@id='assignedTo']//following::span/button)[2]";

        //select user 

        protected string txtSearchUser = "(//input[@placeholder='Input search text'])[1]";
        protected string btnSearchUserOk = "//span[text()='Ok']";
        protected string btnSearchUserCancel = "//span[text()='Cancel']";
        //select asset 
        protected string txtSearchAsset = "(//input[@placeholder='Input search text'])[2]";
        
        protected string btnSearchAssetOk = "(//span[text()='Ok'])[2]";

        protected string antPickerAssignedDate = "//input[@id='date']";
        protected string txtaNote = "//textarea[@id='note']";
        protected string btnSave = "//button[@type='submit']";
        protected string btnCancel = "";

        //table
        protected string rowLocator = "//tbody//tr";
        protected string rowContents = "//tbody//tr//td";

        //sort
        protected string ddwnState = "//div//input[@type='search']";

        protected string ddCategoryLap = "//div[@title='Laptop']";
        protected string colAssetCode = "//span[text()='Asset Code']";

        public void CreateNewAssignment(string staffCode, string assetCode)
        {
            Click(btnCreateAssignment);
            SelectUserByStaffCode(staffCode);
            SelectAssetByAssetCode(assetCode);
            Click(antPickerAssignedDate);
            SendKeys_(antPickerAssignedDate, Keys.Enter);
            SendKeys_(txtaNote, "test");
            Click(btnSave);
        }

        public void ClickPagination(int pageNumber)
        {
            ClickByJavaScript("//li[@title='" + pageNumber + "']");
        }

        //Get Datalist from table
        public List<List<string>> GetDataFromTable()
        {
            IList<IWebElement> row = FindElementsByXpath(rowLocator);

            List<string> cellContent = FindElementsByXpath(rowContents).Select(x => x.Text).ToList();
            var splitted = cellContent.Select(
                (v, i) => new { val = v, idx = i }
                ).GroupBy(x => x.idx / 5)
                .Select(g => g.Select(y => y.val).ToList()).ToList();

            return splitted;
        }

        public void SearchBarWithAssetCode(string assetCode)
        {
            SendKeys_(txtSearchBar, assetCode);
            SendKeys_(txtSearchBar, Keys.Enter);
        }

        public void ViewState(string state)
        {
            Click(ddwnState);
            var selectState = "//div[@class='ant-select-selector']//div[text()='" +state+ "']";
        }

        public void ViewAssignmentDetails(string key)
        {
            var assetDetails = "//td//a[contains(text(),'"+key+"')]";
            WaitForElementVisible(driver, assetDetails);
            Click(assetDetails);
        }

        public void SelectUserByStaffCode(string staffCode) 
        {
            Click(btnSelectUser);
            SendKeys_(txtSearchUser, staffCode);
            SendKeys_(txtSearchUser, Keys.Enter);
            var radioButton = FindElementByXpath("//tr[@data-row-key='" + staffCode + "']//input[@type='radio']");
            radioButton.Click();
            Click(btnSearchUserOk);
        }

        public void SelectAssetByAssetCode(string assetCode)
        {
            Click(btnSelectAsset);
            SendKeys_(txtSearchAsset, assetCode);
            SendKeys_(txtSearchAsset, Keys.Enter);
            var radioButton = FindElementByXpath("//tr[@data-row-key='" + assetCode + "']//input[@type='radio']");
            radioButton.Click();
            Click(btnSearchAssetOk);
        }

        public Boolean VerifyStateWaitingForAcceptance(string assetCode)
        {
            var assignmentWaiting = "//tbody//tr//td//span[text()='"+ assetCode + "']/../../td//span[text()='Waiting for acceptance']";
            return IsElementDisplay(assignmentWaiting);
        }

        public Boolean VerifyStateAccepted(string assetCode)
        {
            var stateAccepted = "//tbody//tr//td//span[text()='" + assetCode + "']/../../td//span[text()='Accepted']";
            return IsElementDisplay(stateAccepted);
        }
        public Boolean VerifyStateReturning(string assetCode)
        {
            var stateReturning = "//tbody//tr//td//span[text()='" + assetCode + "']/../../td//span[text()='Returning']";
            return IsElementDisplay(stateReturning);
        }


        public void AcceptAssignment(string assetCode)
        {
            var acceptButton = "//tbody//tr//td//span[text()='" + assetCode + "']/../../td//span[@aria-label='check']";
            Click(acceptButton);
        }

        public void DeclineAssignment(string assetCode)
        {
            var declineButton = "//tbody//tr//td//span[text()='" + assetCode + "']/../../td//span[@aria-label='close']";
            Click(declineButton);
        }
        public void ReturnAssignment(string assetCode)
        {
            var undoButton = "//tbody//tr//td//span[text()='" + assetCode + "']/../../td//span[@aria-label='undo']";
            IsElementEnable(undoButton);
            Click(undoButton);
        }
    }
}
