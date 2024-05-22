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
using System.Text.RegularExpressions;

namespace WindowsFormsApp8
{
    public partial class Form3 : Form
    {

        string pattern = @"""(.*?[^\\])""";
        private int currentIndex = 1;
        public string[] red;
        private List<string> peopleData;
        public Form3()
        {
            InitializeComponent();
            peopleData = new List<string>();
        }
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentIndex = listBox1.SelectedIndex;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPeopleFromFile(@"C:\Users\Ucenik.PRVABEOGIM\Desktop\Lenka\OOP\oops.txt");
            DisplayCurrentPerson();
        }

        private void LoadPeopleFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                peopleData.AddRange(File.ReadAllLines(filePath));
                string[] personDetails = peopleData[currentIndex].Split(',');
            }
            else
            {
                MessageBox.Show("File not found!");
            }
        }

        private void DisplayCurrentPerson()
        {
            if (peopleData != null && peopleData.Count > 0 && currentIndex < peopleData.Count)
            {
                string[] personDetails = peopleData[currentIndex].Split(',');
                //listBox1.Items.Clear();
                listBox1.Items.Add($"{personDetails[7]},{personDetails[8]},{personDetails[6]},{personDetails[1]},{personDetails[2]},{personDetails[3]},{personDetails[4]},{personDetails[5]}");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (this.listBox1.SelectedIndex >= 0)
                {
                    this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
                }
            }
        }
        private string[] selectedPersonDetails;

        private void DisplayAllPeople()
        {
            listBox1.Items.Clear();
            foreach (string person in peopleData)
            {
                MatchCollection matches = Regex.Matches(person, pattern);
                List<string> personDetails = new List<string>();
                foreach (Match match in matches)
                {
                    string value = match.Groups[1].Value;
                    personDetails.Add(value);
                }
                listBox1.Items.Add($"{personDetails[5]}  {personDetails[6]}  {personDetails[7]} ,{personDetails[0]} ,{personDetails[1]} ,{personDetails[2]} ,{personDetails[3]} ,{personDetails[4]}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadPeopleFromFile(@"C:\Users\Ucenik.PRVABEOGIM\Desktop\Lenka\OOP\oops.txt");
            DisplayAllPeople();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && currentIndex < peopleData.Count)
            {
                selectedPersonDetails = peopleData[currentIndex].Split(',');
                Form4 editForm = new Form4(selectedPersonDetails);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    string[] editedDetails = editForm.GetEditedDetails();

                    peopleData[currentIndex] = string.Join(",", editedDetails);

                    listBox1.Items.Clear();
                    DisplayCurrentPerson();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
                if (listBox1.SelectedIndex != -1)
                {
                    if (this.listBox1.SelectedIndex >= 0)
                    {
                        this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
                    }
                }
    }
    }
}

