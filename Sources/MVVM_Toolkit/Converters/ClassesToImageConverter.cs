using Model;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Toolkit.Converters
{
    public class ClassesToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            var classes = (ChampionClass)value;
            switch (classes)
            {
                case ChampionClass.Assassin:
                    return "assassin_icon.png";
                case ChampionClass.Fighter:
                    return "fighter_icon.png";
                case ChampionClass.Mage:
                    return "mage_icon.png";
                case ChampionClass.Marksman:
                    return "marksman_icon.png";
                case ChampionClass.Support:
                    return "support_icon.png";
                case ChampionClass.Tank:
                    return "tank_icon.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
