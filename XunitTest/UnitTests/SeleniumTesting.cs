using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XunitTest.UnitTests
{
    public class SeleniumTesting
    {
        private readonly ITestOutputHelper output;
        public SeleniumTesting(ITestOutputHelper output)
        {
            this.output = output;
        }
        const string homeUrl = "https://localhost:44350/";
        const string loginPage = "https://localhost:44350/CustomerPages/Login";
        const string cart = "https://localhost:44350/CustomerPages/Cart";

        [Fact]
        public void SeleniumWithCompletePurches()
        {
            using (IWebDriver driver = new FirefoxDriver(new FirefoxOptions { AcceptInsecureCertificates = true }))
            {
                driver.Navigate().GoToUrl(homeUrl);

                //navegate to login page
                IWebElement loginNavLink = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/a"));
                loginNavLink.Click();
                

                //navigate to Create new account
                IWebElement createAccountBTN = driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/form/a"));
                createAccountBTN.Click();


                //Filling out form and creates account
                driver.FindElement(By.Id("Customer_Name")).SendKeys("Selenium");
                driver.FindElement(By.Id("Customer_Address")).SendKeys("Seleniumvej 1");
                driver.FindElement(By.Id("Customer_Mail")).SendKeys("Selenium@Selenium.com");

                IWebElement createBTN = driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[4]/input"));
                createBTN.Click();


                //navigate to loginpage and logs in
                driver.Navigate().GoToUrl(loginPage);


                driver.FindElement(By.Id("Email")).SendKeys("Selenium@Selenium.com");


                IWebElement loginBTN = driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/form/div[3]/input"));
                loginBTN.Click();


                //home
                driver.Navigate().GoToUrl(homeUrl);


                //page2
                Actions scroll = new Actions(driver);
                IWebElement page2 = driver.FindElement(By.XPath("/html/body/div[1]/main/div[2]/div/div/ul/li[2]/a"));
                page2.Click();

                //add 2 dinos to cart
                IWebElement buy2Dinos = driver.FindElement(By.XPath("/html/body/div[1]/main/div[2]/div/form[1]/div/div[4]/input"));
                buy2Dinos.SendKeys(Keys.Delete + "2");


                IWebElement putInCart = driver.FindElement(By.XPath("/html/body/div[1]/main/div[2]/div/form[1]/div/div[5]/input[2]"));
                putInCart.Click();


                //navigate to Cart
                driver.Navigate().GoToUrl(cart);


                //buy the dinos
                IWebElement buyDinosBTN = driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/a"));
                buyDinosBTN.Click();


                //Confirm your buy
                IAlert confirmation = driver.SwitchTo().Alert();
                confirmation.Accept();
                Pause();
                
            }
        }

        private void Pause()
        {
            Thread.Sleep(3000);
        }

        [Fact]
        public void SeleniumMultipleWindows1()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://demoqa.com/";

            output.WriteLine(driver.Title + " " + driver.Title.Length);

            output.WriteLine($"{driver.Url} + {driver.Url.Length}");

            output.WriteLine("{0}", driver.PageSource.Length);

            driver.Quit();
        }

        [Fact]
        public void SeleniumMultipleWindows2()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://shop.demoqa.com/";

            driver.Navigate().GoToUrl("http://shop.demoqa.com/cart/");

            driver.Navigate().Back();

            driver.Navigate().Forward();

            driver.Navigate().GoToUrl("http://shop.demoqa.com/");

            driver.Navigate().Refresh();

            driver.Quit();
        }
    }
}
