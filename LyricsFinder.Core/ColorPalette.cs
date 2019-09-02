using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LyricsFinder.Core
{
    public static class ColorPalette
    {
        public static Color Title => Color.FromRgb(53, 59, 72);
        public static Color Main => Color.FromRgb(42, 47, 57);
        public static Color Dark => Color.FromRgb(31, 35, 43);
        public static Color Font => Color.FromRgb(204, 204, 204);

        public static Brush TitleBrush => new SolidColorBrush(Title);
        public static Brush MainBrush => new SolidColorBrush(Main);
        public static Brush DarkBrush => new SolidColorBrush(Dark);
        public static Brush FontBrush => new SolidColorBrush(Font);
    }
}
