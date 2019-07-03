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
        private IList<Recipe> recipeList;

        public RecipeRepository()
        {
            recipeList = new List<Recipe>()
                {
                    new Recipe()
                    {
                        Name = "Ratatouille",
                        Description = "French cuisine vegetable mix",
                        Ingredients = new List<Ingredient>()
                        {
                            new Ingredient() {Name = "Tomato"},
                            new Ingredient(){ Name = "Onion"},
                            new Ingredient(){ Name = "Garlic"}
                        },
                        Steps = new List<Step>()
                        {
                            new Step() {Name = "Cut the tomatoes." , Order = 1},
                            new Step() {Name = "Cut the onion." , Order = 2},
                            new Step() {Name = "Cut the garlic." , Order = 3}
                        }
                    }
                };
        }

        public async Task<IList<Recipe>> GetRecipes()
        {
            return recipeList;
        }

        public async Task<Recipe> SaveRecipe(Recipe recipe)
        {
            recipe.Id = 1;

            recipeList.Add(recipe);

            return recipe;
        }
    }
}
