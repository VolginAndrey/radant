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

namespace АдминистрированиеБД
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(DataSourseString.getString());
            try
            {
                sqlConnection.Open();
                if (textBox2.Text != ""&& textBox3.Text != ""&& textBox4.Text != "")
                {
                    
                    DateTime date1 = DateTime.Now;
                    DateTime date2 = date1.AddDays(Convert.ToInt32(textBox4.Text)); 
                    String date1s = "";
                    String date2s = "";
                    date1s += date1.Year + "-0" + date1.Month + "-" + date1.Day + "T00:00:00.000"; 
                    date2s += date2.Year + "-0" + date2.Month + "-0" + date2.Day + "T00:00:00.000";
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO [Emploer] (Name_emploer, password_emploer, role_emploer, date_in_System,date_out_System,block_,[count]) VALUES ('" + textBox2.Text+"','"+ textBox3.Text+"', 0,'"+ date1s + "','"+ date2s+"',0,0)",  sqlConnection);
                    sqlCommand.ExecuteReader();
                    this.Hide();
                    new Form1().Show();
                }
                else
                {
                    MessageBox.Show("Заполните данные");
                }

                sqlConnection.Close();
            }
            catch (SqlException err)
            {
                Console.WriteLine(err.ToString(), "Error");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(DataSourseString.getString());
            SqlDataReader reader;
            try
            {
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand("select * from [Emploer] where [Name_emploer] = '" + textBox1.Text + "'", sqlConnection);
                reader = comand.ExecuteReader();
                if (textBox1.Text != "")
                {
                    if (reader.Read())
                    {
                        reader.Close();
                           SqlCommand sqlCommand = new SqlCommand("update [Emploer] set [block_]=0, count=0 where [Name_emploer] = '" + textBox1.Text + "'", sqlConnection);
                        sqlCommand.ExecuteReader();
                        this.Hide();
                        new Form1().Show();
                    }
                    else
                    {
                        MessageBox.Show("Такого пользователя не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните данные");
                }

                sqlConnection.Close();
            }
            catch (SqlException err)
            {
                Console.WriteLine(err.ToString(), "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }   
}
