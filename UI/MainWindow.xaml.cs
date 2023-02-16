using Chazan.GamesCatalog.BL;
using Chazan.GamesCatalog.INTERFACES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chazan.GamesCatalog.UI
{
    public partial class MainWindow : Window
    {
        ObservableCollection<IProducer> Help = new ObservableCollection<IProducer>();
        public MainWindow()
        {
            Singleton.SetDataAccess(ConfigurationManager.AppSettings["DBName"]);
            InitializeComponent();
            foreach (var x in Glvm.Producers)
            {
                Help.Add(x.Producer);
            }
            ProducerComboBox.ItemsSource = Help;
            Tc.SelectionChanged += Tabcontrol_SelectionChanged;
        }

        private void Tabcontrol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.Source is TabControl)
            {
                Glvm.GetAllGames();
                Help.Clear();
                foreach (var x in Glvm.Producers)
                {
                    Help.Add(x.Producer);
                }
            }
        }
    }
}
