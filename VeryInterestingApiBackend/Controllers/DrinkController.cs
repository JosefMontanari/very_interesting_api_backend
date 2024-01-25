using Microsoft.AspNetCore.Mvc;
using VeryInterestingApiBackend.Models;

namespace VeryInterestingApiBackend.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DrinkController : ControllerBase
    {
        public static List<Drink> Drinks { get; set; } = new()
        {
            new Drink
            {
                Id = 1,
                Name = "Margarita",
                Ingredients = new List<string>(){"Tequila", "Triple Sec", "Lime Juice", "Salt"},
                Description = "Doesn't taste like the pizza"
            },
            new Drink
            {
                Id=2,
                Name = "Mojito",
                Ingredients = new List<string>(){"White rum", "Sugar", "Lime Juice", "Soda Water", "Mint"},
                Description = "A traditional Cuban punch."
            },
            new Drink
            {
                Id = 3,
                Name = "Long Island Iced Tea",
                Ingredients = new List<string>(){"Vodka", "Tequila", "Light Rum", "Triple sec", "Gin", "Lemon juice", "Cola"},
                Description = "Despite its name, the cocktail does not typically contain iced tea."
            },
            new Drink
            {
                Id = 4,
                Name = "Cosmopolitan",
                Ingredients = new List < string >() { "Vodka", "Triple sec", "Cranberry juice", "Fresh lime juice" },
                Description = "Though often presented far differently, the cosmopolitan also bears a likeness in composition to the kamikaze cocktail."
            },
            new Drink
            {
                Id = 5,
                Name = "Pina Colada",
                Ingredients = new List<string>(){"Light rum", "Coconut cream", "Pineapple juice"},
                Description = "A tropical blend of rich coconut cream, white rum and tangy pineapple – serve with an umbrella for kitsch appeal."
            }
        };

        [HttpGet]
        public ActionResult<List<Drink?>> Get()
        {
            // Returnera en lista med drinkar
            if (Drinks != null && Drinks.Any())
            {
                return Ok(Drinks);
            }
            return NotFound("Could not find any drinks");
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Drink?> Get(int id)
        {
            Drink? drink = Drinks.FirstOrDefault(x => x.Id == id);
            if (drink != null)
            {
                // Kunde hitta en drink
                return Ok(drink);
            }
            return NotFound("Could not find a drink with that Id");
        }

        [HttpPost]
        public ActionResult Post(Drink drink)
        {
            if (drink != null)
            {
                Drinks.Add(drink);
                return Ok("Drink added!");
            }
            return BadRequest("Could not add that drink, check your Json and try again!");
        }
        [HttpPut]
        public ActionResult Put(Drink drink, int id)
        {
            Drink? drinkToReplace = Drinks.FirstOrDefault(drink => drink.Id == id);
            if (drinkToReplace != null && drink != null)
            {
                Drinks.Remove(drinkToReplace);
                Drinks.Add(drink);
                return Ok("The drink has been changed!");
            }
            return BadRequest("Check your inputs and try again!");

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Drink? drink = Drinks.FirstOrDefault(d => d.Id == id);
            if (drink != null)
            {
                Drinks.Remove(drink);
                return Ok("Drink removed!");
            }
            return BadRequest("Check your inputs and try again!");
        }
    }
}
