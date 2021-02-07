using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class LearningWindowViewModel
    {
        public RelayCommand ShowQuestion { get; }
        public ManagerViewModel MyManager { get; }

        public LearningWindowViewModel()
        {

        }

        public LearningWindowViewModel(ManagerViewModel myManager)
        {
            MyManager = myManager;
            ShowQuestion = new RelayCommand(() => VM_ShowNewCard());

        }

        private void VM_ShowNewCard()
        {
            //LearningCard Card = new LearningCard();
            //Card.Question = "Was ist 1 + 1?";
            //Card.Answer = "2";

            Console.WriteLine("WindowViewModel");

        }
    }
}
