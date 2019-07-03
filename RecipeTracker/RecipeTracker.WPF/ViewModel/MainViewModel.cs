using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using RecipeTracker.DataAccess.Model;

namespace RecipeTracker.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private ViewModelBase currentViewModel;

        #endregion

        #region Properties

        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }

        #endregion

        #region Commands

        public RelayCommand AddCommmand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            CurrentViewModel = SimpleIoc.Default.GetInstance<RecipesViewModel>();

            AddCommmand = new RelayCommand(OnAddCommand);

            // Listen to the NewRecipedAdded event from the AddRecipeViewModel to navigate to the Recipes view
            var addedNewRecipiedViewModel = SimpleIoc.Default.GetInstance<AddRecipeViewModel>();

            if(addedNewRecipiedViewModel != null)
            {
                addedNewRecipiedViewModel.NewRecipedAdded += OnNewRecipedAdded;
            }
        }

        #endregion

        #region Business

        #region Private

        private void OnAddCommand()
        {
            CurrentViewModel = SimpleIoc.Default.GetInstance<AddRecipeViewModel>();
        }

        private void OnNewRecipedAdded()
        {
            CurrentViewModel = SimpleIoc.Default.GetInstance<RecipesViewModel>();
        }

        #endregion

        #endregion
    }
}