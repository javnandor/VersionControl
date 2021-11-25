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
            //lblLastName.Text = ResourceFile.LastName;
            //lblFirstName.Text = ResourceFile.FirstName;
            lblFullName.Text = ResourceFile.FullName;
            btnAdd.Text = ResourceFile.Add;
            btnExport.Text = ResourceFile.Export;

            listUser.DataSource = users;
            listUser.ValueMember = "ID";
            listUser.DisplayMember = "FullName";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User u = new User();
            //u.LastName = txtLastName.Text;
            //u.FirstName = txtFirstName.Text;
            u.FullName = txtFullName.Text;
            users.Add(u);

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    foreach (User item in users)
                    {
                        sw.WriteLine(item.ID + ";" + item.FullName);
                    }
            }
        }
    }
}
