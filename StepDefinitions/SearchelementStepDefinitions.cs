using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using TrademeSearchelement.Classes;

namespace TrademeSearchelement.StepDefinitions
{
    [Binding]
    public sealed class SearchelementStepDefinitions
    {
        private IWebDriver driver;        
        webElements webElements;

        public SearchelementStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
           
        }

        [Given(@"Open the browser")]
        public void GivenOpenTheBrowser()
        {
            //Handeled in Hooks
        }

        [When(@"Enter the URL")]
        public void WhenEnterTheURL()
        {
            driver.Url = "http://www.tmsandbox.co.nz/";
        }

        
        [Then(@"Search for the (.*)")]
        public void ThenSearchForTheElement(string element)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webElements = new webElements(driver);
            webElements.searchElementbyID(element);
            
            try
            {                
                string numberOfListings = webElements.searchElementbyXpath();
                Console.WriteLine(numberOfListings);                
            }
            catch(Exception ex) 
            {

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                webElements.searchElementbyClassSendKeys(); // If an element present , Click the first element
                string strListingId = webElements.searchElementbyClassid(); //capure the listingId element
                Console.WriteLine(strListingId); //verify in test
                Assert.AreEqual("Listing #: 2149566835", strListingId);//assert

                string strAddressvalidation = webElements.searchElementbyIDText();
                Console.WriteLine(strAddressvalidation);
                Assert.AreEqual("Manukau, Auckland, NZ", strAddressvalidation);               
            }          
        }    
    }
}