using System;
using Xamarin.Forms;
using PakaPakaCalc.ViewModels;
using PakaPakaCalc.ValueConverters;
using System.Threading.Tasks;

namespace PakaPakaCalc.Views
{
    public partial class AnswerPage : ContentPage
    {
        public AnswerPage(int indexOfQuestions)
        {
            InitializeComponent();

            var vm = new AnswerViewModel(this.Navigation, indexOfQuestions);
            this.BindingContext = vm;

            this.LabelAnswer.BindingContext = vm;
            this.LabelAnswer.SetBinding(Label.TextProperty, new Binding(AnswerViewModel.AnswerTextPropertyName, BindingMode.OneWay, 
                new DelegateValueConverter<string, string>(x => String.IsNullOrEmpty(x) ? "答えは？" : x, null)));

            foreach (var btn in this.ButtonNumbers)
            {
                btn.Clicked += (sender, e) => 
                {
                    var b = sender as Button;
                    vm.AnswerText = vm.AnswerText + b.Text;
                };
            }

            this.ButtonClear.Clicked += (sender, e) => vm.AnswerText = String.Empty;
            this.ButtonClear.LongClicked += async (sender, e) => 
            {
                if (await this.DisplayAlert(String.Empty, "はじめにもどりますか？", "はい", "いいえ")) 
                {
                    await this.Navigation.PushAsync(new GameSettingPage());
                }
            };

            this.ViewResult.BindingContext = vm;
            this.ViewResult.SetBinding(View.BackgroundColorProperty, new Binding(
                AnswerViewModel.IsCorrectAnswerPropertyName, BindingMode.OneWay,
                new DelegateValueConverter<bool?, Color>(x => x.HasValue && x.Value ? Color.Blue : Color.Red, null)
            ));

            this.ButtonEnter.BindingContext = vm;
            this.ButtonEnter.SetBinding(Button.CommandProperty, AnswerViewModel.CommandEnterAnswerCommandName);
            this.ButtonEnter.SetBinding(Button.IsEnabledProperty, new Binding(AnswerViewModel.AnswerTextPropertyName, BindingMode.OneWay, 
                new DelegateValueConverter<string, bool>(x => !String.IsNullOrEmpty(x), null)));

            vm.PropertyChanged += async (sender, e) => 
            {
                if (String.Equals(e.PropertyName, AnswerViewModel.IsCorrectAnswerPropertyName)) {
                    this.LabelResult.Text = vm.IsCorrectAnswer.Value ? "正解！" : "不正解";

                    this.ViewResult.IsVisible = true;
                    await Task.Delay(1000);
                    this.ViewResult.IsVisible = false;

                    if (vm.CommandNextPage.CanExecute(null)) {
                        vm.CommandNextPage.Execute(null);
                    }
                }
            };
        }
    }
}

