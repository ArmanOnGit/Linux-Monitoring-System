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
        var disk = _monitorService.RunScript("/app/scripts/Disk/wholeDisk.sh");
        ViewData["DiskData"] = disk;
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

    [HttpGet("Monitoring/GetSystemTime")]
    public IActionResult GetSystemTime()
    {
        try
        {
            var systemTime = _monitorService.RunScript("/app/scripts/General/Time.sh");
            string[] systemTimeDetails = systemTime.Split("&");

            return Json(new
            {
                success = true,
                systemTime = systemTimeDetails
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

    [HttpGet("Monitoring/GetDiskData")]
    public IActionResult GetDiskData()
    {
        try
        {
            var diskData = _monitorService.RunScript("/app/scripts/Disk/wholeDisk.sh");
            return Json(new
            {
                success = true,
                diskData = diskData
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


    [HttpGet("Monitoring/GetMemoryData")]
    public IActionResult GetMemoryData()
    {
        try
        {
            var memoryData = _monitorService.RunScript("/app/scripts/Memory/UsingMem.sh");
            var cachedMemoryData = _monitorService.RunScript("/app/scripts/Memory/CachedMem.sh");
            var swapMemoryData = _monitorService.RunScript("/app/scripts/Memory/SwapMem.sh");

            return Json(new
            {
                success = true,
                memoryData = memoryData,
                cachedMemoryData = cachedMemoryData,
                swapMemoryData = swapMemoryData
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