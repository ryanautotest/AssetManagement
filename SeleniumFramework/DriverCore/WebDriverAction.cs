using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumFramework.Reporter;
using System;
using System.Collections.Generic;

namespace SeleniumFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;
        public WebDriverWait wait_;

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public By ByID(string locator)
        {
            return By.Id(locator);
        }

        public string getTitle()
        {
            return driver.Title;
        }

        public IWebElement FindElementByID(string locator)
        {
            IWebElement e = driver.FindElement(ByID(locator));
            highlightElement(e);
            return e;
        }

        public IWebElement FindElementByXpath(string locator)
        {
            IWebElement e = driver.FindElement(ByXpath(locator));
            highlightElement(e);
            return e;
        }

        public IList<IWebElement> FindElementsByXpath(string locator)
        {
            return driver.FindElements(ByXpath(locator));
        }
        public void GoToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
            HtmlReport.Pass("Go to URL: " + url);
        }

        //click by ID

        public void ClickByID(string locator)
        {
            try
            {
                FindElementByID(locator).Click();
                TestContext.WriteLine("Click into element " + locator + " successfuly");
                HtmlReport.Pass("Click into element " + locator + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into element " + locator + " failed");
                HtmlReport.Fail("Click into element " + locator + " failed", TakeScreenShot());
                throw ex;
            }
        }

        public void Click(IWebElement e)
        {
            try
            {
                highlightElement(e);
                e.Click();
                TestContext.WriteLine("Click into element " + e.ToString + " successfuly");

            }
            catch (Exception ex)
            {

                TestContext.WriteLine("Click into element " + e.ToString + " failed");
                HtmlReport.Fail("Click into element " + e.ToString + " failed", TakeScreenShot());
                throw ex;
            }
        }

        public IWebElement WaitForElementToBeClickable(IWebDriver driver, string locator, float timeOut = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
        }

        public IWebElement WaitForElementVisible(IWebDriver driver, string locator, float timeOut = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locator)));
        }

        public void Click(string locator)
        {
            try
            {
                WaitForElementToBeClickable(driver, locator);
                FindElementByXpath(locator).Click();
                TestContext.WriteLine("Click into element " + locator + " successfuly");
                HtmlReport.Pass("Click into element " + locator + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into element " + locator + " failed");
                HtmlReport.Fail("Click into element " + locator + " failed", TakeScreenShot());
                throw ex;
            }
        }

        //click by dynamic xpath
        public void ClickToElementWithKey(string locator, string key)
        {
            try
            {
                FindElementByXpath(locator).Click();
                TestContext.WriteLine("Click into element " + locator + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into element " + locator + " failed");
                HtmlReport.Fail("Click into element " + locator + " failed", TakeScreenShot());
                throw ex;
            }
        }

        //Move to Element and Click Action
        public void MoveToElementAndClick(string locator)
        {
            try
            {
                IWebElement webElement = FindElementByXpath(locator);
                Actions action = new Actions(driver);
                action.MoveToElement(webElement).Perform();
                action.Click();
                TestContext.WriteLine("Move to element " + locator + " and click successfuly");
                HtmlReport.Pass("Move to element " + locator + " and click successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Move to element " + locator + " and click failed");
                HtmlReport.Fail("Move to element " + locator + " and click failed", TakeScreenShot());
                throw ex;
            }
        }

        public void ClickByJavaScript(string locator)
        {
            try
            {
                IWebElement webElement = FindElementByXpath(locator);
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                jse.ExecuteScript("arguments[0].click();", webElement);
                jse.ExecuteScript("return arguments[0].style", webElement); 
                TestContext.WriteLine("Click into element " + locator + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into element " + locator + " failed");
                HtmlReport.Fail("Click into element " + locator + " failed", TakeScreenShot());
                throw ex;
            }
        }

        public void SendKeys_(string locator, string key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                TestContext.WriteLine("Sendkey into element " + locator + " successfuly");
                HtmlReport.Pass("Sendkey into element " + locator + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Sendkey into element " + locator + " failed");
                HtmlReport.Fail("Sendkey into element " + locator + " failed", TakeScreenShot());
                throw ex;
            }
        }

        // Clear and Sendkeys for editting

        public void ClearAndSendKeyByID(string locator, string key)
        {
            try
            {
                FindElementByID(locator).Clear();
                FindElementByID(locator).SendKeys(key);
                TestContext.WriteLine("Sendkey into element " + locator + " successfuly");
                HtmlReport.Pass("Sendkey into element " + locator + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Sendkey into element " + locator + " failed");
                HtmlReport.Fail("Sendkey into element " + locator + " failed", TakeScreenShot());
                throw ex;
            }
        }

        //sendkey by ID

        public void SendKeysByID(string locator, string key)
        {
            try
            {
                FindElementByID(locator).SendKeys(key);
                TestContext.WriteLine("Sendkey into element " + locator + " successfuly");
                HtmlReport.Pass("Sendkey into element " + locator + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Sendkey into element " + locator + " failed");
                HtmlReport.Fail("Sendkey into element " + locator + " failed", TakeScreenShot());
                throw ex;
            }
        }

        //Fill date into Ant date picker with java script
        public void RemoveReadonlyAndSendKeys(string locator, string key)
        {
            ClickByID(locator);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("document.getElementById('" + locator + "').removeAttribute('readonly',0);");
            jse.ExecuteScript("document.getElementById('" + locator + "').value='';");
            ClearAndSendKeyByID(locator, key);
            SendKeysByID(locator, Keys.Enter);
        }


        // action select option normal
        public void SelectOption(string locator, string key)
        {
            try
            {
                IWebElement mySelectOption = FindElementByXpath(locator);
                SelectElement dropdown = new SelectElement(mySelectOption);
                dropdown.SelectByText(key);
                TestContext.WriteLine("Select element " + locator + " successfuly with " + key);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Select element " + locator + " failed with " + key);
                throw ex;
            }
        }

        //Click to ant select dropdown then click to select
        public void ClickAndSelect(string locator, string optionLocator)
        {
            Click(locator);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            IWebElement selectedOption = FindElementByXpath(optionLocator);
            jse.ExecuteScript("arguments[0].scrollIntoViewIfNeeded(true);", selectedOption);
            WaitForElementVisible(driver, optionLocator);
            Click(optionLocator);
            TestContext.WriteLine("Select element " + locator + " successfuly with " + optionLocator);
            HtmlReport.Pass("Select element " + locator + " successfuly with " + optionLocator);
        }

        public void SelectDropdown(string dropdown, string value)
        {
            Click(dropdown);
            Actions action = new Actions(driver);
            action.ScrollToElement(FindElementByXpath(value)).Perform();
            WaitForElementVisible(driver, value);
            Click(value);
        }

        /*public void ScrollToElement(string locatorList, string locatorValue)
        {

            IWebElement selectElement = FindElementByXpath(locatorValue);
            Actions action = new Actions(driver);
            action.MoveToElement(elementList[0]);
            action.ScrollToElement(selectElement).SendKeys(Keys.Enter);

            action.ScrollToElement(selectElement).Build().Perform();
            action.Click(selectElement);
        }*/

        //Enable Disable

        public IWebElement IsElementEnable(string locator)
        {
            IWebElement e = FindElementByXpath(locator);
            if (e.Enabled)
            {
                TestContext.WriteLine("Element " + locator + " is Enable");
            }
            else
            {
                TestContext.WriteLine("Element " + locator + " is Disable");
            }
            return e;
        }
        public bool IsElementDisable(string locator)
        {
            IWebElement e = FindElementByXpath(locator);
            if (e.Enabled)
            {
                return false;
                TestContext.WriteLine("Element "+ locator +" is Enable");
            }
            else
            {
                TestContext.WriteLine("Element " + locator + " is Disable");
                return true;
            }
        }

        // action double click
        public void DoubleClick(string locator)
        {
            try
            {
                IWebElement doubleClick = FindElementByXpath(locator);
                WebDriverAction action = new WebDriverAction(driver);
                action.DoubleClick(locator);
                TestContext.WriteLine("Double click on element " + locator + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Double click on element " + locator + " failed with");
                throw ex;
            }
        }

        //action get text
        public string GetText(string locator)
        {
            try
            {
                TestContext.WriteLine("Get Text of element " + locator + " successfully");
                HtmlReport.Pass("Get Text of element " + locator + " successfully");
                return FindElementByXpath(locator).Text;
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Get Text of element " + locator + " failed");
                throw ex;
            }
        }


        public Boolean IsElementDisplay(string locator)
        {
            try
            {
                Boolean tf = FindElementByXpath(locator).Displayed;
                return tf;
                TestContext.WriteLine("Element " + locator + " is Displayed");
                HtmlReport.Pass("Element " + locator + " is Displayed");
            }
            catch (Exception e)
            {
                TestContext.WriteLine("Element " + locator + " is no longer Displayed");
                HtmlReport.Fail("Element " + locator + " is no longer Displayed", TakeScreenShot());
                return false;
            }

        }

        // action get screenshot

        public string TakeScreenShot()
        {
            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }

        public IWebElement highlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border='2px solid red'", element);
            return element;
        }
    }
}


