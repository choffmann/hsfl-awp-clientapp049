using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper
{
    public class ClientCollectionViewModel: ObservableCollection<ClientViewModel>
    {
        public ClientCollection myCollection;
        private bool syncDisabled;
        

        public ClientCollectionViewModel()
        {
            myCollection = new ClientCollection();
            this.CollectionChanged += ViewModelCollectionChanged;
            myCollection.CollectionChanged += ModelCollectionChangend;

        }

        private void ViewModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var client in e.NewItems.OfType<ClientViewModel>().Select(v => v.myClient).OfType<Client>())
                        myCollection.Add(client);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var client in e.OldItems.OfType<ClientViewModel>().Select(v => v.myClient).OfType<Client>())
                        myCollection.Remove(client);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    myCollection.Clear();
                    break;
            }
            syncDisabled = false;
        }

        private void ModelCollectionChangend(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var client in e.NewItems.OfType<Client>())
                        Add(new ClientViewModel(client));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var client in e.OldItems.OfType<Client>())
                        Remove(GetViewModelOfModel(client));
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Clear();
                    break;
            }
            syncDisabled = false;
        }

        private ClientViewModel GetViewModelOfModel(Client client)
        {
            foreach(ClientViewModel cvm in this)
            {
                if (cvm.myClient.Equals(client))
                    return cvm;
            }

            return null;
        }
    }
}
