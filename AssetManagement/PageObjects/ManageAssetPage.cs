using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework.DriverCore;

namespace AssetManagement.PageObjects
{
    public class ManageAssetPage : HomePage
    {
        public ManageAssetPage(IWebDriver driver) : base(driver)
        {
        }

        protected string txtSearchBar = "//input[@type='text']";
        protected string assetDetails = "//td//a[contains(text(),'LA000006')]";

        //create new asset
        protected string btnCreateAsset = "//button//span[text()='Create new Asset']";
        protected string txtNameId = "//input[@id='name']";
        protected string ddCategory = "//div[@class='ant-select-selector']";
        protected string ddCategoryLaptop = "//div[@title='Laptop']";
        protected string txtSpecificationId = "//textarea";
        protected string antPickerInstalledDate = "//input[@id='installedDate']";
        protected string btnSave = "//button//span[text()='Save']";


        protected string categoryList = "//div[@class='rc-virtual-list-holder-inner']";
        //table
        protected string rowLocator = "//tbody//tr";
        protected string rowContents = "//tbody//tr//td";

        //sort
        protected string ddState = "//span[@class='ant-select-selection-search']//following-sibling::span[text()='State']";
        protected string ddStateAvailable = "//div[@title='Available']";

        protected string ddwnCategory = "//span[@class='ant-select-selection-search']//following-sibling::span[text()='Category']";
        protected string colAssetCode = "//span[text()='Asset Code']";

        public void CreateNewAsset()
        {
            Click(btnCreateAsset);
            SendKeys_(txtNameId, "New Asset");
            SelectNewAssetCategory();
            SendKeys_(txtSpecificationId, "Test");
            RemoveReadonlyAndSendKeys(antPickerInstalledDate, RandomInstalledDate().ToString());
            Click(btnSave);
        }

        public void ClickPagination(int pageNumber)
        {
            var paginationButton = "//li[@title='" + pageNumber + "']";
            ClickByJavaScript(paginationButton);
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

        public void SortAssetCode()
        {
            ClickByJavaScript(colAssetCode);
        }

        public void SearchBarWithKey(string key)
        {
            SendKeys_(txtSearchBar, key);
            SendKeys_(txtSearchBar, Keys.Enter);
        }
        public void ViewAssetDetails()
        {
            WaitForElementVisible(driver, assetDetails);
            Click(assetDetails);
        }

        public void SelectNewAssetCategory()
        {
            Click(btnCreateAsset);
            ClickAndSelect(ddCategory, ddCategoryLaptop);
        }

        public DateTime RandomInstalledDate()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2018, 1, 1);
            DateTime end = new DateTime(2022, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
