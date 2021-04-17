using MarvelHeroesXF.Models;
using MarvelHeroesXF.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelHeroesXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        private readonly Character _character;
        internal const int MAXVALUE = 50;

        public DetailPage(Character character)
        {
            InitializeComponent();
            BindingContext = new DetailPageViewModel(Navigation, character);
            _character = character;
            gridDetails.TranslationY = 30;
            imgBackground.Scale = 1.2;
            CreateStacks();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = Task.WhenAll(
             imgBackground.ScaleTo(1, 950, Easing.Linear),
                   gridDetails.TranslateTo(0, -30, 950, Easing.Linear)
             );
        }

        private void CreateStacks()
        {
            if (_character.ability is null)
                return;

            //STRENGTH
            for (int i = 1; i <= MAXVALUE; i++)
            {
                //STRENGTH
                stackStrength.Children.Add(new BoxView()
                {
                    HeightRequest = i == _character.ability.strength ? 15 : 10,
                    WidthRequest = 1,
                    BackgroundColor = Color.White,
                    Opacity = i <= _character.ability.strength ? 1 : 0.4,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center
                });

                //INTELLIGENCE
                stackIntelligence.Children.Add(new BoxView()
                {
                    HeightRequest = i == _character.ability.intelligence ? 15 : 10,
                    WidthRequest = 1,
                    BackgroundColor = Color.White,
                    Opacity = i <= _character.ability.intelligence ? 1 : 0.4,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center
                });

                //AGILITY
                stackAgility.Children.Add(new BoxView()
                {
                    HeightRequest = i == _character.ability.agility ? 15 : 10,
                    WidthRequest = 1,
                    BackgroundColor = Color.White,
                    Opacity = i <= _character.ability.agility ? 1 : 0.4,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center
                });

                //RESISTANCE
                stackResistance.Children.Add(new BoxView()
                {
                    HeightRequest = i == _character.ability.resistance ? 15 : 10,
                    WidthRequest = 1,
                    BackgroundColor = Color.White,
                    Opacity = i <= _character.ability.resistance ? 1 : 0.4,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center
                });

                //VELOCITY
                stackVelocity.Children.Add(new BoxView()
                {
                    HeightRequest = i == _character.ability.velocity ? 15 : 10,
                    WidthRequest = 1,
                    BackgroundColor = Color.White,
                    Opacity = i <= _character.ability.velocity ? 1 : 0.4,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center
                });
            }
        }
    }
}