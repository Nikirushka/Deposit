using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class MainMenuForUser : Form
    {
        string NameUser="",name,surname,phone,email;
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|VkladDB.mdf';Integrated Security=True;Connect Timeout=30";
        string save_text;
        public void ConnectBD()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Vklad] where UserID=N'{NameUser}'";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int rows = dataGridView1.Rows.Add();

                    dataGridView1.Rows[rows].Cells[0].Value = reader[0];
                    dataGridView1.Rows[rows].Cells[1].Value = reader[1];
                    dataGridView1.Rows[rows].Cells[2].Value = reader[2];
                    dataGridView1.Rows[rows].Cells[3].Value = reader[3];
                    dataGridView1.Rows[rows].Cells[4].Value = reader[4];
                    dataGridView1.Rows[rows].Cells[5].Value = reader[5];
                    dataGridView1.Rows[rows].Cells[6].Value = reader[6];
                    dataGridView1.Rows[rows].Cells[7].Value = reader[7];
                    dataGridView1.Rows[rows].Cells[8].Value = reader[8];
                    dataGridView1.Rows[rows].Cells[9].Value = reader[9];
                    dataGridView1.Rows[rows].Cells[10].Value = reader[10];
                }
            }
            reader.Close();
        }
        public MainMenuForUser()
        {
            InitializeComponent();
        }
        public MainMenuForUser(string a,string b,string c, string d, string e)
        {
            InitializeComponent();
            NameUser = a;
            name = b;
            surname = c;
            phone = d;
            email =e;
        }
        Point lastpoint;
        private void MainMenuForUser_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            this.Text = $"Welcome, {NameUser}";
            label2.Text = $"Profile {NameUser}";
            ConnectBD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddInput form = new AddInput(NameUser);
            form.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            ConnectBD();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            int ID = Convert.ToInt32(dataGridView1[0, index].Value);
            string nazv=Convert.ToString(dataGridView1[1, index].Value);
            string valut = Convert.ToString(dataGridView1[2, index].Value);
            double summa = Convert.ToDouble(dataGridView1[3, index].Value);
            DateTime data1 = Convert.ToDateTime(dataGridView1[4, index].Value);
            DateTime data2 = Convert.ToDateTime(dataGridView1[5, index].Value);
            string proc = Convert.ToString(dataGridView1[6, index].Value);
            string sposob = Convert.ToString(dataGridView1[7, index].Value);
            string capit = Convert.ToString(dataGridView1[8, index].Value);
            this.Hide();
            Red Red = new Red(ID,nazv,valut,summa,data1,data2,proc,sposob,capit);
            Red.ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            ConnectBD();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            int ID = Convert.ToInt32(dataGridView1[0, index].Value);

            string delQuery = $"DELETE FROM [Vklad] WHERE Id = '{ID}'";

            cmd = new SqlCommand(delQuery, connection);
            cmd.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            ConnectBD();
        }

        private void MainMenuForUser_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void MainMenuForUser_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HELP hELP = new HELP();
            hELP.ShowDialog();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.help2;
            label4.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.help1;
            label4.ForeColor = Color.White;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.help2;
            label4.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.help1;
            label4.ForeColor = Color.White;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.info2;
            label5.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.info2;
            label5.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.info1;
            label5.ForeColor = Color.White;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.info1;
            label5.ForeColor = Color.White;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            INFO iNFO = new INFO();
            iNFO.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            INFO iNFO = new INFO();
            iNFO.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HELP hELP = new HELP();
            hELP.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.profile2;
            label2.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.profile1;
            label2.ForeColor = Color.White;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.exit2;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.exit1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Vklad] WHERE USERID='{NameUser}'";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 1;
                while (reader.Read())
                {
                    save_text += $"{i}.Вклад :\n Название вклада : {reader[1]}\n Валюта вложения : {reader[2]}\n Сумма : {reader[3]}\n Дата начала : {reader[4]}\n Дата конца : {reader[5]}\n Банковский процент : {reader[6]}\n Способ начисления : {reader[7]}\n Капитализация : {reader[8]}\n Итог : {reader[9]}\n";
                    i++;
                }
            }
            reader.Close();
            connection.Close();
            File.Delete("VKLAD.txt");
            File.WriteAllText("VKLAD.txt", save_text);
            panel1.Hide();
            MessageBox.Show("Успешно сохранено","Готово");
            save_text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Vklad] WHERE USERID='{NameUser}'";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 1;
                while (reader.Read())
                {
                    save_text += $"{i}.Вклад :\n Название вклада : {reader[1]}\n Валюта вложения : {reader[2]}\n Сумма : {reader[3]}\n Дата начала : {reader[4]}\n Дата конца : {reader[5]}\n Банковский процент : {reader[6]}\n Способ начисления : {reader[7]}\n Капитализация : {reader[8]}\n Итог : {reader[9]}\n";
                    i++;
                }
            }
            reader.Close();
            connection.Close();
            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += PrintPageHandler;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
                printDocument.Print();
            panel1.Hide();
            MessageBox.Show("Успешно сохранено", "Готово");
            save_text = "";
        }

        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(save_text, new Font("Arial", 14), Brushes.Black, 0, 0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.off2;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.off1;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Vklad] WHERE USERID='{NameUser}'";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 1;
                while (reader.Read())
                {
                    save_text += $"{i}.Вклад :\n Название вклада : {reader[1]}\n Валюта вложения : {reader[2]}\n Сумма : {reader[3]}\n Дата начала : {reader[4]}\n Дата конца : {reader[5]}\n Банковский процент : {reader[6]}\n Способ начисления : {reader[7]}\n Капитализация : {reader[8]}\n Итог : {reader[9]}\n";
                    i++;
                }
            }
            reader.Close();
            connection.Close();

            MailAddress fromMailAddress = new MailAddress("nikirushka@yandex.ru", "AutoSave");
            MailAddress toAddress = new MailAddress(textBox1.Text);

            MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress);
            mailMessage.Subject = "AutoReport";
            mailMessage.Body = save_text;
            SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru", 587);
            smtpClient.Credentials = new NetworkCredential("nikirushka@yandex.ru", "T49BtPV_");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            panel1.Hide();
            MessageBox.Show("Успешно сохранено", "Готово");
            save_text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(NameUser,name,surname,phone,email);
            this.Hide();
            profile.ShowDialog();
            this.Show();
            ConnectBD2();
        }
        public void ConnectBD2()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [USERS] where Login=N'{NameUser}'";
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
        }
    }
}
