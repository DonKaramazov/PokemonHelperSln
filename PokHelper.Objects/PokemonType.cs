using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokHelper.Objects
{
    public class PokemonType
    {

        public String Name { get; set; }
        public Element Element { get; set; }
        public Element? Element2 { get; set; }

        public Dictionary<Element, double> DicMultipliers { get; set; }

        // constructeur par défaut pour désérialisation xml
        public PokemonType()
        {

        }

        public PokemonType(PokeBuilder builder)
        {
            Name = builder.Name;
            Element = builder.Element;
            Element2 = builder.Element2;
            DicMultipliers = builder.DicMultipliers;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
