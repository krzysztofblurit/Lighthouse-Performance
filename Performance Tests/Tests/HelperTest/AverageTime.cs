using Performance_Tests;

namespace PerformanceTests.Tests
{
    public class AverageTime : BaseSetup
    {
        public static void AverageTimeForEveryPage()
        {
            string averageTimeReportDirectory = Path.Combine(Config.GetOutputDirectoryFromConfig(), "AverageScoreReport");
            Directory.CreateDirectory(averageTimeReportDirectory);

            List<string> pages = Config.GetCombinedData();
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");


            foreach (string pageReport in pages)
            {
                List<string> fileNames = Directory.GetFiles(Config.GetOutputDirectoryFromConfig(), $"*{pageReport}*.json").ToList();

                if (fileNames.Count == 0)
                {
                    Console.WriteLine($"No files found for {pageReport}. Skipping report generation.");
                    continue;
                }

                var result = new
                {
                    FirstContentfulPaint = CalculateAverageTime(fileNames, "first-contentful-paint"),
                    LargestContentfulPaint = CalculateAverageTime(fileNames, "largest-contentful-paint"),
                    FirstMeaningfulPaint = CalculateAverageTime(fileNames, "first-meaningful-paint"),
                    SpeedIndex = CalculateAverageTime(fileNames, "speed-index"),
                    TotalBlockingTime = CalculateAverageTime(fileNames, "total-blocking-time"),
                    MaxPotentialFid = CalculateAverageTime(fileNames, "max-potential-fid"),
                    CumulativeLayoutShift = CalculateAverageTime(fileNames, "cumulative-layout-shift"),
                    ServerResponseTime = CalculateAverageTime(fileNames, "server-response-time"),
                    Interactive = CalculateAverageTime(fileNames, "interactive"),
                    Redirects = CalculateAverageTime(fileNames, "redirects"),
                    MainThreadWorkBreakdown = CalculateAverageTime(fileNames, "mainthread-work-breakdown"),
                    BootupTime = CalculateAverageTime(fileNames, "bootup-time"),
                    NetworkRtt = CalculateAverageTime(fileNames, "network-rtt"),
                    NetworkServerLatency = CalculateAverageTime(fileNames, "network-server-latency")
                };

                string outputJson = JsonConvert.SerializeObject(result);
                string outputFilePath = Path.Combine(averageTimeReportDirectory, $"{pageReport}_average_time_{timestamp}.json");
                File.WriteAllText(outputFilePath, outputJson);

                Console.WriteLine($"Average time calculated and written to {pageReport}_average_time_{timestamp}.json.");
            }
        }

        public static double CalculateAverageTime(List<string> fileNames, string auditKey)
        {
            List<double> time = new List<double>();

            foreach (string fileName in fileNames)
            {
                string jsonContent = File.ReadAllText(fileName);
                dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

                if (jsonData.audits.ContainsKey(auditKey))
                {
                    double numericValueMilliseconds = jsonData.audits[auditKey].numericValue;
                    double numericValueSeconds = numericValueMilliseconds / 10000.0; // Konwersja na sekundy
                    time.Add(numericValueSeconds);
                }
            }

            return time.Count > 0 ? time.Average() : 0.0; // Jeżeli nie ma wyników, zwróć 0.0
        }
    }
}