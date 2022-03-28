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

        public By btn_Capture = By.XPath("//*[text()='Capture']");
        public By btn_AddActions = By.XPath("//*[text()='Add Actions']");
        public By btn_proj = By.XPath("//a[text()='va01']");
        public By btn_practice_proj = By.XPath("//a[text()='va01 - Practice']");
        public By txt_Tttle = By.Id("LeftContent_MessageTitle");
        public By btn_stop = By.XPath("//*[text()='Stop']");

        public By btn_delete = By.XPath("//*[@class='assima__treeNode  main']/parent::*/child::li[last()]/child::*/child::*/child::*/child::*/child::*/child::*/child::*/child::*/child::*/child::*/child::*/child::*/child::*/child::*/child::li[@class='action delete']");
        public By count = By.XPath("//*[@class='assima__treeNode  main']/parent::*/child::*");
        public By last_item = By.XPath("//*[@class='assima__treeNode  main']/parent::*/child::li[last()]");

        public By txt_ActionEditorTitle = By.XPath("//h1[@id='LeftContent_MessageTitle']");

        public IWebElement findElement(OpenQA.Selenium.By element)
        {
            return _driver.FindElement(element);
        }
        public bool btn_ActionEditorTitle_Exists()
        {
            return _driver.FindElement(txt_ActionEditorTitle).Displayed;
        }
        public int count_elements()
        {
            return _driver.FindElements(count).Count();
        }

        public bool btn_Capture_Exists()
        {
            return _driver.FindElement(btn_Capture).Displayed;
        }
        public bool exists_btn_proj()
        {
            return _driver.FindElement(btn_proj).Displayed;
        }
        public bool exists_btn_practice_proj()
        {
            return _driver.FindElement(btn_practice_proj).Displayed;
        }
        public bool exists_btn_delete()
        {
            return _driver.FindElement(btn_delete).Displayed;
        }
        public bool exists_last_item()
        {
            return _driver.FindElement(last_item).Displayed;
        }
        public bool btn_AddActions_Exists()
        {
            return _driver.FindElement(btn_AddActions).Displayed;
        }
        public void clk_btn_delete()
        {
            _driver.FindElement(btn_delete).Click();
        }
        public void clk_last_item()
        {
            _driver.FindElement(last_item).Click();
        }
        public void clk_btn_Capture()
        {
            _driver.FindElement(btn_Capture).Click();
        }

        public void clk_btn_AddActions()
        {
            _driver.FindElement(btn_AddActions).Click();
        }
        public void clk_btn_proj()
        {
            _driver.FindElement(btn_proj).Click();
        }
        public void clk_btn_practice_proj()
        {
            _driver.FindElement(btn_practice_proj).Click();
        }

    }

}