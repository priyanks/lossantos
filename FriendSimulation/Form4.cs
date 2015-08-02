using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriendSimulation
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private Form1 mainform = null;
         public Form4(Form callingForm)
        {
            mainform = callingForm as Form1;
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5(this.mainform);
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6(this.mainform);
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.mainform.Show();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
