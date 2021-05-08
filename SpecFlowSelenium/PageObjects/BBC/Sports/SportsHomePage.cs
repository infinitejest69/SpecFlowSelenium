using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
using System;

namespace SpecFlowSelenium.PageObjects.BBC.Sports
{

    class SportsHomePage
    {
        private IWebDriver Driver;
        public string PageUrl { get; } = "https://www.bbc.co.uk/sport";

        private string menustring = ".//*[@data-stat-name='primary-nav-v2'][contains(text(),'replace')]";
        private string submenustring = ".//*[@data-stat-name='secondary-nav-v2'][contains(text(),'replace')]";

        [FindsBy(How = How.Id, Using = "page")]
        [CacheLookup]
        public IWebElement pageTitle { get; set; }

        public SportsHomePage(IWebDriver driver)
        {
            this.Driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(Driver, this);
        }

        public void clickMenuItem(string menuItem)
        {
            Driver.FindElement(By.XPath(menustring.Replace("replace", menuItem))).Click();

        }

        public void clickSubMenuItem(string subMenuItem)
        {
            Driver.FindElement(By.XPath(submenustring.Replace("replace", subMenuItem))).Click();
        }

        public string getPageTitle()
        {
            return pageTitle.Text;
        }
    }
}
