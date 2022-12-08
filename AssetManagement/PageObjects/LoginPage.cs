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

        protected string btnLogin = "//button[text()='Login']";
        protected string txtUserName = "username";
        protected string txtPassword = "password";
        protected string btnSubmitLogin = "loginButton";

        //change password 1st time
        protected string txtNewPass = "//input[@id='newPass']";
        protected string btnOK = "//span[text()='OK']";


        public Boolean LoginButtonIsDisplayed()
        {
            var tf = IsElementDisplay(btnLogin);
            return tf;
        }
        public void LoginAsAdmin()
        {
            SendKeysByID(txtUserName, Constants.ADMIN_USERNAME);
            SendKeysByID(txtPassword, Constants.ADMIN_PASSWORD);
            ClickByID(btnSubmitLogin);
        }

        public void LoginAsUser(string userName, string password)
        {
            SendKeysByID(txtUserName, userName);
            SendKeysByID(txtPassword, password);
            Click(btnLogin);
        }

        public void ChangePassword1stTime(string password)
        {
            SendKeys_(txtNewPass, password);
            Click(btnOK);
        }

    }
}