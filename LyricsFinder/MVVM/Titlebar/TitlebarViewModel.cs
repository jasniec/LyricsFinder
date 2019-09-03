using LyricsFinder.Core.MVVM.Settings;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace LyricsFinder.Main.MVVM.Titlebar
{
    class TitlebarViewModel : BindableBase
    {
        public TitlebarViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Title = "Lyrics Finder";
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                SetProperty(ref _title, value);
            }
        }

        public bool ShowOptions { get; set; } = true;
        public Brush Background => new SolidColorBrush(Color.FromRgb(53, 59, 72));
        public ICommand OptionsClick => new DelegateCommand(() => { _regionManager.RequestNavigate("Content", nameof(SettingsView)); });

        string _title;
        IRegionManager _regionManager;
    }
}
