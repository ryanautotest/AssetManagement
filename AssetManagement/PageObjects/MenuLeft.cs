using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.PageObjects
{
    public class MenuLeft : HomePage
    {
        public MenuLeft(IWebDriver driver) : base(driver)
        {
        }

        private string btnManageUser = "//button[text()='Manage User']";

    }
}
