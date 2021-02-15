﻿using BinarySerializer;
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
        private String currentBox;
        private int selectedBox;
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
        public String CurrentBox
        {
            get
            {
                return this.currentBox;
            }
            set
            {
                this.currentBox = value;
                OnPropertyChanged("CurrentBox");
            }
        }

        public int SelectedBox
        {
            get
            {
                return this.selectedBox;
            }

            set
            {
                this.selectedBox = value;
                OnPropertyChanged("SelectedBox");
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
            CardCollection = Manager.LearningCards.GetEnumerator();

            CurrentBox = "12345";
            selectedBox = 0;

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


            Boolean found = false;

            CardCollection.MoveNext();

            while (!found && CardCollection.Current != null)
            {
                //Filter
                if (CardCollection.Current.Box == SelectedBox && CardCollection.Current.Theme == Theme.Name)
                {
                    //Hintergrund und Antwort löschen
                    BGColor = "white";
                    Answer = "";
                    CurrentCard = CardCollection.Current;
                    found = true;
                }
                else
                {
                    CardCollection.MoveNext();

                }
            }

            if (CardCollection.Current == null)
            {
                Answer = "Keine Weiteren Karten verfügbar";
                BGColor = "yellow";
                CardCollection.Reset();
            }


        }

        private void VM_CheckAnswer()
        {

            //TODO: Attempt erstellen
            AttemptViewModel test = new AttemptViewModel();
            test.AttemptDate = DateTime.Today;

            //Antwort Testen (Texterkennung wird noch hinzugefügt)
            if (Answer == CurrentCard.Answer)
            {
                BGColor = "green";
                test.Success = true;
                if (CurrentCard.Box >= 4)
                {
                    CurrentCard.Box = 0;
                }
                else
                {
                    CurrentCard.Box++;
                }
            }
            else
            {
                BGColor = "red";
                test.Success = false;
            }
            CurrentCard.CardAttempts.Add(test);
            SerializeToBinMethode();
        }

        private void SerializeToBinMethode()
        {
            Console.WriteLine("Speichere...");
            BinarySerializerFileHandler.Save(Manager.Model);
        }
    }
}
