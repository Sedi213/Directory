using Directonary.Entity;
using System.Data;
using System.Windows.Forms;

namespace Directonary
{
    public partial class Form1 : Form
    {
        Context context;
        public Form1()
        {
            InitializeComponent();
            context = new Context();

            foreach (var loca in context.Locations.Select(m => m.Country).Distinct())
                listBox1.Items.Add(loca);

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string selectedCountry = listBox1.SelectedItem.ToString();

            foreach (var loca in context.Locations.Where(l => l.Country == selectedCountry).Select(l=>l.Region).Distinct())
                listBox2.Items.Add(loca);
           
            listBox3.Items.Clear();
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            string selectedCountry = listBox1.SelectedItem.ToString();
            string selectedRegion = listBox2.SelectedItem?.ToString();

            foreach (var loca in context.Locations.Where
                            (l => l.Country == selectedCountry && 
                            l.Region==selectedRegion)
                            .Select(l => l.City).Distinct())
                listBox3.Items.Add(loca);
        }


        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxCountry.Text == "") {
                MessageBox.Show("The Country field is empty");
                return; }
            Location temp = new Location()
            {
                Country = textBoxCountry.Text,
                Region = textBoxRegion.Text,
                City = textBoxCity.Text
            };

            context.Locations.Add(temp);
            context.SaveChanges();
            Refresh();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string selectedCountry = listBox1.SelectedItem?.ToString();
            string selectedRegion = listBox2.SelectedItem?.ToString();
            string selectedCity = listBox3.SelectedItem?.ToString();

            context.Locations.RemoveRange(context.Locations.Where(l => l.Country == selectedCountry &&
                                                                          l.Region == (selectedRegion ?? l.Region) &&
                                                                           l.City == (selectedCity ?? l.City) ));
            context.SaveChanges();
            Refresh();
}

        private void Refresh()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            foreach (var loca in context.Locations.Select(m=>m.Country).Distinct())
                listBox1.Items.Add(loca);
        }
    }
}