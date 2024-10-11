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
    public partial class Patients : Form
    {
        public static string connectionString = "server=.;Database=ClinicProject;User Id=sa;password=samir123456";
        SqlConnection connection = new SqlConnection(connectionString);
        public int ID = 0;
        public Patients()
        {
            InitializeComponent();
        }

        public DataTable GetAllPatients()
        {
            DataTable dt = new DataTable();
            string GetAllPatientsWithDoctors_Query = "select Patients.* , Doctors.DoctorName  , Doctors.Specialization from Doctors inner join Patients on Doctors.ID = Patients.Doctor_ID";
            SqlCommand command = new SqlCommand(GetAllPatientsWithDoctors_Query, connection);

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
                Console.WriteLine(Error.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        private void _RefershDataSource()
        {
            PatientDataGridView.DataSource = GetAllPatients();
        }

        private void codeeloPictureBox1_Click(object sender, EventArgs e)
        {
            Form1 myForm = new Form1();

            myForm.Show();
            this.Hide();
        }

        private void codeeloButton1_Click(object sender, EventArgs e)
        {
            Doctors myDoctor_Form = new Doctors();
            myDoctor_Form.Show();
            this.Hide();
        }

        private void codeeloButton3_Click(object sender, EventArgs e)
        {
            Form1 myForm = new Form1();
            myForm.Show();
            this.Hide();
        }

        private void codeeloButton7_Click(object sender, EventArgs e)
        {

            // Start Text Box Validation
            if (string.IsNullOrEmpty(PNameTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (string.IsNullOrEmpty(GenderTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (string.IsNullOrEmpty(PAgeTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (string.IsNullOrEmpty(PNumberTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (string.IsNullOrEmpty(EmailTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (string.IsNullOrEmpty(AddressTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (string.IsNullOrEmpty(PaymentTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (string.IsNullOrEmpty(DIDTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (string.IsNullOrEmpty(DateTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (!IsValidEmail(EmailTB.Text))
            {
                MessageBox.Show("Please Enter Valid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // End Text Box Validation

            // Query To Insert The New Patient


            string PatientName = PNameTB.Text;
            string PatientGender = GenderTB.Text;
            string PatientAge = PAgeTB.Text;
            string PatientPhoneNumber = PNumberTB.Text;
            string PatientEmail = EmailTB.Text;
            string PatientAddress = AddressTB.Text;
            string PatientPayment = PaymentTB.Text;
            int DoctorID = Convert.ToInt32(DIDTB.Text);
            string AppointmentDate = DateTB.Text;

            string InsertNewPatient_Query = "insert into Patients values(@PatientName, @patientGender, @PatientAge, @PatientPhone, @PatientEmail, @PatientAddress, @PatientPayment, @AppointmentDate, @DoctorID);";
            SqlCommand InsertNewPatient_Command = new SqlCommand(InsertNewPatient_Query, connection);

            InsertNewPatient_Command.Parameters.AddWithValue("@PatientName", PatientName);
            InsertNewPatient_Command.Parameters.AddWithValue("@patientGender", PatientGender);
            InsertNewPatient_Command.Parameters.AddWithValue("@PatientAge", PatientAge);
            InsertNewPatient_Command.Parameters.AddWithValue("@PatientPhone", PatientPhoneNumber);
            InsertNewPatient_Command.Parameters.AddWithValue("@PatientEmail", PatientEmail);
            InsertNewPatient_Command.Parameters.AddWithValue("@PatientAddress", PatientAddress);
            InsertNewPatient_Command.Parameters.AddWithValue("@PatientPayment", PatientPayment);
            InsertNewPatient_Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            InsertNewPatient_Command.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                connection.Open();

                int RowAffected = InsertNewPatient_Command.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    MessageBox.Show("Patient Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Patient Didn't Added Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch(Exception Error )
            {
                MessageBox.Show(Error.Message, "Error");
            }
            finally
            {

                connection.Close();
            }

            ResetTextBoxes();
            _RefershDataSource();
        }
        public void ResetTextBoxes()
        {
            PNameTB.ResetText();
            GenderTB.ResetText();
            PAgeTB.ResetText();
            PNumberTB.ResetText();
            EmailTB.ResetText();
            AddressTB.ResetText();
            PaymentTB.ResetText();
            DIDTB.ResetText();
            DateTB.ResetText();
        }
        public bool IsValidEmail(string Email)
        {
            return Email.Contains('@') && Email.Contains('.');
        }
        public void NumberFieldAuthorization(KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void ErrorEmptyOrNullTextBoxMessageBox()
        {
            MessageBox.Show("Please Fill All Text Boxs" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
        }
   

        private void PNumberTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFieldAuthorization(e);
        }

        private void PAgeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFieldAuthorization(e);
        }

        private void PaymentTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFieldAuthorization(e);
        }

        private void Patients_Load(object sender, EventArgs e)
        {
            _RefershDataSource();
        }

        private void codeeloButton8_Click(object sender, EventArgs e)
        {
            string PassCode = "From Patients Form";
            DeleteForm deleteForm = new DeleteForm(PassCode);
            deleteForm.Show();
            deleteForm.FormClosed += (s, args) => _RefershDataSource();
        }
    }
}
