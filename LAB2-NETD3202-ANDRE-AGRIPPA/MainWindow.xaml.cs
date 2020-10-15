/*
 * Name: Andre Agrippa
 * Date: 10/15/2020
 * Course: NETD 3202
 * Purpose: MainWindow functionality between listview selections
 * File: MainWindow.xaml.cs
 */
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
        //MainWindow initialization 
        public MainWindow()
        {
            InitializeComponent();
            //Default column 1 pane to show add equipment page
            Control addEquipment = new AddEquipment();
            ContentPanel.Children.Add(addEquipment);
        }

        //When user selects either lend out or view
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = e.Source as ListView;

            if (listView != null)
            {
                //If listview is not empty clear before changing listview contents
                ContentPanel.Children.Clear();

                if (listView.SelectedItem.Equals(lsvItemLendOut))
                {
                    //AddEquipment is a custom user control from AddEquipment.xaml
                    Control addEquipment = new AddEquipment();
                    this.ContentPanel.Children.Add(addEquipment);
                }
                if (listView.SelectedItem.Equals(lsvItemViewLendOut))
                {
                    //ViewEquipment is a custom user control from ViewEquipment.xaml
                    Control viewEquipment = new ViewEquipment();
                    this.ContentPanel.Children.Add(viewEquipment);
                }
            }
        }
    }
}

