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
        var Cpu = _monitorService.RunCpu("/app/scripts/CPU.sh");
        var CpuDetail = _monitorService.RunCpuDetail("/app/scripts/CpuDetail.sh");
        string [] CpuD = CpuDetail.Split('-');
        ViewData["CpuData"] = Cpu;
        ViewData["CpuDetailData"] = CpuD;

        return View();
    }
}
