using RecipesProject_JuheeKim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject_JuheeKim.ViewModels
{
    public class RecipeCuisionViewModel
    {
        public Recipe Recipe { get; set; }
        public Cuisine Cuisine { get; set; }
        public IEnumerable<Cuisine> Cuisines { get; set; }
    }
}
