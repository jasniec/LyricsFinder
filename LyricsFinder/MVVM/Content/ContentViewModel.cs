using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyricsFinder.Core;

namespace LyricsFinder.Main.MVVM.Content
{
    class ContentViewModel : BindableBase
    {
        public ContentViewModel()
        {
            var a = ColorPalette.Main;
        }
    }
}
