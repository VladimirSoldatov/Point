using System.Diagnostics;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            source = new CancellationTokenSource();
            token = source.Token;
            var form2 = new Form2();
            if (DialogResult.OK == form2.ShowDialog())
            {
                var list = form2.list_of_words;
            }
        }
    }
}
