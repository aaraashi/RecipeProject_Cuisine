using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject_JuheeKim.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get;  }
        IQueryable<Cuisine> Cuisines { get; }

        void SaveRecipe(Recipe recipe);

        Recipe DeleteRecipe(int recipeId);

        void SaveCuisine(Cuisine cuisine);

        Cuisine DeleteCuisine(int cuisineId);

    }
}
