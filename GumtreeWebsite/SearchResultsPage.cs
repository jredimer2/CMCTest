using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumLogger;

namespace GumtreeWebsite
{
    public class SearchResultsPage : BasePage
    {
        //private IWebDriver driver;
        //private SeleniumLog log;

        private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> ResultsList
        {
            get
            {
                return this.driver.FindElements(By.XPath("//*[text() = 'Most recent']/../div/a[contains(@id,'user-ad-')]"));
            }
        }

        private SelectElement ResultsCounter
        {
            get
            {
                return new SelectElement(this.driver.FindElement(By.XPath("//option[contains(text(),'results per page')]/..")));
            }
        }

        private IWebElement PageNumbers
        {
            get
            {
                return this.driver.FindElement(By.ClassName("page-number-navigation"));
            }
        }

        private IWebElement ClosePicture
        {
            get
            {
                return this.driver.FindElement(By.ClassName("icon-close")).FindElement(By.XPath("../.."));
            }
        }


        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Checks if the image close button is present. This is how we know we are still in the Pictures page.
        /// </summary>
        /// <returns></returns>
        private bool IsCloseButtonExist()
        {
            try
            {
                SetTimeout(10);
                IWebElement elem = this.driver.FindElement(By.ClassName("icon-close"));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                ResetDefaultTimeout();
            }
        }

        public int CountSearchResults()
        {
            try
            {
                return ResultsList.Count;
            }
            catch (Exception e)
            {
                log.Error().WriteLine("SearchResultsPage::CountSearchResults() exception raised [" + e.Message + "]");
                return -1;
            }
        }

        private IWebElement GetSearchResult(int Index)
        {
            return ResultsList[Index];
        }

        public int GetDisplayedResultsCountPerPage()
        {
            try
            {
                string SelectedItem = ResultsCounter.SelectedOption.Text;
                log.WriteLine("Currently selected results per page [" + SelectedItem + "]");
                return Convert.ToInt32(Regex.Replace(SelectedItem, "results per page", "").Trim());
            }
            catch (Exception e)
            {
                log.Error().WriteLine("SearchResultsPage::GetDisplayedResultsCountPerPage() exception raised [" + e.Message + "]");
                return -1;
            }
        }

        private IWebElement GetPageNumberButton(int PageNum)
        {
            try
            {
                return PageNumbers.FindElement(By.XPath("a[text() = '" + PageNum + "']"));
            }
            catch (Exception e)
            {
                log.Error().WriteLine("SearchResultsPage::GetPageNumberButton() exception raised [" + e.Message + "]");
                return null;
            }
        }

        private int GenerateRandomNumber(int Max)
        {
            try
            {
                Random rnd = new Random();
                return rnd.Next(1, Max);
            }
            catch (Exception e) 
            {
                log.Error().WriteLine("SearchResultsPage::GenerateRandomNumber() exception raised [" + e.Message + "]");
                return -1;
            }
        }

        public void ClickCloseButtonIfExist()
        {
            try
            {
                if (IsCloseButtonExist())
                {
                    ClosePicture.Click();
                }
            }
            catch (Exception e)
            {
                log.Error().WriteLine("SearchResultsPage::ClickCloseButtonIfExist() exception raised [" + e.Message + "]");
            }
        }

        public void GotoPage(int PageNum)
        {
            try
            {
                Thread.Sleep(1000); //allow for the button to be clickable. It may exist on the page, but not clickable yet.
                ScrollIntoView(PageNumbers);
                GetPageNumberButton(PageNum).Click();
            }
            catch (Exception e)
            {
                log.Error().WriteLine("SearchResultsPage::GotoPage() exception raised [" + e.Message + "]");
            }
        }

        public void ClickOnRandomSearchResult()
        {
            try
            {               
                int i = GenerateRandomNumber(CountSearchResults());
                log.WriteLine("Generated random number [" + i + "]");

                IWebElement res = GetSearchResult(i);
                ScrollIntoView(res);

                //Thread.Sleep(7000);
                log.WriteLine("Click on random search result");
                res.Click();

            }
            catch (Exception e)
            {
                log.Error().WriteLine("SearchResultsPage::ClickOnRandomSearchResult() exception raised [" + e.Message + "]");

            }
        }
    }
}
