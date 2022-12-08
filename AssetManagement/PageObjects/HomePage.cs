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

        protected string btnManageUser = "//li[contains(@data-menu-id, 'user')]";
        protected string btnManageAsset = "//li[contains(@data-menu-id, 'asset')]";
        protected string btnRequestForReturning = "//div[text()='Request for returning']";
        protected string btnUser = "//div//button//following-sibling::button";
        protected string optChangePassword = "//a[text()='Change password']";
        protected string optLogout = "//a[text()='Log out']";
        protected string btnLogout = "//button[text()='Log out']";

        //Change password locators
        protected string oldPass = "oldPass";
        protected string newPass = "newPass";
        protected string btnSave = "//button[text()='Save']";
        protected string btnClose = "//button[text()='Close']";

        //Manage Asset locators

        public Boolean ManagerUserIsDisplayed()
        {
            var checkManageUser = IsElementDisplay(btnManageUser);
            return checkManageUser;
        }

        public Boolean RequestForReturningIsDisplayed()
        {
            var checkRequestReturning = IsElementDisplay(btnRequestForReturning);
            return checkRequestReturning;
        }

        public void ClickLogout()
        {
            Click(btnUser);
            Click(optLogout);
            Click(btnLogout);
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            Click(btnUser);
            Click(optChangePassword);
            SendKeysByID(oldPass, oldPassword);
            SendKeysByID(newPass, newPassword);
            Click(btnSave);
            Click(btnClose);
        }

        public void ClickManageUser()
        {
            Click(btnManageUser);
        }

        public void ClickManageAsset()
        {
            Click(btnManageAsset);
        }
    }
}