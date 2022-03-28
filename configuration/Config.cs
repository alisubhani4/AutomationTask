using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using AssimaDemo.PageObjects;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Runtime.InteropServices;
using NUnit.Framework.Interfaces;
using System.Text;
using System.Threading;

namespace AssimaDemo.config
{
    public class Config
    {
        protected IWebDriver driver;
        protected string currDir = System.IO.Directory.GetCurrentDirectory();
        public static ExtentV3HtmlReporter htmlReporter;
        public static AventStack.ExtentReports.ExtentReports extent;
        public static ExtentTest test;

        public static bool isWindows = System.Runtime.InteropServices.RuntimeInformation
                                               .IsOSPlatform(OSPlatform.Windows);

        public static bool isMac = System.Runtime.InteropServices.RuntimeInformation
                                               .IsOSPlatform(OSPlatform.OSX);

        public string reportPath = "";


        [SetUp]
        public void SetUp()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");

            driver = new ChromeDriver(chromeOptions);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = "https://www.amazon.com/ap/register?openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.com%2F%3F_encoding%3DUTF8%26ref_%3Dnav_custrec_newcust&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.assoc_handle=usflex&openid.mode=checkid_setup&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&";

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {

            string reportTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            if (isWindows)
            {
                reportPath = currDir.Replace("\\bin\\Debug\\netcoreapp3.1", "\\GeneratedReports\\");
            }
            else if (isMac)
            {
                reportPath = currDir.Replace("/bin/Debug/netcoreapp3.1", "/GeneratedReports/");
            }

            extent = new AventStack.ExtentReports.ExtentReports();
            htmlReporter = new ExtentV3HtmlReporter(reportPath + "AutomatedTestReport-" + ".html");
            extent.AttachReporter(htmlReporter);

        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            try
            {
                extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
            driver.Quit();
        }

        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        string screenShotPath = Capture(driver, TestContext.CurrentContext.Test.Name);
                        test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        test.Log(logstatus, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }


        private string Capture(IWebDriver driver, string screenShotName)
        {
            string localpath = "";
            try
            {
                Thread.Sleep(4000);
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("/bin/Debug/netcoreapp3.1", "/GeneratedReports");
                DirectoryInfo di = Directory.CreateDirectory(dir);
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "GeneratedReports/" + screenShotName + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }

    }
}