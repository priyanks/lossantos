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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private Form1 mainform = null;

        public Form3(Form callingForm)
        {
            mainform = callingForm as Form1;
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument mydoc = new XmlDocument();
            try
            {
                mydoc.Load("entry.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("User File don't exist");
                Application.Exit();
                    
            }
            XmlElement root = mydoc.DocumentElement;
            XmlNodeList list = root.ChildNodes;
            int c = list.Count;
            Boolean accepted = false;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("Please fill all the fields");
                textBox1.Text = textBox2.Text = "";
            }
            else
            {
                for (int i = 0; i < c; i++)
                {
                    if (textBox1.Text == list.Item(i).Name.ToString())
                    {
                        for (int j = 0; j < c; j++)
                        {
                            if (textBox2.Text == list.Item(j).Name.ToString())
                            {
                                accepted = true;
                                foreach (XmlNode node in root.ChildNodes)
                                {
                                    if (node.Name.ToString() == textBox1.Text)
                                    {
                                        XmlNode main = root.SelectSingleNode(textBox1.Text);
                                        XmlNode node1 = mydoc.CreateNode(XmlNodeType.Element, "Friend", "");
                                        node1.InnerText = textBox2.Text;
                                        main.AppendChild(node1);
                                    }
                                    if (node.Name.ToString() == textBox2.Text)
                                    {
                                        XmlNode main = root.SelectSingleNode(textBox2.Text);
                                        XmlNode node1 = mydoc.CreateNode(XmlNodeType.Element, "Friend", "");
                                        node1.InnerText = textBox1.Text;
                                        main.AppendChild(node1);
                                    }
                                    mydoc.Save("entry.xml");
                                }
                                MessageBox.Show("Friendship created");
                                this.Hide();
                                this.mainform.Show();

                            }

                        }
                    }


                }
                if (!accepted)
                {
                    MessageBox.Show("Username don't exist" + Environment.NewLine + "Both of the users should be registered");
                    textBox1.Text = textBox2.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.mainform.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
