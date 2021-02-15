using De.HsFlensburg.ClientApp049.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels.Chart;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp049.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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

        public StatisticBars myBars;
        public StatisticBars StatisticBars
        {
            get
            {
                return myBars;
            }
            set
            {
                myBars = value;
                OnPropertyChanged("StatisticBars");
            }
        }

        public StatisticsBarCollection StatBars
        {
            get
            {
                return StatisticBars.BarCollection;
            }
        }

        private String total;
        private String totalSuccess;
        private String totalFailed;
        public String Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                OnPropertyChanged("Total");
            }
        }
        public String TotalSuccess
        {
            get
            {
                return totalSuccess;
            }
            set
            {
                totalSuccess = value;
                OnPropertyChanged("TotalSuccess");
            }
        }
        public String TotalFailed
        {
            get
            {
                return totalFailed;
            }
            set
            {
                totalFailed = value;
                OnPropertyChanged("TotalFailed");
            }
        }

        public RelayCommand CreateTestData { get; }
        public RelayCommand MouseDown { get; }

        public StatisticsWindowViewModel(ManagerViewModel model)
        {
            ManagerObject = model;
            CardVM = new CardViewModel();
            CreateTestData = new RelayCommand(() => CreateTestDataMethode());
            //DrawStatisticBar();
            DrawStatisticBar();
        }

        private void DrawStatisticBar()
        {
            List<double> valueList = new List<double>();
            List<String> themeList = new List<String>();
            List<String> toolTipList = new List<String>();
            List<int> totalList = new List<int>();
            List<int> failList = new List<int>();
            var v = ManagerObject.LearningCards.GetEnumerator();
            v.MoveNext();
            if(v.Current == null)
            {
                CreateTestDataMethode();
            }
            var Themes = ManagerObject.Themes.GetEnumerator();
            Themes.MoveNext();
            int total = 0;
            int totalSuc = 0;
            int totalFail = 0;
            int globalMessureBar = 0;
            while (Themes.Current != null)
            {
                int countCards = 0;
                int countAttempts = 0;
                int success = 0;
                int failed = 0;
                IEnumerable<CardViewModel> Cards = ManagerObject.LearningCards.Where(c => c.Theme == Themes.Current.Name);
                foreach (var Card in Cards)
                {
                    countCards++;
                    total = total + Card.CardAttempts.Count;
                    countAttempts = countAttempts + Card.CardAttempts.Count;
                    IEnumerable<AttemptViewModel> AttemptsSuccess = Card.CardAttempts.Where(a => a.Success == true);
                    IEnumerable<AttemptViewModel> AttemptsFailed = Card.CardAttempts.Where(a => a.Success == false);

                    foreach(var suc in AttemptsSuccess)
                    {
                        success++;
                        totalSuc++;
                    }
                    foreach(var fail in AttemptsFailed)
                    {
                        failed++;
                        totalFail++;
                    }
                }
                themeList.Add(Themes.Current.Name);
                if (countAttempts < 5)
                {
                    globalMessureBar = 50;
                } else if (countAttempts > 30 && countAttempts < 50)
                {
                    globalMessureBar = 5;
                } else
                {
                    globalMessureBar = 2;
                }
                valueList.Add(countAttempts * globalMessureBar);
                toolTipList.Add("Gesamt: " + countAttempts + "\nErfolgreich: " + success + "\nErfolglos: " + failed);
                Themes.MoveNext();
            }
            Total = "" + total;
            TotalSuccess = "" + totalSuc;
            TotalFailed = "" + totalFail;
            StatisticBars = new StatisticBars(valueList, themeList, toolTipList);
        }

        private void CreateTestDataMethode()
        {
            String[] theme = { "Mathe", "Deutsch", "Englisch", "AWP", "Algo.", "DSV" };
            Random rand = new Random();
            int n = rand.Next(10) + 1 * 10;
            for (int i = 0; i < n; i++)
            {
                CardViewModel cvm = new CardViewModel();
                cvm.Theme = theme[rand.Next(6)];
                cvm.Box = rand.Next(5);
                int c = rand.Next(10) + 1;
                for (int j = 0; j < c; j++)
                {
                    AttemptViewModel attempt = new AttemptViewModel();
                    attempt.AttemptDate = DateTime.Today;
                    if (rand.Next(10) % 2 == 0)
                    {
                        attempt.Success = false;
                    }
                    else
                    {
                        attempt.Success = true;
                    }

                    cvm.CardAttempts.Add(attempt);
                }
                CardVM = cvm;
                ManagerObject.LearningCards.Add(cvm);
            }
            DrawStatisticBar();
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
