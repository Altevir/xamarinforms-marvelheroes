using MarvelHeroesXF.Models;
using MarvelHeroesXF.ViewModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarvelHeroesXF.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        public DetailPageViewModel(INavigation navigation, Character character)
        {
            Navigation = navigation;
            Character = character;
            GoBackPageCommand = new Command(async () => await ExecuteGoBackPageCommand());
        }

        public Character Character { get; set; }
        public Command GoBackPageCommand { get; set; }

        private async Task ExecuteGoBackPageCommand()
        {
            await Navigation.PopAsync();
        }
    }
}
