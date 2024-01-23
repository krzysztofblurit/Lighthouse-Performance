namespace PerformanceTests.Helpers
{
    public static class PageLoadTimeHelper
    {
        public static double GetLoadTimeSeconds(IWebDriver driver, string timingEvent)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            /*            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("body")));*/
            wait.Until(driver => ((IJavaScriptExecutor)driver)
                .ExecuteScript("return document.readyState").Equals("complete"));
            long loadTime = (long)((IJavaScriptExecutor)driver)
                .ExecuteScript($"return window.performance.timing.{timingEvent}");

            double loadTimeSeconds = loadTime / 1000.0;
            Assert.IsNotNull(loadTimeSeconds);
            return loadTimeSeconds;
        }
        public static void SmartWait(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public static string TimeStamp() => DateTime.Now.ToString("yyyyMMddHHmmssfff");
    }
}
