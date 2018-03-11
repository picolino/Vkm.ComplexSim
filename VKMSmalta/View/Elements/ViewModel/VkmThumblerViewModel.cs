﻿#region Usings

using System;
using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;

#endregion

namespace VKMSmalta.View.Elements.ViewModel
{
    public sealed class VkmThumblerViewModel : ClickableElementViewModelBase
    {
        private readonly bool isInitialize;
        private readonly string imageOffSource;
        private readonly string imageOnSource;

        private List<DependencyAction> DependencyActions { get; }

        public int StartupRotation
        {
            get { return GetProperty(() => StartupRotation); }
            set { SetProperty(() => StartupRotation, value); }
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            switch (Value)
            {
                case 0:
                    ImageSource = imageOffSource;
                    break;
                case 1:
                    ImageSource = imageOnSource;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            if (DependencyActions != null && !isInitialize)
            {
                NotifyDependedElements();
            }
        }

        public VkmThumblerViewModel(int value,
                                    string name,
                                    HistoryService historyService,
                                    string imageOffSource,
                                    string imageOnSource,
                                    List<DependencyAction> dependencyActions = null) : base(value, name, historyService)
        {
            isInitialize = true;

            this.imageOffSource = imageOffSource;
            this.imageOnSource = imageOnSource;
            DependencyActions = dependencyActions;
            Value = value;

            isInitialize = false;
        }

        protected override void OnMouseLeftButtonUp()
        {
            base.OnMouseLeftButtonUp();

            Value = Value == 0 ? 1 : 0;
        }

        private void NotifyDependedElements()
        {
            foreach (var dependencyAction in DependencyActions)
            {
                dependencyAction.SetDependencyElementValue(Value);
            }
        }
    }
}