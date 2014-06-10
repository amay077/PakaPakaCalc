using System;
using Xamarin.Forms;
using System.Collections.Generic;
using PakaPakaCalc.ValueConverters;
using PakaPakaCalc.ViewModels;

namespace PakaPakaCalc.Views
{
    public partial class GameSettingPage : ContentPage
    {
        public GameSettingPage()
        {
            InitializeComponent();

            var vm = new GameSettingViewModel();
            this.BindingContext = vm;

            this.LabelNums.SetBinding(Label.TextProperty, 
                new Binding(GameSettingViewModel.QuestionNumPropertyName, BindingMode.OneWay, 
                    null, null, "問題数:{0}"));

            this.SliderNums.SetBinding(Slider.ValueProperty,
                new Binding(GameSettingViewModel.QuestionNumPropertyName, BindingMode.TwoWay, 
                    new DelegateValueConverter<int, double>(Convert.ToDouble, Convert.ToInt32)));

            this.LabelTimes.SetBinding(Label.TextProperty, 
                new Binding(GameSettingViewModel.QuestionTimesPropertyName, BindingMode.OneWay, 
                    null, null, "口数:{0}"));

            this.SliderTimes.SetBinding(Slider.ValueProperty,
                new Binding(GameSettingViewModel.QuestionTimesPropertyName, BindingMode.TwoWay, 
                    new DelegateValueConverter<int, double>(Convert.ToDouble, Convert.ToInt32)));

            this.LabelDigits.SetBinding(Label.TextProperty, 
                new Binding(GameSettingViewModel.QuestionDigitsPropertyName, BindingMode.OneWay, 
                    null, null, "桁数:{0}"));

            this.SliderDigits.SetBinding(Slider.ValueProperty,
                new Binding(GameSettingViewModel.QuestionDigitsPropertyName, BindingMode.TwoWay, 
                    new DelegateValueConverter<int, double>(Convert.ToDouble, Convert.ToInt32)));

            this.LabelIntervals.SetBinding(Label.TextProperty, 
                new Binding(GameSettingViewModel.IntervalsPropertyName, BindingMode.OneWay, 
                    null, null, "間隔:{0:0.0}秒"));

            this.SliderIntervals.SetBinding(Slider.ValueProperty,
                new Binding(GameSettingViewModel.IntervalsPropertyName, BindingMode.TwoWay));

            this.ButtonPlay.BindingContext = vm;
            this.ButtonPlay.SetBinding(Button.CommandProperty, GameSettingViewModel.PlayCommandName);

            vm.PropertyChanged += (sender, e) =>
            {
                if (String.Compare(e.PropertyName, GameSettingViewModel.GameSettingsPropertyName) == 0) {
                    Navigation.PushAsync(new PlayPage(0));
                }
            };
        }
    }
}

