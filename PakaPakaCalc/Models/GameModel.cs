using System;
using System.Linq;
using System.Collections.Generic;

namespace PakaPakaCalc.Models
{
    public class GameModel
    {
        private static GameModel _instance = null;
        public static GameModel Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new GameModel();
                }

                return _instance;
            }
        }

        private GameModel()
        {
        }

        public GameSettings Settings  
        {
            get;
            private set;
        }

        private readonly List<int[]> _numbersList = new List<int[]>();
        private List<int> _answerList;
        private readonly List<int> _correctAnswerList = new List<int>();

        public void BuildGame(GameSettings settings) 
        {
            this.Settings = settings;

            _answerList = Enumerable.Repeat(0, settings.Nums).ToList();
            _numbersList.Clear();
            _correctAnswerList.Clear();
            var rand = new Random();
            for (int i = 0; i < settings.Nums; i++)
            {
                var nums = Enumerable.Range(0, settings.Times)
                    .Select(_ =>
                {
                    int n;
                    while ((n = rand.Next((int)Math.Pow(10, settings.Digits))) == 0)
                    {
                    }
                    return n;
                });
                var arrNums = nums.ToArray();
                _numbersList.Add(arrNums);
                _correctAnswerList.Add(arrNums.Sum());
            }
        }

        public int[] GetNumbers(int indexOfQuestions)
        {
            return _numbersList[indexOfQuestions];
        }

        public bool SetAnswer(int indexOfQuestions, int answer)
        {
            var correct = _correctAnswerList[indexOfQuestions] == answer;
            _answerList[indexOfQuestions] = answer;

            return correct;
        }

        public int GetAnswer(int indexOfQuestions)
        {
            return _answerList[indexOfQuestions];
        }

        public int GetCollectAnswer(int indexOfQuestions)
        {
            return _correctAnswerList[indexOfQuestions];
        }
    }
}

