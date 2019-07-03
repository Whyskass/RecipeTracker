using RecipeTracker.DataAccess.Abstraction;
using RecipeTracker.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTracker.DataAccess
{
    public class RecipeRepository : IRecipeRepository
    {
        public IList<Recipe> GetRecipes()
        {
            throw new NotImplementedException();
        }

        public Recipe SaveRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
