using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class SaveWindowViewModel
    {
        private ManagerViewModel myManager;
        public SaveWindowViewModel(ManagerViewModel manager)
        {
            this.myManager = manager;

            //Hier die beiden ralycommands für import / export
        }
    }
}
