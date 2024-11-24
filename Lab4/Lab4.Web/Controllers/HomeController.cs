using Lab4.Objects;
using Lab4.Web;
public class HomeController : Controller

{
    
    public IActionResult Index() 

    {

         return View(); 

    }

    public IActionResult Laborers()
    {
        ChoreWorkforce myWorkforce = new ChoreWorkforce();
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Bob", Age = 7, Difficulty = 5 });
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Amy", Age = 8, Difficulty = 6 });
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Frank", Age = 5, Difficulty = 3 });
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Tina", Age = 6, Difficulty = 4 });
        for(int i = 0; i < 30; i++)
        {
            myWorkforce.AddRandomLaborer();
        }

        ChoreWorkforce filtered = new ChoreWorkforce();
        foreach(ChoreLaborer laborer in myWorkforce.Laborers.Where(labor => ((labor?.Difficulty ?? 0) < 7) && ((labor?.Age ?? 0) <= 10) && ((labor?.Age ?? 0) >= 3)))
        {
            filtered.AddLaborer(laborer.Name, laborer.Age, laborer.Difficulty);
        }
        ChoreWorkforce sorted = new ChoreWorkforce();
        foreach(ChoreLaborer laborer in filtered.Laborers.OrderBy(labor => labor?.Name ?? ""))
        {
            sorted.AddLaborer(laborer.Name, laborer.Age, laborer.Difficulty);
        }

        return View(sorted);
    }
}