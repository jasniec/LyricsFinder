using LyricsFinder.Main.MVVM.Titlebar;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.Main
{
    class ModuleMain : IModule
    {
        public ModuleMain(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        IRegionManager _regionManager;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(nameof(TitlebarView), typeof(TitlebarView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<TitlebarView, TitlebarViewModel>();
        }
    }
}
