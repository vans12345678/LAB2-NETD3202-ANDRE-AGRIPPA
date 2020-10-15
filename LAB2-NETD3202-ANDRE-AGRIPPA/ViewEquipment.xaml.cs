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
        public ViewEquipment()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}