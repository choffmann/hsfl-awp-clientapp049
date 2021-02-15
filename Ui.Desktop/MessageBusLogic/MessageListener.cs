using De.HsFlensburg.ClientApp049.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp049.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp049.Ui.Desktop.MessageBusLogic
{
    public class MessageListener
    {
        public bool BindableProperty => true;
        public MessageListener()
        {
            InitMessenger();
        }

        private void InitMessenger()
        {
            NewLearningCardWindow newLearningCard = new NewLearningCardWindow();
            StatisticsWindow statistics = new StatisticsWindow();
            ServiceBus.Instance.Register<OpenNewLearningCardWindowMessage>(this, delegate () {
                newLearningCard.ShowDialog();
            });

            ServiceBus.Instance.Register<OpenLearningWindowMessage>(this, delegate () {
                LearnWindow learnWindow = new LearnWindow();
                learnWindow.ShowDialog();
            });

            ServiceBus.Instance.Register<OpenSaveWindowMessage>(this, delegate () {
                SaveWindow saveWindow = new SaveWindow();
                saveWindow.ShowDialog();
            });

            ServiceBus.Instance.Register<OpenStatisticsWindowMessage>(this, delegate () {
                statistics = new StatisticsWindow();
                statistics.ShowDialog();
            });

            ServiceBus.Instance.Register<CloseNewLearningCardWindowMessage>(this, delegate () {
                newLearningCard.Close();
                newLearningCard = new NewLearningCardWindow();
            });

            ServiceBus.Instance.Register<CloseStatisticsWindowMessage>(this, delegate () {
                statistics.Close();
                statistics = new StatisticsWindow();
            });
        }
    }
}
