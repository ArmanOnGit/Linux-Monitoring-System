using System.Diagnostics;

public class SystemMonitorService
{
    public string RunScript(string scriptPath)
    {
        var process = new Process();
        process.StartInfo.FileName = "/bin/bash";
        process.StartInfo.Arguments = scriptPath;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        return output;
    }
}
