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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3(this);
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2(this);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f = new Form4(this);
            f.Show();
        }
    }
}
