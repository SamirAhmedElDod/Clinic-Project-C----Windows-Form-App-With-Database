using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinic
{
    public partial class Doctors : Form
    {

        public static string connectionString = "server=.;Database=ClinicProject;User Id=sa;password=samir123456";
        SqlConnection connection = new SqlConnection(connectionString);

        public void LoadAllDoctors()
        {
            // DataBase Read All Data From Database When Load ;
            DoctorDataGridView.DataSource = null;
            DoctorDataGridView.Rows.Clear();

            string getAllDoctors_Query = "select * from Doctors";
            SqlCommand command = new SqlCommand(getAllDoctors_Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int ID = (int)reader["ID"];
                    string DoctorName = (string)reader["DoctorName"];
                    string DoctorGender = (string)reader["Gender"];
                    DateTime DoctorDateOfBirth = (DateTime)reader["DateOfBirth"];
                    string DoctorPhone = (string)reader["phoneNumber"];
                    string DoctorEmail = (string)reader["Email"];
                    string DoctorAddress = (string)reader["Address"];
                    string DoctorSpecialization = (string)reader["Specialization"];


                    DoctorDataGridView.Rows.Add
                        (ID, DoctorName, DoctorGender, DoctorDateOfBirth, DoctorPhone, DoctorEmail, DoctorAddress, DoctorSpecialization);
                }

                connection.Close();
                reader.Close();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error");

            }
        }
        private void Doctors_Load(object sender, EventArgs e)
        {
            LoadAllDoctors();
        }



        public int ID = 0;
  
        public Doctors()
        {
            InitializeComponent();
        }


        private void codeeloButton7_Click(object sender, EventArgs e)
        {
            string DoctorName = DNameTB.Text;
            string DoctorDateofBirth = DofBirthTB.Text;
            string DoctorPhoneNumber = PNumberTB.Text;
            string DoctorGender = GenderTB.Text;
            string DoctorEmail = EmailTB.Text;
            string DoctorAddress = AddressTB.Text;
            string DoctorSpecialization = SpecializationTB.Text;
            

            // Start Text Box Validation
            if (string.IsNullOrEmpty(DNameTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (string.IsNullOrEmpty(GenderTB.Text))
            {
                ErrorEmptyOrNullTextBoxMessageBox();
                return;
            }
            if (string.IsNullOrEmpty(DofBirthTB.Text))
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
            if (string.IsNullOrEmpty(SpecializationTB.Text))
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

            connection.Open();
            string InsertNewDoctor_Query = "Insert into Doctors Values (@DoctorName, @DateOfBirth, @Gender, @Address, @PhoneNumber , @Email, @Specialization)";
            
            SqlCommand Insertcommand = new SqlCommand(InsertNewDoctor_Query, connection);

            Insertcommand.Parameters.AddWithValue("@DoctorName", DoctorName);
            Insertcommand.Parameters.AddWithValue("@DateOfBirth", DoctorDateofBirth);
            Insertcommand.Parameters.AddWithValue("@Gender", DoctorGender);
            Insertcommand.Parameters.AddWithValue("@Address", DoctorAddress);
            Insertcommand.Parameters.AddWithValue("@PhoneNumber", DoctorPhoneNumber);
            Insertcommand.Parameters.AddWithValue("@Email", DoctorEmail);
            Insertcommand.Parameters.AddWithValue("@Specialization", DoctorSpecialization);

            int RowsAffected = Insertcommand.ExecuteNonQuery();

            if (RowsAffected > 0)
            {
                MessageBox.Show("Doctor Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show("Doctor Didn't Added Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            connection.Close();
            ResetTextBoxes();
            LoadAllDoctors();
        }






        private void ResetTextBoxes()
        {
            DNameTB.ResetText();
            DofBirthTB.ResetText();
            PNumberTB.ResetText();
            GenderTB.ResetText();
            EmailTB.ResetText();
            AddressTB.ResetText();
            SpecializationTB.ResetText();
        }
        private void NumberFieldAuthorization(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public bool IsValidEmail(string Email)
        {
            return Email.Contains('@') && Email.Contains('.');
        }

        

        private void PNumberTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFieldAuthorization(e);
        }

        public void ErrorEmptyOrNullTextBoxMessageBox()
        {
            MessageBox.Show("Please Fill All Text Boxs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void codeeloPictureBox1_Click_1(object sender, EventArgs e)
        {
            Form1 myForm = new Form1();
            myForm.Show();
            this.Hide();
        }
        private void codeeloButton3_Click_1(object sender, EventArgs e)
        {
            Form1 myForm = new Form1();
            myForm.Show();
            this.Hide();
        }
        private void codeeloButton2_Click_1(object sender, EventArgs e)
        {

            Patients patients = new Patients();
            patients.Show();
            this.Hide();
        }

        private void codeeloButton8_Click(object sender, EventArgs e)
        {
            string PassCode = "From Doctors Form";
            DeleteForm deleteForm = new DeleteForm(PassCode);
            deleteForm.Show();
            deleteForm.FormClosed += (s, args) => LoadAllDoctors();
        }
    }
}
