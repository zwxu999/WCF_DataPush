using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.MyCallbackServiceReference;

namespace Client
{
    public partial class Form1 : Form
    {
        public Book[] ComicsStore { get; set; }
        private  MyCallbackServiceReference.ServiceClient handler;
        private RequestCallback callback;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            callback = new RequestCallback();
            InstanceContext context = new InstanceContext(callback);
            handler = new MyCallbackServiceReference.ServiceClient(context);          
        }
        public void Init(int id)
        {
            if (ComicsStore[id] != null)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(ComicsStore[id].ImgPath);
                label1.Text = ComicsStore[id].Title;
                label2.Text = ComicsStore[id].Author;
            }
        }

        private void getComicsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handler.Seed();
            MessageBox.Show("Seed Completed");
            try
            {
                ComicsStore = callback.Books;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (ComicsStore.Count() != 0)
                MessageBox.Show(ComicsStore.Count().ToString() + " comics added to this store");
            listBox1.DataSource = ComicsStore.Select(x=>x.Title).ToList();
            
        }

        private void startRecievingSpamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handler.Seed();
            SpamFreq sf = new SpamFreq();
            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                handler.StartSpam(sf.freq * 1000);
                MessageBox.Show("Spam activated");
            }                     
        }

        private void stopReceiveingSpamFromServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handler.StopSpam();
            MessageBox.Show("Spam deactivated");
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Init(listBox1.SelectedIndex);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            handler.StopSpam();
        }

       
    }
}
