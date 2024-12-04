using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace _3SemSelenium
{
    [TestClass]
    public class UnitTest1
    {
        private static string DriverDirectory = "C:\\webDriver";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory); // fast

        }
        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //string url = "http://localhost:3000/";

            _driver.Navigate().GoToUrl("http://localhost:52330/WOTD/exercises.html");


            string title = _driver.Title;
            Assert.AreEqual("Exercises", title);

            Thread.Sleep(1400);
            IWebElement inputElement = _driver.FindElement(By.Id("search-input"));
            inputElement.SendKeys("biceps");

            Thread.Sleep(1400);
            IWebElement buttonElement = _driver.FindElement(By.Id("search-button"));
            buttonElement.Click();

            Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            //IWebElement wpId = wait.Until(d => d.FindElement(By.Id("foundId")));
            //Assert.AreEqual("{ \"id\": 1, \"brand\": \"APilMaster\", \"price\": 1000, \"quality\": 5 }", wpId.Text);


        }
    }
}