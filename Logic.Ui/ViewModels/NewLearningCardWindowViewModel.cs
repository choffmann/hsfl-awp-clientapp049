using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class NewLearningCardWindowViewModel
    {
        public String Question { get; set; }
        public String Answer { get; set; }

        public Manager MyManager { get; set; }

        public RelayCommand AddCard { get; }


        public NewLearningCardWindowViewModel(Manager manager)
        {
            AddCard = new RelayCommand(() => AddCardMethod());
            MyManager = manager;
            //TODO Theme relay command
        }

        private void AddCardMethod()
        {
            CardViewModel cvm = new CardViewModel();
            cvm.Answer = Answer;
            cvm.Question = Question;
            MyManager.learningCards.Add(cvm);
        }

    }
}
