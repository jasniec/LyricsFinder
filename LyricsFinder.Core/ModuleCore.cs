using Prism.Ioc;
using Prism.Modularity;
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
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
