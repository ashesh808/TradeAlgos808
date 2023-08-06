using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TradeAlgos808.Models;
using Newtonsoft.Json;

namespace TradeAlgos808.Controllers;

public class StockController : Controller
{
    // Other actions...

    public async Task<ActionResult> Details(string stockId)
    {
        // Retrieve stock details using the stockId from your data source
        string details_apiUrl = "https://www.alphavantage.co/query"; // API endpoint URL
        string details_apiKey = "ZJ5TTTG78YBAY1D8"; // Replace with your API key

        string details_function = "OVERVIEW";
        string details_symbol = stockId;

        string details_url = $"{details_apiUrl}?function={details_function}&symbol={details_symbol}&apikey={details_apiKey}";

//Does not work
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(details_url);
            var jsonData = await response.Content.ReadAsStringAsync();

            // Process the CSV data
            StockViewModel stock = JsonConvert.DeserializeObject<StockViewModel>(jsonData);
            return View(stock);
        }
    }
}

    // private async Task<ActionResult> GetStockDetails(string stockId)
    // {
    //     string apiUrl = "https://www.alphavantage.co/query"; // API endpoint URL
    //     string apiKey = "DLLF3V8I0GWA7MJG"; // Replace with your API key

    //     string function = "OVERVIEW";
    //     string symbol = stockId;

    //     string url = $"{apiUrl}?function={function}&symbol={symbol}&apikey={apiKey}";

    //     var stock = new StockViewModel
    //     {
    //         Symbol = stockId,
    //         Name = "Some Name",
    //         Exchange = "Some Exchange ",
    //         Type = "Some Type",
    //         Description = "Some discription"
    //     };
    //     using (HttpClient client = new HttpClient())
    //     {
    //         HttpResponseMessage response = await client.GetAsync(url);

    //         if (response.IsSuccessStatusCode)
    //         {
    //             var csvData = await response.Content.ReadAsStringAsync();

    //             // Process the CSV data
    //             var stockData = ParseCsvData(csvData);
    //         }
    //     }

    //     return stock;
    // }
