using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class LogIn : Form

    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string name, surname, phone, email;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|VkladDB.mdf';Integrated Security=True;Connect Timeout=30";

        
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            textBox2.TabStop = false;
            textBox3.TabStop = false;
        }
        Point lastpoint;
        private void LogIn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
        private void LogIn_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string LoginTB, PasswordTB;
            LoginTB = textBox2.Text;
            PasswordTB = textBox3.Text;
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"SELECT * FROM [Users] WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS)";
            cmd = new SqlCommand(query, connection);
            reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                MessageBox.Show("Wrong Login", "Error");
                reader.Close();
                return;
            }
            else
            {
                reader.Close();
                query = $"SELECT * FROM Users WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{PasswordTB}' COLLATE CYRILLIC_General_CS_AS) ";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    MessageBox.Show("Wrong Password", "Error");
                    return;
                }
                else
                {
                    this.Hide();
                    reader.Close();
                    query = $"SELECT * FROM Users WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS) AND (Password= '{PasswordTB}' COLLATE CYRILLIC_General_CS_AS) AND Access=0";
                    cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        MainMenuForAdmin mainMenuForAdmin = new MainMenuForAdmin(LoginTB);
                        DialogResult dialogResult = new DialogResult();
                        dialogResult = mainMenuForAdmin.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Show();
                        }
                        else
                        {
                            connection.Close();
                            this.Close();
                        }

                    }
                    else
                    {
                        reader.Close();
                        query = $"SELECT * FROM Users WHERE Login=N'{LoginTB}' AND Password= '{PasswordTB}'";
                        cmd = new SqlCommand(query, connection);
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                name = reader[4].ToString();
                                surname = reader[5].ToString();
                                phone = reader[6].ToString();
                                email = reader[7].ToString();
                            }
                        }
                        reader.Close();
                        DialogResult dialogResult2 = new DialogResult();
                        MainMenuForUser mainMenuForUser = new MainMenuForUser(LoginTB, name, surname, phone, email);
                        dialogResult2 = mainMenuForUser.ShowDialog();
                        if (dialogResult2 == DialogResult.OK)
                        {
                            this.Show();
                        }
                        else
                        {
                            connection.Close();
                            this.Close();
                        }
                    }
                }
            }
        }

        

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.TabStop = true;
            textBox3.TabStop = true;
            textBox2.Clear();
            pictureBox2.Image = Properties.Resources.user;
            panel1.BackColor = Color.FromArgb(36, 110, 160);
            textBox2.ForeColor = Color.FromArgb(36, 110, 160);

            pictureBox1.Image = Properties.Resources.iconfinder_icon_114_lock_314692;
            panel2.BackColor = Color.White;
            textBox3.ForeColor = Color.White;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.PasswordChar = '*';
            pictureBox2.Image = Properties.Resources.iconfinder_00_ELASTOFONT_STORE_READY_user_2703063;
            panel1.BackColor = Color.White;
            textBox2.ForeColor = Color.White;

            pictureBox1.Image = Properties.Resources.login;
            panel2.BackColor = Color.FromArgb(36, 110, 160);
            textBox3.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.PasswordChar = '*';
            pictureBox2.Image = Properties.Resources.iconfinder_00_ELASTOFONT_STORE_READY_user_2703063;
            panel1.BackColor = Color.White;
            textBox2.ForeColor = Color.White;

            pictureBox1.Image = Properties.Resources.login;
            panel2.BackColor = Color.FromArgb(36, 110, 160);
            textBox3.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.TabStop = true;

            textBox3.TabStop = true;

            textBox2.Clear();
            pictureBox2.Image = Properties.Resources.user;
            panel1.BackColor = Color.FromArgb(36, 110, 160);
            textBox2.ForeColor = Color.FromArgb(36, 110, 160);

            pictureBox1.Image = Properties.Resources.iconfinder_icon_114_lock_314692;
            panel2.BackColor = Color.White;
            textBox3.ForeColor = Color.White;
        }

        private void button1_Enter(object sender, EventArgs e)
        {

            pictureBox2.Image = Properties.Resources.iconfinder_00_ELASTOFONT_STORE_READY_user_2703063;
            panel1.BackColor = Color.White;
            textBox2.ForeColor = Color.White;

            pictureBox1.Image = Properties.Resources.iconfinder_icon_114_lock_314692;
            panel2.BackColor = Color.White;
            textBox3.ForeColor = Color.White;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.off2;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.off1;
        }
    }
}
