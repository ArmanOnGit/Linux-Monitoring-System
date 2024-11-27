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
        var output = _monitorService.RunBashScript("/app/scripts/cpuFreePercentage.sh");
        ViewData["SystemData"] = output;
        return View();
    }
}
