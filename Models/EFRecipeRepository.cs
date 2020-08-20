using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject_JuheeKim.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {

        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;
        public IQueryable<Cuisine> Cuisines => context.Cuisines;

        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.Id == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe recipeEntry = context.Recipes
                    .FirstOrDefault(r => r.Id == recipe.Id);

                if (recipeEntry != null)
                {
                    recipeEntry.CuisineId = recipe.CuisineId;
                    recipeEntry.Name = recipe.Name;
                    recipeEntry.Description = recipe.Description;
                    recipeEntry.Ingredients = recipe.Ingredients;
                    recipeEntry.PreparationTime = recipe.PreparationTime;
                }
            }

            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int recipeId)
        {
            Recipe recipeEntry = context.Recipes
                   .FirstOrDefault(p => p.Id == recipeId);

            if (recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }

            return recipeEntry;
        }

        public void SaveCuisine(Cuisine cuisine)
        {
            if (cuisine.CuisineId == 0)
            {
                context.Cuisines.Add(cuisine);
            }
            else
            {
                Cuisine cuisineEntry = context.Cuisines
                    .FirstOrDefault(r => r.CuisineId == cuisine.CuisineId);

                if (cuisineEntry != null)
                {
                    cuisineEntry.CuisineId = cuisine.CuisineId;
                    cuisineEntry.Type = cuisine.Type;
                }
            }

            context.SaveChanges();
        }

        public Cuisine DeleteCuisine(int cuisineId)
        {
            Cuisine cuisineEntry = context.Cuisines
                   .FirstOrDefault(p => p.CuisineId == cuisineId);

            if (cuisineEntry != null)
            {
                context.Cuisines.Remove(cuisineEntry);
                context.SaveChanges();
            }

            return cuisineEntry;
        }

    }
    
}
