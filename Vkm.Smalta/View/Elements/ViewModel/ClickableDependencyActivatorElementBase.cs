﻿#region Usings

using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public abstract class ClickableDependencyActivatorElementBase : ClickableElementViewModelBase, IDependencyActivatorElement
    {
        protected ClickableDependencyActivatorElementBase(int value, string name, HistoryService historyService, List<DependencyAction> dependencyActions) : base(value, name, historyService)
        {
            DependencyActions = dependencyActions;
        }

        #region IDependencyActivatorElement

        public void CancelDependencyActionsExecution()
        {
            if (DependencyActions == null || DependencyActions.Count == 0)
            {
                return;
            }

            foreach (var dependencyAction in DependencyActions)
            {
                dependencyAction.CancellationToken = true;
            }
        }

        public virtual void NotifyDependedElements()
        {
        }

        public List<DependencyAction> DependencyActions { get; }

        #endregion
    }
}