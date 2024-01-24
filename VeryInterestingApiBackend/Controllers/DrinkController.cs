using Microsoft.AspNetCore.Mvc;
using VeryInterestingApiBackend.Models;

namespace VeryInterestingApiBackend.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DrinkController : ControllerBase
    {
        public static List<Drink> Drinnks { get; set; } = new List<Drink>()
        {
            new Drink
            {
                Id = 1,
                Name = "Margarita",
                Ingredients = {"Tequila", "Triple Sec", "Lime Juice"}
            }
        };
    }
}
