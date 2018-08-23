using PokHelper.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokHelper.Objects
{
    public static class Pokedex
    {
        #region Properties
        private static List<PokemonType> _pokemonTypes = null;
        public static List<PokemonType> PokemonTypes
        {
            get
            {
                if (_pokemonTypes == null)
                    _pokemonTypes = GetAllPokemonTypes();

                return _pokemonTypes;
            }
        }

        private static List<Pokemon> _pokemons = null;
        public static List<Pokemon> Pokemons
        {
            get
            {
                if (_pokemons == null)
                    _pokemons = GetAllPokemons();

                return _pokemons;
            }
        }
        #endregion

        private static List<Pokemon> GetAllPokemons()
        {
            List<Pokemon> pokemons = new List<Pokemon>();

            ////pokemons.AddRange(FirePokemons.GetAllPokemons());
            ////pokemons.AddRange(SteelPokemons.GetAllPokemons());
            //GetGrassPokemons(pokemons);
            //GetDragonPokemons(pokemons);

            List<string> values = File.ReadAllLines(@"D:\Lab\PokemonHelperSln\pokedex.csv").ToList();
            values.RemoveAt(0); // la première ligne correspond aux headers.
            

            foreach (string line in values)
            {
                var data = line.Split(';');

                string name = data[0];
                Element mainElement = (Element)Enum.Parse(typeof(Element), data[1], true);
                Element? secondaryElement = data[2] == ""
                                            ? null as Element?
                                            : (Element)Enum.Parse(typeof(Element), data[2], true);

                pokemons.Add(new Pokemon(name, mainElement, secondaryElement));
            }


            return pokemons.OrderBy(p => p.Name).ToList();
        }

        private static void GetDragonPokemons(List<Pokemon> pokemons)
        {
            pokemons.Add(new Pokemon("Dragonite", Element.DRAGON));
            pokemons.Add(new Pokemon("Charizard", Element.DRAGON));
        }



        private static void GetGrassPokemons(List<Pokemon> pokemons)
        {
            pokemons.Add(new Pokemon("Bulbizare", Element.GRASS));
            pokemons.Add(new Pokemon("Bulbifleure", Element.GRASS));
        }

        private static List<PokemonType> GetAllPokemonTypes()
        {
            List<PokemonType> types = new List<PokemonType>();

            BuildSingularTypes(types);
            BuildAssociatedTypes(types);

            return types;
        }

        private static void BuildSingularTypes(List<PokemonType> types)
        {
            PokemonType steel = new PokeBuilder(Element.STEEL)
               .VulnerableTo(Element.FIGHTING, Element.FIRE, Element.GROUND)
               .ResistantTo(Element.STEEL, Element.DRAGON, Element.FAIRY, Element.ICE, Element.BUG, Element.NORMAL,
               Element.GRASS, Element.PSY, Element.ROCK, Element.FLY)
               .ImmuneTo(Element.POISON)
               .Build();

            PokemonType fighting = new PokeBuilder(Element.FIGHTING)
                 .VulnerableTo(Element.FAIRY, Element.PSY, Element.FLY)
                 .ResistantTo(Element.BUG, Element.ROCK, Element.DARK)
                 .Build();

            PokemonType dragon = new PokeBuilder(Element.DRAGON)
                .VulnerableTo(Element.DRAGON, Element.FAIRY, Element.ICE)
                .ResistantTo(Element.WATER, Element.THUNDER, Element.FIRE, Element.GRASS)
                .Build();

            PokemonType water = new PokeBuilder(Element.WATER)
                .VulnerableTo(Element.THUNDER, Element.GRASS)
                .ResistantTo(Element.STEEL, Element.WATER, Element.FIRE, Element.ICE)
                .Build();

            PokemonType thunder = new PokeBuilder(Element.THUNDER)
                .VulnerableTo(Element.GROUND)
                .ResistantTo(Element.STEEL, Element.THUNDER, Element.FLY)
                .Build();

            PokemonType fairy = new PokeBuilder(Element.FAIRY)
                .VulnerableTo(Element.STEEL, Element.POISON)
                .ResistantTo(Element.FIGHTING, Element.BUG, Element.DARK)
                .ImmuneTo(Element.DRAGON)
                .Build();

            PokemonType fire = new PokeBuilder(Element.FIRE)
                .VulnerableTo(Element.WATER, Element.ROCK, Element.GROUND)
                .ResistantTo(Element.STEEL, Element.FAIRY, Element.FIRE, Element.ICE, Element.BUG, Element.GRASS)
                .Build();

            PokemonType ice = new PokeBuilder(Element.ICE)
                .VulnerableTo(Element.STEEL, Element.FIGHTING, Element.FIRE, Element.ROCK)
                .ResistantTo(Element.ICE)
                .Build();

            PokemonType bug = new PokeBuilder(Element.BUG)
                .VulnerableTo(Element.FIRE, Element.ROCK, Element.FLY)
                .ResistantTo(Element.FIGHTING, Element.GRASS, Element.GROUND)
                .Build();

            PokemonType normal = new PokeBuilder(Element.NORMAL)
                .VulnerableTo(Element.FIGHTING)
                .ImmuneTo(Element.GHOST)
                .Build();

            PokemonType grass = new PokeBuilder(Element.GRASS)
                .VulnerableTo(Element.FIRE, Element.ICE, Element.BUG, Element.FLY, Element.POISON)
                .ResistantTo(Element.WATER, Element.THUNDER, Element.GRASS, Element.GROUND)
                .Build();

            PokemonType poison = new PokeBuilder(Element.POISON)
                .VulnerableTo(Element.GROUND, Element.PSY)
                .ResistantTo(Element.FIGHTING, Element.FAIRY, Element.BUG, Element.GRASS, Element.POISON)
                .Build();

            PokemonType psy = new PokeBuilder(Element.PSY)
                .VulnerableTo(Element.BUG, Element.GHOST, Element.DARK)
                .ResistantTo(Element.FIGHTING, Element.PSY)
                .Build();

            PokemonType rock = new PokeBuilder(Element.ROCK)
               .VulnerableTo(Element.STEEL, Element.FIGHTING, Element.WATER, Element.GRASS, Element.GROUND)
               .ResistantTo(Element.FIRE, Element.NORMAL, Element.POISON, Element.FLY)
               .Build();

            PokemonType ground = new PokeBuilder(Element.GROUND)
               .VulnerableTo(Element.WATER, Element.ICE, Element.GRASS)
               .ResistantTo(Element.POISON, Element.ROCK)
               .ImmuneTo(Element.THUNDER)
               .Build();

            PokemonType ghost = new PokeBuilder(Element.GHOST)
                 .VulnerableTo(Element.GHOST, Element.DARK)
                 .ResistantTo(Element.GRASS, Element.POISON)
                 .ImmuneTo(Element.NORMAL, Element.FIGHTING)
                 .Build();

            PokemonType dark = new PokeBuilder(Element.DARK)
                 .VulnerableTo(Element.FIGHTING, Element.FAIRY, Element.BUG)
                 .ResistantTo(Element.GHOST, Element.DARK)
                 .ImmuneTo(Element.PSY)
                 .Build();


            PokemonType fly = new PokeBuilder(Element.FLY)
                 .VulnerableTo(Element.THUNDER, Element.ICE, Element.PSY)
                 .ResistantTo(Element.FIGHTING, Element.BUG, Element.GRASS)
                 .ImmuneTo(Element.GROUND)
                 .Build();

            types.Add(steel); types.Add(fighting); types.Add(dark); types.Add(ground); types.Add(fairy); types.Add(fire); types.Add(water);
            types.Add(grass); types.Add(bug); types.Add(rock); types.Add(psy); types.Add(thunder); types.Add(ghost); types.Add(poison);
            types.Add(normal); types.Add(ice); types.Add(fly); types.Add(dragon);
        }

        private static void BuildAssociatedTypes(List<PokemonType> types)
        {
            BuildSteelAssociatedTypes(types);
            BuildFireAssociatedTypes(types);
            BuildWaterAssociatedTypes(types);
            BuildThunderAssociatedTypes(types);
        }

        /// <summary>
        /// Add thunder & association types
        /// Amount of pokemons : 
        /// </summary>
        private static void BuildThunderAssociatedTypes(List<PokemonType> types)
        {
            //fighting -- none
            types.Add(new PokeBuilder(Element.THUNDER, Element.FIGHTING)
              .VulnerableTo(Element.GROUND, Element.PSY, Element.FAIRY)
              .ResistantTo(Element.THUNDER, Element.BUG, Element.ROCK, Element.DARK, Element.STEEL)
              .Build());

            //dragon -- 2 pokemons
            types.Add(new PokeBuilder(Element.THUNDER, Element.DRAGON)
              .VulnerableTo(Element.FAIRY, Element.DRAGON,Element.ICE,Element.GROUND)
              .ResistantTo(Element.FIRE,Element.WATER,Element.GRASS,Element.FLY,Element.STEEL)
              .SuperResistantTo(Element.THUNDER)
              .Build());

            //fire -- 1 pokemon
            types.Add(new PokeBuilder(Element.THUNDER, Element.FIRE)
            .SuperVulnerableTo(Element.GROUND)
            .VulnerableTo(Element.WATER, Element.ROCK)
            .ResistantTo(Element.FLY, Element.FIRE, Element.THUNDER, Element.FAIRY, Element.ICE, Element.BUG, Element.GRASS)
            .SuperResistantTo(Element.STEEL)
            .Build());

            //water -- 3 pokemons
            types.Add(new PokeBuilder(Element.THUNDER, Element.WATER)
            .VulnerableTo(Element.GRASS, Element.GROUND)
            .ResistantTo(Element.FLY, Element.WATER, Element.FIRE, Element.ICE)
            .SuperResistantTo(Element.STEEL)
            .Build());

            //fairy -- 2 pokemons
            types.Add(new PokeBuilder(Element.THUNDER, Element.FAIRY)
            .VulnerableTo(Element.POISON, Element.GROUND)
            .ResistantTo(Element.THUNDER,Element.FIGHTING, Element.FLY, Element.BUG, Element.DARK)
            .ImmuneTo(Element.DRAGON)
            .Build());

            //steel -- 4 pokemons
            types.Add(new PokeBuilder(Element.THUNDER, Element.STEEL)
            .SuperVulnerableTo(Element.GROUND)
            .VulnerableTo(Element.FIGHTING, Element.FIRE)
            .ResistantTo(Element.DRAGON, Element.THUNDER, Element.FAIRY, Element.ICE, Element.BUG, Element.NORMAL, Element.GRASS, Element.PSY, Element.ROCK)
            .SuperResistantTo(Element.STEEL, Element.FLY)
            .ImmuneTo(Element.POISON)
            .Build());

            //ice -- 1 pokemon
            types.Add(new PokeBuilder(Element.THUNDER, Element.ICE)
            .VulnerableTo(Element.FIRE, Element.FIGHTING, Element.GROUND, Element.ROCK)
            .ResistantTo(Element.THUNDER,Element.ICE,Element.FLY)
            .Build());

            //bug -- 4 pokemons
            types.Add(new PokeBuilder(Element.THUNDER, Element.BUG)
            .VulnerableTo(Element.ROCK, Element.FIRE)
            .ResistantTo(Element.THUNDER, Element.GRASS, Element.FIGHTING, Element.STEEL)
            .ImmuneTo(Element.GROUND)
            .Build());

            //grass -- 1 pokemon
            types.Add(new PokeBuilder(Element.THUNDER, Element.GRASS)
            .VulnerableTo(Element.FIRE, Element.ICE, Element.POISON,Element.BUG)
            .ResistantTo(Element.WATER,Element.GRASS, Element.STEEL)
            .SuperResistantTo(Element.THUNDER)
            .Build());

            //psy -- 6 pokemons
            types.Add(new PokeBuilder(Element.THUNDER, Element.PSY)
            .VulnerableTo(Element.GROUND, Element.BUG, Element.GHOST, Element.DARK)
            .ResistantTo(Element.THUNDER, Element.FIGHTING,Element.FLY, Element.STEEL, Element.PSY)
            .Build());

            //rock -- 3 pokemons
            types.Add(new PokeBuilder(Element.THUNDER, Element.ROCK)
            .SuperVulnerableTo(Element.GROUND)
            .VulnerableTo(Element.FIGHTING, Element.WATER, Element.GRASS)
            .ResistantTo(Element.NORMAL, Element.FIRE,Element.THUNDER, Element.POISON)
            .SuperResistantTo(Element.FLY)
            .Build());

            //ground -- 1 pokemon
            types.Add(new PokeBuilder(Element.THUNDER, Element.GROUND)
            .VulnerableTo(Element.GRASS,Element.WATER,Element.ICE,Element.GROUND)
            .ResistantTo(Element.FLY, Element.POISON, Element.ROCK, Element.STEEL)
            .ImmuneTo(Element.THUNDER)
            .Build());

            //ghost -- 1 pokemon
            types.Add(new PokeBuilder(Element.THUNDER, Element.GHOST)
            .VulnerableTo(Element.GHOST, Element.DARK)
            .ResistantTo(Element.THUNDER,Element.POISON, Element.STEEL, Element.BUG,Element.FLY)
            .ImmuneTo(Element.NORMAL, Element.FIGHTING,Element.GROUND)
            .Build());

            //dark -- none
            types.Add(new PokeBuilder(Element.THUNDER, Element.DARK)
            .VulnerableTo(Element.GROUND, Element.FIGHTING, Element.BUG, Element.FAIRY)
            .ResistantTo(Element.THUNDER, Element.FLY, Element.FIRE, Element.GHOST, Element.DARK, Element.STEEL)
            .ImmuneTo(Element.PSY)
            .Build());

            //fly -- 6 pokemons
            types.Add(new PokeBuilder(Element.THUNDER, Element.FLY)
            .VulnerableTo(Element.ROCK,Element.ICE)
            .ResistantTo(Element.GRASS, Element.FIGHTING, Element.FLY, Element.STEEL, Element.BUG)
            .ImmuneTo(Element.GROUND)
            .Build());

            //normal -- 1 pokemon
            types.Add(new PokeBuilder(Element.THUNDER, Element.NORMAL)
            .VulnerableTo(Element.GROUND, Element.FIGHTING)
            .ResistantTo(Element.THUNDER, Element.FLY, Element.STEEL)
            .ImmuneTo(Element.GHOST)
            .Build());
        }

        /// <summary>
        /// Add fire & association types
        /// Amount of pokemons : 
        /// </summary>
        private static void BuildWaterAssociatedTypes(List<PokemonType> types)
        {
            //fighting -- 3 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.FIGHTING)
              .VulnerableTo(Element.THUNDER, Element.FLY, Element.GRASS, Element.PSY,Element.FAIRY)
              .ResistantTo(Element.WATER,Element.FIRE, Element.ICE, Element.BUG,Element.ROCK, Element.DARK, Element.STEEL)
              .Build());

            //dragon -- 2 pokemon
            types.Add(new PokeBuilder(Element.WATER, Element.DRAGON)
              .VulnerableTo(Element.FAIRY, Element.DRAGON)
              .ResistantTo(Element.STEEL)
              .SuperResistantTo(Element.FIRE, Element.WATER)
              .Build());

            //fire -- 1 pokemon
            types.Add(new PokeBuilder(Element.WATER, Element.FIRE)
            .VulnerableTo(Element.GROUND, Element.THUNDER, Element.ROCK)
            .ResistantTo(Element.FAIRY, Element.BUG)
            .SuperResistantTo(Element.FIRE, Element.ICE, Element.STEEL)
            .Build());

            //thunder -- 2 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.THUNDER)
            .VulnerableTo(Element.GRASS, Element.GROUND)
            .ResistantTo(Element.FLY, Element.WATER, Element.FIRE,Element.ICE)
            .SuperResistantTo(Element.STEEL)
            .Build());

            //fairy -- 4 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.FAIRY)
            .VulnerableTo(Element.THUNDER, Element.POISON, Element.GRASS)
            .ResistantTo(Element.WATER,Element.FIRE, Element.FIGHTING, Element.ICE, Element.BUG, Element.DARK)
            .ImmuneTo(Element.DRAGON)
            .Build());

            //steel -- 1 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.STEEL)
            .VulnerableTo(Element.FIGHTING, Element.GROUND, Element.THUNDER)
            .ResistantTo(Element.DRAGON, Element.WATER, Element.FAIRY, Element.BUG, Element.NORMAL, Element.PSY, Element.ROCK, Element.FLY)
            .SuperResistantTo(Element.STEEL, Element.ICE)
            .ImmuneTo(Element.POISON)
            .Build());

            //ice -- 6 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.ICE)
            .VulnerableTo(Element.THUNDER, Element.GRASS,Element.ICE, Element.ROCK)
            .ResistantTo(Element.WATER)
            .SuperResistantTo(Element.ICE)
            .Build());

            //bug -- 5 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.BUG)
            .VulnerableTo(Element.ROCK,Element.THUNDER,Element.FLY)
            .ResistantTo(Element.WATER, Element.ICE, Element.FIGHTING, Element.STEEL, Element.GROUND)
            .Build());

            //grass -- 3 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.GRASS)
            .VulnerableTo(Element.POISON, Element.FLY, Element.BUG)
            .ResistantTo(Element.GROUND, Element.STEEL)
            .SuperResistantTo(Element.WATER)
            .Build());

            //psy -- 6 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.PSY)
            .VulnerableTo(Element.THUNDER, Element.GRASS, Element.BUG, Element.GHOST, Element.DARK)
            .ResistantTo(Element.WATER, Element.FIRE, Element.ICE, Element.FIGHTING,Element.STEEL, Element.PSY)
            .Build());

            //rock -- 10 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.ROCK)
            .SuperVulnerableTo(Element.GRASS)
            .VulnerableTo(Element.FIGHTING, Element.THUNDER,Element.GROUND)
            .ResistantTo(Element.NORMAL, Element.ICE, Element.POISON, Element.FLY)
            .SuperResistantTo(Element.FIRE)
            .Build());

            //ground -- 10 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.GROUND)
            .SuperVulnerableTo(Element.GRASS)
            .ResistantTo(Element.FIRE, Element.POISON, Element.ROCK, Element.STEEL)
            .ImmuneTo(Element.THUNDER)
            .Build());

            //ghost -- 2 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.GHOST)
            .VulnerableTo(Element.THUNDER, Element.GRASS,Element.GHOST, Element.DARK)
            .ResistantTo(Element.WATER, Element.ICE, Element.FIRE, Element.POISON, Element.STEEL, Element.BUG)
            .ImmuneTo(Element.NORMAL, Element.FIGHTING)
            .Build());

            //dark -- 7 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.DARK)
            .VulnerableTo(Element.THUNDER, Element.GRASS, Element.FIGHTING, Element.BUG,Element.FAIRY)
            .ResistantTo(Element.WATER, Element.ICE, Element.FIRE, Element.GHOST, Element.DARK, Element.STEEL)
            .ImmuneTo(Element.PSY)
            .Build());

            //fly -- 7 pokemons
            types.Add(new PokeBuilder(Element.WATER, Element.FLY)
            .SuperVulnerableTo(Element.THUNDER)
            .VulnerableTo(Element.ROCK)
            .ResistantTo(Element.WATER, Element.FIGHTING, Element.FIRE, Element.STEEL,Element.BUG)
            .ImmuneTo(Element.GROUND)
            .Build());

            //normal -- 1 pokemon
            types.Add(new PokeBuilder(Element.WATER,Element.NORMAL)
            .VulnerableTo(Element.THUNDER,Element.GRASS,Element.FIGHTING)
            .ResistantTo(Element.FIRE,Element.WATER,Element.ICE,Element.STEEL)
            .ImmuneTo(Element.GHOST)
            .Build());
        }

        /// <summary>
        /// Add fire & association types
        /// Amount of pokemons : 
        /// </summary>
        private static void BuildFireAssociatedTypes(List<PokemonType> types)
        {
            //fighting -- 7 pokemons
            types.Add(new PokeBuilder(Element.FIRE, Element.FIGHTING)
              .VulnerableTo(Element.WATER, Element.FLY, Element.GROUND, Element.PSY)
              .ResistantTo(Element.FIRE, Element.ICE, Element.GRASS, Element.DARK,Element.STEEL)
              .SuperResistantTo(Element.BUG)
              .Build());

            //dragon -- 3 pokemons
            types.Add(new PokeBuilder(Element.FIRE, Element.DRAGON)
              .VulnerableTo(Element.ROCK, Element.GROUND,Element.DRAGON)
              .ResistantTo(Element.THUNDER, Element.BUG, Element.STEEL)
              .SuperResistantTo(Element.GRASS,Element.FIRE)
              .Build());

            //water -- 1 pokemon
            types.Add(new PokeBuilder(Element.FIRE, Element.WATER)
            .VulnerableTo(Element.GROUND, Element.THUNDER,Element.ROCK)
            .ResistantTo(Element.FAIRY, Element.BUG)
            .SuperResistantTo(Element.FIRE, Element.ICE,Element.STEEL)
            .Build());

            //thunder -- 1 pokemon
            types.Add(new PokeBuilder(Element.FIRE, Element.THUNDER)
            .SuperVulnerableTo(Element.GROUND)
            .VulnerableTo(Element.WATER, Element.ROCK)
            .ResistantTo(Element.FLY,Element.FIRE,Element.THUNDER, Element.FAIRY, Element.ICE, Element.BUG,Element.GRASS)
            .SuperResistantTo(Element.STEEL)
            .Build());

            //fairy -- none
            types.Add(new PokeBuilder(Element.FIRE, Element.FAIRY)
            .VulnerableTo( Element.GROUND,Element.WATER,Element.POISON,Element.ROCK)
            .ResistantTo(Element.FIRE,Element.FIGHTING, Element.FAIRY, Element.ICE, Element.GRASS,Element.DARK)
            .SuperResistantTo(Element.BUG)
            .ImmuneTo(Element.DRAGON)
            .Build());

            //steel -- 1 pokemon
            types.Add(new PokeBuilder(Element.FIRE, Element.STEEL)
            .SuperVulnerableTo(Element.GROUND)
            .VulnerableTo(Element.FIGHTING, Element.WATER)
            .ResistantTo(Element.DRAGON, Element.NORMAL, Element.PSY, Element.FLY)
            .SuperResistantTo(Element.STEEL, Element.FAIRY, Element.ICE, Element.BUG, Element.GRASS)
            .ImmuneTo(Element.POISON)
            .Build());

            //ice -- none
            types.Add(new PokeBuilder(Element.FIRE, Element.ICE)
            .SuperVulnerableTo(Element.ROCK)
            .VulnerableTo(Element.GROUND,Element.WATER,Element.FIGHTING)
            .ResistantTo( Element.FAIRY, Element.BUG,Element.GRASS)
            .SuperResistantTo(Element.ICE)
            .Build());

            //bug -- 2 pokemons
            types.Add(new PokeBuilder(Element.FIRE, Element.BUG)
            .SuperVulnerableTo(Element.ROCK)
            .ResistantTo( Element.FAIRY, Element.ICE,Element.FIGHTING,Element.STEEL, Element.BUG)
            .SuperResistantTo(Element.GRASS)
            .Build());

            //grass -- none
            types.Add(new PokeBuilder(Element.FIRE, Element.GRASS)
            .VulnerableTo(Element.POISON,Element.FLY,Element.ROCK)
            .ResistantTo(Element.THUNDER, Element.FAIRY,Element.STEEL)
            .SuperResistantTo(Element.GRASS)
            .Build());

            //psy -- 3 pokemons
            types.Add(new PokeBuilder(Element.FIRE, Element.PSY)
            .VulnerableTo(Element.WATER, Element.GROUND,Element.ROCK, Element.GHOST, Element.DARK)
            .ResistantTo(Element.FIRE, Element.FAIRY, Element.ICE, Element.FIGHTING, Element.FAIRY, Element.STEEL, Element.PSY)
            .Build());

            //rock -- 1 pokemon
            types.Add(new PokeBuilder(Element.FIRE, Element.ROCK)
            .SuperVulnerableTo(Element.WATER, Element.GROUND)
            .VulnerableTo(Element.FIGHTING,Element.ROCK)
            .ResistantTo(Element.NORMAL,Element.ICE,Element.POISON,Element.FLY, Element.BUG, Element.FAIRY)
            .SuperResistantTo(Element.FIRE)
            .Build());

            //ground -- 4 pokemons
            types.Add(new PokeBuilder(Element.FIRE, Element.GROUND)
            .SuperVulnerableTo(Element.WATER)
            .VulnerableTo(Element.GROUND)
            .ResistantTo(Element.FIRE,Element.POISON,Element.BUG,Element.STEEL,Element.FAIRY)
            .ImmuneTo(Element.THUNDER)
            .Build());

            //ghost -- 5 pokemons
            types.Add(new PokeBuilder(Element.FIRE, Element.GHOST)
            .VulnerableTo(Element.WATER, Element.GROUND,Element.ROCK,Element.GHOST,Element.DARK)
            .ResistantTo(Element.FIRE, Element.ICE, Element.GRASS, Element.POISON, Element.STEEL, Element.FAIRY)
            .SuperResistantTo(Element.BUG)
            .ImmuneTo(Element.NORMAL, Element.FIGHTING)
            .Build());

            //dark -- 4 pokemons
            types.Add(new PokeBuilder(Element.FIRE, Element.DARK)
            .VulnerableTo(Element.GROUND,Element.WATER,Element.FIGHTING,Element.ROCK)
            .ResistantTo(Element.FIRE, Element.ICE,Element.GRASS, Element.GHOST, Element.DARK, Element.STEEL)
            .ImmuneTo(Element.PSY)
            .Build());

            //fly -- 7 pokemons
            types.Add(new PokeBuilder(Element.FIRE, Element.FLY)
            .SuperVulnerableTo(Element.ROCK)
            .VulnerableTo(Element.THUNDER, Element.WATER)
            .ResistantTo(Element.FIRE,Element.FIGHTING,Element.FAIRY,Element.STEEL)
            .SuperResistantTo(Element.BUG, Element.GRASS)
            .ImmuneTo(Element.GROUND)
            .Build());

            //normal -- 2 pokemons
            types.Add(new PokeBuilder(Element.FIRE, Element.NORMAL)
           .VulnerableTo(Element.FIGHTING,Element.GROUND,Element.ROCK, Element.WATER)
           .ResistantTo(Element.FIRE, Element.GRASS,Element.ICE,Element.BUG, Element.FAIRY, Element.STEEL)
           .ImmuneTo(Element.GHOST)
           .Build());
        }

        /// <summary>
        /// Add steel & association types
        /// Amount of pokemons : 37 (5,13%)
        /// </summary>
        private static void BuildSteelAssociatedTypes(List<PokemonType> types)
        {
            //fighting -- 2 pokemons
            types.Add(new PokeBuilder(Element.STEEL, Element.FIGHTING)
              .VulnerableTo(Element.FIGHTING, Element.FIRE, Element.GROUND)
              .ResistantTo(Element.STEEL, Element.DRAGON, Element.ICE, Element.NORMAL, Element.GRASS, Element.DARK)
              .SuperResistantTo(Element.BUG)
              .ImmuneTo(Element.POISON)
              .Build());

            //dragon -- 1 pokemon
            types.Add(new PokeBuilder(Element.STEEL, Element.DRAGON)
              .VulnerableTo(Element.FIGHTING, Element.GROUND)
              .ResistantTo(Element.STEEL, Element.WATER, Element.THUNDER, Element.BUG, Element.NORMAL, Element.PSY, Element.ROCK, Element.FLY)
              .SuperResistantTo(Element.GRASS)
              .ImmuneTo(Element.POISON)
              .Build());

            //water -- 1 pokemon
            types.Add(new PokeBuilder(Element.STEEL, Element.WATER)
            .VulnerableTo(Element.FIGHTING, Element.GROUND, Element.THUNDER)
            .ResistantTo(Element.DRAGON, Element.WATER, Element.FAIRY, Element.BUG, Element.NORMAL, Element.PSY, Element.ROCK, Element.FLY)
            .SuperResistantTo(Element.STEEL, Element.ICE)
            .ImmuneTo(Element.POISON)
            .Build());

            //thunder -- 3 pokemons
            types.Add(new PokeBuilder(Element.STEEL, Element.THUNDER)
            .SuperVulnerableTo(Element.GROUND)
            .VulnerableTo(Element.FIGHTING, Element.FIRE)
            .ResistantTo(Element.DRAGON, Element.THUNDER, Element.FAIRY, Element.ICE, Element.BUG, Element.NORMAL, Element.GRASS, Element.PSY, Element.ROCK)
            .SuperResistantTo(Element.STEEL, Element.FLY)
            .ImmuneTo(Element.POISON)
            .Build());

            //fairy -- 2 pokemons
            types.Add(new PokeBuilder(Element.STEEL, Element.FAIRY)
            .VulnerableTo(Element.FIRE, Element.GROUND)
            .ResistantTo(Element.FAIRY, Element.ICE, Element.NORMAL, Element.GRASS, Element.PSY, Element.ROCK, Element.DARK, Element.FLY)
            .SuperResistantTo(Element.BUG)
            .ImmuneTo(Element.POISON, Element.DRAGON)
            .Build());

            //fire -- 1 pokemon
            types.Add(new PokeBuilder(Element.STEEL, Element.FIRE)
            .SuperVulnerableTo(Element.GROUND)
            .VulnerableTo(Element.FIGHTING, Element.WATER)
            .ResistantTo(Element.DRAGON, Element.NORMAL, Element.PSY, Element.FLY)
            .SuperResistantTo(Element.STEEL, Element.FAIRY, Element.ICE, Element.BUG, Element.GRASS)
            .ImmuneTo(Element.POISON)
            .Build());

            //ice -- none
            types.Add(new PokeBuilder(Element.STEEL, Element.ICE)
            .SuperVulnerableTo(Element.FIGHTING, Element.FIRE)
            .VulnerableTo(Element.GROUND)
            .ResistantTo(Element.DRAGON, Element.FAIRY, Element.BUG, Element.NORMAL, Element.GRASS, Element.PSY, Element.FLY)
            .SuperResistantTo(Element.ICE)
            .ImmuneTo(Element.POISON)
            .Build());

            //bug -- 5 pokemons
            types.Add(new PokeBuilder(Element.STEEL, Element.BUG)
            .SuperVulnerableTo(Element.FIRE)
            .ResistantTo(Element.STEEL, Element.DRAGON, Element.FAIRY, Element.ICE, Element.BUG, Element.NORMAL, Element.PSY)
            .SuperResistantTo(Element.GRASS)
            .ImmuneTo(Element.POISON)
            .Build());

            //grass -- 2 pokemons
            types.Add(new PokeBuilder(Element.STEEL, Element.GRASS)
            .SuperVulnerableTo(Element.FIRE)
            .VulnerableTo(Element.FIGHTING)
            .ResistantTo(Element.STEEL, Element.DRAGON, Element.WATER, Element.THUNDER, Element.FAIRY, Element.NORMAL, Element.PSY, Element.ROCK)
            .SuperResistantTo(Element.GRASS)
            .ImmuneTo(Element.POISON)
            .Build());

            //psy -- 6 pokemons
            types.Add(new PokeBuilder(Element.STEEL, Element.PSY)
            .VulnerableTo(Element.FIRE, Element.GROUND, Element.GHOST, Element.DARK)
            .ResistantTo(Element.STEEL, Element.DRAGON, Element.FAIRY, Element.ICE, Element.NORMAL, Element.GRASS, Element.ROCK, Element.FLY)
            .SuperResistantTo(Element.PSY)
            .ImmuneTo(Element.POISON)
            .Build());

            //rock -- 6 pokemons
            types.Add(new PokeBuilder(Element.STEEL, Element.ROCK)
            .SuperVulnerableTo(Element.FIGHTING, Element.GROUND)
            .VulnerableTo(Element.WATER)
            .ResistantTo(Element.DRAGON, Element.FAIRY, Element.ICE, Element.BUG, Element.PSY, Element.ROCK)
            .SuperResistantTo(Element.NORMAL, Element.FLY)
            .ImmuneTo(Element.POISON)
            .Build());

            //ground -- 2 pokemons
            types.Add(new PokeBuilder(Element.STEEL, Element.GROUND)
            .VulnerableTo(Element.FIGHTING, Element.WATER, Element.GROUND)
            .ResistantTo(Element.STEEL, Element.DRAGON, Element.FAIRY, Element.BUG, Element.NORMAL, Element.PSY, Element.FLY)
            .SuperResistantTo(Element.ROCK)
            .ImmuneTo(Element.THUNDER, Element.POISON)
            .Build());

            //ghost -- 3 pokemons
            types.Add(new PokeBuilder(Element.STEEL, Element.GHOST)
            .VulnerableTo(Element.FIRE, Element.GROUND, Element.GHOST, Element.GHOST)
            .ResistantTo(Element.STEEL, Element.DRAGON, Element.FAIRY, Element.ICE, Element.GRASS, Element.PSY, Element.ROCK, Element.FLY)
            .SuperResistantTo(Element.BUG)
            .ImmuneTo(Element.NORMAL, Element.POISON)
            .Build());

            //dark -- 2 pokemons
            types.Add(new PokeBuilder(Element.STEEL, Element.DARK)
            .SuperVulnerableTo(Element.FIGHTING)
            .VulnerableTo(Element.GROUND)
            .ResistantTo(Element.STEEL, Element.DRAGON, Element.ICE, Element.NORMAL, Element.GRASS, Element.ROCK, Element.GHOST, Element.DARK, Element.FLY)
            .ImmuneTo(Element.POISON, Element.PSY)
            .Build());

            //fly -- 1 pokemon
            types.Add(new PokeBuilder(Element.STEEL, Element.FLY)
            .VulnerableTo(Element.THUNDER, Element.FIRE)
            .ResistantTo(Element.STEEL, Element.DRAGON, Element.FAIRY, Element.NORMAL, Element.PSY, Element.FLY)
            .SuperResistantTo(Element.BUG, Element.GRASS)
            .ImmuneTo(Element.POISON, Element.GROUND)
            .Build());

            //normal -- none
            types.Add(new PokeBuilder(Element.STEEL, Element.FLY)
            .SuperVulnerableTo(Element.FIGHTING)
            .VulnerableTo(Element.GROUND, Element.FIRE)
            .ResistantTo(Element.GRASS,Element.ICE,Element.BUG,Element.ROCK, Element.STEEL, Element.DRAGON, Element.FAIRY, Element.NORMAL, Element.PSY, Element.FLY)
            .ImmuneTo(Element.POISON, Element.GHOST)
            .Build());
        }
    }
}
