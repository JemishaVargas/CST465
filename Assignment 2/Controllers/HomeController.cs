public class HomeController : Controller

{

    [Route("")]
    public IActionResult Index() 

    {
        ViewData["Title"] = "Home";
         return View(); 

    }
    [Route("ContactHTML")]
    public IActionResult ContactHTML()
    {
        ViewData["Title"] = "ContactHTML";
        return View();
    }
    [Route("ContactTagHelper")]
    public IActionResult ContactTagHelper()
    {
        ViewData["Title"] = "ContactTagHelper";
        return View();
    }

}