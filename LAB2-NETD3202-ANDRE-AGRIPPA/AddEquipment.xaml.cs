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
        public AddEquipment()
        {
            InitializeComponent();
        }

        private void btnAddToDatabase_Click(object sender, RoutedEventArgs e)
        {
            int employeeID;
            if (txtName.Text != string.Empty)
            {
                if (txtEmployeeID.Text != string.Empty && int.TryParse(txtEmployeeID.Text, out employeeID))
                {
                    if (txtDescOfEquipment.Text != string.Empty)
                    {
                        if (txtContactPhoneNumber.Text != string.Empty)
                        {
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
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception);
                                throw;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Phone number cannot be empty");
                            txtContactPhoneNumber.SelectAll();
                            txtContactPhoneNumber.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Description of Equipment cannot be empty");
                        txtDescOfEquipment.SelectAll();
                        txtDescOfEquipment.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Employee ID cannot be empty and must be numeric");
                    txtEmployeeID.SelectAll();
                    txtEmployeeID.Focus();
                }
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
