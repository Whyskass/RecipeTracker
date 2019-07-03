using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using RecipeTracker.DataAccess;
using RecipeTracker.DataAccess.Abstraction;

namespace RecipeTracker.WPF.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<RecipesViewModel>();
            SimpleIoc.Default.Register<AddRecipeViewModel>();
            SimpleIoc.Default.Register<IRecipeRepository, RecipeRepository>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public RecipesViewModel Recipes
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RecipesViewModel>();
            }
        }

        public AddRecipeViewModel AddRecipe
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddRecipeViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}