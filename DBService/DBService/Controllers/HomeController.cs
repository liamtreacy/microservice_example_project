using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DBService.Models;

namespace DBService.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMessageReceiver _messageReceiver;

    public HomeController(ILogger<HomeController> logger, IMessageReceiver messageReceiver)
    {
        _logger = logger;
        _messageReceiver = messageReceiver;
    }

    public IActionResult Index()
    {
        return View(_messageReceiver.GetLatestReceivedNumber());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
