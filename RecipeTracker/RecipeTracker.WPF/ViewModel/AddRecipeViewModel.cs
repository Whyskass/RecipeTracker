using GalaSoft.MvvmLight;
using RecipeTracker.DataAccess.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTracker.WPF.ViewModel
{
    public class AddRecipeViewModel : ViewModelBase
    {
        #region Fields

        private readonly IRecipeRepository recipeRepository;

        #endregion

        #region Constructor

        public AddRecipeViewModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        #endregion
    }
}
