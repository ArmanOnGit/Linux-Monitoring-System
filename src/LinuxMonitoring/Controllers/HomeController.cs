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
        return View();
    }
}
