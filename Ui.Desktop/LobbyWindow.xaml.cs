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
    /// Interaction logic for LobbyWindow.xaml
    /// </summary>
    public partial class LobbyWindow : Window
    {
        public LobbyWindow()
        {
            InitializeComponent();
        }

        // UIs

        // Karten erstellen
        private void OpenCreateWindow(object sender, RoutedEventArgs e)
        {
            NewLearningCardWindow newLearningCardWindow = new NewLearningCardWindow();
            newLearningCardWindow.ShowDialog();
        }

        // Karten Lernen
        private void OpenLearnWindow(object sender, RoutedEventArgs e)
        {
            LearnWindow learnWindow = new LearnWindow();
            learnWindow.ShowDialog();
        }

        // Statistik
        private void OpenStatsWindow(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statistics = new StatisticsWindow();
            statistics.ShowDialog();
        }

        // Import / Export
        private void OpenSaveWindow(object sender, RoutedEventArgs e)
        {
            SaveWindow saveWindow = new SaveWindow();
            saveWindow.ShowDialog();
        }

    }
}
