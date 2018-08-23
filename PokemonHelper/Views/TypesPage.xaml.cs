using PokemonHelper.ViewModels;
using PokHelper.Objects;
using System.Windows;
using System.Windows.Controls;

namespace PokemonHelper.Views
{
    /// <summary>
    /// Logique d'interaction pour TypesPage.xaml
    /// </summary>
    public partial class TypesPage : Page
    {
        private PokemonViewModel viewModel = new PokemonViewModel();

        public TypesPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxPokemons.ItemsSource = Pokedex.Pokemons;
            cbxPokemons.SelectionChanged += CbxPokemons_SelectionChanged;
            cbxPokemons.SelectedIndex = 0;
        }

        void CbxPokemons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pokemon selectedPokemon = cbxPokemons.SelectedItem as Pokemon;
            if (selectedPokemon == null)
                return;

            DataContext = new PokemonViewModel(selectedPokemon);
        }
    }
}
