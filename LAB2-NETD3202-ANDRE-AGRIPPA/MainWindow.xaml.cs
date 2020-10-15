using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace LAB2_NETD3202_ANDRE_AGRIPPA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Control addEquipment = new AddEquipment();

            ContentPanel.Children.Add(addEquipment);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = e.Source as ListView;

            if (listView != null)
            {
                ContentPanel.Children.Clear();
                if (listView.SelectedItem.Equals(lsvItemLendOut))
                {
                    Control addEquipment = new AddEquipment();
                    this.ContentPanel.Children.Add(addEquipment);
                }
                if (listView.SelectedItem.Equals(lsvItemViewLendOut))
                {
                    Control viewEquipment = new ViewEquipment();
                    this.ContentPanel.Children.Add(viewEquipment);
                }
            }
        }
    }
}

