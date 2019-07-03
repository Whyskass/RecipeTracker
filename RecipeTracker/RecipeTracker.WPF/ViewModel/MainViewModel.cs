using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

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
        #region Properties

        public ViewModelBase CurrentViewModel { get; set; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            CurrentViewModel = SimpleIoc.Default.GetInstance<RecipesViewModel>();
        }

        #endregion
    }
}