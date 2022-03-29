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
    class AmazonSignupPage
    {
        private IWebDriver _driver;

        public AmazonSignupPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public By textfield_Name = By.XPath("//*[contains(text(),'Your name')]/following-sibling::input");
        public By textfield_Email = By.XPath("//*[@name='email']");
        public By btn_VerifyEmail = By.XPath("//*[text()='Verify email']");
        public By btn_Continue = By.XPath("//*[@id='continue']");
        public By txt_InvalidEmail = By.XPath("//*[contains(text(),'Invalid email')]");
        public By txt_EmptyEmailError = By.XPath("//*[contains(text(),'Enter your email')]");
        public By txt_EmptyPasswordError = By.XPath("//*[contains(text(),'Minimum 6 characters required')]");
        public By txtfield_Password = By.XPath("//*[contains(text(),'Password')]/following-sibling::input");
        public By txt_EmptyReEnterPassword = By.XPath("//*[contains(text(),'Type your password again')]");
        public By txtfield_ReEnterPassword = By.XPath("//*[contains(text(),'Re-enter password')]/following-sibling::input");
        public By txt_SignUpFormSubmitted = By.XPath("//*[contains(text(),'Solve this puzzle')]");

        public IWebElement findElement(OpenQA.Selenium.By element)
        {
            return _driver.FindElement(element);
        }

        public bool textfield_Email_exists()
        {
            return _driver.FindElement(textfield_Email).Displayed;
        }
        public bool exists_txt_SignUpFormSubmitted()
        {
            return _driver.FindElement(txt_SignUpFormSubmitted).Displayed;
        }
        public bool exists_txtfield_Password()
        {
            return _driver.FindElement(txtfield_Password).Displayed;
        }
        public bool exists_txtfield_ReEnterPassword()
        {
            return _driver.FindElement(txtfield_ReEnterPassword).Displayed;
        }
        public bool exists_txt_EmptyReEnterPassword()
        {
            return _driver.FindElement(txt_EmptyReEnterPassword).Displayed;
        }
        public bool exists_btn_Continue()
        {
            return _driver.FindElement(btn_Continue).Displayed;
        }
        public bool exists_txt_EmptyPasswordError()
        {
            return _driver.FindElement(txt_EmptyPasswordError).Displayed;
        }
        public bool exists_txt_EmptyEmailError()
        {
            return _driver.FindElement(txt_EmptyEmailError).Displayed;
        }
        public bool btn_VerifyEmail_exists()
        {
            return _driver.FindElement(btn_VerifyEmail).Displayed;
        }
        public bool exists_txt_InvalidEmail()
        {
            return _driver.FindElement(txt_InvalidEmail).Displayed;
        }

        public bool exists_textfield_Name()
        {
            return _driver.FindElement(textfield_Name).Displayed;
        }

        public void clk_btn_Continue()
        {
            _driver.FindElement(btn_Continue).Click();
        }

        public void sendkeys_textfield_Name(string text)
        {
            _driver.FindElement(textfield_Name).SendKeys(text);
        }
        public void sendkeys_textfield_Email(string text)
        {
            _driver.FindElement(textfield_Email).SendKeys(text);
        }
        public void clk_btn_VerifyEmail()
        {
            _driver.FindElement(btn_VerifyEmail).Click();
        }
        public void sendkeys_txtfield_Password(string text)
        {
            _driver.FindElement(txtfield_Password).SendKeys(text);
        }
        public void sendkeys_txtfield_ReEnterPassword(string text)
        {
            _driver.FindElement(txtfield_ReEnterPassword).SendKeys(text);
        }

    }

}