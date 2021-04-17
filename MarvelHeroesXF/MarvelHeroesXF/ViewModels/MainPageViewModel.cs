using MarvelHeroesXF.Models;
using MarvelHeroesXF.ViewModel;
using MarvelHeroesXF.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarvelHeroesXF.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Heroes = new ObservableCollection<Character>();
            Villains = new ObservableCollection<Character>();
            Antiheroes = new ObservableCollection<Character>();
            Aliens = new ObservableCollection<Character>();
            Humans = new ObservableCollection<Character>();
            NavigateToDetailPageCommand = new Command<Character>(async (model) => await ExecuteNavigateToDetailPageCommand(model));
            InitCollections();
        }

        public ObservableCollection<Character> Heroes { get; }
        public ObservableCollection<Character> Villains { get; }
        public ObservableCollection<Character> Antiheroes { get; }
        public ObservableCollection<Character> Aliens { get; }
        public ObservableCollection<Character> Humans { get; }
        public Command NavigateToDetailPageCommand { get; set; }

        private void InitCollections()
        {
            GetHeroes();
            GetVillains();
            GetAntiHeroes();
            GetAliens();
            GetHumans();
        }

        private string _titleHeroes;
        public string TitleHeroes
        {
            get { return _titleHeroes; }
            set { SetProperty(ref _titleHeroes, value); }
        }

        private void GetHeroes()
        {
            Heroes.Add(new Character()
            {
                personName = "Peter Parker",
                name = "Homem Aranha",
                age = 30,
                weight = 78,
                height = 1.80,
                universe = "Terra 616",
                description = "Em Forest Hills, Queens, Nova York, o estudante de ensino médio, Peter Parker, é um cientista orfão que vive com seu tio Ben e tia May. Ele é mordido por uma aranha radioativa em uma exposição científica e adquire a agilidade e a força proporcional de um aracnídeo. Junto com a super força, Parker ganha a capacidade de andar nas paredes e tetos.\n\nAtravés de sua habilidade nativa para a ciência, ele desenvolve um aparelho que o permitir lançar teias artificiais.Inicialmente buscando capitalizar suas novas habilidades, Parker cria um traje e, como Homem Aranha, torna - se uma estrela de televisão.",
                image = "spider_man_background",
                ability = new Ability()
                {
                    strength = 40,
                    intelligence = 35,
                    agility = 40,
                    resistance = 30,
                    velocity = 40
                },
                movies = new List<Movie>()
                {
                    new Movie(){ image = "captain_america_3" },
                    new Movie(){ image = "spiderman_homecoming" },
                    new Movie(){ image = "avengers4" },
                }
            });

            Heroes.Add(new Character()
            {
                personName = "T'challa",
                name = "Pantera Negra",
                age = 47,
                weight = 91,
                height = 1.83,
                universe = "Terra 616",
                description = "O Pantera Negra é o título cerimonial atribuído ao chefe da Tribo Pantera da avançada nação africana de Wakanda. Além de governar o país, ele também é chefe de suas várias tribos (coletivamente conhecida como Wakandas). O uniforme do Pantera é um símbolo oficial (chefe de estado) e é usado mesmo durante missões diplomáticas. O Pantera é um título hereditário, mas ainda é preciso ganhar um desafio.\n\nNo passado distante, um enorme meteorito maciço composto de vibranium - elemento que absorve o som, entre outras propriedades especiais - caiu em Wakanda, e é desenterrado uma geração antes dos eventos do presente.",
                image = "black_panther_background",
                ability = new Ability()
                {
                    strength = 30,
                    intelligence = 28,
                    agility = 49,
                    resistance = 28,
                    velocity = 45
                },
                movies = new List<Movie>()
                {
                    new Movie(){ image = "black_panther" },
                    new Movie(){ image = "captain_america_3" },
                    new Movie(){ image = "avengers4" },
                }
            });

            Heroes.Add(new Character()
            {
                personName = "Tony Stark",
                name = "Homem de Ferro",
                age = 50,
                weight = 102,
                height = 1.85,
                universe = "Terra 616",
                description = "Durante a guerra do Vietnã, o inventor e empresário Tony Stark foi vítima de uma explosão de granada. Stark sobreviveu à explosão mas estilhaços do explosivo se alojaram próximo ao seu coração, ameaçando sua vida. Ele foi capturado e levado até o líder Wong Chu, que o forçou a criar uma poderosa arma, mas ele criou algo que o mantivesse vivo e permitisse derrotar os captores.\n\nO Homem de Ferro enfrentou os soldados e os derrotou.Sua armadura resistia aos disparos contra ele.Wong Chu tentou fugir e o Homem de Ferro incendiou o galpão de munições fazendo com que a explosão o matasse.",
                image = "iron_man_background",
                ability = new Ability()
                {
                    strength = 40,
                    intelligence = 45,
                    agility = 38,
                    resistance = 30,
                    velocity = 42
                },
                movies = new List<Movie>()
                {
                    new Movie(){ image = "iron_man1" },
                    new Movie(){ image = "iron_man2" },
                    new Movie(){ image = "captain_america_3" },
                    new Movie(){ image = "avengers4" },
                }
            });
        }

        private void GetVillains()
        {
            Villains.Add(new Character()
            {
                personName = "Jöhann Schmidt",
                name = "Caveira Vermelha",
                universe = "Terra 999",
                image = "red_skull_background"
            });

            Villains.Add(new Character()
            {
                personName = "Victor Von Doom",
                name = "Doutor Destino",
                universe = "Terra 999",
                image = "dr_doom_background"
            });

            Villains.Add(new Character()
            {
                personName = "Norman Osborn",
                name = "Duende Verde",
                universe = "Terra 999",
                image = "green_goblin_background"
            });
        }

        private void GetAntiHeroes()
        {
            Antiheroes.Add(new Character()
            {
                personName = "Wade Wilson",
                name = "Deadpool",
                universe = "Terra 999",
                image = "deadpool_background"
            });

            Antiheroes.Add(new Character()
            {
                personName = "Eddie Brock",
                name = "Venom",
                universe = "Terra 999",
                image = "venom_background"
            });

            Antiheroes.Add(new Character()
            {
                personName = "Francis Castle",
                name = "Justiceiro",
                universe = "Terra 999",
                image = "punisher_background"
            });
        }

        private void GetAliens()
        {
            Aliens.Add(new Character()
            {
                personName = "Deviant",
                name = "Thanos",
                universe = "Terra 999",
                image = "thanos_background"
            });

            Aliens.Add(new Character()
            {
                personName = "Kree",
                name = "Ronan",
                universe = "Terra 999",
                image = "ronan_background"
            });

            Aliens.Add(new Character()
            {
                personName = "Skrull",
                name = "Talos",
                universe = "Terra 999",
                image = "talos_background"
            });
        }

        private void GetHumans()
        {
            Humans.Add(new Character()
            {
                personName = "Homem de Ferro",
                name = "Howard Stark",
                universe = "Terra 999",
                image = "howard_stark_background"
            });

            Humans.Add(new Character()
            {
                personName = "Homem-Aranha",
                name = "Mary Jane",
                universe = "Terra 999",
                image = "mary_jane_background"
            });

            Humans.Add(new Character()
            {
                personName = "Homem de ferro",
                name = "Happy Hogan",
                universe = "Terra 999",
                image = "happy_hogan_background"
            });
        }

        private async Task ExecuteNavigateToDetailPageCommand(Character character)
        {
            await Navigation.PushAsync(new DetailPage(character));
        }
    }
}
