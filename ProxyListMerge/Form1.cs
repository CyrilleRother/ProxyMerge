using System.Windows.Forms;
using System.IO;


namespace ProxyListMerge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            fo.RestoreDirectory = true;
            fo.Multiselect = false;
            fo.Filter = "txt files (*.txt)|*.txt";
            fo.FilterIndex = 1;
            //fo.ShowDialog();
            if (fo.ShowDialog() == DialogResult.OK)
            {
                if (fo.FileName != null)
                {
                    using (StreamReader r = new StreamReader(fo.FileName))
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            listBox1.Items.Add(line);

                        }
                    }
                }
            }
            else { }

            label2.Text = Convert.ToString(listBox1.Items.Count);
        }
            private void button2_Click(object sender, EventArgs e)
            {
                if (listBox1.Items.Count > 0)
                {
                    SaveFileDialog fs = new SaveFileDialog();
                    fs.RestoreDirectory = true;
                    fs.Filter = "txt files (*.txt)|*.txt";
                    fs.FilterIndex = 1;
                    fs.ShowDialog();
                    if (!(fs.FileName == null))
                    {
                        using (StreamWriter sw = new StreamWriter(fs.FileName))
                        {
                            foreach (string line in listBox1.Items)
                            {
                                sw.WriteLine(line);
                            }
                        }

                    }
                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label2.Text = "-";
        }
    } }