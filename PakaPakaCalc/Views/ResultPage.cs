using System;
using Xamarin.Forms;
using PakaPakaCalc.ViewModels;
using PakaPakaCalc.ValueConverters;

namespace PakaPakaCalc.Views
{
    public partial class ResultPage : ContentPage
    {
        public ResultPage()
        {
            InitializeComponents();

            var vm = new ResultViewModel(this.Navigation);
            this.BindingContext = vm;

            this.ButtonNextGame.Clicked += (sender, e) => Navigation.PushAsync(new GameSettingPage());

            this.LabelResult.SetBinding(Label.TextProperty, new Binding(ResultViewModel.IsPassedPropertyName, BindingMode.OneWay, 
                new DelegateValueConverter<bool, string>(x => x ? "合格！" : "不合格…", null)));

            this.LabelStats.SetBinding(Label.TextProperty, new Binding(ResultViewModel.CollectCountPropertyName, BindingMode.OneWay, 
                new DelegateValueConverter<int, string>(x => String.Format("{0}問中、{1}問正解", vm.QuestionCount, x), null)));

            this.ListViewResult.ItemsSource = vm.Stats;
            this.ListViewResult.ItemTemplate = new DataTemplate(() =>
            {
                Func<Binding> colorBinding = () => new Binding("IsCollect", BindingMode.OneWay, 
                    new DelegateValueConverter<bool, Color>(x => x ? Color.Black : Color.Red, null));

                var labelNumber = new Label
                {
                    Font = Font.SystemFontOfSize(Style.FontSizeMid),
                    XAlign = TextAlignment.Center,
                    YAlign = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };
                labelNumber.SetBinding(Label.TextProperty,
                    new Binding("Number", BindingMode.OneWay, null, null, "{0}."));
                labelNumber.SetBinding(Label.TextColorProperty, colorBinding());

                var labelIsCollect = new Label
                {
                    Font = Font.SystemFontOfSize(Style.FontSizeLarge),
                    YAlign = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.Start,
                };
                labelIsCollect.SetBinding(Label.TextProperty, new Binding("IsCollect", BindingMode.OneWay, 
                    new DelegateValueConverter<bool, string>(x => x ? "○" : "×", null)));
                labelIsCollect.SetBinding(Label.TextColorProperty, colorBinding());

                var labelAnswer = new Label
                {
                    Font = Font.SystemFontOfSize(Style.FontSizeMid),
                    XAlign = TextAlignment.Center,
                    YAlign = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                labelAnswer.SetBinding(Label.TextProperty,
                    new Binding("Answer", BindingMode.OneWay, null, null, "回答:{0}"));
                labelAnswer.SetBinding(Label.TextColorProperty, colorBinding());

                var labelCollectAnswer = new Label
                {
                    Font = Font.SystemFontOfSize(Style.FontSizeMid),
                    XAlign = TextAlignment.Center,
                    YAlign = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                labelCollectAnswer.SetBinding(Label.TextProperty,
                    new Binding("CollectAnswer", BindingMode.OneWay, null, null, "正解:{0}"));
                labelCollectAnswer.SetBinding(Label.TextColorProperty, colorBinding());

                // Return an assembled ViewCell.
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            labelNumber,
                            labelIsCollect,
                            labelAnswer,
                            labelCollectAnswer,
                        },
                        VerticalOptions = LayoutOptions.Center,
                    }
                };
            });

        }
    }
}

