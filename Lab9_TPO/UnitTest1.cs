using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Network;

namespace Lab9_TPO
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private PastebinPage pastebinPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            pastebinPage = new PastebinPage(driver);
        }

        [TestMethod]
        public void ADD_SAMEPRODUCTTOCOMPARE_RETURNEDNOTIFICATION()
        {
            driver.Navigate().GoToUrl("https://musicmarket.by/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);

            driver.FindElement(By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/div/div/div/div/ul/div[1]/li[1]/a")).Click();

            driver.FindElement(By.XPath("//*[@id=\"categories_view_pagination_contents\"]/div[1]/div/form/div/div[1]/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"add_to_cart_update_29807\"]/a[2]")).Click();
            Thread.Sleep(9000);
            driver.FindElement(By.XPath("//*[@id=\"abt__ut2_compared_products\"]/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"tygh_main_container\"]/div[3]/div/div[2]/div/div/div/div/div[1]/div/a[3]")).Click();
            Thread.Sleep(3000);

            Assert.IsTrue(driver.FindElement(By.ClassName("ty-no-items")) != null);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}