using Microsoft.AspNetCore.Mvc;

namespace Lab9;

[Route("")]
[Route("Home")]
public class HomeController : Controller
{

    [Route("")]
    [Route("Index")]
    public IActionResult Index() 
    {
        return View(); 

    }
}