
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace De.HsFlensburg.ClientApp049.Ui.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenNewLearningCardWindow(object sender, RoutedEventArgs e)
        {
            NewLearningCardWindow newLearningCardWindow = new NewLearningCardWindow();
            newLearningCardWindow.ShowDialog();
        }

        private void OpenStatisticsWindow(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statWindow = new StatisticsWindow();
            statWindow.ShowDialog();
        }
    }
}
