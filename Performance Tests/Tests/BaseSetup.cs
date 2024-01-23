using Performance_Tests;

namespace PerformanceTests.Tests
{
    public class BaseSetup
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new();
            options.AddArguments($"--remote-debugging-port={Config.GetPortFromConfig()}");
            options.AddArgument("--whitelisted-ips=");
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-cache");
            options.AddArgument("--disable-application-cache");
            options.AddArgument("--disable-gpu-shader-disk-cache");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--no-sandbox");
            driver = new ChromeDriver(@"Drivers", options);
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AverageTime.AverageTimeForEveryPage();
        }

    }

}
