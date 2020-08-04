using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject_JuheeKim.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        Name = "French Onion Soup",
                        Description = "Stay warm with this GREAT French onion soup! With beef stock base, slow-cooked caramelized onions, French bread, gruyere and Parmesan cheese.",
                        Ingredients = "6 large yellow onions, 4 T-spoones olive oil, 2 T-spoons butter, 1 t-spoopn of sugar, Salt, 8 cups of beef stock",
                        Chef = "Courtney Kim",
                        PreparationTime = 30,
                        CookingTime = 50
                    },
                    new Recipe 
                    { 
                        Name = "Birthday Seaweed Soup", 
                        Description = "Enjoy traditonal Korean birthday soup! Soft seaweed's texture and sesame oil's flavor will make you happy.", 
                        Ingredients = "Dried seaweed, 8 cups of water, Salt, 4 T-spoon Soy suace, Onion, Sesame oil, Beef cubes, Sugar", 
                        Chef = "Courtney Kim", 
                        PreparationTime = 35, 
                        CookingTime = 60 
                    },
                    new Recipe 
                    { 
                        Name = "Chocolate Pancake", 
                        Description = "Start your Sunday morning with special treat! Try Pancake with chocoate chips and butter flavor.", 
                        Ingredients = "Pancake mix, 1 cup of chocolate chips, 1 cup of water, 1 T-spoon butter", 
                        Chef = "Allen Lusk", 
                        PreparationTime = 15, 
                        CookingTime = 30 
                    },
                    new Recipe 
                    { 
                        Name = "Creamy Shrimp Pasta", 
                        Description = "The creamy Alfredo sauce generously coats the juicy shrimp and noodles. Your family will be humming with every bite and will request it for dinner again and again. One of our favorite shrimp recipes!", 
                        Ingredients = "3/4 lb fettuccini pasta, 1 lb large raw shrimp peeled and deveined (21-25 ct), 1 T-spoon olive oil, 1 / 2 onion(medium), 2 T-spoon butter, 1 garlic clove minced, 2 cups whipping cream, Salt, Black pepper", 
                        Chef = "Linda Mac", 
                        PreparationTime = 35, 
                        CookingTime = 60 }
                    ,
                    new Recipe 
                    { 
                        Name = "Summer Pasta Salad", 
                        Description = "Summer pasta salad is always a fan favorite around here! There’s just something I love about a fresh cold pasta salad on a hot day.", 
                        Ingredients = "8 oz dry rotini pasta, 1/2 cup red onion, 1 yellow pepper, 1 small zucchini, 1 cup grape tomatoes, 1/2 cup feta cheese, 1/2 cup Olive Oil, 3 T-spoons Apple Cider Vinegar, 1/2 t-spoon Oregano, Salt, Black pepper", 
                        Chef = "Courtney Kim", 
                        PreparationTime = 35, 
                        CookingTime = 30 
                    },
                    new Recipe
                    {
                        Name = "Grilled Salmon Steak",
                        Description = "This is a terrific way to fix salmon...and it's so easy to do. The marinade mellows the fish flavor, and the dill sauce is a wonderful complement. ",
                        Ingredients = "2 T-spoons white wine vinegar, 2 T-spoons sugar, 1 T-spoon dill weed, Salt, Pepper, 4 salmon steaks",
                        Chef = "Rosco Sill",
                        PreparationTime = 25,
                        CookingTime = 60
                    }

                );

                context.SaveChanges();

            }
        }
    }
}
