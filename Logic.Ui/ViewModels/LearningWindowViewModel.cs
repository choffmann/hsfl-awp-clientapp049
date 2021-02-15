using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class LearningWindowViewModel : INotifyPropertyChanged
    {
        public RelayCommand CheckAnswer { get; }
        public RelayCommand NextCard { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ManagerViewModel MyManager;
        private LearningCard learningCard;
        private String answer;
        private String bgColor;


        public ManagerViewModel ManagerVM
        {
            get
            {
                return MyManager;
            }

            set
            {
                MyManager = value;
                OnPropertyChanged("ManagerVM");
            }
        }




        private LearningCard LearningCard
        {
            get
            {
                return this.learningCard;
            }
            set
            {
                this.learningCard = value;
                OnPropertyChanged("LearningCard");
                OnPropertyChanged("Question");
            }
        }

        public String Question
        {
            get
            {
                return this.learningCard.Question;
            }
        }

        public String Answer
        {
            get
            {
                return this.answer;
            }

            set
            {
                this.answer = value;
                this.bgColor = "white";
                OnPropertyChanged("BGColor");
                OnPropertyChanged("Answer");
            }
        }

        public String BGColor
        {
            get
            {
                return this.bgColor;
            }
            set
            {
                this.bgColor = value;
                OnPropertyChanged("BGColor");
            }
        }


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public LearningWindowViewModel() { }
        public LearningWindowViewModel(ManagerViewModel myManager)
        {
            //Testkarte
            LearningCard t1 = new LearningCard();
            t1.Question = "Was ist 1 + 1";
            t1.Answer = "2";
            LearningCard = t1;

            BGColor = "white";
            MyManager = myManager;
            CheckAnswer = new RelayCommand(() => VM_CheckAnswer());
            NextCard = new RelayCommand(() => VM_NextCard());
        }

        private void VM_NextCard()
        {
            //nächste karte laden
            BGColor = "white";
            LearningCard MyNextCard = new LearningCard();
            MyNextCard.Question = "Nächste Frage";
            MyNextCard.Answer = "0";

            LearningCard = MyNextCard;
            Answer = "";
        }

        private void VM_CheckAnswer()
        {
            //wenn answer == answer von learncard von collection

            /* TODO: Leaningcard erstellen (simuliert karte von collection)
             * question löschen (steht ja in der learningCard)
             * asnwer für VM erzeugen und mit answer aus leaningcard vergleichen
             */

            if (Answer == learningCard.Answer)
            {
                BGColor = "green";
            }
            else
            {
                BGColor = "red";
            }
        }
    }
}
