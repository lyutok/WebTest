using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebDriverTest
{

    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://old.qalight.com.ua/");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Smoke()
        {
            //Arrange

            // Act
            // click on all four links

            IWebElement element = driver.
                FindElement(By.XPath("//*[@id=\"mpfp_nav_cource\"]/li[1]/a"));
            element.Click();

            driver.Navigate().Back();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement element1 = driver.
               FindElement(By.XPath("//*[@id=\"mpfp_nav_cource\"]/li[2]/a"));
            element1.Click();

            driver.Navigate().Back();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement element2 = driver.
               FindElement(By.XPath("//*[@id=\"mpfp_nav_cource\"]/li[3]/a"));
            element2.Click();

            driver.Navigate().Back();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement element3 = driver.
               FindElement(By.XPath("//*[@id=\"mpfp_nav_cource\"]/li[4]/a"));
            element3.Click();

            driver.Navigate().Back();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //F5
            driver.Navigate().Refresh();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            #region does_not_work
           // click on Записаться на курсы
           IWebElement element4 = driver.
             FindElement(By.XPath("//*[@id=\"navbar-collapse-1\"]/ul/li/a[@href=\"/zapisatsya-na-kursy.html\"]"));
             element4.Click();
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            #endregion

            // driver.Navigate().GoToUrl("http://old.qalight.com.ua/zapisatsya-na-kursy.html");


            IWebElement element5 = driver.
              FindElement(By.XPath("//*[@id=\"fox_form_m135\"]/div[9]/div/button[1]"));
            element5.Click();

            //IWebElement failElement = driver.
            //   FindElement(By.CssSelector(".alert.alert-error"));

            string expectedElementLocatorFail = ".alert.alert-error";
            Assert.True(IsElementPresent(driver, expectedElementLocatorFail),
                $"Element with locator {expectedElementLocatorFail} is not present on the page.");

            //IWebElement element6 = driver.
            //    FindElement(By.XPath("//*[contains(text(), 'Недопустимое значение: Ваша Фамилия')]"));

            //IWebElement element7 = driver.
            //    FindElement(By.XPath("//*[contains(text(), 'Недопустимое значение: Ваше Имя')]"));

            //IWebElement element8 = driver.
            //    FindElement(By.XPath("//*[contains(text(), 'Недопустимое значение: Ваш Телефон')]"));

            //IWebElement element9 = driver.
            //    FindElement(By.XPath("//*[contains(text(), 'Недопустимое значение: Ваш E-Mail')]"));

            //IWebElement element10 = driver.
            //    FindElement(By.XPath("//*[contains(text(), 'Недопустимое значение: Ваш Skype')]"));

            //IWebElement element11 = driver.
            //    FindElement(By.XPath("//*[contains(text(), 'Недопустимое значение: Откуда Вы узнали о QALight')]"));

            // Fill in the form

            // select from dropdown
            IWebElement course = driver.FindElement(By.CssSelector("[name='_7c8289bf6b8e80c1749ef54ab01b92b8']"));
            SelectElement courseDropdown = new SelectElement(course);
            courseDropdown.SelectByIndex(3);

            IWebElement element12 = driver.
                FindElement(By.XPath("//*[@id=\"fox_form_m135\"]/div[1]/div/select/option[2]"));

            IWebElement element13 = driver.
                FindElement(By.XPath("//*[@id=\"z_sender0\"]"));
            element13.SendKeys("TestSurname");

            IWebElement element14 = driver.
                FindElement(By.XPath("//*[@id=\"z_text1\"]"));
            element14.SendKeys("TestName");

            IWebElement element15 = driver.
                FindElement(By.XPath("//*[@id=\"z_text0\"]"));
            element15.SendKeys("0669876767");

            IWebElement element16 = driver.
                FindElement(By.XPath("//*[@id=\"z_sender1\"]"));
            element16.SendKeys("test@gmail.com");

            IWebElement element17 = driver.
              FindElement(By.XPath("//*[@id=\"z_text2\"]"));
            element17.SendKeys("test_gmail");

            // select from dropdown
            IWebElement sourceInfo= driver.FindElement(By.CssSelector("[name='_e926ba2b2813f56de8fc13877057e908']"));
            SelectElement sourceInfoDropdown = new SelectElement(sourceInfo);
            sourceInfoDropdown.SelectByIndex(4);
            //OR
            // IWebElement element18 = driver.
            //  FindElement(By.XPath("//*[@id=\"fox_form_m135\"]/div[7]/div/select/option[4]"));
            //element18.Click();

            IWebElement element19 = driver.
             FindElement(By.XPath("//*[@id=\"fox_form_m135\"]/div[8]/div/textarea"));
            element19.SendKeys("Comment comment comment");

            // click Submit button
            IWebElement submitButton = driver.
             FindElement(By.CssSelector("[type=submit]"));
            submitButton.Click();

            // Assert
            // IWebElement successElement = driver.
            //     FindElement(By.CssSelector(".alert.alert-success"));

            // Thread.Sleep(2000); // - заходит на стр и уходит назад

            string expectedElementLocator = ".alert.alert-success";
            Assert.True(IsElementPresent(driver, expectedElementLocator),
                $"Element with locator {expectedElementLocator} is not present on the page.");

        }

        public bool IsElementPresent(IWebDriver driver, string cssSelector)
        {
            var elements = driver.FindElements(By.CssSelector(cssSelector));

            if (elements.Count == 1)
            {
                return true;
            }
            else if (elements.Count == 0 )
            {
                return false;
            }
            else 
            {
                throw new Exception("Unexpected Exception");
            }
        }
    }
}
