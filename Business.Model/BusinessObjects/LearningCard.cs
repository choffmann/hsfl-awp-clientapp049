using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects
{
    [Serializable]
    public class LearningCard
    {
        public ObservableCollection<Attempt> CardAttempts { get; set; }
        public String Question { get; set; }
        public String Answer { get; set; }
        public int Box { get; set; }
        public String Theme {get; set;}
    }
}
