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
            MyVMCollection = new ClientCollectionViewModel();

            MainWindowVM = new MainWindowViewModel(MyVMCollection);
            NewClientWindowVM = new NewClientWindowViewModel(MyVMCollection);
        }

        public MainWindowViewModel MainWindowVM { get; }
        public NewClientWindowViewModel NewClientWindowVM { get; }
    }
}
