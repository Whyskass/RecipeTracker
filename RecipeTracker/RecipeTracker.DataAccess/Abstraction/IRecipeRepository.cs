﻿using RecipeTracker.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTracker.DataAccess.Abstraction
{
    public interface IRecipeRepository
    {
        Task<IList<Recipe>> GetRecipes();
        Task<Recipe> SaveRecipe(Recipe recipe);
    }
}
