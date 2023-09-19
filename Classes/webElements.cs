using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TrademeSearchelement.Classes
{
    public class webElements
    {
        private IWebDriver driver;

        public webElements(IWebDriver driver)
        {
            this.driver = driver;
        }

        By searchbyID=By.Id("searchString");
        By searchbyXpath = By.XPath("//div[@id='FiltersContainer']/h1");
        By searchbyClassSendkeys = By.ClassName("tmm-search-card-list-view__link");
        By SearchbyClassid = By.ClassName("listing-id");
        By SearchbyIDText = By.Id("ListingTitleBox_LocationText");
        

        public string searchElementbyID(string elementbyID)
        {

            driver.FindElement(searchbyID).SendKeys(elementbyID);
            driver.FindElement(searchbyID).SendKeys(Keys.Enter);
            return elementbyID;

        }
        public string searchElementbyXpath()
        {
            string elementbyXpath=driver.FindElement(searchbyXpath).Text.ToString();
            return elementbyXpath;
        }

        public void searchElementbyClassSendKeys()
        {
            driver.FindElement(searchbyClassSendkeys).SendKeys(Keys.Enter);
        }
        public string searchElementbyClassid()
        {
            string searchbyClassText=driver.FindElement(SearchbyClassid).Text.ToString();
            return searchbyClassText;
        }
        public string searchElementbyIDText()
        {
            string searchbyIdText = driver.FindElement(SearchbyIDText).Text.ToString();
            return searchbyIdText;
        }
    }
}
