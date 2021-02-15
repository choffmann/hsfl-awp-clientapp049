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
        public StatisticsBarCollection bars;
        public StatisticsBarCollection BarCollection 
        { 
            get
            {
                return bars;
            }
            set
            {
                bars = value;
                OnPropertyChanged("BarCollection");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public StatisticBars(List<double> data, List<String> themeList, List<String> ToolTip)
        {
            BarCollection = new StatisticsBarCollection();
            int n = data.Count;
            String[] color = { "green", "blue", "lightblue", "yellow", "green", "blue" };
            for (int i = 0; i < n; i++)
            {
                double value = data[i] * 3;
                double space = 700 / (n * 1.5);
                double width = 320 / (n * 1.2);
                double x = 30 + (space / 2) + (i * (space + width));
                double y = 550 - value;
                BarItem success = new BarItem(x, y, width, value, color[i], themeList[i], ToolTip[i]);
                BarCollection.Add(success);
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
