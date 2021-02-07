using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class LearningCardWindowViewModel
    {

        public ManagerViewModel MyManager { get; set; }

        public RelayCommand GetCard { get; }



        public LearningCardWindowViewModel(ManagerViewModel manager)
        {
            MyManager = manager;

            GetCard = new RelayCommand(() => GetCardMethod());
        }

        private void GetCardMethod()
        {
            // Hier Beispielcarte Erstellen


        }
    }

}
