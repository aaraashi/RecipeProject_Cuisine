using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject_JuheeKim.Models
{
    public static class Repository
    {
        private static List<Recipe> recipes = new List<Recipe>();
        private static List<RecipeReview> reviews = new List<RecipeReview>();

        // to see filtering mechanism
        public static IEnumerable<Recipe> Recipes
        {
            get
            {
                return recipes;
            }
        }

        public static void AddRecipe(Recipe newRecipe)
        {
            recipes.Add(newRecipe);
        }
        
        public static void AddReview(RecipeReview newReview)
        {
            reviews.Add(newReview);
        }
    }
}
