namespace PerformanceTests.POM
{
    public class LoginPage : BasePage
    {
        private IWebDriver _driver;
        private string _username = "performance";
        private string _password = "test";
        public string LoginPageURL { get; }

        public LoginPage(IWebDriver driver, string url)
        {
            this._driver = driver;
            this.LoginPageURL = $"{url}login";
        }

        public void GoToUrl()
        {
            _driver.Navigate().GoToUrl(LoginPageURL);
        }
        private IWebElement UserNameInput => _driver.FindElement(By.Name("UserName"));
        private IWebElement PasswordInput => _driver.FindElement(By.Name("Password"));
        private IWebElement LoginInButton => _driver.FindElement(By.XPath("//button[@type='submit']"));



        public void LoginIn()
        {
            UserNameInput.SendKeys(_username);
            PasswordInput.SendKeys(_password);
            LoginInButton.Click();

        }
    }
}
