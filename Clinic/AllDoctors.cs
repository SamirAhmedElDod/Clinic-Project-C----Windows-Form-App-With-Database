using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    public partial class AllDoctors : Form
    {
        public string SelectedValue = "";

        Form1 Home = new Form1();
        Doctors myDoctor_Form = new Doctors();
        Patients myPatient_Form = new Patients();
        public AllDoctors(string Spechialization)
        {
            InitializeComponent();
            //SpecialitiesCB.SelectedIndex = 1; 
            SpecialitiesCB.Items.Add("Pediatrics");
            SpecialitiesCB.Items.Add("Internal Medicine");
            SpecialitiesCB.Items.Add("General Surgery");
            SpecialitiesCB.Items.Add("Ophthalmology");
            SpecialitiesCB.Items.Add("Dentistry");
            SpecialitiesCB.Items.Add("Cardiology");
            
            SelectedValue = Spechialization;

            int Index = 0;
            for (int i = 0; i < SpecialitiesCB.Items.Count; i++)
            {
                if (SpecialitiesCB.Items[i].ToString() == Spechialization)
                {
                    Index = i; 
                    break;
                }
            }

            SpecialitiesCB.SelectedIndex = Index;
            _RefereshDataGridView();
        }

        private void SpecialitiesCB_OnSelectedIndexChanged(object sender, EventArgs e)
        {
             SelectedValue = SpecialitiesCB.SelectedItem.ToString();
            _RefereshDataGridView();
        }

        public DataTable GetDoctorsWithComboBox()
        {
            DataTable dt = new DataTable();

            string connectionString = "server=.;Database=ClinicProject;User Id=sa;password=samir123456;";
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = @"select * from Doctors where Specialization = @Specialization;";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Specialization" , SelectedValue);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        private void _RefereshDataGridView()
        {
            AllDoctorsDataGridView.DataSource = GetDoctorsWithComboBox();
        }

        private void codeeloButton3_Click(object sender, EventArgs e)
        {
            Home.Show();
            this.Hide();
        }

        private void codeeloButton1_Click(object sender, EventArgs e)
        {
            myDoctor_Form.Show();
            this.Hide();
        }

        private void codeeloButton2_Click(object sender, EventArgs e)
        {
            myPatient_Form.Show();
            this.Hide();
        }

        private void codeeloPictureBox1_Click(object sender, EventArgs e)
        {
            Home.Show();
            this.Hide();
        }
    }
    
}

