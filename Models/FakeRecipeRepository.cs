using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject_JuheeKim.Models
{
    public class FakeRecipeRepository /*: IRecipeRepository*/
    {
        public IQueryable<Recipe> Recipes => new List<Recipe>
                {
                    new Recipe {Name="Birthday Seaweed Soup", Description="Des", Ingredients="Ing", Chef="Courtney Kim", PreparationTime=35, CookingTime=60},
                    new Recipe {Name="Chocolate Pancake", Description="Des", Ingredients="Ing", Chef="Courtney Kim", PreparationTime=35, CookingTime=60},
                    new Recipe {Name="Creamy Shrimp Pasta", Description="Des", Ingredients="Ing", Chef="Courtney Kim", PreparationTime=35, CookingTime=60},
                    new Recipe {Name="French Onion Soup", Description="Des", Ingredients="Ing", Chef="Courtney Kim", PreparationTime=35, CookingTime=60},
                    new Recipe {Name="Summer Pasta Salad", Description="Des", Ingredients="Ing", Chef="Courtney Kim", PreparationTime=35, CookingTime=60},
                    new Recipe {Name="Grilled Salmon Steak", Description="Des", Ingredients="Ing", Chef="Courtney Kim", PreparationTime=35, CookingTime=60}
                }.AsQueryable<Recipe>();
    }
}
