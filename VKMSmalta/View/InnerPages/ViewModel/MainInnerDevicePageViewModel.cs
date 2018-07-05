﻿#region Usings

using System.Collections.ObjectModel;
using System.Windows.Media;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;

#endregion

namespace Vkm.Smalta.View.InnerPages.ViewModel
{
    public class MainInnerDevicePageViewModel : InnerPageViewModelBase
    {
        private readonly Algorithm currentAlgorithm;
        private readonly HistoryService historyService;

        public MainInnerDevicePageViewModel(HistoryService historyService, InnerRegionPage pageKey, string background, Algorithm currentAlgorithm) : base(pageKey, background)
        {
            this.historyService = historyService;
            this.currentAlgorithm = currentAlgorithm;
            InitializeElements(); //TODO: ВЫШЕ!
        }

        private void InitializeElements()
        {
            if (PageKey == InnerRegionPage.LO01P)
            {
                Elements = new ObservableCollection<ElementViewModelBase>
                           {
                               //Тумблеры в середине
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(280, 341).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(323, 340).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(367, 341).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(411, 341).Thumbler(historyService).Please(),

                               //Подсветка в середине
                               GiveMe.Element().On(PageKey).WithName("lo01p_reciever_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(309, 540).LightBox("ПРИЕМНИК\nI КАНАЛ").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_reciever_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(353, 540).LightBox("ПРИЕМНИК\nII КАНАЛ").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_reciever_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(396, 540).LightBox("ПРИЕМНИК\nIII КАНАЛ").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_reciever_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(441, 541).LightBox("ПРИЕМНИК\nIV КАНАЛ").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_antenna_leftside").WithValueFrom(currentAlgorithm.StartStateOfElements).At(483, 540).LightBox("АНТЕННА\nЛЕВЫЙ БОРТ").Please(),

                               GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(309, 628).LightBox("ПЕРЕДАТЧИК\nI КАНАЛ").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(353, 628).LightBox("ПЕРЕДАТЧИК\nI КАНАЛ").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(396, 628).LightBox("ПЕРЕДАТЧИК\nI КАНАЛ").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(441, 627).LightBox("ПЕРЕДАТЧИК\nI КАНАЛ").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_antenna_rightside").WithValueFrom(currentAlgorithm.StartStateOfElements).At(484, 627).LightBox("АНТЕННА\nПРАВЫЙ БОРТ").Please(),

                               GiveMe.Element().On(PageKey).WithName("lo01p_defect_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(311, 715).LightBox("НЕИСПРАВНОСТЬ\nI КАНАЛ").WithBackgroundColor(Colors.Orange).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_defect_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(354, 715).LightBox("НЕИСПРАВНОСТЬ\nII КАНАЛ").WithBackgroundColor(Colors.Orange).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_defect_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(396, 714).LightBox("НЕИСПРАВНОСТЬ\nIII КАНАЛ").WithBackgroundColor(Colors.Orange).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_defect_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(441, 714).LightBox("НЕИСПРАВНОСТЬ\nIV КАНАЛ").WithBackgroundColor(Colors.Orange).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_1cooler").WithValueFrom(currentAlgorithm.StartStateOfElements).At(484, 714).LightBox("ВЕНТИЛЯТОР I").Please(),

                               GiveMe.Element().On(PageKey).WithName("lo01p_glow_on").WithValueFrom(currentAlgorithm.StartStateOfElements).At(310, 802).LightBox("НАКАЛ\nВКЛЮЧЕН").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_simulator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(353, 802).LightBox("ИМИТАТОР").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_modulation").WithValueFrom(currentAlgorithm.StartStateOfElements).At(441, 801).LightBox("МОДУЛЯЦИЯ").Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_2cooler").WithValueFrom(currentAlgorithm.StartStateOfElements).At(484, 801).LightBox("ВЕНТИЛЯТОР II").Please(),

                               //Тумблеры снизу
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_simulator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(582, 385).Thumbler(historyService)
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_simulator")
                                                                 .WithDependencyValue(0, 0)
                                                                 .WithDependencyValue(1, 1)
                                                                 .Please())
                                     .Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_antenna_leftside").WithValueFrom(currentAlgorithm.StartStateOfElements).At(584, 662).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_antenna_rightside").WithValueFrom(currentAlgorithm.StartStateOfElements).At(586, 752).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_light").WithValueFrom(currentAlgorithm.StartStateOfElements).At(656, 753).Thumbler(historyService).Please(),

                               //Кнопки снизу
                               GiveMe.Element().On(PageKey).WithName("lo01p_button_reciever_glow_on").WithValueFrom(currentAlgorithm.StartStateOfElements).At(581, 463).BigButton(historyService)
                                     .WithDependencySecureElement("lo01p_button_reciever_glow_off")
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_glow_on")
                                                                 .WithDependencyValue(1, 1)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01r_lamp_heating")
                                                                 .WithDependencyValue(1, 1)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01r_lamp_heating")
                                                                 .WithDependencyValue(1, 0)
                                                                 .WithDelay(5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_1channel")
                                                                 .WithDependencyValue(1, 1)
                                                                 .WithDelay(10)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_2channel")
                                                                 .WithDependencyValue(1, 1)
                                                                 .WithDelay(10)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_3channel")
                                                                 .WithDependencyValue(1, 1)
                                                                 .WithDelay(10)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_4channel")
                                                                 .WithDependencyValue(1, 1)
                                                                 .WithDelay(10)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_1channel_arrow")
                                                                 .WithDependencyValue(1, 1)
                                                                 .WithDelay(10)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_2channel_arrow")
                                                                 .WithDependencyValue(1, 1)
                                                                 .WithDelay(10)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_3channel_arrow")
                                                                 .WithDependencyValue(1, 1)
                                                                 .WithDelay(10)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_4channel_arrow")
                                                                 .WithDependencyValue(1, 1)
                                                                 .WithDelay(10)
                                                                 .Please())
                                     .Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_button_reciever_glow_off").WithValueFrom(currentAlgorithm.StartStateOfElements).At(655, 462).BigButton(historyService)
                                     .WithDependencySecureElement("lo01p_button_reciever_glow_on")
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_glow_on")
                                                                 .WithDependencyValue(1, 0)
                                                                 .WithDelay(8)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_1channel_arrow")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_2channel_arrow")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_3channel_arrow")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_4channel_arrow")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_1channel")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_2channel")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_3channel")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_reciever_4channel")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_button_transmitter_on").WithValueFrom(currentAlgorithm.StartStateOfElements).At(580, 554).BigButton(historyService)
                                     .WithDependencySecureElement("lo01p_button_transmitter_off")
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_1channel")
                                                                 .WithDependencyValue(1, 1)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_2channel")
                                                                 .WithDependencyValue(1, 1)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_3channel")
                                                                 .WithDependencyValue(1, 1)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_4channel")
                                                                 .WithDependencyValue(1, 1)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_1channel_arrow")
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_2channel_arrow")
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_3channel_arrow")
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_4channel_arrow")
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_button_transmitter_off").WithValueFrom(currentAlgorithm.StartStateOfElements).At(655, 554).BigButton(historyService)
                                     .WithDependencySecureElement("lo01p_button_transmitter_on")
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_1channel")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_2channel")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_3channel")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_4channel")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_1channel_arrow")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_2channel_arrow")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_3channel_arrow")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .WithDependencyElementName("lo01p_transmitter_4channel_arrow")
                                                                 .WithDependencyValue(1, 0)
                                                                 .Please())
                                     .Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_button_control").WithValueFrom(currentAlgorithm.StartStateOfElements).At(656, 371).BigButton(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_button_eject").WithValueFrom(currentAlgorithm.StartStateOfElements).At(655, 645).BigButton(historyService).Please(),

                               //Тумблеры справа сверху
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_power").WithValueFrom(currentAlgorithm.StartStateOfElements).At(68, 1178).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_cold").WithValueFrom(currentAlgorithm.StartStateOfElements).At(67, 1226).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_autosarpp").WithValueFrom(currentAlgorithm.StartStateOfElements).At(69, 1278).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_aircontrol").WithValueFrom(currentAlgorithm.StartStateOfElements).At(70, 1329).Thumbler(historyService).Please(),

                               //Тумблеры справа снизу
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_cooler").WithValueFrom(currentAlgorithm.StartStateOfElements).At(636, 1170).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_light_maintance").WithValueFrom(currentAlgorithm.StartStateOfElements).At(637, 1217).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_light_advanced").WithValueFrom(currentAlgorithm.StartStateOfElements).At(635, 1262).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_light_table").WithValueFrom(currentAlgorithm.StartStateOfElements).At(636, 1308).Thumbler(historyService).Please(),

                               //Стрелки слева
                               GiveMe.Element().On(PageKey).WithName("lo01p_reciever_1channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(96, 127).LittleArrow().Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_reciever_2channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(288, 127).LittleArrow().Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_reciever_3channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(478, 128).LittleArrow().Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_reciever_4channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(665, 128).LittleArrow().Please(),

                               //Стрелки справа
                               GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_1channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(103, 1004).LittleArrow().Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_2channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(294, 1004).LittleArrow().Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_3channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(479, 1003).LittleArrow().Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_4channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(667, 999).LittleArrow().Please()
                           };
            }

            if (PageKey == InnerRegionPage.LO01R)
            {
                Elements = new ObservableCollection<ElementViewModelBase>
                           {
                               //Тумблеры приемника-передатчика
                               GiveMe.Element().On(PageKey).WithName("lo01r_reciever_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(400, 104).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01r_reciever_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(400, 168).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01r_reciever_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(398, 236).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01r_reciever_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(395, 303).Thumbler(historyService).Please(),

                               GiveMe.Element().On(PageKey).WithName("lo01r_transmitter_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(394, 366).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01r_transmitter_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(396, 435).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01r_transmitter_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(394, 507).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01r_transmitter_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(393, 576).Thumbler(historyService).Please(),

                               //Лампочки в середине устройства
                               GiveMe.Element().On(PageKey).WithName("lo01r_lamp_network_27v").WithValueFrom(currentAlgorithm.StartStateOfElements).At(109, 829).Lamp().Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01r_lamp_equal").WithValueFrom(currentAlgorithm.StartStateOfElements).At(258, 786).Lamp().Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01r_lamp_+10v").WithValueFrom(currentAlgorithm.StartStateOfElements).At(257, 878).Lamp().Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01r_lamp_heating").WithValueFrom(currentAlgorithm.StartStateOfElements).At(575, 836).Lamp().Please(),

                               //Контролы управления в середине устройства
                               GiveMe.Element().On(PageKey).WithName("lo01r_antenna_equal").At(309, 788).WithValueFrom(currentAlgorithm.StartStateOfElements).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01r_modulation").At(430, 806).WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(30).RotateWheel(historyService)
                                     .WithMaxValue(5).WithRotationStepDegrees(30).Please()
                           };
            }

            if (PageKey == InnerRegionPage.LO01I_LO01K)
            {
                Elements = new ObservableCollection<ElementViewModelBase>
                           {
                               //lo01I
                               GiveMe.Element().On(PageKey).WithName("lo01i_thumbler_1generator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(301, 369).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01i_thumbler_2generator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(302, 523).Thumbler(historyService)
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_1channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_2channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_3channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_4channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     //////////////////////////////////////////////////////////////////////
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_1channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_2channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_3channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_4channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01i_thumbler_3generator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(443, 364).Thumbler(historyService)
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_1channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_2channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_3channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_4channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     //////////////////////////////////////////////////////////////////////
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_1channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_2channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_3channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_4channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01i_thumbler_4generator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(439, 524).Thumbler(historyService)
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_1channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_2channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_3channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_reciever_4channel_arrow")
                                                                 .WithDependencyValue(0, -5)
                                                                 .WithDependencyValue(1, 5)
                                                                 .Please())
                                     //////////////////////////////////////////////////////////////////////
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_1channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_2channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_3channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("lo01p_transmitter_4channel_arrow")
                                                                 .WithDependencyValue(0, 2)
                                                                 .WithDependencyValue(1, -2)
                                                                 .Please())
                                     .Please(),

                               //lo01K
                               GiveMe.Element().On(PageKey).WithName("lo01k_modulation_13channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(262, 1140).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("lo01k_modulation_24channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(264, 1237).Thumbler(historyService).Please()
                           };
            }
        }
    }
}