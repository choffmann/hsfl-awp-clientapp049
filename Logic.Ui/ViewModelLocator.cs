using BinarySerializer;
using De.HsFlensburg.ClientApp049.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp049.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui
{
    public class ViewModelLocator
    {

        public ManagerViewModel MyManager { get; set; }
        public NewLearningCardWindowViewModel NewLeaningCardWVM { get; set; }
        public StatisticsWindowViewModel StatisticsWVM { get; set; }
        public LearningWindowViewModel LearningWVM { get; set; }
        public LobbyWindowsViewModel LobbyWindowVM { get; }
        public ManagerViewModel ManagerObject { get; private set; }

        public RelayCommand OpenNewLearningCard { get; }
        public RelayCommand OpenLearningWindow { get; }
        public RelayCommand OpenStatisticsWindow { get; }
        public RelayCommand OpenSaveWindow { get; }

        public ViewModelLocator()
        {
            //ManagerViewmodel erzeugen
            DeserializeFromBinMethode();
            //jedem windowwievmodel das model als managerviewmodel übergeben
            //NewLeaningCardWVM = new NewLearningCardWindowViewModel(ManagerObject);
            OpenNewLearningCard = new RelayCommand(() => OpenNewLearningCardMethode());
            OpenLearningWindow = new RelayCommand(() => OpenLearningWindowMethode());
            OpenStatisticsWindow = new RelayCommand(() => OpenStatisticsWindowMethode());
            OpenSaveWindow = new RelayCommand(() => OpenSaveWindowMethode());

            //LobbyWindowVM = new LobbyWindowsViewModel(ManagerObject);
            
        }

        private void OpenNewLearningCardMethode()
        {
            NewLeaningCardWVM = new NewLearningCardWindowViewModel(ManagerObject);
            ServiceBus.Instance.Send(new OpenNewLearningCardWindowMessage());
        }
        private void OpenLearningWindowMethode()
        {
            LearningWVM = new LearningWindowViewModel(ManagerObject);
            ServiceBus.Instance.Send(new OpenLearningWindowMessage());
        }
        private void OpenSaveWindowMethode()
        {
            //LearningWVM = new LearningWindowViewModel(ManagerObject);
            ServiceBus.Instance.Send(new OpenSaveWindowMessage());
        }

        private void OpenStatisticsWindowMethode()
        {
            StatisticsWVM = new StatisticsWindowViewModel(ManagerObject);
            ServiceBus.Instance.Send(new OpenStatisticsWindowMessage());
        }

        private void DeserializeFromBinMethode()
        {
            if (File.Exists(BinarySerializerFileHandler.filePath))
            {
                Console.WriteLine("Lade...");
                ManagerObject = new ManagerViewModel();
                ManagerObject.Model = BinarySerializerFileHandler.Load();
            } else
            {
                ManagerObject = new ManagerViewModel();
            }
        }
    }
}
