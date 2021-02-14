using De.HsFlensburg.ClientApp049.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp049.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class LobbyWindowsViewModel: INotifyPropertyChanged
    {
        public ManagerViewModel manager;
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand OpenNewLearningCardWindow { get; }
        public RelayCommand OpenLearningWindow { get; }
        public RelayCommand OpenSaveWindow { get; }
        public RelayCommand OpenStatisticsWindow { get; }

        public ManagerViewModel ManagerObject
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("ManagerObject");
            }
        }
        public LobbyWindowsViewModel(ManagerViewModel model)
        {
            ManagerObject = model;
            OpenNewLearningCardWindow = new RelayCommand(() => OpenNewLearningCardWindowMethode());
            OpenLearningWindow = new RelayCommand(() => OpenLearningWindowMethode());
            OpenSaveWindow = new RelayCommand(() => OpenSaveWindowMethode());
            OpenStatisticsWindow = new RelayCommand(() => OpenStatisticsWindowMethode());
        }

        private void OpenNewLearningCardWindowMethode()
        {
            ServiceBus.Instance.Send(new OpenNewLearningCardWindowMessage());
        }

        private void OpenLearningWindowMethode()
        {
            ServiceBus.Instance.Send(new OpenLearningWindowMessage());
        }
        private void OpenSaveWindowMethode()
        {
            ServiceBus.Instance.Send(new OpenSaveWindowMessage());
        }

        private void OpenStatisticsWindowMethode()
        {
            ServiceBus.Instance.Send(new OpenStatisticsWindowMessage());
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
