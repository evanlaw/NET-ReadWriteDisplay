using System;
using System.Collections.Generic;
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
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace TestDBReadWriteDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
             OleDbConnection con = new OleDbConnection();
             con.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
             con.Open();
             OleDbCommand cmd = new OleDbCommand();
             cmd.CommandText = "select * from [People]";
             cmd.Connection = con;
             OleDbDataReader rd = cmd.ExecuteReader();
             DataGridBox.ItemsSource = rd;


            /*DataTable dt = new DataTable();
            DataColumn id = new DataColumn("id", typeof(int));
            DataColumn firstname = new DataColumn("firstname", typeof(string));
            DataColumn lastname = new DataColumn("lastname", typeof(string));
            DataColumn age = new DataColumn("age", typeof(int));
            DataColumn notes = new DataColumn("notes", typeof(string));*/

            /*dt.Columns.Add(id);
            dt.Columns.Add(firstname);
            dt.Columns.Add(lastname);
            dt.Columns.Add(age);
            dt.Columns.Add(notes);*/


        }

        private void DataGridBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView row_selected = DataGridBox.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                TextFirstName.Text = row_selected["FirstName"].ToString();
                TextLastName.Text = row_selected["LastName"].ToString();
                TextAge.Text = row_selected["Age"].ToString();
                TextNotes.Text = row_selected["Notes"].ToString();
            }

        }
    }
}
