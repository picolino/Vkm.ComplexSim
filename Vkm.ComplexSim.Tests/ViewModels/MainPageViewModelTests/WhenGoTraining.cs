﻿#region Usings

using NUnit.Framework;
using Vkm.ComplexSim.Services.Navigate;

#endregion

namespace Vkm.ComplexSim.Tests.ViewModels.MainPageViewModelTests
{
    public class WhenGoTraining : MainPageViewModelTestBase
    {
        [Test]
        public void ChooseAlgorithmDialogIsShown()
        {
            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(DialogFactory.IsChooseAlgorithmDialogShown, Is.True);
        }

        [Test]
        public void ChooseDeviceDialogIsShown()
        {
            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(DialogFactory.IsChooseDeviceDialogShown, Is.True);
        }

        [Test]
        public void DevicePageModeIsTraining()
        {
            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(ViewInjectionManager.InjectedOuterPages[OuterRegionPages.Device].Mode, Is.EqualTo(ApplicationMode.Training));
        }

        [Test]
        public void InnerPajesAreCreated()
        {
            ViewInjectionManager.InjectedOuterPages.Clear();

            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(ViewInjectionManager.InjectedOuterPages.Count, Is.GreaterThan(0));
        }

        [Test]
        public void NavigatedOnDevicePage()
        {
            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(ViewInjectionManager.CurrentPages[Regions.OuterRegion], Is.Not.EqualTo(OuterRegionPages.MainMenu));
        }

        [Test]
        public void TrainingIsStart()
        {
            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(HintService.TrainingStarted);
        }
    }
}