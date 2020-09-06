using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class AddForADm : Form
    {
        SqlConnection connection;
        SqlDataReader reader = null;
        SqlCommand cmd;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|VkladDB.mdf';Integrated Security=True;Connect Timeout=30";

        public AddForADm()
        {
            InitializeComponent();
        }

        double result;
        int sposob;
        double money;
        int days;
        double proc;
        string choice = "", namevklad = "";
        double RUB = 0.032, USD = 2.58, EUR = 2.76, GBP = 2.99, CHF = 2.61, CNY = 0.36, UAH = 0.094, JPY = 0.023;

        private void AddForADm_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
        Point lastpoint;

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void AddForADm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void AddForADm_Load(object sender, EventArgs e)
        {
            button2.Hide();
            panel1.Hide();
            ConnectBD1();
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
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Show();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Error");
                return;
            }
            label10.Text = string.Empty;
            TimeSpan time = dateTimePicker2.Value - dateTimePicker1.Value;
            days = time.Days;
            namevklad = textBox3.Text;
            choice = comboBox1.SelectedItem.ToString();
            money = Convert.ToInt32(textBox1.Text);
            proc = Convert.ToDouble(textBox2.Text);
            sposob = comboBox2.SelectedIndex;
            if (sposob == 0)
            {
                raschet(days);
            }
            else if (sposob == 1)
            {
                raschet(days / 7);
            }
            else if (sposob == 2)
            {
                raschet(days / 30);
            }
            else if (sposob == 3)
            {
                raschet(days / 90);
            }
            else if (sposob == 4)
            {
                raschet(days / 180);
            }
            else if (sposob == 5)
            {
                raschet(days / 360);
            }
        }
        string capit;
        public void raschet(int a)
        {
            if (checkBox1.Checked == true)
            {
                capit = "Да";
                for (int i = 0; i < a; i++)
                {
                    result = money * proc / 100;
                    money += result;
                }
                label10.Text = "Итог : С капитализацей за " + days + " дней" + " вы получите : " + money + " " + choice;
            }
            else
            {
                capit = "Нет";
                result = money;
                for (int i = 0; i < a; i++)
                {
                    result += money * proc / 100;
                }
                money = result;
                label10.Text = "Итог : Без капитализации за " + days + " дней" + " вы получите : " + money + " " + choice;

            }
            int choice_valut = comboBox1.SelectedIndex;
            if (choice_valut == 0)
            {
                label12.Text = "Итог в BYN : " + money * RUB + " рублей";
            }
            else if (choice_valut == 1)
            {
                label12.Text = "Итог в BYN : " + money + " рублей";
            }
            else if (choice_valut == 2)
            {
                label12.Text = "Итог в BYN : " + money * USD + " рублей";
            }
            else if (choice_valut == 3)
            {
                label12.Text = "Итог в BYN : " + money * EUR + " рублей";
            }
            else if (choice_valut == 4)
            {
                label12.Text = "Итог в BYN : " + money * GBP + " рублей";
            }
            else if (choice_valut == 5)
            {
                label12.Text = "Итог в BYN : " + money * CHF + " рублей";
            }
            else if (choice_valut == 6)
            {
                label12.Text = "Итог в BYN : " + money * CNY + " рублей";
            }
            else if (choice_valut == 7)
            {
                label12.Text = "Итог в BYN : " + money * UAH + " рублей";
            }
            else if (choice_valut == 8)
            {
                label12.Text = "Итог в BYN : " + money * JPY + " рублей";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Enter text", "Erorr");
            }
            else
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string add = $"INSERT INTO Vklad ([Название Вклада] , [Валюта вложения] ,[Сумма] , [Дата начала]  , [Дата конца]   ,[Банковский процент],[Способ начисления], [Капитализация],[Итог],[UserID]) VALUES(N'{namevklad}', N'{choice}', {textBox1.Text}, N'{dateTimePicker1.Value}', N'{dateTimePicker2.Value}', N'{proc}', N'{comboBox2.Text}', N'{capit}', N'{money.ToString("F" + 2)}', N'{textBox4.Text}'); ";
                cmd = new SqlCommand(add, connection);
                cmd.ExecuteNonQuery();
                this.Close();
            }
        }
    }
}
