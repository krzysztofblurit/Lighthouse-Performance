using Performance_Tests;
using PerformanceTests.Tests;
using System.Diagnostics;

namespace PerformanceTests.Helpers
{
    public class LighthouseAudit : BaseSetup
    {
        public LighthouseAudit(string URL, string ReportName, string device, int width, int height, int deviceScaleFactor, IWebDriver driver)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process process = new Process { StartInfo = startInfo };
            process.Start();

            StreamWriter streamWriter = process.StandardInput;
            string command = BuildLighthouseCommand(URL, ReportName, device, width, height, deviceScaleFactor);
            streamWriter.WriteLine(command);
            streamWriter.Close();

            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            process.WaitForExit();
        }

        private string BuildLighthouseCommand(string URL, string ReportName, string device, int width, int height, int deviceScaleFactor)
        {
            return $"lighthouse {URL} " +
                   $"--port={Config.GetPortFromConfig()} " +
                   $"--output={Config.GetOutputFilesFromConfig()} " +
                   $"--output-path={Config.GetOutputDirectoryFromConfig()}{ReportName} " +
                   $"--only-categories={Config.GetCategoriesFromConfig()} " +
                   $"--screenEmulation.width={width} " +
                   $"--screenEmulation.height={height} " +
                   $"--screenEmulation.deviceScaleFactor={deviceScaleFactor}";
        }
    }
}
