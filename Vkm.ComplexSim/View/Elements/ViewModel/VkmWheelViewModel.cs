﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.Elements.ViewModel.Interfaces;

namespace Vkm.ComplexSim.View.Elements.ViewModel
{
    public class VkmWheelViewModel : ElementViewModelBase, IDependencyActivatorElement
    {
        private readonly bool isInitialize;
        private readonly int minValue;
        private readonly int maxValue;
        private readonly int rotationCoefficient;

        public ICommand MouseWheelCommand { get; private set; }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        public VkmWheelViewModel(int value, string imageSource, int minValue, int maxValue, int rotationCoefficient, List<DependencyAction> dependencyActions, string name, int posTop, int posLeft, int width, int height, Enum page) : base(value, name, posTop, posLeft, page, width, height)
        {
            isInitialize = true;

            this.minValue = minValue;
            this.maxValue = maxValue;
            this.rotationCoefficient = rotationCoefficient;
            DependencyActions = dependencyActions;
            ImageSource = imageSource;

            if (Value < minValue)
                Value = minValue;
            else if (Value > maxValue)
                Value = maxValue;
            else
                Value = value;

            RotationDegrees = rotationCoefficient * Value;

            CreateCommands();

            isInitialize = false;
        } 

        private void CreateCommands()
        {
            MouseWheelCommand = new DelegateCommand<MouseWheelEventArgs>(OnMouseWheel);
        }

        private void OnMouseWheel(MouseWheelEventArgs e)
        {
            var delta = e.Delta / 120;
            var nextValue = Value + delta;
            if (nextValue > maxValue || nextValue < minValue)
            {
                return;
            }

            Value = nextValue;
            RotationDegrees = rotationCoefficient * Value;
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            if (DependencyActions != null && !isInitialize)
            {
                NotifyDependedElements();
            }
        }

        public List<DependencyAction> DependencyActions { get; }

        public void CancelDependencyActionsExecution()
        {
        }

        public void NotifyDependedElements()
        {
            foreach (var dependencyAction in DependencyActions)
            {
                Task.Run(() => dependencyAction.UpdateDependencyElementValueAsync(Value));
            }
        }
    }
}