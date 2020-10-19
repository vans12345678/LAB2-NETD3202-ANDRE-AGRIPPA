/*
 * Name: Andre Agrippa
 * Date: 10/15/2020
 * Course: NETD 3202
 * Purpose: Add equipment page functionality
 * File: AddEquipment.xaml.cs
 */

using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : UserControl
    {
        //Initializes AddEquipment contents
        public AddEquipment()
        {
            InitializeComponent();
        }

        //When the add button is clicked, validate user input then add record to database
        private void btnAddToDatabase_Click(object sender, RoutedEventArgs e)
        {
            int employeeID;

            //If text name is not an empty entry
            if (txtName.Text != string.Empty)
            {
                //If text employee id is not an empty entry and can be parsed as an integer
                if (txtEmployeeID.Text != string.Empty && int.TryParse(txtEmployeeID.Text, out employeeID))
                {
                    //If text description of equipment is not an empty entry
                    if (txtDescOfEquipment.Text != string.Empty)
                    {
                        //If text phone number is not an empty entry
                        if (txtContactPhoneNumber.Text != string.Empty)
                        {
                            //Try to add to database
                            try
                            {
                                string connectString = Properties.Settings.Default.connect_string;

                                SqlConnection conn = new SqlConnection(connectString);
                                conn.Open();

                                string insertQuery = "INSERT INTO [Equipment] (name, empID, description, phone) VALUES('" + txtName.Text + "', '" + int.Parse(txtEmployeeID.Text) + "', '" + txtDescOfEquipment.Text + "', '" + txtContactPhoneNumber.Text + "')";

                                SqlCommand command = new SqlCommand(insertQuery, conn);

                                command.ExecuteNonQuery();
                                conn.Close();

                                MessageBox.Show("Successfully added equipment entry");
                            }
                            //Will catch and display exception if there is an error adding to database
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.ToString());
                                throw;
                            }
                        }
                        //If phone number is empty
                        else
                        {
                            MessageBox.Show("Phone number cannot be empty");
                            txtContactPhoneNumber.SelectAll();
                            txtContactPhoneNumber.Focus();
                        }
                    }
                    //If description is empty
                    else
                    {
                        MessageBox.Show("Description of Equipment cannot be empty");
                        txtDescOfEquipment.SelectAll();
                        txtDescOfEquipment.Focus();
                    }
                    //If employee ID is empty or not numeric
                }
                else
                {
                    MessageBox.Show("Employee ID cannot be empty and must be numeric");
                    txtEmployeeID.SelectAll();
                    txtEmployeeID.Focus();
                }
                //If name is empty
            }
            else
            {
                MessageBox.Show("Name cannot be empty.");
                txtName.SelectAll();
                txtName.Focus();
            }
            
        }
    }
}
