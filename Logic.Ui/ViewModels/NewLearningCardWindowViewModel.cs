using BinarySerializer;
using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp049.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class NewLearningCardWindowViewModel: INotifyPropertyChanged
    {
        private String question;
        private String awnser;
        private ThemeViewModel theme;
        public ManagerViewModel manager;
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

        public String Question
        {
            get
            {
                return question;
            }
            set
            {
                question = value;
                OnPropertyChanged("Question");
            }
        }
        public String Awnser
        {
            get
            {
                return awnser;
            }
            set
            {
                awnser = value;
                OnPropertyChanged("Awnser");
            }
        }
        public ThemeViewModel Theme {
            get
            {
                return theme;
            }
            set
            {
                theme = value;
                OnPropertyChanged("Theme");
            }
        }
        public ThemeCollectionViewModel ThemeCollectionVM { get; set; }
        public RelayCommand AddLearningCard { get; }
        public RelayCommand SerializeToBin { get; }
        public RelayCommand CloseWindow { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public NewLearningCardWindowViewModel(ManagerViewModel model)
        {
            Console.WriteLine("Konstruktor");
            ManagerObject = model;
            AddLearningCard = new RelayCommand(() => AddLearningCardMethode());
            //DeserializeFromBinMethode();
        }
        private void SerializeToBinMethode()
        {
            Console.WriteLine("Speichere...");
            BinarySerializerFileHandler.Save(ManagerObject.Model);
        }

        private void DeserializeFromBinMethode()
        {
            if(File.Exists(BinarySerializerFileHandler.filePath))
            {
                Console.WriteLine("Lade...");
                ManagerObject = new ManagerViewModel();
                ManagerObject.Model = BinarySerializerFileHandler.Load();
            }
        }

        private void AddLearningCardMethode()
        {
            CardViewModel cvm = new CardViewModel();
            cvm.Question = Question;
            cvm.Answer = Awnser;
            cvm.Theme = Theme.Name;
            
            ManagerObject.LearningCards.Add(cvm);
            SerializeToBinMethode();

            Question = "";
            Awnser = "";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
