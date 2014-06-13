using System;
using Xamarin.Forms;
using PakaPakaCalc.ViewModels;
using PakaPakaCalc.ValueConverters;

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
            this.LabelAnswer.SetBinding(Label.TextProperty, AnswerViewModel.AnswerTextPropertyName);

            foreach (var btn in this.ButtonNumbers)
            {
                btn.Clicked += (sender, e) => 
                {
                    var b = sender as Button;
                    vm.AnswerText = vm.AnswerText + b.Text;
                };
            }

            this.ButtonClear.Clicked += (sender, e) => vm.AnswerText = String.Empty;

            this.ButtonEnter.BindingContext = vm;
            this.ButtonEnter.SetBinding(Button.CommandProperty, AnswerViewModel.CommandEnterAnswerCommandName);
            this.ButtonEnter.SetBinding(Button.IsEnabledProperty, new Binding(AnswerViewModel.AnswerTextPropertyName, BindingMode.OneWay, 
                new DelegateValueConverter<string, bool>(x => !String.IsNullOrEmpty(x), null)));
        }
    }
}

