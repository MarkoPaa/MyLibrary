using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                driver.Manage().Window.Maximize();
                driver.Url = "https://vaalikone.yle.fi/eduskuntavaali2019?lang=fi-FI";
            }
            else { }

        }

        [Test, Order(1)]
        public void EtsiSivunOtsikko()
        {
            driver.FindElement(By.XPath("//*[@id='root']/main/div[1]/section/h1"));
        }

        [Test, Order(2)]
        public void AvaaSelaaEhdokkaat()
        {
            driver.FindElement(By.XPath("//*[@id='root']/main/div[1]/section/a")).Click();
        }
        [Test, Order(3)]
        public void HaeEhdokasta()
        {
            
            driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/div[1]/input")).SendKeys("Li Andersson");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
        [Test, Order(4)]
        public void TutustuEhdokkaaseenJaVertaa()
        {
            // Arrange
            string puolue;
            string oletus = "Varsinais-Suomen vaalipiiri";

            // Act
            driver.FindElement(By.XPath("//*[@id='root']/main/div[1]/div/div[3]/div[1]/div/div/div/section/div/div[1]/a[2]")).Click();
            puolue= driver.FindElement(By.XPath("//*[@id='root']/main/div[1]/div/section[1]/div[4]/div[1]/p")).Text;

            // Assert
            Assert.AreEqual(puolue, oletus);
        }
        
    }
}