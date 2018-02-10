﻿using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Services;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class ElementViewModelBase : ViewModelBase
    {

        private int hintsCounter;

        public DelegateCommand ShowHintCommand { get; set; }

        public ObservableCollection<HintViewModel> HintsCollection { get; set; }

        public string ImageSource
        {
            get { return GetProperty(() => ImageSource); }
            set { SetProperty(() => ImageSource, value); }
        }

        protected ElementViewModelBase()
        {
            hintsCounter = 0;
            CreateCommands();
        }

        private void CreateCommands()
        {
            ShowHintCommand = new DelegateCommand(OnShowHint);
        }

        private void OnShowHint()
        {
            HintService.Instance.ShowHint(PosTop, PosLeft, HintsCollection[hintsCounter++].HintText);
        }

        public double PosLeft { get; set; }
        public double PosTop { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public string Name { get; set; }
    }
}