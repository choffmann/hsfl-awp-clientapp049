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

        private ManagerViewModel manger;
        public ManagerViewModel ManagerObject;
        public CardCollectionViewModel CardCollectionVM { get; set; }
        public RelayCommand AddLearningCard { get; }
        public RelayCommand SerializeToBin { get; }
        public RelayCommand DeserializeFromBin { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public NewLearningCardWindowViewModel(CardCollectionViewModel model)
        {
            SerializeToBin = new RelayCommand(() => SerializeToBinMethode());
            DeserializeFromBin = new RelayCommand(() => DesrializeFromBinMethode());
            AddLearningCard = new RelayCommand(() => AddLearningCardMethode());
            CardCollectionVM = model;
        }

        private void SerializeToBinMethode()
        {
            BinarySerializerFileHandler.Save(CardCollectionVM.Model);
        }

        private void DesrializeFromBinMethode()
        {
            LearningCardCollection model = BinarySerializerFileHandler.Load();
            CardCollectionVM.Clear();
            foreach(var element in model)
            {
                //CardCollectionVM.Add(new CardViewModel(element));
            }
        }

        private void AddLearningCardMethode()
        {
            CardViewModel cvm = new CardViewModel();
            cvm.Question = Question;
            cvm.Answer = Awnser;
            CardCollectionVM.Add(cvm);
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
