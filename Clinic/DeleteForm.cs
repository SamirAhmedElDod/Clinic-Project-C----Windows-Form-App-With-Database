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

namespace Clinic
{
    public partial class DeleteForm : Form
    {
        public string ThePassCode = "";
        public DeleteForm(string PassCode)
        {
            InitializeComponent();
            if (PassCode == "From Doctors Form") 
            {
                label1.Text = "Delete Doctor";
            }
            else if (PassCode == "From Patients Form")
            {
                label1.Text = "Delete Patient";
            }
            ThePassCode = PassCode;
        }
        // For Doctors 
        
        // Stopped Here I Will Connect Database And Delete With ID From TextBox Then With name;

        public void DeleteDoctorWithID(int ID)
        {
            string connectionString = "server=.;Database=ClinicProject;User Id=sa;password=samir123456;";
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = @"delete from Doctors where ID = @DoctorID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DoctorID", ID);
            try
            {
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                if (RowAffected > 0) 
                {
                    MessageBox.Show($"Doctor Deleted Successfully , With ID {ID}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"ID : {ID} , Faild To Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteDoctorWithName(string DoctorName)
        {
            string connectionString = "server=.;Database=ClinicProject;User Id=sa;password=samir123456;";
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = @"delete from Doctors where DoctorName = @DoctorName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DoctorName", DoctorName);

            try
            {
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    MessageBox.Show($"Doctor : {DoctorName} Deleted Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Doctor : {DoctorName} , Faild To Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

        }


        public void DeletePatientWithID(int ID)
        {
            string connectionString = "server=.;Database=ClinicProject;User Id=sa;password=samir123456;";
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = @"delete from Patients where ID = @PatientID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PatientID", ID);
            try
            {
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    MessageBox.Show($"Patient Deleted Successfully , With ID {ID}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Patient ID : {ID} , Faild To Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeletePatientWithName(string PatientName)
        {
            string connectionString = "server=.;Database=ClinicProject;User Id=sa;password=samir123456;";
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = @"delete from Patients where Name = @PatientName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PatientName", PatientName);

            try
            {
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    MessageBox.Show($"Patient : {PatientName} Deleted Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Patient : {PatientName} , Faild To Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void codeeloButton1_Click(object sender, EventArgs e)
        {
            bool ISconverted = int.TryParse(codeeloTextBox1.Text , out int ID);

            if (ThePassCode == "From Doctors Form")
            {
                if (ISconverted)
                {
                    DeleteDoctorWithID(ID);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Enter Valid ID -- ( Only Number | Integers )", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else if (ThePassCode == "From Patients Form")
            {
                if (ISconverted)
                {
                    DeletePatientWithID(ID);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Enter Valid ID -- ( Only Number | Integers )", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void codeeloButton2_Click(object sender, EventArgs e)
        {
            if (ThePassCode == "From Doctors Form")
            {
                string DoctorName = codeeloTextBox2.Text;
                DeleteDoctorWithName(DoctorName);
                this.Close();
            }
            else if (ThePassCode == "From Patients Form")
            {
                string PatientName = codeeloTextBox2.Text;
                DeletePatientWithName(PatientName);
                this.Close();
            }
        }
    }
}
