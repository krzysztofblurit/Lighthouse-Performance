namespace PerformanceTests.POM
{
    public class WelcomePage : BasePage
    {
        private IWebDriver _driver;
        public string WelcomePageURL { get; }

        public WelcomePage(IWebDriver driver, string url)
        {
            this._driver = driver;
            this.WelcomePageURL = $"{url}welcomepage";
        }

        private IWebElement Logo => _driver.FindElement(By.XPath("//img[@alt='Home page']"));

        public void GoToUrl()
        {
            _driver.Navigate().GoToUrl(WelcomePageURL);
        }

        public void ClickLogo()
        {
            Logo.Click();
        }
    }
}
