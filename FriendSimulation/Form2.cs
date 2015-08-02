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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private Form1 mainform = null;

        public Form2(Form callingForm)
        {
            mainform = callingForm as Form1;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument mydoc = new XmlDocument();
                mydoc.Load("entry.xml");
                XmlNode root = mydoc.DocumentElement;
                XmlNode root1 = mydoc.CreateNode(XmlNodeType.Element, username.Text, "");
                XmlNode node = mydoc.CreateNode(XmlNodeType.Element,"Firstname","");
                node.InnerText = firstname.Text;
                XmlNode node1= mydoc.CreateNode(XmlNodeType.Element, "Lastname", "");
                node1.InnerText = lastname.Text;
                root1.AppendChild(node);
                root1.AppendChild(node1);
                root.AppendChild(root1);
                mydoc.Save("entry.xml");
                MessageBox.Show("User Created");
                this.Hide();
                this.mainform.Show();
            }
            catch (Exception ex)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter write = XmlWriter.Create("entry.xml", settings);
                write.WriteStartDocument();
                write.WriteStartElement("Users");
                write.WriteStartElement(username.Text);
                try
                {
                    write.WriteElementString("Firstname", firstname.Text);
                    write.WriteElementString("Lastname", lastname.Text);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Please enter alphabets only");
                }
                write.WriteEndElement();
                write.WriteEndElement();
                write.WriteEndDocument();
                write.Flush();
                write.Close();
                MessageBox.Show("User Created");
                this.Hide();
                this.mainform.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.mainform.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
