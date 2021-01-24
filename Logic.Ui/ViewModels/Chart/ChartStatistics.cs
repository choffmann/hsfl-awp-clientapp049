using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels.Chart
{
    public class ChartStatistics
    {
        public String Theme { set; get; }
        public int Total { get; set; }
        public int Success { get; set; }
        public int Failed { get; set; }
        public ChartStatistics(String theme, int total, int success, int failed)
        {
            Theme = theme;
            Total = total;
            Success = success;
            Failed = failed;
        }

    }
}
