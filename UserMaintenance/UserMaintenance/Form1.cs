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
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FirstName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.Save;
            button3.Text = Resource1.Delete;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            using (StreamWriter sw = new StreamWriter(sfd.FileName))
            {
                foreach (User user in users)
                {
                    sw.WriteLine(user.FullName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User user = (User)listBox1.SelectedItem;
            users.Remove(user);
        }
    }
}
