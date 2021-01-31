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

        public ManagerViewModel MyManager { get; set; }

        public RelayCommand GetCard { get; }


        public NewLearningCardWindowViewModel(ManagerViewModel manager)
        {
            GetCard = new RelayCommand(() => AddCardMethod());
            MyManager = manager;
            //TODO Theme relay command
        }

        private void AddCardMethod()
        {
            // Demo Karte erstellen und anzeigen

            LearningCard MyCard = new LearningCard();
            MyCard.Question= "Was ist 1 + 1?";
            MyCard.Answer = "2";

            //CardViewModel cvm = new CardViewModel();
            //cvm.Answer = Answer;
            //cvm.Question = Question;
            //MyManager.learningCards.Add(cvm)
        }

    }
}
