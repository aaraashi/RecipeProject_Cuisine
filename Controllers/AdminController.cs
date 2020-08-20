using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipesProject_JuheeKim.Models;
using RecipesProject_JuheeKim.ViewModels;

namespace RecipesProject_JuheeKim.Controllers
{
    public class AdminController : Controller
    {
        private IRecipeRepository repository;

        public AdminController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult RecipeList()
        => View(repository.Recipes);

        [HttpGet]
        public ViewResult EditRecipe(int recipeId)
        {
            var cuisines = repository.Cuisines.ToList();

            var viewModel = new RecipeCuisionViewModel
            {
                Recipe = repository.Recipes
                    .FirstOrDefault(p => p.Id == recipeId),
                Cuisines = cuisines
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                //return View("Index", repository.Products);

                var viewModel = new RecipeCuisionViewModel
                {
                    Recipe = recipe
                };

                TempData["message"] = $"{recipe.Name} was saved!";
                return RedirectToAction("RecipeList");
            }
            else
            {
                // stay in the same page and show the input
                return View(recipe);
            }
        }

        public ViewResult CreateRecipe()
        {
            var cuisines = repository.Cuisines.ToList();

            var viewModel = new RecipeCuisionViewModel
            {
                Recipe = new Recipe(),
                Cuisines = cuisines
            };

            return View("EditRecipe", viewModel);
        }

        [HttpPost]
        public IActionResult DeleteRecipe(int recipeId)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeId);

            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted!";

            }
            return RedirectToAction("RecipeList");
        }


         public ViewResult CuisineList()
        => View(repository.Cuisines);

        [HttpGet]
        public ViewResult EditCuisine(int cuisineId)
        {
            var cuisines = repository.Cuisines.ToList();

            var viewModel = new RecipeCuisionViewModel
            {
                Cuisine = repository.Cuisines
                    .FirstOrDefault(c => c.CuisineId == cuisineId),
                Cuisines = cuisines
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult EditCuisine(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCuisine(cuisine);
                //return View("Index", repository.Products);

                var viewModel = new RecipeCuisionViewModel
                {
                    Cuisine = cuisine,
                    Cuisines = repository.Cuisines.ToList()
                };

                TempData["message"] = $"{cuisine.Type} was saved!";
                return RedirectToAction("CuisineList");
            }
            else
            {
                // stay in the same page and show the input
                return View(cuisine);
            }
        }

        public ViewResult CreateCuisine()
        {
            var cuisines = repository.Cuisines.ToList();

            var viewModel = new RecipeCuisionViewModel
            {
                Cuisine = new Cuisine(),
                Cuisines = cuisines
            };

            return View("EditCuisine", viewModel);
        }

        [HttpPost]
        public IActionResult DeleteCuisine(int cuisineId)
        {
            Cuisine deletedCuisine = repository.DeleteCuisine(cuisineId);

            if (deletedCuisine != null)
            {
                TempData["message"] = $"{deletedCuisine.Type} was deleted!";

            }
            return RedirectToAction("CuisineList");
        }
    }
}
