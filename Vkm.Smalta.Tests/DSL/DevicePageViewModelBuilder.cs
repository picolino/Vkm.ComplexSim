﻿#region Usings

using System.Collections.Generic;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Tests.Fakes.ServicesAndFactories;
using Vkm.Smalta.View.ViewModel;

#endregion

namespace Vkm.Smalta.Tests.DSL
{
    public class DevicePageViewModelBuilder : BaseBuilder
    {
        private Algorithm algorithm = new Algorithm(new Dictionary<string, int>(), new Dictionary<string, int>());
        private DeviceEntry deviceEntry = new DeviceEntry();
        private ApplicationMode mode = ApplicationMode.Training;

        public DevicePageViewModelBuilder(IAppContext app, DialogFactoryStub dialogFactory, HintServiceStub hintService,
                                          LoadingServiceStub loadingService, HistoryService historyService, ViewInjectionManagerStub viewInjectionManager,
                                          DevicesFactory devicesFactory, ActionsFactory actionsFactory,
                                          PagesFactory pagesFactory) : base(app, dialogFactory, hintService, loadingService, historyService, viewInjectionManager, devicesFactory, actionsFactory, pagesFactory)
        {
            algorithm.Actions = new LinkedList<Action>();
        }

        public DevicePageViewModel Please()
        {
            return new DevicePageViewModel(mode, algorithm, deviceEntry, HintService, HistoryService, DialogFactory, ViewInjectionManager, PagesFactory);
        }

        public DevicePageViewModelBuilder WithAlgorithm(Algorithm algorithm)
        {
            this.algorithm = algorithm;
            return this;
        }

        public DevicePageViewModelBuilder WithDeviceEntry(DeviceEntry deviceEntry)
        {
            this.deviceEntry = deviceEntry;
            return this;
        }

        public DevicePageViewModelBuilder WithMode(ApplicationMode mode)
        {
            this.mode = mode;
            return this;
        }
    }
}