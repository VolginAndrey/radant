using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace goodfast
{
    public partial class substitution : Form
    {
        public substitution()
        {
            InitializeComponent();
        }
        public static bool check(String Alf1, String Alf2,String st)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < Alf1.Length; i++)
            {
                if (dic.ContainsKey(Alf1[i]))
                {
                    MessageBox.Show("В верхнем алфавите недопустимое значение \nЭлементы алфавита не должны повторяться", "Ошибка", MessageBoxButtons.OK);
                    return false;
                }
                else
                    dic.Add(Alf1[i], 1);
            }
            Dictionary<char, int> dic2 = new Dictionary<char, int>();
            for (int i = 0; i < Alf2.Length; i++)
            {
                if (dic2.ContainsKey(Alf2[i]))
                {
                    MessageBox.Show("В нижнем алфавите недопустимое значение \nЭлементы алфавита не должны повторяться", "Ошибка", MessageBoxButtons.OK);
                    return false;
                }
                else
                    dic2.Add(Alf2[i], 1);
            }
            if (Alf1.Length != Alf2.Length)
            {
                MessageBox.Show("Поля алфавита содержат разную длинну", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            //for (int i = 0; i < Alf2.Length; i++)
            //{
            //    if (dic.ContainsKey(Alf2[i]))
            //    {
            //        MessageBox.Show("Поля алфавита имеют одинаковое значение", "Ошибка", MessageBoxButtons.OK);
            //        return false;
            //    }
            //    if (dic2.ContainsKey(Alf1[i]))
            //    {
            //        MessageBox.Show("Поля алфавита имеют одинаковое значение", "Ошибка", MessageBoxButtons.OK);
            //        return false;
            //    }
            //}
            //for (int i = 0; i < st.Length; i++)
            //{
            //    if ((dic2.ContainsKey(st[i]) == false) && (dic.ContainsKey(st[i]) == false))
            //    {
            //        MessageBox.Show("В тексте есть элемент не использующийся в алфавите", "Ошибка", MessageBoxButtons.OK);
            //        return false;
            //    }
            //}
            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form ifrm = new Menu();
            ifrm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Alf1, Alf2, st;
            Alf1 = textBox1.Text.ToString();
            Alf2 = textBox2.Text.ToString();
            st = textBox3.Text.ToString();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите верхний алфавит", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите нижний алфавит", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (check(Alf1, Alf2,st) == false)
            {
                return;
            }

            Dictionary<char, char> dic = new Dictionary<char, char>();
            for (int i = 0; i < Alf1.Length; i++)
            {
                dic.Add(Alf1[i], Alf2[i]);
                //dic.Add(Alf2[i], Alf1[i]);
            }
            String result = "";
            for (int i = 0; i < st.Length; i++)
            {
                if (dic.ContainsKey(st[i]))
                {
                    result += dic[st[i]];
                }
                else
                {
                    result += st[i];
                }
            }
            textBox4.Text = result;

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = File.AppendText(desktop + "\\text.txt");
            sw.WriteLine(result);
            sw.Close();

        }
    


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Alf1, Alf2, st;
            Alf1 = textBox1.Text.ToString();
            Alf2 = textBox2.Text.ToString();
            st = textBox3.Text.ToString();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите верхний алфавит", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите нижний алфавит", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (check(Alf1, Alf2, st) == false)
            {
                return;
            }

            Dictionary<char, char> dic = new Dictionary<char, char>();
            for (int i = 0; i < Alf1.Length; i++)
            {
                //dic.Add(Alf1[i], Alf2[i]);
                dic.Add(Alf2[i], Alf1[i]);
            }
            String result = "";
            for (int i = 0; i < st.Length; i++)
            {
                if (dic.ContainsKey(st[i]))
                {
                    result += dic[st[i]];
                }
                else
                {
                    result += st[i];
                }
            }
            textBox4.Text = result;

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = File.AppendText(desktop + "\\text.txt");
            sw.WriteLine(result);
            sw.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            int count = System.IO.File.ReadAllLines(desktop + "\\text.txt").Length;
            string s = File.ReadLines(desktop + "\\text.txt").Skip(count - 1).First();
            textBox3.Text = s;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Шифр простой замены, простой подстановочный шифр, моноалфавитный шифр — класс методов шифрования, которые\n сводятся к созданию по определённому алгоритму таблицы шифрования, в которой для каждой буквы открытого текста существует единственная сопоставленная ей буква шифр-текста. Само шифрование заключается в замене букв согласно таблице. Для расшифровки достаточно иметь ту же таблицу, либо знать алгоритм, по которой она генерируется.", "Шифр простой замены", MessageBoxButtons.OK);
        }
    }
}
