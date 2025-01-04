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
        string[] CpuD = CpuDetail.Split('-');
        ViewData["CpuData"] = Cpu;
        ViewData["CpuDetailData"] = CpuD;
        var Mem = _monitorService.RunScript("/app/scripts/Memory/UsingMem.sh");
        ViewData["MemoryData"] = Mem;
        var CachedMem = _monitorService.RunScript("/app/scripts/Memory/CachedMem.sh");
        ViewData["CacheData"] = CachedMem;
        var SwapMem = _monitorService.RunScript("/app/scripts/Memory/SwapMem.sh");
        ViewData["SwapData"] = SwapMem;
        var disk = _monitorService.RunScript("/app/scripts/Disk/wholeDisk.sh");
        ViewData["DiskData"] = disk;
        var Network = _monitorService.RunScript("/app/scripts/Network/network_monitor.sh");
        string[] NetworkD = Network.Split('*');
        ViewData["NetworkData"] = NetworkD;
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

    [HttpGet("Monitoring/GetNetworkData")]
    public IActionResult GetNetworkData()
    {
        try
        {
            var networkData = _monitorService.RunScript("/app/scripts/Network/network_monitor.sh");
            string[] networkDetails = networkData.Split('*');
            return Json(new
            {
                success = true,
                networkData = networkDetails
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