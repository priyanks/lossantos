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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private Form1 mainform = null;
         public Form5(Form callingForm)
        {
            mainform = callingForm as Form1;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string name="",name1="";
            int degree=0;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("Please fill all the fields");
                textBox1.Text = textBox2.Text = "";
            }
            else
            {
                try
                {
                    XmlDocument mydoc = new XmlDocument();
                    mydoc.Load("entry.xml");
                    XmlNode root = mydoc.DocumentElement;
                    XmlNodeList list = root.ChildNodes;
                    int c = list.Count;

                    for (int i = 0; i < c; i++)
                    {
                        if (textBox1.Text == list.Item(i).Name.ToString())
                        {
                            for (int j = 0; j < c; j++)
                            {
                                if (textBox2.Text == list.Item(j).Name.ToString())
                                {
                                    foreach (XmlNode child in list.Item(i).ChildNodes)
                                    {
                                        switch (child.Name.ToString())
                                        {
                                            case "Friend":
                                                name = child.InnerText;
                                                
                                                foreach (XmlNode child1 in list.Item(j).ChildNodes)
                                                {
                                                    switch (child1.Name.ToString())
                                                    {
                                                        case "Friend":
                                                            name1 = child1.InnerText;

                                                            if (name == name1)
                                                                degree++;
                                                            break;
                                                    }

                                                }

                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("Degree of friendship between " + textBox1.Text + " and " + textBox2.Text + " is " + degree*5+"%");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("User Files don't exist");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.mainform.Show();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
