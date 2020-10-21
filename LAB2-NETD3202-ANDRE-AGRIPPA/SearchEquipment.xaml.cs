/*
 * Name: Andre Agrippa
 * Date: 10/20/2020
 * Course: NETD 3202
 * Purpose: Search equipment by EmployeeID page functionality
 * File: SearchEquipment.xaml.cs
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
    /// Interaction logic for SearchEquipment.xaml
    /// </summary>
    public partial class SearchEquipment : UserControl
    {
        public SearchEquipment()
        {
            //Initialize SearchEquipment contents
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int id;

            //If input is not empty and an integer
            if (txtSearch.Text != string.Empty && int.TryParse(txtSearch.Text, out id))
            { 
                //Connect string for db
                string connectString = Properties.Settings.Default.connect_string;
                //New sql connnection
                SqlConnection conn = new SqlConnection(connectString);
                conn.Open();

                //Sql command
                string selectionQuery = "SELECT * FROM Equipment WHERE empID =" + id;

                SqlCommand command = new SqlCommand(selectionQuery, conn);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Equipment");

                sda.Fill(dt);
                searchEmployeeGrid.ItemsSource = dt.DefaultView;
            }
            //If user input invalid
            else
            {
                MessageBox.Show("Employee ID must numeric and not empty");
            }
        }
    }
}
