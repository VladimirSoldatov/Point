using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        public List<string> list_of_words;
        private void Form2_Load(object sender, EventArgs e)
        {
            radioButton1.PerformClick();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                string file_name = openFileDialog1.FileName;
                using (StreamReader sr = new StreamReader(file_name))
                {
                    list_of_words = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line is not null)
                            list_of_words.Add(line);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.OK;
        }
    }
}
