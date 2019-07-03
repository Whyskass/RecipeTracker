using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private Recipe selectedRecipe;
        private ObservableCollection<Recipe> recipes;

        #endregion

        #region Properties

        public ObservableCollection<Recipe> Recipes { get => recipes; set => Set(ref recipes, value); }

        public Recipe SelectedRecipe { get => selectedRecipe; set => Set(ref selectedRecipe, value); }

        public RelayCommand LoadRecipes { get; set; }

        #endregion

        #region Constructor

        public RecipesViewModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;

            LoadRecipes = new RelayCommand(OnLoadRecipes);
        }

        #endregion

        #region Business

        #region Private

        public async void OnLoadRecipes()
        {
            if (IsInDesignModeStatic)
            {
                #region Design Data

                Recipes = new ObservableCollection<Recipe>()
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

                SelectedRecipe = Recipes[0];

                #endregion
            }
            else
            {
                Recipes = new ObservableCollection<Recipe>(await recipeRepository.GetRecipes());
            }
        }

        #endregion

        #endregion
    }
}
