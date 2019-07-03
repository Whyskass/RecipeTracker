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
    public class AddRecipeViewModel : ViewModelBase
    {
        #region Fields

        private readonly IRecipeRepository recipeRepository;
        private string newIngredientName;
        private string newStepName;

        #endregion

        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public string NewIngredientName
        {
            get => newIngredientName;
            set
            {
                Set(ref newIngredientName, value);
            }
        }

        public ObservableCollection<Step> Steps { get; set; }
        public string NewStepName { get => newStepName; set => Set(ref newStepName , value); }

        #endregion

        #region Event

        public event Action NewRecipedAdded;

        #endregion

        #region Commands

        public RelayCommand AddIngredient { get; set; }

        public RelayCommand AddStep { get; set; }

        public RelayCommand AddRecipe { get; set; }

        #endregion

        #region Constructor

        public AddRecipeViewModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;

            // Initialize collections
            Ingredients = new ObservableCollection<Ingredient>();
            Steps = new ObservableCollection<Step>();

            // Initialize commands
            AddIngredient = new RelayCommand(OnAddIngredient);
            AddStep = new RelayCommand(OnAddStep);
            AddRecipe = new RelayCommand(OnAddRecipe);
        }

        #endregion

        #region Business

        #region Private

        private void OnAddIngredient()
        {
            if (!string.IsNullOrEmpty(NewIngredientName))
            {
                Ingredients.Add(new Ingredient() { Name = NewIngredientName });
                NewIngredientName = "";
            }
        }

        private void OnAddStep()
        {
            if (!string.IsNullOrEmpty(NewStepName))
            {
                Steps.Add(new Step() { Name = NewStepName, Order = Steps.Count + 1 });
                NewStepName = "";
            }
        }

        private async void OnAddRecipe()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var newRecipe = new Recipe()
                {
                    Name = Name,
                    Description = Description,
                    Ingredients = Ingredients.ToList(),
                    Steps = Steps.ToList()
                };
                await recipeRepository.SaveRecipe(newRecipe);
                NewRecipedAdded();
            }
        }

        #endregion

        #endregion
    }
}
