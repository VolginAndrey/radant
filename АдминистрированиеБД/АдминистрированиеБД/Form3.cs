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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(DataSourseString.getString());
            sqlConnection.Open();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlCommand sqlCommand = new SqlCommand("update [Emploer] set [password_emploer]='"+textBox1.Text+ "',[LastName_emploer] = '" + textBox2.Text + "'  where ID_Emploer =" + User.ID_user + ";", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                this.Hide();
                new Form1().Show();
            }
            else
            {
                MessageBox.Show("Заполните данные");
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(DataSourseString.getString());
            sqlConnection.Open();
            SqlCommand comand = new SqlCommand("select * from [Emploer] where ID_Emploer =" + User.ID_user+";" , sqlConnection);
            SqlDataReader reader;
            reader = comand.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader["password_emploer"].ToString();
                textBox2.Text =  reader["LastName_emploer"].ToString();
            }
            else
            {
                MessageBox.Show("Текущго пользователя не существует");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
