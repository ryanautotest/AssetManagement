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

        public void LoginAsAdmin()
        {
            Click(btnLogin);
            SendKeysByID(txtUserName, Constants.ADMIN_USERNAME);
            SendKeysByID(txtPassword, Constants.ADMIN_PASSWORD);
            ClickByID(btnSubmitLogin);
        }

        public void LoginAsUser(string userName, string password)
        {
            Click(btnLogin);
            SendKeysByID(txtUserName, userName);
            SendKeysByID(txtPassword, password);
            Click(btnLogin);
        }



    }
}
