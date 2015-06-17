using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SpamFreq : Form
    {
        public int freq = 1;
        public SpamFreq()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            freq = (int)numericUpDown1.Value;
            this.DialogResult = DialogResult.OK;
        }
    }
}
