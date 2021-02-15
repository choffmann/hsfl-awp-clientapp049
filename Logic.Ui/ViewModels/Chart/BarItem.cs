using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels.Chart
{
    public class BarItem : INotifyPropertyChanged
    { 
        public RelayCommand MouseClick { get; }
        public BarItem(double x, double y, double width, double height, String color, String theme, String toolTip)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Color = color;
            this.Theme = theme;
            this.ToolTip = toolTip;
            MouseClick = new RelayCommand(() => MouseDownMethode());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public String Color { get; set; }
        public String Theme { get; set; }
        public String ToolTip { get; set; }
        private void MouseDownMethode()
        {
            Console.WriteLine("click");
        }
        
    }
}
