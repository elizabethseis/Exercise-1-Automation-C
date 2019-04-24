using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace Exercise_1_Automation_C
{
    class Program
    {
        static IWebDriver driver;
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of the browser");
            Console.WriteLine('\n' + "1. Chrome" + '\n' + "2. Firefox" + '\n' + "3. IE");
            int browser = Convert.ToInt32(Console.ReadLine());
            SetUp(browser);
            driver.Navigate().GoToUrl("https://www.facebook.com");
            #region
            WaitForElement(By.XPath("//div[@class='mbl _3m9 _6o _6s _mf']"), 5);
            string ValidateText = driver.FindElement(By.XPath("//div[@class='mbl _3m9 _6o _6s _mf']")).Text;
            Console.WriteLine(ValidateText);
            string Text = "It’s free and always will be.";
            IWebElement txtFirstName = driver.FindElement(By.Id("u_0_c"));
            IWebElement txtLastName = driver.FindElement(By.Id("u_0_e"));
            IWebElement txtPhone = driver.FindElement(By.Id("u_0_h"));
            #endregion
            

            try
            {
                Assert.AreEqual(ValidateText, Text);
                Console.WriteLine("Valid Text");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Invalid Text");
              
            }
            
            EnterTex(txtFirstName, txtLastName, txtPhone);

            WaitForElement(By.XPath("//span[@class='_2md']"), 5);

            Console.ReadLine();
        }

        public static void WaitForElement(By Locator, int seconds)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(Locator));
            }
            catch (Exception i)
            {
                Console.WriteLine("Element is not displayed");
            }
        }
        static void Click(IWebElement element1)
        {
            element1.Click();
        }

        static void EnterTex(IWebElement element2, IWebElement element3, IWebElement element4)
        {
            element2.SendKeys("Elizabeth");
            element3.SendKeys("Perez");
            element4.SendKeys("4777018223");
        }

        static void WaitElement()
        {

        }
        static void SetUp(int browser)
        {
            switch (browser)
            {
                case 1:
                    driver = new ChromeDriver();
                    break;
                case 2:
                    driver = new FirefoxDriver();
                    break;
                case 3:
                    
                    driver = new InternetExplorerDriver(@"C:\Users\elizabeth.perez\Desktop\Microsoft");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;


            }
        }
    }
}
