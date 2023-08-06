//This is just for testing and learning
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace TradeAlgos808.Controllers;

public class HelloWorldController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }

    // GET: /HelloWorld/Welcome/ 
    // Requires using System.Text.Encodings.Web;
    //Use this : https://localhost:7146/HelloWorld/Welcome?name=Ashesh&numTimes=8
    public string Welcome(string name, int numTimes = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
    }
    //Testing out by 808
    public int[] Test()
    {
        int[] arr = { 8, 0, 8};
        return arr;
    }

}