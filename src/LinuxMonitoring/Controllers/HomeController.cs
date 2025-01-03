using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly SystemMonitorService _monitorService;

    public HomeController()
    {
        _monitorService = new SystemMonitorService();
    }

    public IActionResult Index()
    {
        var Cpu = _monitorService.RunScript("/app/scripts/Cpu/CPU.sh");
        var CpuDetail = _monitorService.RunScript("/app/scripts/Cpu/CpuDetail.sh");
        string [] CpuD = CpuDetail.Split('-');
        ViewData["CpuData"] = Cpu;
        ViewData["CpuDetailData"] = CpuD;
        var Mem =_monitorService.RunScript("/app/scripts/Memory/UsingMem.sh");
        ViewData["MemoryData"] = Mem;
        var CachedMem = _monitorService.RunScript("/app/scripts/Memory/CachedMem.sh");
        ViewData["CacheData"] = CachedMem;
        var SwapMem = _monitorService.RunScript("/app/scripts/Memory/SwapMem.sh");
        ViewData["SwapData"] = SwapMem;
        var disk = _monitorService.RunScript("/app/scripts/Disk/wholeDisk.sh");
        ViewData["DiskData"] = disk;
        var Network = _monitorService.RunScript("/app/scripts/Network/network_monitor.sh");
        string [] NetworkD = Network.Split('*');
        ViewData["NetworkData"] = NetworkD;
        //var Sysinfo = _monitorService.RunScript("/app/scripts/General/SystemInfo.sh");
        //string [] SysinfoD = Sysinfo.Split('&');
        //ViewData["Sysinfo"] = SysinfoD;
        //var Uptime = _monitorService.RunScript("/app/scripts/General/Uptime.sh");
        //string[] SystemUptimeD = Uptime.Split("&");
        //ViewData["Uptime"] = SystemUptimeD;
        //var SystemTime = _monitorService.RunScript("/app/scripts/General/Time.sh");
        //string [] SystemTimeD = SystemTime.Split('&');
        //ViewData["SystemTime"] = SystemTimeD;
        return View();
    }


    [HttpGet("Monitoring/GetSystemInfo")]
    public IActionResult GetSystemInfo()
    {
        try
        {
            var sysinfo = _monitorService.RunScript("/app/scripts/General/SystemInfo.sh");
            string[] sysinfoDetails = sysinfo.Split('&');

            return Json(new
            {
                success = true,
                systemInfo = sysinfoDetails
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                success = false,
                error = ex.Message
            });
        }
    }


    [HttpGet("Monitoring/GetSystemTime")]
    public IActionResult GetSystemTime()
    {
        try
        {
            // Run the Time script and process the output
            var systemTime = _monitorService.RunScript("/app/scripts/General/Time.sh");
            string[] systemTimeDetails = systemTime.Split("&");
            // Return the data as JSON
            return Json(new
            {
                success = true,
                systemTime = systemTimeDetails
            });
        }
        catch (Exception ex)
        {
            // Return an error message if something goes wrong
            return Json(new
            {
                success = false,
                error = ex.Message
            });
        }
    }


    [HttpGet("Monitoring/GetSystemUptime")]
    public IActionResult GetSystemUptime()
    {
        try
        {
            var uptime = _monitorService.RunScript("/app/scripts/General/Uptime.sh");
            string[] systemUptimeDetails = uptime.Split("&");

            return Json(new
            {
                success = true,
                systemUptime = systemUptimeDetails
            });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                success = false,
                error = ex.Message
            });
        }
    }
}
