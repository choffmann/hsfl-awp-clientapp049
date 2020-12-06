using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class NewClientWindowViewModel
    {
        public int Identifier { get; set; }
        public String Name { get; set; }
        public ClientCollectionViewModel MyVMCollection { get; set; }
        public RelayCommand AddClient { get; }

        public NewClientWindowViewModel(ClientCollectionViewModel model)
        {
            AddClient = new RelayCommand(() => AddClientMethod());
            MyVMCollection = model;
        }

        private void AddClientMethod()
        {
            ClientViewModel cvm = new ClientViewModel();
            cvm.Id = Identifier;
            cvm.Name = Name;
            MyVMCollection.Add(cvm);
        }
    }
}
