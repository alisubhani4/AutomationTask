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
        public void SignupToPlatform()
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

            List<string> data = loadCsvFile(dataPath + "credentials.csv");
            string dataFromCSV = data.ElementAt(1);
            string[] credentials = dataFromCSV.Split(';');
            System.Threading.Thread.Sleep(10000);
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

            System.Threading.Thread.Sleep(5000);
        }

        [Test, Order(2)]
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

            List<string> data = loadCsvFile(dataPath + "credentials.csv");
            string dataFromCSV = data.ElementAt(1);
            string[] credentials = dataFromCSV.Split(';');
            System.Threading.Thread.Sleep(10000);
            AmazonLoginPage login = new AmazonLoginPage(driver);
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