using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    // public async Task<ActionResult> Today()
    // {
    //     var stockService = new StockService();
    //     var stockData = await stockService.GetStockDataAsync();

    //     if (stockData != null)
    //     {
    //         var stockViewModels = stockData.Select(d => new StockViewModel
    //         {
    //             Symbol = d.symbol,
    //             Name = d.name,
    //             Currency = d.currency
    //             // Initialize other properties as needed
    //         });

    //         return View(stockViewModels);
    //     }
    //     else
    //     {
    //         // Handle error or display a message to the user
    //         return View("Error");
    //     }
    // }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
