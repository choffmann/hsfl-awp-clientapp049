using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels.Chart
{
    public class StatisticBars
    {
        public StatisticsBarCollection BarCollection { get; set; }
        public StatisticBars(List<double> data)
        {
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
                BarCollection.Add(new BarItem(x, y, width, value, color[i]));
            }
        }
    }
}
