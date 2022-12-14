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
    public class LoginPage : WebDriverAction
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        protected string txtUserName = "//input[@id='username']";
        protected string txtPassword = "//input[@id='password']";
        protected string btnSubmitLogin = "//button[@id='loginButton']";

        //change password 1st time
        protected string txtChangePassword = "//div[text()='Change password']";
        protected string txtNewPass = "//input[@id='newPassword']";
        protected string btnSave = "//button[@id='btnSubmitChangePassword']";

        public void LoginAsAdmin()
        {
            IsElementDisable(btnSubmitLogin);
            SendKeys_(txtUserName, Constants.ADMIN_USERNAME);
            SendKeys_(txtPassword, Constants.ADMIN_PASSWORD);
            IsElementEnable(btnSubmitLogin);
            Click(btnSubmitLogin);
        }

        public void LoginAsUser()
        {
            IsElementDisable(btnSubmitLogin);
            SendKeys_(txtUserName, Constants.STAFF_USERNAME);
            SendKeys_(txtPassword, Constants.STAFF_PASSWORD);
            IsElementEnable(btnSubmitLogin);
            Click(btnSubmitLogin);
        }
        public void LoginAsUserAfterChangePassword()
        {
            IsElementDisable(btnSubmitLogin);
            SendKeys_(txtUserName, Constants.STAFF_USERNAME);
            SendKeys_(txtPassword, Constants.NEW_PASSWORD);
            IsElementEnable(btnSubmitLogin);
            Click(btnSubmitLogin);
        }
        public void LoginAsUserFirstTime()
        {
            IsElementDisable(btnSubmitLogin);
            SendKeys_(txtUserName, Constants.NEW_USERNAME);
            SendKeys_(txtPassword, Constants.FIRST_PASSWORD);
            IsElementEnable(btnSubmitLogin);
            Click(btnSubmitLogin);
        }

        public void ChangePassword1stTime()
        {
            WaitForElementVisible(driver, txtChangePassword);
            IsElementDisable(btnSave);
            SendKeys_(txtNewPass, Constants.NEW_PASSWORD);
            IsElementEnable(btnSave);
            Click(btnSave);
        }
        public void LoginAsNewUserAfterChangePassword()
        {
            IsElementDisable(btnSubmitLogin);
            SendKeys_(txtUserName, Constants.NEW_USERNAME);
            SendKeys_(txtPassword, Constants.NEW_PASSWORD);
            IsElementEnable(btnSubmitLogin);
            Click(btnSubmitLogin);
        }

    }
}