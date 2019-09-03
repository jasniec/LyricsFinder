using LyricsFinder.Core.MVVM.Settings;
using LyricsFinder.Core.MVVM.Song;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.Core
{
    public class ModuleCore : IModule
    {
        public ModuleCore(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        IRegionManager _regionManager;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("Content", typeof(SongView));
            _regionManager.RegisterViewWithRegion("Content", typeof(SettingsView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<SongView, SongViewModel>();
            ViewModelLocationProvider.Register<SettingsView, SettingsViewModel>();
        }
    }
}
