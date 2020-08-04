using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web;

namespace RecipesProject_JuheeKim.Models
{
    public class Recipe
    {
        public int Id { get; set; } = 0;
        //public Cuisine cuisine { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Chef { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }

        //[DisplayName("Upload File")]
        //public string ImagePath { get; set; }
    }
}
