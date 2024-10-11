using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Clinic
{
    public partial class Form1 : Form
    {




        Doctors myDoctor_Form = new Doctors();
        Patients myPatient_Form = new Patients();
        
        public Form1()
        {
            InitializeComponent();

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




        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void codeeloButton9_Click(object sender, EventArgs e)
        {
            string Spechialization = "Pediatrics";
            AllDoctors allDoctors = new AllDoctors(Spechialization);
            allDoctors.Show();
            this.Hide();
        }

        private void codeeloButton8_Click(object sender, EventArgs e)
        {
            string Spechialization = "Internal Medicine";
            AllDoctors allDoctors = new AllDoctors(Spechialization);
            allDoctors.Show();
            this.Hide();
        }

        private void codeeloButton7_Click(object sender, EventArgs e)
        {
            string Spechialization = "General Surgery";
            AllDoctors allDoctors = new AllDoctors(Spechialization);
            allDoctors.Show();
            this.Hide();
        }

        private void codeeloButton10_Click(object sender, EventArgs e)
        {
            string Spechialization = "Ophthalmology";
            AllDoctors allDoctors = new AllDoctors(Spechialization);
            allDoctors.Show();
            this.Hide();
        }

        private void codeeloButton11_Click(object sender, EventArgs e)
        {
            string Spechialization = "Dentistry";
            AllDoctors allDoctors = new AllDoctors(Spechialization);
            allDoctors.Show();
            this.Hide();
        }

        private void codeeloButton12_Click(object sender, EventArgs e)
        {
            string Spechialization = "Cardiology";
            AllDoctors allDoctors = new AllDoctors(Spechialization);
            allDoctors.Show();
            this.Hide();
        }
    }
}
