using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TradeAlgos808.Models;
namespace TradeAlgos808.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<ActionResult> Index()
    {
        string apiUrl = "https://www.alphavantage.co/query"; // API endpoint URL
        string apiKey = "DLLF3V8I0GWA7MJG"; // Replace with your API key

        string function = "LISTING_STATUS";
        string state = "active"; // or "delisted"
        string date = ""; // Optionally, set a specific date

        string url = $"{apiUrl}?function={function}&state={state}&date={date}&apikey={apiKey}";


        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var csvData = await response.Content.ReadAsStringAsync();

                // Process the CSV data
                var stockData = ParseCsvData(csvData);

                // Pass the stockData to a view or perform further operations
                return View(stockData);
            }
            else
            {
                // Handle API error response
                // You can redirect to an error page or display a suitable error message
                return View("Error");
            }
        }
    }

    private List<StockViewModel> ParseCsvData(string csvData)
    {
        var stockData = new List<StockViewModel>();

        using (var reader = new StringReader(csvData))
        {
            string? line;
            bool isFirstLine = true;

            while ((line = reader.ReadLine()) != null)
            {
                if (isFirstLine)
                {
                    // Skip the header line
                    isFirstLine = false;
                    continue;
                }

                var values = line.Split(',');

                // Map the values to your Stock model properties
                var stock = new StockViewModel
                {
                    Symbol = values[0],
                    Name = values[1],
                    Exchange = values[2],
                    Type = values[3]
                };

                stockData.Add(stock);
            }
        }

        return stockData;
    }


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