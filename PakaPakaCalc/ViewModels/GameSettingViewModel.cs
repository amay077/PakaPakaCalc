using System;
using System.ComponentModel;
using System.Collections.Generic;
using PakaPakaCalc.ViewModels;
using PakaPakaCalc.Models;
using Xamarin.Forms;
using PakaPakaCalc.Views;

namespace PakaPakaCalc.ViewModels
{
    public class GameSettingViewModel : BaseViewModel
    {
        public GameSettingViewModel(INavigation navigator) : base(navigator)
        {
        }

        private int _questionNum = 5;
        public static readonly string QuestionNumPropertyName = "QuestionNum";
        public int QuestionNum
        {
            get { return _questionNum; }
            set { SetProperty(ref _questionNum, value, QuestionNumPropertyName); }
        }

        private int _questionTimes = 5;
        public static readonly string QuestionTimesPropertyName = "QuestionTimes";
        public int QuestionTimes
        {
            get { return _questionTimes; }
            set { SetProperty(ref _questionTimes, value, QuestionTimesPropertyName); }
        }

        private double _intervals = 1d;
        public static readonly string IntervalsPropertyName = "Intervals";
        public double Intervals
        {
            get { return _intervals; }
            set { SetProperty(ref _intervals, value, IntervalsPropertyName); }
        }

        private int _questionDigits = 1;
        public static readonly string QuestionDigitsPropertyName = "QuestionDigits";
        public int QuestionDigits
        {
            get { return _questionDigits; }
            set { SetProperty(ref _questionDigits, value, QuestionDigitsPropertyName); }
        }

        private Command _commandPlay;
        public const string PlayCommandName = "CommandPlay";
        public Command CommandPlay
        {
            get
            {
                return _commandPlay ?? (_commandPlay = new Command(_ => 
                {
                    var settings = new GameSettings(this.QuestionDigits, this.QuestionTimes, this.Intervals, this.QuestionNum);
                    GameModel.Instance.BuildGame(settings);

                    this.Navigator.PushAsync(new PlayPage(0));
                }));
            }
        }


    }
}

