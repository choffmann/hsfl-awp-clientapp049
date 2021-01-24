using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace De.HsFlensburg.ClientApp049.Ui.Desktop
{
    /// <summary>
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int success = 5;
            int failed = 5;

            int WIDTH = 805;
            int HEIGHT = 550;

            int total = success + failed;
            double successHeight = 0;
            double failedHeight = 0;

            String[] theme = { "Mathe", "Englisch", "AWP", "DSV", "Algo." };

            double space = 134;
            for(int i = 1; i <= 5; i++)
            {
                TextBlock text = new TextBlock();
                text.Text = theme[i - 1];
                text.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
                text.Arrange(new Rect(text.DesiredSize));
                Canvas.SetLeft(text, space * i - (text.ActualWidth / 2));
                Canvas.SetTop(text, HEIGHT);
                canvas.Children.Add(text);

                successHeight = HEIGHT * (total / 100 * success);
                failedHeight = successHeight + (HEIGHT * (total / 100 * failed));

                Console.WriteLine(successHeight);
                Console.WriteLine(failedHeight);

                Line successLine = new Line();
                successLine.Stroke = Brushes.Green;
                successLine.X1 = space * i;
                successLine.X2 = space * i;
                successLine.Y1 = failedHeight;
                successLine.Y2 = HEIGHT;
                successLine.StrokeThickness = 50;
                canvas.Children.Add(successLine);

                Line failedLine = new Line();
                failedLine.Stroke = Brushes.Red;
                failedLine.X1 = space * i;
                failedLine.X2 = space * i;
                failedLine.Y1 = successHeight;
                failedLine.Y2 = 50;
                failedLine.StrokeThickness = 50;
                canvas.Children.Add(failedLine);
            }
        }
    }
}
