using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumLogger;

namespace GumtreeWebsite
{
    public class BasePage
    {
        public IWebDriver driver;
        public SeleniumLog log;

        public void ScrollIntoView(IWebElement elem)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
            }
            catch (Exception e)
            {
            }
        }

        public void SetTimeout(int Sec)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (Exception e)
            {
                log.Error().WriteLine("Bbase::SetTimeout() exception raised [" + e.Message + "]");
            }
        }

        public void ResetDefaultTimeout()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
            catch (Exception e)
            {
                log.Error().WriteLine("Bbase::ResetDefaultTimeout() exception raised [" + e.Message + "]");
            }
        }

        public void GoBackPreviousPage()
        {
            try
            {
                driver.Navigate().Back();
            }
            catch (Exception e)
            {

            }
        }

        public void Verify(int Expected, int Actual)
        {
            try
            {
                Assert.AreEqual(Expected, Actual);
                log.Pass().WriteLine("Verify search results count. Expected [" + Expected + "]  Actual [" + Actual + "] - PASS");
            }
            catch (Exception e)
            {
                log.Fail().WriteLine("Verify search results count. Expected [" + Expected + "]  Actual [" + Actual + "] - FAIL");
            }
        }

        public BasePage(IWebDriver driver)
        {
            try
            {
                this.driver = driver;
                this.log = SeleniumLog.Instance();
                ResetDefaultTimeout();
            }
            catch (Exception e)
            {
            }

        }
    }
}
