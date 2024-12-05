using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab9;

[Route("Admin")]
[Authorize]
public class AdminController : Controller
{

    [Route("")]
    public IActionResult Index() 
    {
        return View(); 

    }
}