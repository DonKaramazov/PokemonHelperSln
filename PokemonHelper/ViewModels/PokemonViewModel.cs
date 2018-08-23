using PokHelper.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonHelper.ViewModels
{
    public class PokemonViewModel
    {
        public Pokemon Pokemon { get; set; }

        public IEnumerable<Element> SuperVulnerableToElements => Pokemon.PokemonType.DicMultipliers.Where(d => d.Value == 4.0d).Select(d => d.Key);
        public IEnumerable<Element> VulnerableToElements => Pokemon.PokemonType.DicMultipliers.Where(d => d.Value == 2.0d).Select(d => d.Key);
        public IEnumerable<Element> ResistantToElements => Pokemon.PokemonType.DicMultipliers.Where(d => d.Value == 0.5d).Select(d => d.Key);
        public IEnumerable<Element> SuperResistantToElements => Pokemon.PokemonType.DicMultipliers.Where(d => d.Value == 0.25d).Select(d => d.Key);
        public IEnumerable<Element> ImmuneToElements => Pokemon.PokemonType.DicMultipliers.Where(d => d.Value == 0.0d).Select(d => d.Key);

        public PokemonViewModel()
        {

        }

        public PokemonViewModel(Pokemon pokemon)
        {
            Pokemon = pokemon;
        }
    }
}
