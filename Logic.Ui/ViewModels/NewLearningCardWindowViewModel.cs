using BinarySerializer;
using De.HsFlensburg.ClientApp049.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp049.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Logic.Ui.ViewModels
{
    public class NewLearningCardWindowViewModel: INotifyPropertyChanged
    {
        private String question;
        private String awnser;
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

       
        public CardCollectionViewModel CardCollectionVM { get; set; }
        public ThemeCollectionViewModel ThemeCollectionVM { get; set; }
        public RelayCommand AddLearningCard { get; }
        public RelayCommand SerializeToBin { get; }
        public RelayCommand DeserializeFromBin { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public NewLearningCardWindowViewModel(ManagerViewModel model)
        {
            ManagerObject = model;
            AddLearningCard = new RelayCommand(() => AddLearningCardMethode());
            DeserializeFromBin = new RelayCommand(() => DeserializeFromBinMethode());
            DeserializeFromBinMethode();
            //AddTheme();
        }

        private void AddTheme()
        {
            ThemeViewModel themeVM;
            String[] theme = { "Mathe", "Deutsch", "Englisch" };
            for (int i = 0; i < theme.Length; i++)
            {
                themeVM = new ThemeViewModel();
                themeVM.Name = theme[i];
                ManagerObject.Themes.Add(themeVM);
            }
        }

        private void SerializeToBinMethode()
        {
            Console.WriteLine("Speichere...");
            BinarySerializerFileHandler.Save(ManagerObject.Model);
        }

        private void DeserializeFromBinMethode()
        {
            Console.WriteLine("Lade...");
            ManagerObject = new ManagerViewModel();
            ManagerObject.Model = BinarySerializerFileHandler.Load();
        }

        private void AddLearningCardMethode()
        {
            CardViewModel cvm = new CardViewModel();
            cvm.Question = Question;
            cvm.Answer = Awnser;
            cvm.Box = 0;
            cvm.CardAttempts = null;
            ManagerObject.LearningCards.Add(cvm);
            SerializeToBinMethode();
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
