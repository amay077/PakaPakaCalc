using System;
using Xamarin.Forms;
using PakaPakaCalc.ViewModels;
using PakaPakaCalc.ValueConverters;

namespace PakaPakaCalc.Views
{
    public partial class PlayPage : ContentPage
    {
        public PlayPage(int indexOfQuestion)
        {
            InitializeComponent();

            var vm = new PlayViewModel(this.Navigation, indexOfQuestion);
            this.BindingContext = vm;

            this.LabelNumber.SetBinding(Label.TextProperty,
                new Binding(PlayViewModel.NumberPropertyName, BindingMode.OneWay));

            this.LabelNumber.SetBinding(Label.FontProperty,
                new Binding(PlayViewModel.IsStartingPropertyName, BindingMode.OneWay, 
                    new DelegateValueConverter<bool, Font>(x => x ? 
                        Font.SystemFontOfSize(Style.FontSizeBiggest) : 
                        Font.SystemFontOfSize(Style.FontSizeBig), null)));
        }
    }
}

