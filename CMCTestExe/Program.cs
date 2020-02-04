using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumLogger;
using GumtreeWebsite;


namespace CNCTestExe
{
    class Program
    {
        static void Main(string[] args)
        {

            SeleniumLog log = SeleniumLog.Instance(null);

            log.WriteLine("Launch Chrome");
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            int ExpectedCount = -1;
            int ActualCount = -1;

            IWebDriver driver = new ChromeDriver(options);

            GumtreeWebsite.MainPage GumtreeMain = new GumtreeWebsite.MainPage(driver);


            log.WriteLine("Goto GUMTREE URL");

            driver.Navigate().GoToUrl("http://gumtree.com.au");

            log.WriteLine("Run Test");
            MainPage MainPage = new MainPage(driver);
            SearchResultsPage SearchResultsPage = new SearchResultsPage(driver);
            CarDetailsPage CarDetailsPage = new CarDetailsPage(driver);

            MainPage.Search("Toyota");

            log.WriteLine("Currently on Page 1 .....");
            
            ExpectedCount = SearchResultsPage.GetDisplayedResultsCountPerPage();
            log.WriteLine("Displayed results per page [" + ExpectedCount + "]");

            ActualCount = SearchResultsPage.CountSearchResults();
            log.WriteLine("Actual number of results [" + ActualCount + "]");

            log.WriteLine("Goto Page 2");
            SearchResultsPage.GotoPage(2);

            log.WriteLine("Goto Page 3");
            SearchResultsPage.GotoPage(3);

            log.WriteLine("Goto Page 4");
            SearchResultsPage.GotoPage(4);


            log.WriteLine("\n\n********** While on Page 4, click on random advert *******************");
            SearchResultsPage.ClickOnRandomSearchResult();
            CarDetailsPage.ClickImageButton();
            CarDetailsPage.CycleThroughAllImages();
            
            //Close Browser
            driver.Close();
            driver.Quit();
        }
    }
}
