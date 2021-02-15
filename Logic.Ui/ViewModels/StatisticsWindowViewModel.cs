using BinarySerializer;
using De.HsFlensburg.ClientApp049.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels.Chart;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp049.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class StatisticsWindowViewModel : INotifyPropertyChanged
    {
        public ManagerViewModel manager;
        public ManagerViewModel ManagerObject
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("ManagerObject");
            }
        }

        public String selectedItem;
        public String SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                Console.WriteLine(value);
                OnPropertyChanged("SelectedItem");
            }
        }

        public StatisticBars myBars {get; set;}
        public StatisticsBarCollection StatisticBars { 
            get
            {
                return myBars.BarCollection;
            }
            private set
            {
            }
            
        }
        public int totalCards;
        public int TotalCards
        {
            get
            {
                return totalCards;
            }
            set
            {
                totalCards = value;
                OnPropertyChanged("TotalCards");
            }
        }

        public CardViewModel cvm;
        public CardViewModel CardVM
        {
            get
            {
                return cvm;
            }
            set
            {
                cvm = value;
                OnPropertyChanged("CardVM");
            }
        }

        public RelayCommand CloseWindow { get; }

        public StatisticsWindowViewModel(ManagerViewModel model)
        {
            ManagerObject = model;
            CloseWindow = new RelayCommand(() => CloseWindowMethode());
            DrawStatisticBar();
            showStatsNumber();
            CreateTestData();
        }

        private void CloseWindowMethode()
        {
            ServiceBus.Instance.Send(new CloseStatisticsWindowMessage());
        }

        private void DrawStatisticBar()
        {
            int themeTotal = 4;
            int theme1Total = 4;
            int theme2Total = 3;
            int theme3Total = 5;
            int theme4Total = 1;

            int max = 100;

            List<double> valueList = new List<double>();

            for (int i = 0; i < themeTotal; i++)
            {
                valueList.Add(50);
            }
            myBars = new StatisticBars(valueList, "Mathe", 4);
        }

        private void showStatsNumber()
        {
            TotalCards = ManagerObject.LearningCards.Count;
        }

        private void CreateTestData()
        {
            /*CardViewModel cvm = new CardViewModel();
            AttemptViewModel attempt = new AttemptViewModel();
            AttemptCollectionViewModel attemptCollection = new AttemptCollectionViewModel();
            attempt.AttemptDate = DateTime.Today;
            attempt.Success = false;
            attemptCollection.CardAttempts.Add(attempt);
            cvm.Question = "1+1";
            cvm.Answer = "2";
            cvm.Box = 3;
            ManagerObject.LearningCards.Add(cvm);*/

            AttemptViewModel attempt = new AttemptViewModel();
            attempt.AttemptDate = DateTime.Today;
            attempt.Success = true;

            CardVM.CardAttempts.Add(attempt);

            

            /*CardViewModel cvm1 = new CardViewModel();
            AttemptViewModel attempt1 = new AttemptViewModel();
            attempt1.AttemptDate = DateTime.Today;
            attempt1.Success = true;
            cvm1.CardAttempts.Add(attempt);
            cvm1.CardAttempts.Add(attempt1);
            cvm1.Question = "1+2";
            cvm1.Answer = "3";
            cvm1.Box = 3;
            ManagerObject.LearningCards.Add(cvm1);

            CardViewModel cvm2 = new CardViewModel();
            AttemptViewModel attempt2 = new AttemptViewModel();
            AttemptViewModel attempt3 = new AttemptViewModel();
            attempt2.AttemptDate = DateTime.Today;
            attempt2.Success = false;
            attempt3.AttemptDate = DateTime.Today;
            attempt3.Success = true;
            cvm2.CardAttempts.Add(attempt);
            cvm2.CardAttempts.Add(attempt2);
            cvm2.CardAttempts.Add(attempt3);
            cvm2.Question = "1+2";
            cvm2.Answer = "3";
            cvm2.Box = 3;
            ManagerObject.LearningCards.Add(cvm2);*/
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
