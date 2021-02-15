using BinarySerializer;
using De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels.Chart;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
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

        public StatisticsWindowViewModel(ManagerViewModel model)
        {
            ManagerObject = model;
            //DeserializeFromBinMethode();
            //CreateTestData();
            DrawStatisticBar();
        }

        private void DrawStatisticBar()
        {
            List<double> valueList = new List<double>();
            var rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                valueList.Add(rand.NextDouble() * 100);
            }
            myBars = new StatisticBars(valueList);
        }

        private void getTodaysCards()
        {

        }

        private void CreateTestData()
        {
            CardViewModel cvm = new CardViewModel();
            AttemptViewModel attempt = new AttemptViewModel();
            attempt.AttemptDate = DateTime.Today;
            attempt.Success = false;
            cvm.CardAttempts.Add(attempt.Model);
            cvm.Question = "1+1";
            cvm.Answer = "2";
            cvm.Box = 3;
            ManagerObject.LearningCards.Add(cvm);

            CardViewModel cvm1 = new CardViewModel();
            AttemptViewModel attempt1 = new AttemptViewModel();
            attempt1.AttemptDate = DateTime.Today;
            attempt1.Success = true;
            cvm1.CardAttempts.Add(attempt.Model);
            cvm1.CardAttempts.Add(attempt1.Model);
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
            cvm2.CardAttempts.Add(attempt.Model);
            cvm2.CardAttempts.Add(attempt2.Model);
            cvm2.CardAttempts.Add(attempt3.Model);
            cvm2.Question = "1+2";
            cvm2.Answer = "3";
            cvm2.Box = 3;
            ManagerObject.LearningCards.Add(cvm2);
        }


        private void SerializeToBinMethode()
        {
            Console.WriteLine("Speichere...");
            BinarySerializerFileHandler.Save(ManagerObject.Model);
        }

        private void DeserializeFromBinMethode()
        {
            if (File.Exists(BinarySerializerFileHandler.filePath))
            {
                Console.WriteLine("Lade...");
                ManagerObject = new ManagerViewModel();
                ManagerObject.Model = BinarySerializerFileHandler.Load();
            }
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
