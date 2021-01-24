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
        public NewLearningCardWindowViewModel LeaningCardWVM { get; }

        public StatisticsWindowViewModel StatisticsWVM { get; }
        public NewClientWindowViewModel WindowVM { get; }
        public ViewModelLocator()
        {
            //OLD
            //MyVMCollection = new ClientCollectionViewModel(); // Hier den ManagerViewmodel erzeugen
            //MainWindowVM = new MainWindowViewModel(MyVMCollection); // Hier jedem windowwievmodel das model als managerviewmodel übergeben
            //NewClientWindowVM = new NewClientWindowViewModel(MyVMCollection);

            //TODO models erzeugen (für beispieldaten)
            MyManager = new ManagerViewModel();
            //LeaningCardWVM = new NewLearningCardWindowViewModel(MyManager);

            //NewClientWindowVM = new 

        }

     
    }
}
