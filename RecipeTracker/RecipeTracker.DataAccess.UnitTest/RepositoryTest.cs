using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeTracker.DataAccess.Model;

namespace RecipeTracker.DataAccess.UnitTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public async void GetRecipesTest()
        {
            var recipeRepository = new RecipeRepository();
            var recipes = await recipeRepository.GetRecipes();
            Assert.IsTrue(recipes.Count > 0);
        }

        [TestMethod]
        public async void SaveRecipeTest()
        {
            var recipeRepository = new RecipeRepository();
            var newRecipe = new Recipe()
            {
                Name = "Test recipe",
                Description = "New description"
            };
            var result = await recipeRepository.SaveRecipe(newRecipe);
            Assert.IsTrue(result.Id > 0);
        }
    }
}
