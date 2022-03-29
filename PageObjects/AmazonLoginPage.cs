using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssimaDemo.PageObjects
{
    class AmazonLoginPage
    {
        private IWebDriver _driver;

        public AmazonLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public By txtField_Email = By.XPath("//*[contains(text(),'Email or mobile phone number')]/following-sibling::input[1]");
        public By btn_Continue = By.XPath("//*[@id='continue']");
        public By txtField_Password = By.XPath("//*[@name='password']");
        public By btn_SignIn = By.XPath("//*[@id='signInSubmit']");
        public By txt_LoginSuccess = By.XPath("//*[contains(text(),'Hello, Muhammad')]");
        public bool exists_txtField_Email()
        {
            return _driver.FindElement(txtField_Email).Displayed;
        }
        public bool exists_btn_SignIn()
        {
            return _driver.FindElement(btn_SignIn).Displayed;
        }
        public bool exists_txt_LoginSuccess()
        {
            return _driver.FindElement(txt_LoginSuccess).Displayed;
        }
        public bool exists_txtField_Password()
        {
            return _driver.FindElement(txtField_Password).Displayed;
        }
        public bool exists_btn_Continue()
        {
            return _driver.FindElement(btn_Continue).Displayed;
        }
        public void sendkeys_txtField_Email(string text)
        {
            _driver.FindElement(txtField_Email).SendKeys(text);
        }
        public void sendkeys_txtField_Password(string text)
        {
            _driver.FindElement(txtField_Password).SendKeys(text);
        }
        public void clk_btn_Continue()
        {
            _driver.FindElement(btn_Continue).Click();
        }
        public void clk_btn_SignIn()
        {
            _driver.FindElement(btn_SignIn).Click();
        }

    }

}