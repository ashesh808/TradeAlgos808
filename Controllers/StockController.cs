using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers;

public class StockController : Controller
{
    // Other actions...

    public ActionResult Details(string stockId)
    {
        // Retrieve stock details using the stockId from your data source
        var stock = GetStockDetails(stockId);

        // Pass the stock details to the view
        return View(stock);
    }

    private StockViewModel GetStockDetails(string stockId)
    {
        string apiUrl = "https://www.alphavantage.co/query"; // API endpoint URL
        string apiKey = "DLLF3V8I0GWA7MJG"; // Replace with your API key

        string function = "OVERVIEW";
        string symbol = stockId;

        string url = $"{apiUrl}?function={function}&symbol={symbol}&apikey={apiKey}";

        var stock = new StockViewModel
        {
            Symbol = stockId,
            Name = "Some Name",
            Exchange = "Some Exchange ",
            Type = "Some Type",
            Description = "Some discription"
        };

        return stock;
    }

    private StockViewModel ParseCsvData(string csvData)
    {
        var stock = new StockViewModel
        {
            Symbol = " ",
            Name = " ",
            Exchange = " ",
            Type = " ",
            Description = " "
        };

        using (var reader = new StringReader(csvData))
        {
            string line;
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
                stock = new StockViewModel
                {
                    Symbol = values[0],
                    Name = values[2],
                    Exchange = values[5],
                    Type = values[1],
                    Description = values[3]
                };
            }
        }

        return stock;
    }
}
