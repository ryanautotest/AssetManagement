using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework.DriverCore;

namespace AssetManagement.PageObjects
{
    public class RequestForReturningPage : HomePage
    {
        public RequestForReturningPage(IWebDriver driver) : base(driver)
        {
        }

        protected string txtSearchBar = "//input[@type='text']";

        //table
        protected string rowLocator = "//tbody//tr";
        protected string rowContents = "//tbody//tr//td";

        //sort
        protected string ddState = "//span[@class='ant-select-selection-search']//following-sibling::span[text()='State']";
        protected string ddStateAvailable = "//div[@title='Available']";

        protected string ddwnCategory = "//span[@class='ant-select-selection-search']//following-sibling::span[text()='Category']";
        protected string ddCategoryLap = "//div[@title='Laptop']";
        protected string colAssetCode = "//span[text()='Asset Code']";

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


        public void SearchBarWithKey(string key)
        {
            SendKeys_(txtSearchBar, key);
            SendKeys_(txtSearchBar, Keys.Enter);
        }

        public void CompleteReturningRequest(string assetCode)
        {
            var completeButton = "//tbody//tr//td//span[text()='" + assetCode + "']/../../td//span[@aria-label='check']";
            Click(completeButton);
        }

        public void CancelReturningRequest(string assetCode)
        {
            var cancelButton = "//tbody//tr//td//span[text()='" + assetCode + "']/../../td//span[@aria-label='close']";
            Click(cancelButton);
        }

        public Boolean VerifyStateCompleted(string assetCode)
        {
            var stateAccepted = "//tbody//tr//td//span[text()='" + assetCode + "']/../../td//span[text()='Completed']";
            return IsElementDisplay(stateAccepted);
        }
        public Boolean VerifyStateWaitingForReturning(string assetCode)
        {
            var stateReturning = "//tbody//tr//td//span[text()='" + assetCode + "']/../../td//span[text()='Waiting for returning']";
            return IsElementDisplay(stateReturning);
        }
    }
}
