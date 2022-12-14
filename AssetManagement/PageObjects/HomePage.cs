using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumFramework.DriverCore;
using AssetManagement.Resources;

namespace AssetManagement.PageObjects
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        //navigator button
        protected string btnHome = "//li[@data-menu-id='rc-menu-uuid-94643-3-']";
        protected string btnManageUser = "//li[contains(@data-menu-id, 'user')]";
        protected string btnManageAsset = "//li[contains(@data-menu-id, 'asset')]";
        protected string btnManageAssignment = "//li[contains(@data-menu-id, 'assignment')]";
        protected string btnRequestForReturning = "//li[contains(@data-menu-id, 'return')]";
        protected string btnRequest = "//li[contains(@data-menu-id, 'report')]";

        //Change password and log out
        protected string btnUser = "//div//button//following-sibling::button";
        protected string optChangePassword = "//a[text()='Change password']";
        protected string optLogout = "//a[text()='Log out']";
        protected string btnLogout = "//button[text()='Log out']";

        //Change password locators
        protected string oldPass = "//input[@id='oldPass']";
        protected string newPass = "//input[@id='newPass']";
        protected string btnSave = "//button[text()='Save']";
        protected string btnClose = "//button[text()='Close']";


        public void ClickLogout()
        {
            Click(btnUser);
            Click(optLogout);
            Click(btnLogout);
        }

        public void ChangePassword()
        {
            Click(btnUser);
            Click(optChangePassword);
            SendKeys_(oldPass, Constants.OLD_PASSWORD);
            SendKeys_(newPass, Constants.NEW_PASSWORD);
            Click(btnSave);
            Click(btnClose);
        }
        public void ResetPassword()
        {
            Click(btnUser);
            Click(optChangePassword);
            SendKeys_(oldPass, Constants.NEW_PASSWORD);
            SendKeys_(newPass, Constants.OLD_PASSWORD);
            Click(btnSave);
            Click(btnClose);
        }

        public void GoToManageUser()
        {
            Click(btnManageUser);
        }

        public void GoToManageAsset()
        {
            Click(btnManageAsset);
        }

        public void GoToManageAssignment()
        {
            Click(btnManageAssignment);
        }
        public void GoToRequestForReturning()
        {
            Click(btnRequestForReturning);
        }
    }
}