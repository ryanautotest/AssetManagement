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

        protected string btnLogin = "//button[text()='Login']";
        protected string btnManageUser = "//button[text()='Manage User']";
        protected string btnRequestForReturning = "//button[text()='Request for returning']";
        protected string btnUser = "//div//button//following-sibling::button";
        protected string optChangePassword = "//a[text()='Change password']";
        protected string optLogout = "//a[text()='Logout']";
        protected string btnLogout = "//button[text()='Logout']";

        //Change password locator
        protected string oldPass = "oldPass";
        protected string newPass = "newPass";
        protected string btnSave = "//button[text()='Save']";


        public void ClickLogin()
        {
            Click(btnLogin);
        }

        public Boolean ManagerUserIsDisplayed()
        {
            var tf = IsElementDisplay(btnManageUser);
            return tf;
        }

        public Boolean RequestForReturningIsDisplayed()
        {
            var tf = IsElementDisplay(btnRequestForReturning);
            return tf;
        }

        public void ClickLogout()
        {
            Click(btnUser);
            Click(optLogout);
            Click(btnLogout);
        }

        public Boolean LoginButtonIsDisplayed()
        {
            var tf = IsElementDisplay(btnLogin);
            return tf;
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            Click(btnUser);
            Click(optChangePassword);
            SendKeysByID(oldPass, oldPassword);
            SendKeysByID(newPass, newPassword);
            Click(btnSave);
        }


    }
}