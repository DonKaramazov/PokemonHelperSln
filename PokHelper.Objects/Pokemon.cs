using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokHelper.Objects
{
    public class Pokemon
    {
        public String Name { get; set; }
        public Element Element { get; set; }
        public Element? Element2 { get; set; }
        public PokemonType PokemonType { get; private set; }

        // constructeur par défaut pour désérialisation xml
        public Pokemon()
        {

        }

        public Pokemon(string name, Element mainElement, Element? secondaryElement = null)
        {
            Name = name;
            Element = mainElement;
            Element2 = secondaryElement;

            PokemonType = Pokedex.PokemonTypes.Find(t => t.Element.Equals(mainElement) && t.Element2.Equals(secondaryElement));
        }

        public override string ToString() { return Name; }
    }
}
