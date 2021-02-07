using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper.AbstractViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper
{
    public class CardCollectionViewModel : ViewModelSyncCollection<CardViewModel, LearningCard, LearningCardCollection>
    {
        public CardCollectionViewModel(): base()
        {
        }
        public override void NewModelAssigned()
        {
            
        }
    }
}
