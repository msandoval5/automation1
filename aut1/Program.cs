using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace aut1
{
    class Program
    {
        public IWebDriver driver;
        // WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(30));
        static void Main(string[] args)
        {
            var obj = new Program();
            obj.Config("FireFox");
            obj.VerifyText();
            obj.Fill("Mariana");
            obj.Fill('S');
            obj.Fill(993);
            obj.VerifyFake();
            obj.CleanUp();
        }
        public Program()
        {

        }
        #region MyWebElements
        IWebElement TextDisplayed;
        IWebElement FirstNameTextBox;
        IWebElement LastNameTextBox;
        IWebElement MobileTextBox;
       //IWebElement FakeElement;



        #endregion

        public void Config(string Browser)
        {
            switch (Browser)
            {
                case "Chrome":
                default:
                    driver = new ChromeDriver(@"/Users/mariana.sandoval/Projects/aut1/aut1/bin/Debug");
                    driver.Manage().Window.Maximize();
                    break;

                case "FireFox":
                    driver = new FirefoxDriver(@"/Users/mariana.sandoval/Projects/aut1/aut1/bin");
                    driver.Manage().Window.Maximize();
                    break;
            }
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            return;
        }
        public void VerifyText()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TextDisplayed = driver.FindElement(By.XPath("//div[contains(text(),\"gratis\")]"));

            if (TextDisplayed.Displayed)
            {

                Console.WriteLine("THE TEXT EXPECTED IS PRESENT");
            }
            else
            {
                Console.WriteLine("THE TEXT EXPECTED IS NOT PRESENT");
            }

        }
        public void Fill(string name)
        {
            FirstNameTextBox = driver.FindElement(By.Name("firstname"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            FirstNameTextBox.SendKeys(name);
        }
        public void Fill(char lastname)
        {

            LastNameTextBox = driver.FindElement(By.Name("lastname"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LastNameTextBox.SendKeys(lastname.ToString());
        }
        public void Fill(int mobile)
        {
            MobileTextBox = driver.FindElement(By.Name("reg_email__"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            MobileTextBox.SendKeys(mobile.ToString());
        }

        public void VerifyFake()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until<IWebElement>(CustomWait);
            }
            catch (Exception)
            {
                Console.WriteLine("** ELEMENT DOES NOT EXISTS **");
            }
           
                    

        }
        public IWebElement CustomWait(IWebDriver dr)
        {
            IWebElement FakeElement = driver.FindElement(By.Name("fake"));
            if (FakeElement.Displayed)
            {
                return FakeElement;
            }
            return null;
        }


        public void CleanUp() => driver.Quit();

    }
}

/*Create a new console application.
Create your Set up method.
Create and declare your WebElements.
Create and declare your interaction methods (click, enter text, waits).
Go to facebook.com.
Verify following text is displayed:
It's free and always will be.
Fill Firstname, Lastname and Mobile Number.
Once flow is performed, do the following:

Declare an element that does not exist.
Use exception handler to catch the exception and display a customized message for elements that do not exist.
*/