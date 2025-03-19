using System.Diagnostics;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            resetEvent = new ManualResetEvent(false);


        }
        CancellationTokenSource source;
        CancellationToken token;
        List<Task> tasks = new List<Task>();
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

            Potok_1();
            Potok_2();
            Potok_3();
            tasks.ForEach(p => p.Start());


        }
        ManualResetEvent resetEvent;


        private void Potok_1()
        {
            Task task1 = new Task(Searcher, token);

            tasks.Add(task1);

            resetEvent.Set();
        }
        private void Potok_2()
        {
            Task task2 = new Task(
                () =>   {
                            int count = Count_of_files();
                            Invoke(GetMaximum, count);
                        });
            tasks.Add(task2);
        }

        int Count_of_files()
        {
            FileSearcher fs = new FileSearcher();
            IEnumerable<string> objects = fs.GetFiles3("c:\\", "*.txt");
            int count = objects.Count();
            return count;
        }

        private void Potok_3()
        {


            Task task3 = new Task(() =>
            {
                while (true)
                {
                    int maximum = progressBar1.Maximum;
                    Invoke(() => 
                                {
                                    label2.Text = maximum.ToString();
                                });
                    Thread.Sleep(10000);
                }
            });
            tasks.Add(task3);

        }
        private void GetMaximum(int id)
        {
            progressBar1.Maximum = id;
        }

        private void Searcher()
        {

            FileSearcher fs = new FileSearcher();
            foreach (string file in fs.GetFiles("c:\\", "*.txt"))
            {
                if (token.IsCancellationRequested)
                    return;
                resetEvent.WaitOne();
                Invoke(() =>
                {
                    label1.Text = file;
                    progressBar1.PerformStep();
                });
                Thread.Sleep(3000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetEvent.Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetEvent.Set();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            source.Cancel();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            MessageBox.Show($"{Process.GetCurrentProcess().Threads.Count} - {tasks[0].Status} - {tasks[1].Status}");
        }
    }
}