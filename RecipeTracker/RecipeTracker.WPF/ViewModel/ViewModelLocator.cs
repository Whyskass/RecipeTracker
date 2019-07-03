using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using RecipeTracker.DataAccess;
using RecipeTracker.DataAccess.Abstraction;

namespace RecipeTracker.WPF.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            // Initialize our IoC container
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

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
    }
}