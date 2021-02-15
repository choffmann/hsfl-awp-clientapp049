using BinarySerializer;
using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class LearningWindowViewModel : INotifyPropertyChanged
    {
        public RelayCommand CheckAnswer { get; }
        public RelayCommand NextCard { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ManagerViewModel manager;
        private IEnumerator<CardViewModel> cardCollection;
        private CardViewModel currentCard;
        private ThemeViewModel theme;
        private String answer;
        private String bgColor;



        public ManagerViewModel Manager
        {
            get
            {
                return manager;
            }

            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private IEnumerator<CardViewModel> CardCollection
        {
            get
            {
                return this.cardCollection;
            }
            set
            {
                this.cardCollection = value;
                OnPropertyChanged("CardCollection");
            }
        }

        public CardViewModel CurrentCard
        {
            get
            {
                return this.currentCard;
            }
            set
            {
                this.currentCard = value;
                OnPropertyChanged("CurrentCard");
            }
        }

        public ThemeViewModel Theme
        {
            get
            {
                return this.theme;
            }
            set
            {
                this.theme = value;
                OnPropertyChanged("Theme");
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
            Manager = myManager;
            BGColor = "white";

            Console.WriteLine("open nico Constructor");
            CardCollection = Manager.LearningCards.GetEnumerator();

            CardViewModel emptyCard = new CardViewModel();
            emptyCard.Question = "";
            emptyCard.Answer = "";
            emptyCard.Theme = "Mathe";
            CurrentCard = emptyCard;

            CheckAnswer = new RelayCommand(() => VM_CheckAnswer());
            NextCard = new RelayCommand(() => VM_NextCard());

        }

        private void VM_NextCard()
        {
            CardCollection.MoveNext();

            //Filter
            while (CardCollection.Current != null && Theme.Name != CardCollection.Current.Theme)
            {
                Console.WriteLine(CardCollection.Current.Question);
                CardCollection.MoveNext();
            }

            if (CardCollection.Current == null)
            {
                Console.WriteLine("Keine Karten verfügbar");
            }
            else
            {
                // Hintergrund und Antwort löschen
                BGColor = "white";
                Answer = "";
                CurrentCard = CardCollection.Current;
            }



        }

        private void VM_CheckAnswer()
        {

            //TODO: Attempt erstellen

            //Antwort Testen (Texterkennung wird noch hinzugefügt)
            if (Answer == currentCard.Answer)
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
