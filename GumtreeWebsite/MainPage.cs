using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumLogger;


namespace GumtreeWebsite
{
    public class MainPage : BasePage
    {
        //private IWebDriver driver;
        //private SeleniumLog log;

        private IWebElement SearchButton
        {
            get
            {
                return this.driver.FindElement(By.ClassName("header__search-button"));
            }
        }

        private IWebElement SearchField
        {
            get
            {
                return this.driver.FindElement(By.Id("search-query"));
            }
        }

        public MainPage(IWebDriver driver) : base(driver)
        {        
        }


        public void Search(string SearchString)
        {
            try
            {
                log.WriteLine("Enter search string [" + SearchString + "]");
                SearchField.SendKeys(SearchString);

                log.WriteLine("Click on Search button");
                SearchButton.Click();

            }
            catch (Exception e)
            {
                log.Error().WriteLine("MainPage::Search() exception raised [" + e.Message + "]");

            }
        }

        public void test() {
            try
            {
                SeleniumLog log = SeleniumLog.Instance();

                //ApiField.Click();
                //log.WriteLine("Field default text [" + ApiField.GetAttribute("placeholder") + "]");
                //ApiField.SendKeys("test");
                //SearchField.SendKeys("Toyota");
                //SearchButton.Click();
                //log.WriteLine("Ad count [" + AdsList.Count + "]");
                //log.WriteLine("Sleep 3 seconds");
                //Thread.Sleep(3000);
                //log.WriteLine("Finished sleeping");
                //ScrollIntoView(ResultsCount);
                
                log.WriteLine("end test");
            }
            catch (Exception e)
            {
                SeleniumLog log = SeleniumLog.Instance();
                log.Error().WriteLine("Exception: " + e.Message);
            }
        }
    }
}
