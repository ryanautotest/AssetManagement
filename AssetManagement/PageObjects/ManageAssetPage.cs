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

    }
}
