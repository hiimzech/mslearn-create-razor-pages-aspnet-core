using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoPizza.Services;
using ContosoPizza.Models;
using System.Security.Permissions;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _pizzaService;
        public IList<Pizza> pizzaList { get; set; } = default!;

        public PizzaListModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public void OnGet()
        {
            pizzaList = _pizzaService.GetPizzas();
        }

        public IActionResult OnPostDelete(int id)
        {
            _pizzaService.DeletePizza(id);
            return RedirectToAction("Get");
        }

        [BindProperty]
        public Pizza newPizza { get; set; } = default!;

        public IActionResult OnPost()
        {
            if (ModelState.IsValid && newPizza != null)
            {
                _pizzaService.AddPizza(newPizza);
                return RedirectToAction("Get");
            }
            return Page();
        }
    }
}