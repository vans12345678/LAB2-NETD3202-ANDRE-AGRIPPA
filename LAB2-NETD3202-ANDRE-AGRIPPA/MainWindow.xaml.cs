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
        }

        private void lsvItemLendOut_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void AddEquipmentToDatabase(object sender, RoutedEventArgs e)
        {
            // try
            // {
            //     string connectString = Properties.Settings.Default.connect_string;
            //
            //     SqlConnection conn = new SqlConnection(connectString);
            //     conn.Open();
            //
            //     string insertQuery = "INSERT INTO Equipment (name, empID, desc, phone) VALUES" +
            //                          "('" + txtName.Text + "', '" + txtEmployeeID.Text + "', '" + txtDescOfEquipment.Text + "', '" + txtContactPhoneNumber.Text + "')";
            //
            //     SqlCommand command = new SqlCommand(insertQuery, conn);
            //
            //     command.ExecuteNonQuery();
            //     conn.Close();
            //
            //     MessageBox.Show("Successfully added equipment entry");
            // }
            // catch (Exception exception)
            // {
            //     Console.WriteLine(exception);
            //     throw;
            // }
            
        }

        private void btnAddToDatabase_Click(object sender, RoutedEventArgs e)
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
    }
    }

