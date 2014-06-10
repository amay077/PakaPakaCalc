using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace PakaPakaCalc.Views
{
    public partial class AnswerPage
    {
        public Button[] ButtonNumbers { get; private set; }
        public Button ButtonClear { get; private set; }
        public Button ButtonEnter { get; private set; }
        public Label LabelAnswer { get; private set; }

        private void InitializeComponent()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                RowSpacing = Style.MarginSmall,
                ColumnSpacing = Style.MarginSmall,
            };

            // Answer label
            this.LabelAnswer = new Label
            {
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                Font = Font.SystemFontOfSize(Style.FontSizeBig),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
            };
            grid.Children.Add(this.LabelAnswer, 0, 3, 0, 1);

            var numberButtons = new List<Button>();

            // 1-9 buttons
            var buttons = Enumerable.Range(1, 9)
                .Select(x => CreateButton(x.ToString()))
                .ToList();

            for (int i = 0; i < buttons.Count; i++)
            {
                grid.Children.Add(buttons[i], i % 3, 1 + (i / 3));
            }

            // 0, clear, enter
            var zeroButton = CreateButton("0");
            grid.Children.Add(zeroButton, 0, 4);

            numberButtons.Add(zeroButton);
            numberButtons.AddRange(buttons);
            this.ButtonNumbers = numberButtons.ToArray();

            this.ButtonClear = CreateButton("C");
            grid.Children.Add(this.ButtonClear, 1, 4);

            this.ButtonEnter = CreateButton("OK");
            grid.Children.Add(this.ButtonEnter, 2, 4);

            this.Content = new StackLayout
            {
                Padding = new Thickness(Style.MarginMid),
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    grid,
                },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

        }

        private Button CreateButton(string text)
        {
            var btn = new Button 
            {
                Font = Font.SystemFontOfSize(Style.FontSizeBig),
                Text = text
            };

            return btn;
        }
    }
}

