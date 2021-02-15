using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper.AbstractViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper
{
    public class AttemptViewModel : ViewModelBase<Attempt>
    {
        public AttemptViewModel() :base()
        {
        }

        public DateTime AttemptDate
        {
            get
            {
                return Model.AttemptDate;
            }
            set
            {
                Model.AttemptDate = value;
            }
        }

        public Boolean Success
        {
            get
            {
                return Model.Success;
            }
            set
            {
                Model.Success = value;
            }
        }

        public override void NewModelAssigned()
        {
        }
    }
}
