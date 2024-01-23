using Performance_Tests.Models;
using PerformanceTests.Tests;
using System.Reflection;

namespace Performance_Tests
{
    public class Config
    {
        public string Port { get; set; }
        public string OutputFiles { get; set; }
        public string Categories { get; set; }
        public string OutputDirectory { get; set; }
        public List<DeviceConfig> DeviceConfs { get; set; }
        public List<HomePageUrl> HomePageUrls { get; set; }

        private static readonly string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "config.json");

        public static Config LoadConfigFromFile()
        {
            if (File.Exists(configFilePath))
            {
                string jsonString = File.ReadAllText(configFilePath);
                return JsonConvert.DeserializeObject<Config>(jsonString);
            }
            else
            {
                throw new FileNotFoundException($"Config file not found at: {configFilePath}");
            }
        }
        public static string GetPortFromConfig()
        {
            Config config = LoadConfigFromFile();
            return config.Port;
        }

        // Method to get the OutputFiles value from the configuration file
        public static string GetOutputFilesFromConfig()
        {
            Config config = LoadConfigFromFile();
            return config.OutputFiles;
        }

        // Method to get the Categories value from the configuration file
        public static string GetCategoriesFromConfig()
        {
            Config config = LoadConfigFromFile();
            return config.Categories;
        }

        public static string GetOutputDirectoryFromConfig()
        {
            Config config = LoadConfigFromFile();
            return config.OutputDirectory;
        }

        public static IEnumerable<TestCaseData> DeviceConfsData()
        {
            foreach (var deviceConfig in LoadConfigFromFile().DeviceConfs)
            {
                yield return new TestCaseData(deviceConfig.Name, deviceConfig.Width, deviceConfig.Height, deviceConfig.PixelRatio);
            }
        }

        public static IEnumerable<TestCaseData> HomePageUrlsData()
        {
            foreach (var homePageUrl in LoadConfigFromFile().HomePageUrls)
            {
                yield return new TestCaseData(homePageUrl.Url, homePageUrl.Domain);
            }
        }

        public static IEnumerable<TestCaseData> HomePageData()
        {
            foreach (var deviceData in DeviceConfsData())
            {
                foreach (var urlData in HomePageUrlsData())
                {
                    yield return new TestCaseData(deviceData.Arguments.Concat(urlData.Arguments).ToArray());
                }
            }
        }

        public static IEnumerable<string> LoginPageTestMethods()
        {
            Type homePageTestsType = typeof(LighthouseReportTest);
            MethodInfo[] methods = homePageTestsType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                if (method.DeclaringType == homePageTestsType)
                {
                    yield return method.Name;
                }
            }
        }

        public static List<string> GetCombinedData()
        {
            IEnumerable<string> deviceConfs = DeviceConfsData().Select(tc => (string)tc.Arguments[0]);
            IEnumerable<string> methodNames = LoginPageTestMethods();
            IEnumerable<string> urls = HomePageUrlsData().Select(tc => (string)tc.Arguments[1]);

            List<string> combinedDataList = new List<string>();

            foreach (string deviceConf in deviceConfs)
            {
                foreach (string url in urls)
                {
                    foreach (string methodName in methodNames)
                    {
                        combinedDataList.Add($"{deviceConf}-{url}-{methodName}");
                    }
                }
            }

            return combinedDataList;
        }
    }
}
