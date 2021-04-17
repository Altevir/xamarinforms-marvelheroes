using MarvelHeroesXF.ViewModels;
using Xamarin.Forms;

namespace MarvelHeroesXF.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);
        }
    }
}
