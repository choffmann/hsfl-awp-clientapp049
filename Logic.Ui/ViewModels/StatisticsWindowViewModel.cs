using De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels.Chart;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
