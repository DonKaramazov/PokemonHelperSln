using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokHelper.Objects
{
    public enum Element
    {
        [Description("Plante")]
        GRASS,
        [Description("Eau")]
        WATER,
        [Description("Feu")]
        FIRE,
        [Description("Spectre")]
        GHOST,
        [Description("Normal")]
        NORMAL,
        [Description("Ténèbres")]
        DARK,
        [Description("Combat")]
        FIGHTING,
        [Description("Dragon")]
        DRAGON,
        [Description("Glace")]
        ICE,
        [Description("Fée")]
        FAIRY,
        [Description("Poison")]
        POISON,
        [Description("Insecte")]
        BUG,
        [Description("Acier")]
        STEEL,
        [Description("Psy")]
        PSY,
        [Description("Electrik")]
        THUNDER,
        [Description("Vol")]
        FLY,
        [Description("Roche")]
        ROCK,
        [Description("Sol")]
        GROUND

    }
}
