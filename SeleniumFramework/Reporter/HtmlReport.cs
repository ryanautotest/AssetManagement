using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using SeleniumFramework.APICore;
using SeleniumFramework.Reporter.ExtentMarkup;

namespace SeleniumFramework.Reporter
{
    internal class HtmlReport
    {
        private static int testCaseIndex;
        private static ExtentReports _report;
        private static ExtentTest extentTestSuite;
        private static ExtentTest extentTestCase;

        public static ExtentReports createReport()
        {
            if (_report == null)
            {
                _report = createInstance();
            }
            return _report;
        }

        private static ExtentReports createInstance()
        {
            HtmlReportDirectory.InitReportDirection();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(HtmlReportDirectory.REPORT_FILE_PATH);
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";

            ExtentReports report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            return report;
        }

        public static void flush()
        {
            if(_report != null)
            {
                _report.Flush();
            }
        }

        public static ExtentTest createTest(string className, string classDescription = "")
        {
            if(_report == null)
            {
                _report = createInstance();
            }
            extentTestSuite = _report.CreateTest(className, classDescription).AssignAuthor("RyanAutoTest").AssignDevice("Chrome 107.0.5304.106");
            return extentTestSuite;
        }

        public static ExtentTest createNode(string className, string testcase, string description = "")
        {
            if(extentTestSuite == null)
            {
                extentTestSuite = createTest(className);
            }
            extentTestCase = extentTestSuite.CreateNode(testcase, description);
            //.AssignCategory("Regession")
            return extentTestCase;
        }

        public static ExtentTest GetParent()
        {
            return extentTestSuite;
        }

        public static ExtentTest GetNode()
        {
            return extentTestCase;
        }

        public static ExtentTest GetTest()
        {
            if(GetNode() == null)
            {
                return GetParent();
            }
            return GetNode();
        }

        public static void Pass(string des)
        {
            GetTest().Pass(MarkupHelper.CreateLabel(des, ExtentColor.Green));
            
        }

        internal static void Pass(string v, object m)
        {
            throw new System.NotImplementedException();
        }

        public static void Fail(string des, string path)
        {
            GetTest().Fail(MarkupHelper.CreateLabel(des, ExtentColor.Green)).AddScreenCaptureFromPath(path);
        }

        public static void Fail(string des, string ex, string path)
        {
            GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }
        /*public static void Info(HttpWebRequest request, HttpWebResponse response)
        {
            GetTest().Info(MarkupHelperPlus.CreateAPIRequestLog(request, response));
        }

        /*
        public static void MarkUpHtml()
        {
            var htmlMarkup = {};
            var m = MarkupHelper.CreateLabel(htmlMarkup, ExtentColor.Red);
            GetTest().Info(m);
        }
        */

        public static void MarkUpJson()
        {
            var json = "{'name':'Ryan', 'age':29, 'car':null}";
            GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
        }

        public static void MarkUpTable()
        {
            string[][] table = new string[][] { new string[]
            { "TestID", "TestName", "Description" },
            new string[]
            { "01", "Login Test", "Login with exist user name and password" },
            new string[]
            { "02", "Register Test", "Creat new account" },
            new string[]
            { "03", "Logout Test", "Logout" }
            };
            GetTest().Info(MarkupHelper.CreateTable(table));
        }

        public static void CreateAPIRequestLog(APIRequest request, APIResponse response)
        {
            GetTest().Info(MarkupHelperPlus.CreateAPIRequestLog(request, response));
        }

    }
}
