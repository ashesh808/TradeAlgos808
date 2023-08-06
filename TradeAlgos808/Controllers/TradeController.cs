using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace TradeAlgos808.Controllers;

public class TradeController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
}