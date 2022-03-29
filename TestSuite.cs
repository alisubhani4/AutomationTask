using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Threading.Tasks;
using AssimaDemo.PageObjects;
using System.IO;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace AssimaDemo
{

    public class TestSuite : config.Config
    {

        [Test, Order(1)]
        public void SignupWithWrongEmailFormat()
        {
            AmazonLoginPage login = new AmazonLoginPage(driver);
            AmazonSignupPage signup = new AmazonSignupPage(driver);

            //Asynchronus wait added
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            //explicitly wait for the name text field to appear on amazon sign up page
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.textfield_Name));

            //Assert to check whether the text field is available on the sign up page or not
            Assert.IsTrue(signup.exists_textfield_Name(), "Name text field not found on sign up page");

            //Enter the name text in the name text field on sign up page
            signup.sendkeys_textfield_Name("Muhammad Ali");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.textfield_Email));
            Assert.IsTrue(signup.textfield_Email_exists(), "Email text field not found on sign up page");
            signup.sendkeys_textfield_Email("abc");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.btn_Continue));
            Assert.IsTrue(signup.exists_btn_Continue(), "Email text field not found on sign up page");
            signup.clk_btn_Continue();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.txt_InvalidEmail));
            Assert.IsTrue(signup.exists_txt_InvalidEmail(), "Email text field not found on sign up page");

            System.Threading.Thread.Sleep(5000);
        }
        [Test, Order(2)]
        public void SignupWithEmptyEmail()
        {
            AmazonLoginPage login = new AmazonLoginPage(driver);
            AmazonSignupPage signup = new AmazonSignupPage(driver);

            //Asynchronus wait added
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            //explicitly wait for the name text field to appear on amazon sign up page
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.textfield_Name));

            //Assert to check whether the text field is available on the sign up page or not
            Assert.IsTrue(signup.exists_textfield_Name(), "Name text field not found on sign up page");

            //Enter the name text in the name text field on sign up page
            signup.sendkeys_textfield_Name("Muhammad Ali");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.textfield_Email));
            Assert.IsTrue(signup.textfield_Email_exists(), "Email text field not found on sign up page");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.btn_Continue));
            Assert.IsTrue(signup.exists_btn_Continue(), "Email text field not found on sign up page");
            signup.clk_btn_Continue();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.txt_EmptyEmailError));
            Assert.IsTrue(signup.exists_txt_EmptyEmailError(), "Email text field not found on sign up page");

            System.Threading.Thread.Sleep(5000);
        }

        [Test, Order(3)]
        public void SignupWithEmptyPassword()
        {
            AmazonLoginPage login = new AmazonLoginPage(driver);
            AmazonSignupPage signup = new AmazonSignupPage(driver);

            string dataPath = "";

            if (isWindows)
            {
                dataPath = currDir.Replace("\\bin\\Debug\\netcoreapp3.1", "\\Data\\");
            }
            else if (isMac)
            {
                dataPath = currDir.Replace("/bin/Debug/netcoreapp3.1", "/Data/");
            }

            List<string> data = loadCsvFile(dataPath + "SignupCredentials.csv");
            string dataFromCSV = data.ElementAt(1);
            string[] credentials = dataFromCSV.Split(';');

            //Asynchronus wait added
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            //explicitly wait for the name text field to appear on amazon sign up page
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.textfield_Name));

            //Assert to check whether the text field is available on the sign up page or not
            Assert.IsTrue(signup.exists_textfield_Name(), "Name text field not found on sign up page");

            //Enter the name text in the name text field on sign up page
            signup.sendkeys_textfield_Name("Muhammad Ali");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.textfield_Email));
            Assert.IsTrue(signup.textfield_Email_exists(), "Email text field not found on sign up page");
            signup.sendkeys_textfield_Email(credentials[0]);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.btn_Continue));
            Assert.IsTrue(signup.exists_btn_Continue(), "Email text field not found on sign up page");
            signup.clk_btn_Continue();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.txt_EmptyPasswordError));
            Assert.IsTrue(signup.exists_txt_EmptyPasswordError(), "Email text field not found on sign up page");

            System.Threading.Thread.Sleep(5000);
        }

        [Test, Order(4)]
        public void SignupWithEmptyReEnterPassword()
        {
            AmazonLoginPage login = new AmazonLoginPage(driver);
            AmazonSignupPage signup = new AmazonSignupPage(driver);

            string dataPath = "";

            if (isWindows)
            {
                dataPath = currDir.Replace("\\bin\\Debug\\netcoreapp3.1", "\\Data\\");
            }
            else if (isMac)
            {
                dataPath = currDir.Replace("/bin/Debug/netcoreapp3.1", "/Data/");
            }

            List<string> data = loadCsvFile(dataPath + "SignupCredentials.csv");
            string dataFromCSV = data.ElementAt(1);
            string[] credentials = dataFromCSV.Split(';');

            //Asynchronus wait added
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            //explicitly wait for the name text field to appear on amazon sign up page
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.textfield_Name));

            //Assert to check whether the text field is available on the sign up page or not
            Assert.IsTrue(signup.exists_textfield_Name(), "Name text field not found on sign up page");

            //Enter the name text in the name text field on sign up page
            signup.sendkeys_textfield_Name("Muhammad Ali");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.textfield_Email));
            Assert.IsTrue(signup.textfield_Email_exists(), "Email text field not found on sign up page");
            signup.sendkeys_textfield_Email(credentials[0]);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.txtfield_Password));
            Assert.IsTrue(signup.exists_txtfield_Password(), "Email text field not found on sign up page");
            signup.sendkeys_txtfield_Password(credentials[1]);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.btn_Continue));
            Assert.IsTrue(signup.exists_btn_Continue(), "Email text field not found on sign up page");
            signup.clk_btn_Continue();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.txt_EmptyReEnterPassword));
            Assert.IsTrue(signup.exists_txt_EmptyReEnterPassword(), "Email text field not found on sign up page");

            System.Threading.Thread.Sleep(5000);
        }

        [Test, Order(5)]
        public void SignupWithCorrectCredentials()
        {

            AmazonSignupPage signup = new AmazonSignupPage(driver);

            string dataPath = "";

            if (isWindows)
            {
                dataPath = currDir.Replace("\\bin\\Debug\\netcoreapp3.1", "\\Data\\");
            }
            else if (isMac)
            {
                dataPath = currDir.Replace("/bin/Debug/netcoreapp3.1", "/Data/");
            }

            List<string> data = loadCsvFile(dataPath + "SignupCredentials.csv");
            string dataFromCSV = data.ElementAt(1);
            string[] credentials = dataFromCSV.Split(';');

            //Asynchronus wait added
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            //explicitly wait for the name text field to appear on amazon sign up page
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.textfield_Name));

            //Assert to check whether the text field is available on the sign up page or not
            Assert.IsTrue(signup.exists_textfield_Name(), "Name text field not found on sign up page");

            //Enter the name text in the name text field on sign up page
            signup.sendkeys_textfield_Name("Muhammad Ali");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.textfield_Email));
            Assert.IsTrue(signup.textfield_Email_exists(), "Email text field not found on sign up page");
            signup.sendkeys_textfield_Email(credentials[0]);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.txtfield_Password));
            Assert.IsTrue(signup.exists_txtfield_Password(), "Email text field not found on sign up page");
            signup.sendkeys_txtfield_Password(credentials[1]);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.txtfield_ReEnterPassword));
            Assert.IsTrue(signup.exists_txtfield_ReEnterPassword(), "Email text field not found on sign up page");
            signup.sendkeys_txtfield_ReEnterPassword(credentials[1]);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.btn_Continue));
            Assert.IsTrue(signup.exists_btn_Continue(), "Email text field not found on sign up page");
            signup.clk_btn_Continue();

            //Sign up form successfully gets submitted here
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(signup.txt_SignUpFormSubmitted));
            Assert.IsTrue(signup.exists_txt_SignUpFormSubmitted(), "Email text field not found on sign up page");

            System.Threading.Thread.Sleep(5000);
        }

        [Test, Order(6)]
        public void LoginToPlatform()
        {

            string dataPath = "";

            if (isWindows)
            {
                dataPath = currDir.Replace("\\bin\\Debug\\netcoreapp3.1", "\\Data\\");
            }
            else if (isMac)
            {
                dataPath = currDir.Replace("/bin/Debug/netcoreapp3.1", "/Data/");
            }

            driver.Navigate().GoToUrl("https://www.amazon.com/ap/signin?openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.com%2Fref%3Dnav_signin&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.assoc_handle=usflex&openid.mode=checkid_setup&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&");
            List<string> data = loadCsvFile(dataPath + "credentials.csv");
            string dataFromCSV = data.ElementAt(1);
            string[] credentials = dataFromCSV.Split(';');

            AmazonLoginPage login = new AmazonLoginPage(driver);

            //Asynchronus wait added
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(login.txtField_Email));
            Assert.IsTrue(login.exists_txtField_Email(), "Email text field not found on sign up page");
            login.sendkeys_txtField_Email(credentials[0]);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(login.btn_Continue));
            Assert.IsTrue(login.exists_btn_Continue(), "Email text field not found on sign up page");
            login.clk_btn_Continue();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(login.txtField_Password));
            Assert.IsTrue(login.exists_txtField_Password(), "Email text field not found on sign up page");
            login.sendkeys_txtField_Password(credentials[1]);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(login.btn_SignIn));
            Assert.IsTrue(login.exists_btn_SignIn(), "Email text field not found on sign up page");
            login.clk_btn_SignIn();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(login.txt_LoginSuccess));
            Assert.IsTrue(login.exists_txt_LoginSuccess(), "Email text field not found on sign up page");

            System.Threading.Thread.Sleep(5000);
        }

        public List<string> loadCsvFile(string filePath)
        {
            var reader = new StreamReader(File.OpenRead(filePath));
            List<string> searchList = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);
            }
            return searchList;
        }


    }
}