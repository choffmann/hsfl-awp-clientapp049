using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper.AbstractViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper
{
    public class ManagerViewModel: ViewModelBase<Manager>
    {
        private CardCollectionViewModel learningCardCollectionVM;
        private ThemeCollection themes;

        public ManagerViewModel(): base()
        {
            LearningCards = new CardCollectionViewModel();
            this.Model.learningCards = LearningCards.Model;
        }

        public CardCollectionViewModel LearningCards
        {
            get
            {
                return learningCardCollectionVM;
            }
            set
            {
                learningCardCollectionVM = value;
                OnPropertyChanged("LearningCards");
            }
        }

        public override void NewModelAssigned()
        {
            if(this.LearningCards != null)
            {
                this.LearningCards.Model = this.Model?.learningCards;
            }
        }
    }
}
