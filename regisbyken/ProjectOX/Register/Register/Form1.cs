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
                user.Username = boxusername.Text;
                user.Password = boxpassword.Text;
                user.User = boxname.Text;
                /*user.picture = null;
                user.win = "0";
                user.draw = "0";
                user.lose = "0";*/
                symbolcollection.Insert(user);
                MessageBox.Show("เพิ่มข้อมูลเรียบร้อย");
            }
        }
        public class Usermain
        {
            public ObjectId _id { get; set; }
            public string User
            {
                get; set;
            }
            public string Username
            {
                get; set;
            }
            public string Password
            {
                get; set;
            }
            public string picture
            {
                get; set;
            }
            public string win
            {
                get; set;
            }
            public string draw
            {
                get; set;
            }
            public string lose
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
    }
   
}

