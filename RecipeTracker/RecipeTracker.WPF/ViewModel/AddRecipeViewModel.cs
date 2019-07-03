using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RecipeTracker.DataAccess.Abstraction;
using RecipeTracker.DataAccess.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTracker.WPF.ViewModel
{
    public class AddRecipeViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        #region Fields

        private readonly IRecipeRepository recipeRepository;
        private string newIngredientName;
        private string newStepName;
        private string name;

        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        #endregion

        #region Properties

        [Required]
        public string Name
        {
            get => name; set
            {
                SetWithValidation(ref name, value);
                AddRecipe.RaiseCanExecuteChanged();
            }
        }

        public string Description { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public string NewIngredientName
        {
            get => newIngredientName;
            set
            {
                Set(ref newIngredientName, value);
                AddIngredient.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Step> Steps { get; set; }

        public string NewStepName
        {
            get => newStepName; set
            {
                Set(ref newStepName, value);
                AddStep.RaiseCanExecuteChanged();
            }
        }

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
            AddIngredient = new RelayCommand(OnAddIngredient, () => !string.IsNullOrWhiteSpace(NewIngredientName));
            AddStep = new RelayCommand(OnAddStep, () => !string.IsNullOrEmpty(NewStepName));
            AddRecipe = new RelayCommand(OnAddRecipe, () => !string.IsNullOrEmpty(Name) && !HasErrors);
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

        #region Error management methods


        private void SetWithValidation<T>(ref T field, T newValue = default, [CallerMemberName] string propertyName = null)
        {
            base.Set<T>(ref field, newValue, propertyName);
            ValidateProperty(propertyName, newValue);
        }

        private void ValidateProperty<T>(string propertyName, T newValue)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(this);
            validationContext.MemberName = propertyName;
            Validator.TryValidateProperty(newValue, validationContext, results);

            if (results.Any())
            {
                _errors[propertyName] = results.Select(vr => vr.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion

        #endregion

        #region INotifyDataErrorInfo implementation

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];

            return null;
        }

        public bool HasErrors => _errors.Count > 0;

        #endregion

        #endregion
    }
}
