using GalaSoft.MvvmLight;
using RecipeTracker.DataAccess.Abstraction;
using RecipeTracker.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTracker.WPF.ViewModel
{
    public class RecipesViewModel : ViewModelBase
    {
        #region Fields

        private readonly IRecipeRepository recipeRepository;

        #endregion

        #region Properties

        public ObservableCollection<Recipe> Recipes { get; set; }

        public Recipe SelectedRecipe { get; set; }

        #endregion

        #region Constructor

        public RecipesViewModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        #endregion
    }
}
