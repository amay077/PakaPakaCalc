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

            var vm = new AnswerViewModel(indexOfQuestions);
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

            vm.PropertyChanged += (sender, e) => 
            {
                if (String.Compare(e.PropertyName, AnswerViewModel.AnsweredIndexPropertyName) == 0) 
                {
                    Navigation.PushAsync(new PlayPage(vm.AnsweredIndex + 1));
                }
                else if (String.Compare(e.PropertyName, AnswerViewModel.IsFinishedPropertyName) == 0) 
                {
                    Navigation.PushAsync(new ResultPage());
                }
            };

        }
    }
}

