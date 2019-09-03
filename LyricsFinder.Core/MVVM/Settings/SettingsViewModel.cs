﻿using LyricsFinder.Core.MVVM.Song;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LyricsFinder.Core.MVVM.Settings
{
    class SettingsViewModel : BindableBase
    {
        public SettingsViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public ICommand Close => new DelegateCommand(() => { _regionManager.RequestNavigate("Content", nameof(SongView)); });

        readonly IRegionManager _regionManager;
    }
}
