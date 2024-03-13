using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MyNewMVC.Controllers;

public class WelcomeController : Controller
{
    // 
    // GET: /Welcome/
    public string Index()
    {
        return "There is noting here....go away";
    }
    // 
    // GET: /Welcome/Welcome/ 
    public IActionResult Somthing()
    {
        return View();
    }
}