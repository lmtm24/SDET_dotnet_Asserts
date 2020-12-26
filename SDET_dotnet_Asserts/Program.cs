using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSquare_Maintenance
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("//form[@id='tsf']//div[@class='A8SBwf']//div[@class='a4bIc']/input[@role='combobox']");
        By GoogleSearIcon = By.XPath("/html//form[@id='tsf']//div[@class='A8SBwf']/div[@class='FPdoLc tfB0Bf']/center/input[@name='btnK']");
        By UnoSquareGoogleResult = By.CssSelector("div:nth-of-type(1) > .rc h3 > span");                
        By GoogleOutSearchResult = By.XPath("//form[@id='tsf']/div[2]");
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.XPath("//div[@id='navbarSupportedContent']/ul[@class='navbar-nav']//a[@href='/Services']");
        By PracticeAreas = By.XPath("//div[@id='navbarSupportedContent']/ul[@class='navbar-nav']//a[@href='/PracticeAreas']");
        By ContactUs = By.XPath("//div[@id='navbarSupportedContent']/ul[@class='navbar-nav']//a[@href='/ContactUs']");
        By OurDna = By.XPath("//div[@id='navbarSupportedContent']/ul[@class='navbar-nav']//a[@href='/OurDna']");
        By Articles = By.XPath("//div[@id='navbarSupportedContent']/ul[@class='navbar-nav']//a[@href='/Articles']");
        By Digital = By.XPath("//div[@id='services']/div[@class='gray-section']/div[@class='container content-home']/div[3]/div[@class='col-8']/strong[@class='desc']");
        #endregion 
        static void Main(string[] args)
        {

            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            //Wirite the locator for the Google Search Bar
            element = Browser.FindElement(program.GoogleSearchBar);

            // Write Assert True that element is present [Google Search] button
           Assert.IsTrue(Browser.FindElement(program.GoogleSearIcon).Displayed);

            //Send the text "Unosquare" to the Text Bar
            program.SendText(element, "Unosquare");

           
            // Click on the Search Button
            element = Browser.FindElement(program.GoogleSearIcon);

            program.Click(element);

            // Write Assert Equal [Unosquare: Digital Transformation Services | Agile Staffing ...] vs [Element.text]           
            Assert.AreEqual("Unosquare: Digital Transformation Services | Agile Staffing ...", Browser.FindElement(program.UnoSquareGoogleResult).Text);
            // Locate the first result corresponding to Unosquare and click on the Link
            element = Browser.FindElement(program.UnoSquareGoogleResult);

            program.Click(element);

            // Write Assert True that element is present [Our Dna] menu object
            Assert.IsTrue(Browser.FindElement(program.OurDna).Displayed);

            // Write Assert True that element is present [Articles & Events] menu object
            Assert.IsTrue(Browser.FindElement(program.Articles).Displayed);
            
            //Locate the Service Menu and Click the element
            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);

            // Write Assert Equal [Digital transformation solutions] vs [Element.text] h2 ojbect
            Assert.AreEqual("DIGITAL TRANSFORMATION STRATEGIES", Browser.FindElement(program.Digital).Text);

            //Locate the Practice Areas Menu and Click the Element
            element = Browser.FindElement(program.PracticeAreas);

            program.Click(element);

            //Locate the Contact Us Menu and Click the Element
            element = Browser.FindElement(program.ContactUs);

            program.Click(element);

        }
    }
}
