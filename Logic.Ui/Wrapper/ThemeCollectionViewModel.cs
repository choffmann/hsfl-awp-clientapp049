﻿using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper.AbstractViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper
{
    public class ThemeCollectionViewModel : ViewModelSyncCollection<ThemeViewModel, Theme, ThemeCollection>
    {
        public ThemeCollectionViewModel() :base()
        {
        }
        public override void NewModelAssigned()
        {

        }
    }
}
