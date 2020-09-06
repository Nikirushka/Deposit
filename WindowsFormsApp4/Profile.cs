using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Profile : Form
    {
        SqlConnection connection;
        SqlCommand cmd;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|VkladDB.mdf';Integrated Security=True;Connect Timeout=30";

        string UserLogin, name,surname,phone,email;
        public Profile()
        {
            InitializeComponent();
        }
        public Profile(string a,string b,string c,string d, string e)
        {
            InitializeComponent();
            UserLogin = a;
            name = b;
            surname = c;
            phone = d;
            email = e;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            label2.Text = $"Профиль : {UserLogin}";
            textBox2.Text = name;
            textBox3.Text = surname;
            textBox4.Text = phone;
            textBox5.Text = email;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.off2;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.off1;
        }
        Point lastpoint;

        private void Profile_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void Profile_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string editQuery = $"UPDATE [USERS] SET Name=N'{textBox2.Text}', Surname=N'{textBox3.Text}', Phone =N'{textBox4.Text}', Email=N'{textBox5.Text}'";

            cmd = new SqlCommand(editQuery, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
