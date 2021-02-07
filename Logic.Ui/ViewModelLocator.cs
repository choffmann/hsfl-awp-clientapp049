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
        public CardCollectionViewModel CardCollectionVM { get; set; }   
        public NewLearningCardWindowViewModel NewLeaningCardWindowVM { get; }

        public StatisticsWindowViewModel StatisticsWVM { get; }
        public ViewModelLocator()
        {
            //OLD
            //MyVMCollection = new ClientCollectionViewModel(); // Hier den ManagerViewmodel erzeugen
            //MainWindowVM = new MainWindowViewModel(MyVMCollection); // Hier jedem windowwievmodel das model als managerviewmodel übergeben
            //NewClientWindowVM = new NewClientWindowViewModel(MyVMCollection);

            //TODO models erzeugen (für beispieldaten)
            CardCollectionVM = new CardCollectionViewModel();
            NewLeaningCardWindowVM = new NewLearningCardWindowViewModel(CardCollectionVM);
        }
    }
}
