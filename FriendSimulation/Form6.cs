using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FriendSimulation
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private Form1 mainform = null;
        public Form6(Form callingForm)
        {
            mainform = callingForm as Form1;
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox4.TextLength == 0)
            {
                MessageBox.Show("Please fill all the usernames");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            }
            else
            {
                bool b1 = false, b2 = false, b3 = false, b4 = false;
                try
                {
                    XmlDocument mydoc = new XmlDocument();
                    mydoc.Load("entry.xml");
                    XmlNode root = mydoc.DocumentElement;
                    foreach (XmlNode child in root.ChildNodes)
                    {
                        if (child.Name.ToString() == textBox1.Text)
                        {
                            string[] name = new string[10];
                            int i = 0, k = 0;
                            foreach (XmlNode child1 in child.ChildNodes)
                            {
                                switch (child1.Name.ToString())
                                {
                                    case "Friend":
                                        name[i++] = child1.InnerText;
                                        break;
                                }
                            }

                            for (int j = 0; j < i; j++)
                            {

                                if (name[j] == textBox2.Text)
                                {
                                    k++;
                                }
                                if (name[j] == textBox3.Text)
                                {
                                    k++;
                                }
                                if (name[j] == textBox4.Text)
                                {
                                    k++;
                                }

                            }

                            if (k == 3)
                                b1 = true;
                        }
                        if (child.Name.ToString() == textBox2.Text)
                        {
                            string[] name = new string[10];
                            int i = 0, k = 0;
                            foreach (XmlNode child1 in child.ChildNodes)
                            {
                                switch (child1.Name.ToString())
                                {
                                    case "Friend":
                                        name[i++] = child1.InnerText;
                                        break;
                                }
                            }
                            for (int j = 0; j < i; j++)
                            {
                                if (name[j] == textBox1.Text)
                                {
                                    k++;
                                }
                                if (name[j] == textBox3.Text)
                                {
                                    k++;
                                }
                                if (name[j] == textBox4.Text)
                                {
                                    k++;
                                }

                            }
                            if (k == 3)
                                b2 = true;
                        }
                        if (child.Name.ToString() == textBox3.Text)
                        {
                            string[] name = new string[10];
                            int i = 0, k = 0;
                            foreach (XmlNode child1 in child.ChildNodes)
                            {
                                switch (child1.Name.ToString())
                                {
                                    case "Friend":
                                        name[i++] = child1.InnerText;
                                        break;
                                }
                            }
                            for (int j = 0; j < i; j++)
                            {
                                if (name[j] == textBox2.Text)
                                {
                                    k++;
                                }
                                if (name[j] == textBox1.Text)
                                {
                                    k++;
                                }
                                if (name[j] == textBox4.Text)
                                {
                                    k++;
                                }

                            }
                            if (k == 3)
                                b3 = true;
                        }
                        if (child.Name.ToString() == textBox4.Text)
                        {
                            string[] name = new string[10];
                            int i = 0, k = 0;
                            foreach (XmlNode child1 in child.ChildNodes)
                            {
                                switch (child1.Name.ToString())
                                {
                                    case "Friend":
                                        name[i++] = child1.InnerText;
                                        break;
                                }
                            }
                            for (int j = 0; j < i; j++)
                            {
                                if (name[j] == textBox2.Text)
                                {
                                    k++;
                                }
                                if (name[j] == textBox3.Text)
                                {
                                    k++;
                                }
                                if (name[j] == textBox1.Text)
                                {
                                    k++;
                                }

                            }
                            if (k == 3)
                                b4 = true;
                        }
                    }
                    if (b1 && b2 && b3 && b4)
                    {
                        MessageBox.Show("it is a fully connected network");
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("it is not a fully connected network");
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("username doesn't exist");
                    Application.Exit();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.mainform.Show();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
