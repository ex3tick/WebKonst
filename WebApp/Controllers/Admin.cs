using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class Admin : Controller
{
    // GET
    public IActionResult Index2()
    {
        return View();
    }
}