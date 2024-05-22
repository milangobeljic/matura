using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace WindowsFormsApp8
{
    public partial class Form4 : Form
    {
        private string[] personDetails;
        

        public Form4(string[] details)
        {
            InitializeComponent();
            personDetails = details;

            textBox1.Text = personDetails[1];
            textBox2.Text = personDetails[2];
            textBox3.Text = personDetails[3];
            textBox4.Text = personDetails[4];
            textBox5.Text = personDetails[5];
            textBox6.Text = personDetails[6];
            textBox7.Text = personDetails[7];
            textBox8.Text = personDetails[8];
        }

        public string[] GetEditedDetails()
        {
            return new string[]
            {
                personDetails[0], 
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text,

            };
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
