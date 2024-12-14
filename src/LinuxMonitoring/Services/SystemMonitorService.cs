using System.Diagnostics;

public class SystemMonitorService
{
    public string RunCpu(string scriptPath)
    {
        var process = new Process();
        process.StartInfo.FileName = "/bin/bash";
        process.StartInfo.Arguments = scriptPath;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        string Cpu = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        return Cpu;
    }
    public string RunCpuDetail(string scriptPath)
    {
        var process = new Process();
        process.StartInfo.FileName = "/bin/bash";
        process.StartInfo.Arguments = scriptPath;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        string CpuDetail = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        return CpuDetail;
    }
}
