using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace goodfast
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ifrm = new XOR();
            ifrm.Show();
            this.Hide(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form ifrm = new Caesar();
            ifrm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ifrm = new Permutation();
            ifrm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ifrm = new substitution();
            ifrm.Show();
            this.Hide();
        }
    }
}
