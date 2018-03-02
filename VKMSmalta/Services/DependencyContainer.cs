﻿using System.Collections.Generic;
using System.Linq;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.Services
{
    public class DependencyContainer
    {
        private readonly DevicePageViewModel devicePageVm;

        public static DependencyContainer Instance { get; private set; }
        
        public DependencyContainer(DevicePageViewModel vm)
        {
            devicePageVm = vm;
        }

        public static void InitializeService(DevicePageViewModel vm)
        {
            if (Instance == null)
            {
                Instance = new DependencyContainer(vm);
            }
        }

        public IEnumerable<ElementViewModelBase> GetAllElementsOfCurrentDevicePage()
        {
            return devicePageVm.UnionedElements;
        }
    }
}