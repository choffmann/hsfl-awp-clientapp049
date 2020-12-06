﻿using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper
{
    public class ClientViewModel
    {
        public Client myClient = new Client();
        public ClientViewModel(Client client)
        {
            this.myClient = client;
        }

        public ClientViewModel()
        {

        }

        public int Id 
        {
            get
            {
                return myClient.Id;
            }
            set
            {
                myClient.Id = value;
            }
        }

        public String Name
        {
            get
            {
                return myClient.Name;
            }
            set
            {
                myClient.Name = value;
            }
        }
    }
}
