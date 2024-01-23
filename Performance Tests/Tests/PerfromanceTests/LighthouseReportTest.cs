using Performance_Tests;
using PerformanceTests.Helpers;
using PerformanceTests.POM;
using System.Reflection;

namespace PerformanceTests.Tests
{
    public class LighthouseReportTest : BaseSetup
    {
        [Test]
        [TestCaseSource(typeof(Config), nameof(Config.HomePageData))]
        [Description("Lighthouse report of: LoginPage")]
        public void LoginPageTest(string device, int width, int height, int deviceScaleFactor, string url, string website)
        {
            driver.Navigate().GoToUrl(url);

            Assert.That(driver.Url.Contains("loginPage.com"));
            new LighthouseAudit(URL: driver.Url,
                                ReportName: device + "-" + website + "-" + MethodBase.GetCurrentMethod().Name + "-" + PageLoadTimeHelper.TimeStamp(),
                                device: device,
                                width: width,
                                height: height,
                                deviceScaleFactor: deviceScaleFactor,
                                driver: driver);
        }
        [Test]
        [TestCaseSource(typeof(Config), nameof(Config.HomePageData))]
        [Description("Lighthouse report of: WelcomePage")]
        public void WelcomePageTest(string device, int width, int height, int deviceScaleFactor, string url, string website)
        {
            driver.Navigate().GoToUrl(url);
            new LoginPage(driver, url).LoginIn();
            new WelcomePage(driver, url).GoToUrl();

            Assert.That(driver.Url.Contains("WelcomePage.com"));
            new LighthouseAudit(URL: driver.Url,
                                ReportName: device + "-" + website + "-" + MethodBase.GetCurrentMethod().Name + "-" + PageLoadTimeHelper.TimeStamp(),
                                device: device,
                                width: width,
                                height: height,
                                deviceScaleFactor: deviceScaleFactor,
                                driver: driver);
        }
    }
}

