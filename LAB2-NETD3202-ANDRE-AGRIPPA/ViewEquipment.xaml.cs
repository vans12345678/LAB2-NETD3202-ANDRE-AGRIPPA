/*
 * Name: Andre Agrippa
 * Date: 10/15/2020
 * Course: NETD 3202
 * Purpose: View equipment page functionality
 * File: ViewEquipment.xaml.cs
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
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
    /// Interaction logic for ViewEquipment.xaml
    /// </summary>
    public partial class ViewEquipment : UserControl
    {
        //Initialize ViewEquipment contents
        public ViewEquipment()
        {
            InitializeComponent();
            //Display database contents
            FillDataGrid();
        }
        //This function will display the contents of 
        private void FillDataGrid()
        {
            //Try to display the contents of the database
            try
            {
                string connectString = Properties.Settings.Default.connect_string;

                SqlConnection conn = new SqlConnection(connectString);

                conn.Open();

                string selectionQuery = "SELECT * FROM Equipment";
                SqlCommand command = new SqlCommand(selectionQuery, conn);

                SqlDataAdapter sda = new SqlDataAdapter(command);

                DataTable dt = new DataTable("Equipment");

                sda.Fill(dt);
                 
                viewEquipmentGrid.ItemsSource = dt.DefaultView;
            }
            //If contents cannot be displayed, display exception
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}