using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumLogger;

namespace GumtreeWebsite
{
    public class CarDetailsPage : BasePage
    {
        //private IWebDriver driver;
        //private SeleniumLog log;
        private int imagesCount;

        private IWebElement ImagesButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//div[contains(@class, 'vip-ad-image__legend')]/button"));
            }
        }

        private IWebElement GalleryLeftButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//div[contains(@class, 'vip-ad-gallery__controls')]/button[1]"));
            }
        }

        private IWebElement GalleryRightButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//div[contains(@class, 'vip-ad-gallery__controls')]/button[2]"));
            }
        }
        
        public CarDetailsPage(IWebDriver driver) : base(driver)
        {
            this.imagesCount = -1;
        }

        public int GetNumberOfImages()
        {
            try
            {
                return Convert.ToInt16(Regex.Replace(ImagesButton.Text, "images", "").Trim());
            }
            catch (Exception e)
            {
                log.Error().WriteLine("CarDetailsPage::GetNumberOfImages() exception raised [" + e.Message + "]");
                return -1;
            }
        }

        public void ClickImageButton()
        {
            try
            {
                log.WriteLine("Click Image button");
                ScrollIntoView(ImagesButton);
                this.imagesCount = GetNumberOfImages();
                ImagesButton.Click();
            }
            catch (Exception e)
            {
                log.Error().WriteLine("CarDetailsPage::ClickImageButton() exception raised [" + e.Message + "]");
            }
        }

        public void CycleThroughAllImages()
        {
            IWebElement rightArrow = GalleryRightButton;

            log.WriteLine("Cycle through images in gallery ..... total images = " + imagesCount);
            for (int i = 0; i < this.imagesCount - 1; i++)
            {
                Thread.Sleep(1000);
                rightArrow.Click();
            }
        }
    }
}
