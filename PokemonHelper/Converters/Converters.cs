using PokHelper.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PokemonHelper.Converters
{
    /// <summary>
    /// Convertit une String en Visibility
    /// Utile pour binder la visibilité d'un champ sur l'état du texte par exemple
    /// </summary>
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            String s = value as String;
            if (String.IsNullOrEmpty(s))
            {
                String param = parameter as String;
                if (String.IsNullOrEmpty(param) == false && param == "Collapsed")
                    return Visibility.Collapsed;
                else
                    return Visibility.Hidden;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class EnumToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((Element)value)
            {
                case Element.GRASS:
                    return "/Resources/Icons/type_plante.png";
                case Element.WATER:
                    return "/Resources/Icons/type_eau.png";
                case Element.FIRE:
                    return "/Resources/Icons/type_feu.png";
                case Element.GHOST:
                    return "/Resources/Icons/type_spectre.png";
                case Element.NORMAL:
                    return "/Resources/Icons/type_normal.png";
                case Element.DARK:
                    return "/Resources/Icons/type_ténèbres.png";
                case Element.FIGHTING:
                    return "/Resources/Icons/type_combat.png";
                case Element.DRAGON:
                    return "/Resources/Icons/type_dragon.png";
                case Element.ICE:
                    return "/Resources/Icons/type_glace.png";
                case Element.FAIRY:
                    return "/Resources/Icons/type_fee.png";
                case Element.POISON:
                    return "/Resources/Icons/type_poison.png";
                case Element.BUG:
                    return "/Resources/Icons/type_insecte.png";
                case Element.STEEL:
                    return "/Resources/Icons/type_acier.png";
                case Element.PSY:
                    return "/Resources/Icons/type_psy.png";
                case Element.THUNDER:
                    return "/Resources/Icons/type_electrik.png";
                case Element.FLY:
                    return "/Resources/Icons/type_vol.png";
                case Element.ROCK:
                    return "/Resources/Icons/type_roche.png";
                case Element.GROUND:
                    return "/Resources/Icons/type_sol.png";
                default:
                    return String.Empty;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class ListCountToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Membres

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility nonVisible = Visibility.Hidden;
            if (parameter != null && parameter.ToString() == "Collapsed")
                nonVisible = Visibility.Collapsed;

            IEnumerable ie = value as IEnumerable;
            if (ie == null || !ie.Cast<Object>().Any())
                return nonVisible;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
