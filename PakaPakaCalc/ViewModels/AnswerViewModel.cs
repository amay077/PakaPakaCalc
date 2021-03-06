﻿using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using PakaPakaCalc.Models;
using PakaPakaCalc.Views;

namespace PakaPakaCalc.ViewModels
{
    public class AnswerViewModel : BaseViewModel
    {
        private readonly int _indexOfQuestions;
        public AnswerViewModel(INavigation navigator, int indexOfQuestions) : base(navigator)
        {
            _indexOfQuestions = indexOfQuestions;
        }

        private string _answerText = String.Empty;
        public static readonly string AnswerTextPropertyName = "AnswerText";
        public string AnswerText
        {
            get { return _answerText; }
            set { SetProperty(ref _answerText, value, AnswerTextPropertyName); }
        }

        private ICommand _commandEnterAnswer;
        public const string CommandEnterAnswerCommandName = "CommandEnterAnswer";
        public ICommand CommandEnterAnswer
        {
            get
            {
                return _commandEnterAnswer ?? (_commandEnterAnswer = 
                    new Command(() => ExecuteCommandEnterAnswer()));
            }
        }

        private void ExecuteCommandEnterAnswer()
        {
            var correct = GameModel.Instance.SetAnswer(_indexOfQuestions, Convert.ToInt32(_answerText));

            if (_indexOfQuestions < GameModel.Instance.Settings.Nums - 1)
            {
                this.Navigator.PushAsync(new PlayPage(_indexOfQuestions + 1));
            }
            else
            {
                this.Navigator.PushAsync(new ResultPage());
            }

        }
    }
}

