using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using PakaPakaCalc.Models;

namespace PakaPakaCalc.ViewModels
{
    public class AnswerViewModel : BaseViewModel
    {
        private readonly int _indexOfQuestions;
        public AnswerViewModel(int indexOfQuestions)
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

        private int _answeredIndex = -1;
        public static readonly string AnsweredIndexPropertyName = "AnsweredIndex";
        public int AnsweredIndex
        {
            get { return _answeredIndex; }
            set { SetProperty(ref _answeredIndex, value, AnsweredIndexPropertyName); }
        }

        private bool _isFinished = false;
        public static readonly string IsFinishedPropertyName = "IsFinished";
        public bool IsFinished
        {
            get { return _isFinished; }
            set { SetProperty(ref _isFinished, value, IsFinishedPropertyName); }
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
                this.AnsweredIndex = _indexOfQuestions;
            }
            else
            {
                this.IsFinished = true;
            }

        }
    }
}

