namespace Assignment_2;
public class HomeController : Controller
{

    [Route("")]
    public IActionResult Index() 

    {
        ViewData["Title"] = "Home";
        return View(); 

    }

    [HttpGet]
    [Route("ContactHTML")]
    public IActionResult ContactHTML()
    {
        ContactModel model = new ContactModel();
        ViewData["Title"] = "ContactHTML";
        return View(model);
    }

    [HttpGet]
    [Route("ContactTagHelper")]
    public IActionResult ContactTagHelper()
    {
        ContactModel model = new ContactModel();
        ViewData["Title"] = "ContactTagHelper";
        return View(model);
    }

    [HttpPost]
    [Route("ContactResult")]
    public IActionResult Contact(ContactModel model)
    {
        ViewData["Title"] = "ContactResults";
        return View(model);
    }

}