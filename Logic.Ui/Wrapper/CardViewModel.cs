using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper.AbstractViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper
{
    public class CardViewModel: ViewModelBase<LearningCard>
    {
        private AttemptCollectionViewModel attemptViewModel;
        public CardViewModel(): base()
        {
            /*CardAttempts = new AttemptCollectionViewModel();
            this.Model.CardAttempts = CardAttempts.Model;*/
        }

        /*public AttemptCollectionViewModel CardAttempts
        {
            get
            {
                return attemptViewModel;
            }
            set
            {
                attemptViewModel = value;
                OnPropertyChanged("CardAttempts");
            }
        }*/


        public String Question
        {
            get
            {
                return Model.Question;
            }

            set
            {
                Model.Question = value;
            }
        }

        public String Answer
        {
            get
            {
                return Model.Answer;
            }

            set
            {
                Model.Answer = value;
            }
        }

        public int Box
        {
            get
            {
                return Model.Box;
            }
            set
            {
                Model.Box = value;
            }
        }
        public String Theme
        {
            get
            {
                return Model.Theme;
            }
            set
            {
                Model.Theme = value;
            }
        }

        public override void NewModelAssigned()
        {
            /*if (this.CardAttempts != null)
            {
                this.CardAttempts.Model = this.Model?.CardAttempts;
            }*/
        }
    }
}
