namespace PerformanceTests.Tests
{
    public class ConsoleLogCatch : BaseSetup
    {
        /*[Test]
        [TestCaseSource(typeof(Config), nameof(Config.HomePageData))]
        [Description("Check Errors in cosnole of: LoginPage /login?returnUrl=%2F\"")]
        public void LoginPageLogs(string device, int width, int height, int deviceScaleFactor, string url, string website)
        {
            driver.Navigate().GoToUrl(url);
            Assert.That(driver.Url.Contains("/login"));

            new ConsoleLogs(driver, Config.GetOutputDirectoryFromConfig()).ProcessConsoleErrors(MethodBase.GetCurrentMethod().Name);
        }
        [Test]
        [TestCaseSource(typeof(Config), nameof(Config.HomePageData))]
        [Description("Check Errors in cosnole of: WelcomePage /welcomepage")]
        public void WelcomePageLogsTest(string device, int width, int height, int deviceScaleFactor, string url, string website)
        {
            driver.Navigate().GoToUrl(url);

            new LoginPage(driver, url).LoginIn();
            new WelcomePage(driver, url).GoToUrl();

            Assert.That(driver.Url.Contains("/welcomepage"));

            new ConsoleLogs(driver, Config.GetOutputDirectoryFromConfig()).ProcessConsoleErrors(MethodBase.GetCurrentMethod().Name);
        }
        [Test]
        [TestCaseSource(typeof(Config), nameof(Config.HomePageData))]
        [Description("Check Errors in cosnole of: IdeaManagement /IdeaManagement/List/9?page=1&itemsPerPage=30")]
        public void IdeaManagmentPageLogsTest(string device, int width, int height, int deviceScaleFactor, string url, string website)
        {
            driver.Navigate().GoToUrl(url);

            new LoginPage(driver, url).LoginIn();
            new IdeaManagementPage(driver, url).GoToUrl();

            Assert.That(driver.Url.Contains("/IdeaManagement"));

            new ConsoleLogs(driver, Config.GetOutputDirectoryFromConfig()).ProcessConsoleErrors(MethodBase.GetCurrentMethod().Name);
        }
        [Test]
        [TestCaseSource(typeof(Config), nameof(Config.HomePageData))]
        [Description("Check Errors in cosnole of: SubmitPage /Spaces/9/SubmitIdea")]
        public void SubmitIdeaPageLogsTest(string device, int width, int height, int deviceScaleFactor, string url, string website)
        {
            driver.Navigate().GoToUrl(url);

            new LoginPage(driver, url).LoginIn();
            new SubmitIdeaPage(driver, url).GoToUrl();

            Assert.That(driver.Url.Contains("/Spaces/9/SubmitIdea"));

            new ConsoleLogs(driver, Config.GetOutputDirectoryFromConfig()).ProcessConsoleErrors(MethodBase.GetCurrentMethod().Name);
        }
        [Test]
        [TestCaseSource(typeof(Config), nameof(Config.HomePageData))]
        [Description("Check Errors in cosnole of: Idea 088078 /IdeaManagement/Details/88078")]
        public void IdeaPageLogsTest(string device, int width, int height, int deviceScaleFactor, string url, string website)
        {
            driver.Navigate().GoToUrl(url);

            new LoginPage(driver, url).LoginIn();
            new IdeaPage(driver, url).GoToUrlSimpleIdea();

            Assert.That(driver.Url.Contains("/88078"));

            new ConsoleLogs(driver, Config.GetOutputDirectoryFromConfig()).ProcessConsoleErrors(MethodBase.GetCurrentMethod().Name);
        }
        [Test]
        [TestCaseSource(typeof(Config), nameof(Config.HomePageData))]
        [Description("Check Errors in cosnole of: DataCenter /ReportingBrowser/SpaceDataCenters/9?dashboardId=329")]
        public void DataCenterPageLogsTest(string device, int width, int height, int deviceScaleFactor, string url, string website)
        {
            driver.Navigate().GoToUrl(url);

            new LoginPage(driver, url).LoginIn();
            new DataCenterPage(driver, url).GoToUrl();

            Assert.That(driver.Url.Contains("/ReportingBrowser/SpaceDataCenters/9?dashboardId=329"));

            new ConsoleLogs(driver, Config.GetOutputDirectoryFromConfig()).ProcessConsoleErrors(MethodBase.GetCurrentMethod().Name);
        }*/
    }
}
