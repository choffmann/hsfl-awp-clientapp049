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
        public ClientCollectionViewModel MyVMCollection { get; set; }
        public ViewModelLocator()
        {
            MyVMCollection = new ClientCollectionViewModel(); // Hier den Manager-Viewmodel erzeugen

            MainWindowVM = new MainWindowViewModel(MyVMCollection); // Hier jedem window-wiev-model das model als manager-view-model übergeben
            NewClientWindowVM = new NewClientWindowViewModel(MyVMCollection);
        }

        public MainWindowViewModel MainWindowVM { get; }
        public NewClientWindowViewModel NewClientWindowVM { get; }
    }
}
