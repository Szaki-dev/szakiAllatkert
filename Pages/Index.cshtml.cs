using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using szakiAllatkert.Models;


namespace szakiAllatkert.Pages;

public class IndexModel : PageModel
{
    public List<Animal> Animals = new List<Animal>();
    [BindProperty]
    public Animal Animal { get; set; } = new Animal();
    const string path = "animals.csv";


    public void OnGet()
    {
        Animals = Animal.LoadFile(path);
    }

    public IActionResult OnPost()
    {
        Animals = Animal.LoadFile(path);
        if (!ModelState.IsValid)
        {
            return Page();
        }
        Animals.Add(Animal);
        System.IO.File.AppendAllText(path, $"{Animal.Name};{Animal.Species};{Animal.Age}\n");
        return RedirectToPage();
    }
}
