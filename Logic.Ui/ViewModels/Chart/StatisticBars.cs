using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels.Chart
{
    public class StatisticBars : INotifyPropertyChanged
    {
        public StatisticsBarCollection BarCollection { get; set; }

        public String tooltip;

        public event PropertyChangedEventHandler PropertyChanged;

        public String Tooltip
        {
            get
            {
                return tooltip;
            }
            set
            {
                tooltip = value;
                OnPropertyChanged("Tooltip");
            }
        }
        public StatisticBars(List<double> data, String theme, int wrong)
        {
            Tooltip = "Erfolgreich: 4\nErfolglos: 3";
            BarCollection = new StatisticsBarCollection();
            
            int n = data.Count;
            String[] color = { "green", "blue", "red", "lightblue", "yellow", "green", "blue" };
            for (int i = 0; i < n; i++)
            {
                double value = data[i] * 5;
                double space = 700 / (n * 1.5);
                double width = 320 / (n * 1.2);
                double x = 30 + (space / 2) + (i * (space + width));
                double y = 550 - value;
                BarItem failure = new BarItem(x, y, width, value / wrong, "red", "");
                BarItem success = new BarItem(x, y, width, value, color[i], theme);
                BarCollection.Add(success);
                BarCollection.Add(failure);
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
