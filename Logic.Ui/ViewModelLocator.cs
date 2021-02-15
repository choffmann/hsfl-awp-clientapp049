using BinarySerializer;
using De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
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
        public NewLearningCardWindowViewModel NewLeaningCardWVM { get; }
        public StatisticsWindowViewModel StatisticsWVM { get; }
        public LearningWindowViewModel LearningWVM { get; }
        public LobbyWindowsViewModel LobbyWindowVM { get; }
        public ManagerViewModel ManagerObject { get; private set; }

        public ViewModelLocator()
        {
            //ManagerViewmodel erzeugen
            DeserializeFromBinMethode();
            //jedem windowwievmodel das model als managerviewmodel übergeben
            NewLeaningCardWVM = new NewLearningCardWindowViewModel(ManagerObject);
            LobbyWindowVM = new LobbyWindowsViewModel(ManagerObject);
            StatisticsWVM = new StatisticsWindowViewModel(ManagerObject);
            LearningWVM = new LearningWindowViewModel(ManagerObject);
        }

        private void DeserializeFromBinMethode()
        {
            if (File.Exists(BinarySerializerFileHandler.filePath))
            {
                Console.WriteLine("Lade...");
                ManagerObject = new ManagerViewModel();
                ManagerObject.Model = BinarySerializerFileHandler.Load();
            }
        }
    }
}
