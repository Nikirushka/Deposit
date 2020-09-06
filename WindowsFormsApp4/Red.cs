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
    public partial class Red : Form
    {
        SqlConnection connection;
        SqlCommand cmd;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|VkladDB.mdf';Integrated Security=True;Connect Timeout=30";
        int ID;
        string nazv, valut,   procc, sposobb, capitt;
        DateTime data1,data2;


        double summa;
        public Red(int a,string b,string c,double d, DateTime e, DateTime f,string g, string h,string i)
        {
            InitializeComponent();
            ID = a;
            nazv = b;
            valut = c;

            summa = d;
            data1 = e;
            data2 = f;
            procc = g;
            sposobb = h;
            capitt = i;
        }
        private void Red_Load(object sender, EventArgs e)
        {

            button2.Hide();
            textBox3.Text = nazv;
            comboBox1.Text = valut;
            textBox1.Text = Convert.ToString(summa);
            dateTimePicker1.Value = data1;
            dateTimePicker2.Value = data2;
            textBox2.Text = procc;
            comboBox2.Text = sposobb;
           if(capitt=="Да")
            {
                checkBox1.Checked = true;
            }
           else
            {
                checkBox1.Checked = false;
            }

           
        }
        double result;
        int sposob;
        double money;
        int days;
        double proc;
        string choice = "", namevklad;
        double RUB = 0.032, USD = 2.58, EUR = 2.76, GBP = 2.99, CHF = 2.61, CNY = 0.36, UAH = 0.094, JPY = 0.023;

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.off1;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.off2;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point lastpoint;
        private void Red_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void Red_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
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

                string editQuery = $"UPDATE [Vklad] SET [Название Вклада] = N'{textBox3.Text}' , [Валюта вложения] = N'{choice}',[Сумма]={textBox1.Text},[Дата начала]=N'{dateTimePicker1.Value}',[Дата конца] =N'{dateTimePicker2.Value}',[Банковский процент]=N'{textBox2.Text}',[Способ начисления]=N'{sposob2}',[Капитализация]=N'{capit}',[Итог]=N'{money.ToString("F" + 2)}' WHERE Id = '{ID}'";

                cmd = new SqlCommand(editQuery, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

                this.Close();
            }
        }
        string capit;
        string sposob2;
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
            sposob2 = comboBox2.Text;

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
                label10.Text = "Итог : С капитализацей за " + days + " дней" + " вы получите : " + money.ToString("F" + 2) + " " + choice;
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
                label10.Text = "Итог : Без капитализации за " + days + " дней" + " вы получите : " + money.ToString("F" + 2) + " " + choice;

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
    }
}
