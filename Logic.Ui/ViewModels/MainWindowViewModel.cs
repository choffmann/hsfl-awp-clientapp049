using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        public RelayCommand AddClientToList { get; }
        public ClientCollectionViewModel MyVMCollection { get; set; }
        public MainWindowViewModel(ClientCollectionViewModel model)
        {
            AddClientToList = new RelayCommand(() => VM_AddNewClient());
            MyVMCollection = model;

        }
        private void VM_AddNewClient()
        {
            ClientCollectionViewModel list = MyVMCollection;
            if(list != null)
            {
                ClientViewModel cvm = new ClientViewModel();
                //cvm.Id = Int16.Parse("");
                //cvm.Name = "";
                list.Add(cvm);
            } 
        }
    }
}
