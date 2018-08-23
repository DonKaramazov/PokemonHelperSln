using System;
using System.Collections.Generic;

namespace PokHelper.Objects
{
    public class PokeBuilder
    {
        public String Name { get; private set; }
        public Element Element { get; set; }
        public Element? Element2 { get; set; }

        public Dictionary<Element, double> DicMultipliers { get; set; }

        public PokeBuilder(Element element, Element? element2 = null)
        {
            Name = element.ToString() + (element2.HasValue ? "/" + element2.Value.ToString() : String.Empty);
            Element = element;
            Element2 = element2;
            DicMultipliers = new Dictionary<Element, double>();

            // Valeurs par défaut sur tout les types
            foreach (Element e in Enum.GetValues(typeof(Element)))
                DicMultipliers.Add(e, 1.0d);
        }

        public PokeBuilder SuperVulnerableTo(params Element[] elements)
        {
            foreach (Element e in elements)
                DicMultipliers[e] = 4.0d;

            return this;
        }

        public PokeBuilder VulnerableTo(params Element[] elements)
        {
            foreach (Element e in elements)
                DicMultipliers[e] = 2.0d;

            return this;
        }

        public PokeBuilder ResistantTo(params Element[] elements)
        {
            foreach (Element e in elements)
                DicMultipliers[e] = 0.5d;
            return this;
        }

        public PokeBuilder SuperResistantTo(params Element[] elements)
        {
            foreach (Element e in elements)
                DicMultipliers[e] = 0.25d;

            return this;
        }

        public PokeBuilder ImmuneTo(params Element[] elements)
        {
            foreach (Element e in elements)
                DicMultipliers[e] = 0.0d;

            return this;
        }

        public PokemonType Build() { return new PokemonType(this); }
    }
}