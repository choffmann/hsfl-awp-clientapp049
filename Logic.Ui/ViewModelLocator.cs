using De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui
{
    public class ViewModelLocator
    {

        public ManagerViewModel MyManager { get; set; }
        public LearningCardWindowViewModel LeaningCardWVM { get; }
        public NewLearningCardWindowViewModel NewLeaningCardWVM { get; }

        //Window
        public StatisticsWindowViewModel StatisticsWVM { get; }
        public LearningWindowViewModel LearningWVM { get; }
        public LobbyWindowsViewModel LobbyWindowVM { get; }


        public ViewModelLocator()
        {
            //ManagerViewmodel erzeugen
            MyManager = new ManagerViewModel();

            //jedem windowwievmodel das model als managerviewmodel übergeben
            LeaningCardWVM = new LearningCardWindowViewModel(MyManager);
            LearningWVM = new LearningWindowViewModel(MyManager);
            NewLeaningCardWVM = new NewLearningCardWindowViewModel(MyManager);
            LobbyWindowVM = new LobbyWindowsViewModel(MyManager);
            // TODO: StatisticsWVM = new StatisticsWindowViewModel(MyManager);
        }
    }
}
