﻿using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Dialogs;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.ViewModel
{
    public class DevicePageViewModel : ViewModelBase
    {
        public DelegateCommand CheckResultCommand { get; set; }

        public ObservableCollection<ClickableElementViewModelBase> Elements { get; set; }

        public DevicePageViewModel(ApplicationMode appMode)
        {
            CreateCommands();
            InitializeElements();
        }
        
        private void CreateCommands()
        {
            CheckResultCommand = new DelegateCommand(OnCheckResult);
        }

        private void InitializeElements()
        {
            Elements = new ObservableCollection<ClickableElementViewModelBase>
                       {
                           new VkmThumblerViewModel { PosTop = 100, PosLeft = 100 },
                           new VkmRotateWheelViewModel(20, 5) { PosTop = 100, PosLeft = 100 }
                       };
        }

        private void OnCheckResult()
        {
            //TODO:Добавление проверки на оценку
            var dialog = new CheckResultsDialog(5);
            dialog.ShowDialog();
            VkmNavigationService.Instance.GoBack();
        }
    }
}