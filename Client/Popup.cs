using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.MyCallbackServiceReference;

namespace Client
{
    public partial class Popup : Form
    {
        private Random rand = new Random();
        private Book _book;
        public Popup(Book book)
        {
            InitializeComponent();
            _book = book;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            InitFields();
        }

        public void InitFields()
        {
            if (_book != null)
            {
                textBox1.Text = _book.Title;
                textBox2.Text = _book.Author;
                textBox3.Text = _book.Description;
                //MessageBox.Show(_book.ImgPath);
                pictureBox1.Image = Image.FromFile(_book.ImgPath);
            }
        }

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}

        public Image StringToImage(string imageString)
        {

            if (imageString == null)

                throw new ArgumentNullException("imageString");

            byte[] array = Convert.FromBase64String(imageString);

            Image image = Image.FromStream(new MemoryStream(array));

            return image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
