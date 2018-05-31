using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace АдминистрированиеБД
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection sqlConnection = new SqlConnection(DataSourseString.getString());
            SqlDataReader reader;
            
            try
            { 
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand("select * from [Emploer] where [Name_emploer] = '"+textBox1.Text+"';", sqlConnection);
                reader = comand.ExecuteReader();
                if (textBox1.Text !="" && textBox2.Text!="")
                {
                    if (reader.Read())
                    {

                        String pas = reader["password_emploer"].ToString();
                        User.ID_user = Convert.ToInt32(reader["ID_Emploer"].ToString());
                        if (pas == textBox2.Text)
                        {
                            User.role = Convert.ToInt32(reader["role_emploer"]);
                            if (User.role == 1)
                            {
                                this.Hide();
                                new Form2().Show();
                            }
                            else
                            {
                                int block = Convert.ToInt32(reader["block_"].ToString());
                                if (block == 0)
                                {
                                    DateTime dateIn = Convert.ToDateTime(reader["date_in_System"]);
                                    DateTime dateOut = Convert.ToDateTime(reader["date_out_System"]);
                                    if (DateTime.Now.CompareTo(dateIn) >= 0 && DateTime.Now.CompareTo(dateOut) <= 0)
                                    {
                                        
                                        if ((Convert.ToInt32(DateTime.Now.Day)%2==0 && User.ID_user%2==0)|| (Convert.ToInt32(DateTime.Now.Day)% 2 == 1 && User.ID_user % 2 == 1))
                                        {
                                            this.Hide();
                                            new Form3().Show();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error", "Сегодня вы не можете войти");
                                        }
                                        
                                    }
                                    else
                                    {
                                        if (DateTime.Now.CompareTo(dateIn) < 0)
                                        {
                                            MessageBox.Show("Error", "Аккаунт еще не доступен");
                                        }
                                        else
                                        {
                                            reader.Close();
                                            SqlCommand sqlCommand = new SqlCommand("update [Emploer] set [block_]=1 where ID_Emploer =" + User.ID_user + ";", sqlConnection);
                                            sqlCommand.ExecuteNonQuery();
                                            MessageBox.Show("Error", "Время действия аккаунта истекло");
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Пользователь заблокирован");
                                }
                            }
                        }
                        else
                        {
                            SqlCommand sqlCommand;
                            int count = Convert.ToInt32(reader["count"].ToString());
                            if (count == 2)
                            {
                                sqlCommand = new SqlCommand("update [Emploer] set [block_]=1 where ID_Emploer =" + User.ID_user+";", sqlConnection);
                            }
                            else
                            {
                                count++;
                                sqlCommand = new SqlCommand("update [Emploer] set [count]=" + count + " where ID_Emploer =" + User.ID_user + ";", sqlConnection);

                            }
                            reader.Close();
                            //DataReader.Close();
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Неверный пароль");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Текущего пользователя не существует");
                    }
                }else
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
    }
}
