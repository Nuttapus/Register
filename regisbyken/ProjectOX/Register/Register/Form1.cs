using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace Register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void okbut_Click(object sender, EventArgs e)
        {
            try
            {
                MongoClient client = new MongoClient("mongodb://admin:a123456@ds141902.mlab.com:41902/ox");
                MongoServer server = client.GetServer();
                MongoDatabase database = server.GetDatabase("ox");
                MongoCollection symbolcollection = database.GetCollection<Usermain>("User");
                Usermain user = new Usermain();
                BindingList<Usermain> doclist = new BindingList<Usermain>();
                var pd = database.GetCollection<Usermain>("User");
                var pd1 = pd.AsQueryable().Where(pd01 => pd01.Username == boxusername.Text);
                foreach (var p in pd1)
                {
                    doclist.Add(p);
                    Application.DoEvents();
                }
                dataGridView1.DataSource = doclist;
                if (dataGridView1.Rows.Count == 0)
                {
                    if (!string.IsNullOrEmpty(boxusername.Text.Trim()))
                    {
                        user.Username = boxusername.Text;
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่ข้อมูลUsername");
                    }

                    if (!string.IsNullOrEmpty(boxpassword.Text.Trim()))
                    {
                        user.Password = boxpassword.Text;
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่ข้อมูลPassword");
                    }
                    if (!string.IsNullOrEmpty(boxname.Text.Trim()))
                    {
                        user.Name = boxname.Text;
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่ข้อมูลName");
                    }
                    user.Avatar = null;
                    user.Win = 0;
                    user.Draw = 0;
                    user.Lose = 0;
                    if (!string.IsNullOrEmpty(boxusername.Text.Trim()) && !string.IsNullOrEmpty(boxpassword.Text.Trim()) && !string.IsNullOrEmpty(boxname.Text.Trim()))
                    {
                        symbolcollection.Insert(user);
                        MessageBox.Show("เพิ่มข้อมูลเรียบร้อย");
                    }
                    else
                    {
                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ถูกต้อง");
            }
        }
        public class Usermain
        {
            public ObjectId _id { get; set; }
            public string Username
            {
                get; set;
            }
            public string Name
            {
                get; set;
            }
            public string Password
            {
                get; set;
            }
            public string Avatar
            {
                get; set;
            }
            public int Win
            {
                get; set;
            }
            public int Draw
            {
                get; set;
            }
            public int Lose
            {
                get; set;
            }
        }

        private void cancelbut_Click(object sender, EventArgs e)
        {
            boxusername.Text = string.Empty;
            boxpassword.Text = string.Empty;
            boxname.Text = string.Empty;
        }

        private void boxusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
   
}

