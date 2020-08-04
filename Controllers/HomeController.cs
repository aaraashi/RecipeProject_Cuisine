using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipesProject_JuheeKim.Models;

namespace RecipesProject_JuheeKim.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository repository;

        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult RecipeList()
        => View(repository.Recipes);

        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddRecipe(Recipe newRecipe)
        {
            if (repository.Recipes.Any())
            {
                newRecipe.Id = repository.Recipes.Max(r => r.Id) + 1;
            }
            else
            {
                newRecipe.Id = 1;
            }
            repository.SaveRecipe(newRecipe);
            return View();
        }

        [Route("Recipes/ViewRecipe/{id}")]
        public ViewResult ViewRecipe(int id)
        {
            var recipe = repository.Recipes
                        .SingleOrDefault(r => r.Id == id);

            return View(recipe);

        }

        [HttpGet]
        public ViewResult ReviewRecipe()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ReviewRecipe(RecipeReview newReview)
        {
            //repository.AddReview(newReview);
            return View();
        }

        [HttpGet]
        public ViewResult EditRecipe(int recipeId)
            => View(repository.Recipes
                    .FirstOrDefault(p => p.Id == recipeId));

        [HttpPost]
        public IActionResult EditRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                //return View("Index", repository.Products);
                TempData["message"] = $"{recipe.Name} was saved!";
                return RedirectToAction("RecipeList");
            }
            else
            {
                // stay in the same page and show the input
                return View(recipe);
            }
        }

        public ViewResult CreateRecipe() => View("EditRecipe", new Recipe());

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
    }


}