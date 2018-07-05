﻿using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

namespace Vkm.Smalta.Dialogs.Factories
{
    public interface IDialogFactory
    {
        void ShowInfoDialog();
        bool ShowLoginDialog();
        bool ShowRegisterDialog();
        Algorithm ShowChooseAlgorithmDialog(IHintService vm);
        bool ShowTrainingCompleteDialog();
    }
}