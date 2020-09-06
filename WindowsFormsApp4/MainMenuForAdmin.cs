using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class MainMenuForAdmin : Form
    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|VkladDB.mdf';Integrated Security=True;Connect Timeout=30";

        string NameAdmin;
        public MainMenuForAdmin()
        {
            InitializeComponent();
        }
        public MainMenuForAdmin(string a)
        {
            InitializeComponent();
            NameAdmin = a;
        }
        Point lastpoint;
        private void MainMenuForAdmin_Load(object sender, EventArgs e)
        {
            panel7.Hide();
            panel6.Hide();
            panel8.Hide();
            panel4.Hide();
            this.Text = $"Добро пожаловать, {NameAdmin}";
            ConnectBD1();
            ConnectBD();
        }
        public void ConnectBD()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Vklad]";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int rows = dataGridView2.Rows.Add();

                    dataGridView2.Rows[rows].Cells[0].Value = reader[0];
                    dataGridView2.Rows[rows].Cells[1].Value = reader[1];
                    dataGridView2.Rows[rows].Cells[2].Value = reader[2];
                    dataGridView2.Rows[rows].Cells[3].Value = reader[3];
                    dataGridView2.Rows[rows].Cells[4].Value = reader[4];
                    dataGridView2.Rows[rows].Cells[5].Value = reader[5];
                    dataGridView2.Rows[rows].Cells[6].Value = reader[6];
                    dataGridView2.Rows[rows].Cells[7].Value = reader[7];
                    dataGridView2.Rows[rows].Cells[8].Value = reader[8];
                    dataGridView2.Rows[rows].Cells[9].Value = reader[9];
                    dataGridView2.Rows[rows].Cells[10].Value = reader[10];
                }
            }
            reader.Close();
        }
        public void ConnectBD1()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM [Users]";
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
                }
            }
            reader.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.users2;
            label1.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.users2;
            label1.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.users1;
            label1.ForeColor = Color.White;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.users1;
            label1.ForeColor = Color.White;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.inputs2;
            label2.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.inputs2;
            label2.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.inputs1;
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.inputs1;
            label2.ForeColor = Color.White;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            panel4.Show();
            panel5.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel4.Show();
            panel5.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel5.Show();
            panel4.Hide();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel5.Show();
            panel4.Hide();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.help2;
            label4.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.help1;
            label4.ForeColor = Color.White;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HELP hELP = new HELP();
            hELP.ShowDialog();
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

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.info1;
            label5.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.info1;
            label5.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddForADm addForADm = new AddForADm();
            addForADm.ShowDialog();
            this.Show();
            dataGridView2.Rows.Clear();
            ConnectBD();
        }

        private void MainMenuForAdmin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void MainMenuForAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button8.Hide();
            button7.Show();
            panel8.Show();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            pictureBox5.Image = Properties.Resources.user;
            panel10.BackColor = Color.FromArgb(36, 110, 160);
            textBox2.ForeColor = Color.FromArgb(36, 110, 160);

            pictureBox6.Image = Properties.Resources.iconfinder_icon_114_lock_314692;
            panel9.BackColor = Color.White;
            textBox3.ForeColor = Color.White;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
            textBox3.Clear();
            pictureBox5.Image = Properties.Resources.iconfinder_00_ELASTOFONT_STORE_READY_user_2703063;
            panel10.BackColor = Color.White;
            textBox2.ForeColor = Color.White;

            pictureBox6.Image = Properties.Resources.login;
            panel9.BackColor = Color.FromArgb(36, 110, 160);
            textBox3.ForeColor = Color.FromArgb(36, 110, 160);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string check = $"SELECT * FROM Users where Login=N'{textBox2.Text}' AND Password=N'{textBox3.Text}'";
            cmd = new SqlCommand(check,connection);
            reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                reader.Close();
                MessageBox.Show("Such user exists", "Error");
                return;
            }
            else
            {
                reader.Close();
                string add = $"INSERT INTO Users VALUES(N'{textBox2.Text}',N'{textBox3.Text}',0,NULL,NULL,NULL,NULL)";
                cmd = new SqlCommand(add, connection);
                reader = cmd.ExecuteReader();
                
            }
            panel8.Hide();
            textBox2.Clear();
            textBox3.Clear();
            dataGridView1.Rows.Clear();
            ConnectBD1();

        }
        int idred;
        private void button5_Click(object sender, EventArgs e)
        {
            button7.Hide();
            button8.Show();
            panel8.Show();
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            idred = Convert.ToInt32(dataGridView1[0, index].Value);
            string Login = Convert.ToString(dataGridView1[1, index].Value);
            string Password = Convert.ToString(dataGridView1[2, index].Value);
            string Access = Convert.ToString(dataGridView1[3, index].Value);
            textBox2.Text = Login;
            textBox3.Text = Password;
            
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string check = $"DELETE FROM Users where Login=N'{textBox2.Text}'";
            cmd = new SqlCommand(check, connection);
            cmd.ExecuteNonQuery();
            check = $"SELECT * FROM Users where Login=N'{textBox2.Text}'";
            cmd = new SqlCommand(check, connection);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                MessageBox.Show("Such user exists", "Error");
                return;
            }
            else
            {
                reader.Close();
                string add = $"INSERT INTO Users VALUES( N'{textBox2.Text}',N'{textBox3.Text}',0)";
                cmd = new SqlCommand(add, connection);
                cmd.ExecuteNonQuery();
            }
            panel8.Hide();
            textBox2.Clear();
            textBox3.Clear();
            connection.Close();
            dataGridView1.Rows.Clear();
            ConnectBD1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            int ID = Convert.ToInt32(dataGridView1[0, index].Value);

            string delQuery = $"DELETE FROM [Users] WHERE Id = '{ID}'";

            cmd = new SqlCommand(delQuery, connection);
            cmd.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            ConnectBD1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView2.SelectedCells)
            {
                index = cell.RowIndex;
            }
            int ID = Convert.ToInt32(dataGridView2[0, index].Value);

            string delQuery = $"DELETE FROM [Vklad] WHERE Id = '{ID}'";

            cmd = new SqlCommand(delQuery, connection);
            cmd.ExecuteNonQuery();
            dataGridView2.Rows.Clear();
            ConnectBD();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView2.SelectedCells)
            {
                index = cell.RowIndex;
            }
            int ID = Convert.ToInt32(dataGridView2[0, index].Value);
            string nazv = Convert.ToString(dataGridView2[1, index].Value);
            string valut = Convert.ToString(dataGridView2[2, index].Value);
            double summa = Convert.ToDouble(dataGridView2[3, index].Value);
            DateTime data1 = Convert.ToDateTime(dataGridView2[4, index].Value);
            DateTime data2 = Convert.ToDateTime(dataGridView2[5, index].Value);
            string proc = Convert.ToString(dataGridView2[6, index].Value);
            string sposob = Convert.ToString(dataGridView2[7, index].Value);
            string capit = Convert.ToString(dataGridView2[8, index].Value);
            this.Hide();
            Red Red = new Red(ID, nazv, valut, summa, data1, data2, proc, sposob, capit);
            Red.ShowDialog();
            this.Show();
            dataGridView2.Rows.Clear();
            ConnectBD();
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

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.Image = Properties.Resources.exit2;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Image = Properties.Resources.exit1;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel6.Show();
        }
        string save_text;
        private void button13_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM USERS";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 1;
                while (reader.Read())
                {
                    save_text += $"{i}.Пользователь :\n Логин : {reader[1]}\n Пароль : {reader[2]}\n Доступ : {reader[3]}\n";
                    i++;
                }
            }
            reader.Close();
            connection.Close();
            File.Delete("USERS.txt");
            File.WriteAllText("USERS.txt", save_text);
            panel1.Hide();
            MessageBox.Show("Успешно сохранено", "Готово");
            save_text = "";

            panel6.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM USERS";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 1;
                while (reader.Read())
                {
                    save_text += $"{i}.Пользователь :\n Логин : {reader[1]}\n Пароль : {reader[2]}\n Доступ : {reader[3]}\n"; 
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
            MessageBox.Show("Успешно сохранено", "Готово");
            save_text = "";

            panel6.Hide();
        }
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(save_text, new Font("Arial", 14), Brushes.Black, 0, 0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM USERS";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 1;
                while (reader.Read())
                {
                    save_text += $"{i}.Пользователь :\n Логин : {reader[1]}\n Пароль : {reader[2]}\n Доступ : {reader[3]}\n"; 
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
            MessageBox.Show("Успешно сохранено", "Готово");
            save_text = "";
            panel6.Hide();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel7.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM VKLAD";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 1;
                while (reader.Read())
                {
                    save_text += $"{i}.Вклад :\n Название вклада : {reader[1]}\n Валюта вложения : {reader[2]}\n Сумма : {reader[3]}\n Дата начала : {reader[4]}\n Дата конца : {reader[5]}\n Банковский процент : {reader[6]}\n Способ начисления : {reader[7]}\n Капитализация : {reader[8]}\n Итог : {reader[9]}\n Владелец : {reader[10]}\n";
                    i++;
                }
            }
            reader.Close();
            connection.Close();
            File.Delete("ALLVKLADS.txt");
            File.WriteAllText("ALLVKLADS.txt", save_text);
            MessageBox.Show("Успешно сохранено", "Готово");
            save_text = "";
            panel7.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM VKLAD";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 1;
                while (reader.Read())
                {
                    save_text += $"{i}.Вклад :\n Название вклада : {reader[1]}\n Валюта вложения : {reader[2]}\n Сумма : {reader[3]}\n Дата начала : {reader[4]}\n Дата конца : {reader[5]}\n Банковский процент : {reader[6]}\n Способ начисления : {reader[7]}\n Капитализация : {reader[8]}\n Итог : {reader[9]}\n Владелец : {reader[10]}\n";
                    i++;
                }
            }
            reader.Close();
            connection.Close();

            MailAddress fromMailAddress = new MailAddress("nikirushka@yandex.ru", "AutoSave");
            MailAddress toAddress = new MailAddress(textBox4.Text);

            MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress);
            mailMessage.Subject = "AutoReport";
            mailMessage.Body = save_text;
            SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru", 587);
            smtpClient.Credentials = new NetworkCredential("nikirushka@yandex.ru", "T49BtPV_");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            MessageBox.Show("Успешно сохранено", "Готово");
            save_text = "";
            panel7.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            string query = $"SELECT * FROM VKLAD";
            cmd = new SqlCommand(query, connection);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 1;
                while (reader.Read())
                {
                    save_text += $"{i}.Вклад :\n Название вклада : {reader[1]}\n Валюта вложения : {reader[2]}\n Сумма : {reader[3]}\n Дата начала : {reader[4]}\n Дата конца : {reader[5]}\n Банковский процент : {reader[6]}\n Способ начисления : {reader[7]}\n Капитализация : {reader[8]}\n Итог : {reader[9]}\n Владелец : {reader[10]}\n";
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
            MessageBox.Show("Успешно сохранено", "Готово");
            save_text = "";

            panel7.Hide();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }
    }
}
