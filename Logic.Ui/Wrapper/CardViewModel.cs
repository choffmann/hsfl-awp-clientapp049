using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper
{
    public class CardViewModel
    {
        public LearningCard myCard = new LearningCard();

        public CardViewModel(LearningCard card)
        {
            this.myCard = card;
        }

        public CardViewModel()
        {

        }

        public String Question
        {
            get
            {
                return myCard.Question;
            }

            set
            {
                myCard.Question = value;
            }
        }

        public String Answer
        {
            get
            {
                return myCard.Answer;
            }

            set
            {
                myCard.Answer = value;
            }
        }


    }
}
