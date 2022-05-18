using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directory
{
    public partial class Form1 : Form
    {
        private string _fileName = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Sedma\\Documents\\GitHub\\Directory\\Directory\\Database1.mdf;Integrated Security=True";
        private SqlConnection connection;



        public Form1()
        {
            InitializeComponent();
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {   
            connection = new SqlConnection(_fileName);
            connection.Open();
            if (connection.State != ConnectionState.Open)
                MessageBox.Show("Error conection to Data base");


            SetListBoxItem(listBox1,"Country");

    }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountry = listBox1.SelectedItem.ToString();

            SetListBoxItem(listBox2, "Region", $"WHERE Country='{selectedCountry}'");
           
            
            listBox3.Items.Clear();
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountry = listBox1.SelectedItem.ToString();
            string selectedRegion = listBox2.SelectedItem.ToString();

            SetListBoxItem(listBox3, "City", $"WHERE Country='{selectedCountry}' AND Region='{selectedRegion}'");
        }



        private void SetListBoxItem(ListBox refresher,string field, string filter=null) {


            SqlCommand dataAdapter = new SqlCommand(
                $"SELECT DISTINCT {field} FROM Direct {filter}",
                connection);

            SqlDataReader reader = dataAdapter.ExecuteReader();


            refresher.Items.Clear();
            while (reader.Read())
                refresher.Items.Add(Convert.ToString(reader[field]));

            reader.Close();
        }

       
    }
}
