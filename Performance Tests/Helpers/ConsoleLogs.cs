using PerformanceTests.Tests;

namespace PerformanceTests.Helpers
{
    public class ConsoleLogs : BaseSetup
    {
        private readonly IWebDriver driver;
        private readonly string outputDirectory;

        public ConsoleLogs(IWebDriver driver, string outputDirectory)
        {
            this.driver = driver;
            this.outputDirectory = outputDirectory;
        }

        public void ProcessConsoleErrors(string jsonName)
        {
            var consoleErrors = driver.Manage().Logs.GetLog(LogType.Browser);
            if (consoleErrors.Count > 0)
            {
                Console.WriteLine("There are some issues on this page:");

                foreach (var error in consoleErrors)
                {
                    Console.WriteLine($"Level: {error.Level}");
                    Console.WriteLine($"Message: {error.Message}");
                    Console.WriteLine($"Timestamp: {error.Timestamp}");
                }

                var errorInfo = new
                {
                    Url = driver.Url,
                    Errors = consoleErrors
                };

                var json = JsonConvert.SerializeObject(errorInfo, Formatting.Indented);

                var outputFile = Path.Combine(outputDirectory, jsonName + PageLoadTimeHelper.TimeStamp() + ".json");

                File.WriteAllText(outputFile, json);

                Console.WriteLine($"Console errors saved to {outputFile}");
            }
            else
            {
                Console.WriteLine("There are no problems");
            }
        }
    }
}
