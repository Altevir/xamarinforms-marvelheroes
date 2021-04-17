using MarvelHeroesXF.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelHeroesXF.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterCarousel : ContentView
    {
        public static readonly BindableProperty TitleProperty =
           BindableProperty
           .Create(
               propertyName: nameof(Title),
               returnType: typeof(string),
               declaringType: typeof(CharacterCarousel),
               defaultValue: null,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: TitlePropertyChanged);

        public static readonly BindableProperty ItemsSourceProperty =
           BindableProperty
           .Create(
               propertyName: nameof(ItemsSource),
               returnType: typeof(ObservableCollection<Character>),
               declaringType: typeof(CharacterCarousel),
               defaultValue: null,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: ItemsSourcePropertyChanged);

        public string Title
        {
            get { return base.GetValue(TitleProperty).ToString(); }
            set { base.SetValue(TitleProperty, value); }
        }

        public ObservableCollection<Character> ItemsSource
        {
            get { return (ObservableCollection<Character>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public CharacterCarousel()
        {
            InitializeComponent();
        }

        private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CharacterCarousel)bindable;
            control.lbTitle.Text = newValue?.ToString();
        }

        private static void ItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var items = newValue as ObservableCollection<Character>;
            var control = (CharacterCarousel)bindable;
            BindableLayout.SetItemsSource(control.listCharacter, items);
        }
    }
}