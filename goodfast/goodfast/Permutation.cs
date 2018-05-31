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
using System.Collections;

namespace goodfast
{
    public partial class Permutation : Form
    {
        public Permutation()
        {
            InitializeComponent();
        }

        private static ArrayList check(String key)
        {
            ArrayList numbers = new ArrayList();
            int j = 0;
            String number = "";
            //char[] chr = key.toCharArray();
            for (int i = 0; i < key.Length; i++)
            {
                if ((key[i] >= '0' && key[i] <= '9') || (key[i] == ' '))
                {
                    if ((i == key.Length - 1) && (key[i] != ' '))
                    {
                        number += key[i];
                        numbers.Add(Convert.ToInt16(number) - 1);
                    }
                    else if (key[i] >= '0' && key[i] <= '9')
                        number += key[i];
                    if (key[i] == ' ')
                    {
                        numbers.Add(Convert.ToInt16(number) - 1);
                        number = "";
                        j++;
                    }
                    if (i + 1 < key.Length)
                        if ((key[i] == ' ') && (key[i + 1] == ' '))
                        {
                            numbers.Insert(0, -3);
                            return numbers;
                        }
                }
                else
                {
                    numbers.Insert(0, -1);
                    return numbers;
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                int a = 0;
                for (j = 0; j < numbers.Count; j++)
                {
                    if (Convert.ToInt16(numbers[j]) == i)
                        a++;
                }
                if (a != 1)
                {
                    numbers.Insert(0, -2);
                    return numbers;
                }

            }
            return numbers;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form ifrm = new Menu();
            ifrm.Show();
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            String per, st;
            st = textBox4.Text.ToString();
            per = textBox1.Text.ToString();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите перестановку", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            ArrayList numbers = check(per);
            if (Convert.ToInt16(numbers[0]) == -1)
            {
                MessageBox.Show("В поле ВВЕДИТЕ ПЕРЕСТАНОВКУ\nНедопустимый символ", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            if (Convert.ToInt16(numbers[0]) == -2)
            {
                MessageBox.Show("В поле ВВЕДИТЕ ПЕРЕСТАНОВКУ\nНеправильная перестановка", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            if (Convert.ToInt16(numbers[0]) == -3)
            {
                MessageBox.Show("В поле ВВЕДИТЕ ПЕРЕСТАНОВКУ\nБолее одно пробела между символами", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            int l=0,perl;
            perl = per.Length;
            while (l < perl)
            {
                if ((per[l] == '0') || (per[l] == '1') || (per[l] == '2') || (per[l] == '3') || (per[l] == '4') || (per[l] == '5') || (per[l] == '6') || (per[l] == '7') || (per[l] == '8') || (per[l] == '9') || (per[l] == ' '))
                {
                    l++;
                }
                else
                {
                    MessageBox.Show("В поле ВВЕДИТЕ ПЕРЕСТАНОВКУ недопустимое значение \n Допускаются только цифры", "Ошибка", MessageBoxButtons.OK);
                    return;
                }
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            
            
            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    int a = 0;
            //    for (int j = 0; j < numbers.Count; j++)
            //    {
            //        String s = "" + per[j];
            //        int v = Convert.ToInt16(s);
            //        if (v == i + 1)
            //        {
            //            a++;
            //        }
            //    }
            //    if (a != 1)
            //    {
            //        MessageBox.Show("Не корректно введёна перестановка", "Ошибка", MessageBoxButtons.OK);
            //        return;
            //    }
            //}

            int n = numbers.Count, d = st.Length, k = d / n;
            //int[] mas = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    String s = "" + per[i];
            //    int v = Convert.ToInt16(s);
            //    numbers[i] = v - 1;
            //}
            String result = "";
            if (n * k != d)
            {
                k++;
                while (n * k != d)
                {
                    st += " ";
                    d++;
                }
            }
            
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result += st[Convert.ToInt16(numbers[j]) + i * n];
                }
            }
            textBox2.Text = result;
            //return s;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = File.AppendText(desktop + "\\text.txt");
            sw.WriteLine(result);
            sw.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String per, st;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите перестановку", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            int l = 0, perl;
            per = textBox1.Text.ToString();
            perl = per.Length;
            ArrayList numbers = check(per);
            if (Convert.ToInt16(numbers[0]) == -1)
            {
                MessageBox.Show("В поле ВВЕДИТЕ ПЕРЕСТАНОВКУ\nНедопустимый символ", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            if (Convert.ToInt16(numbers[0]) == -2)
            {
                MessageBox.Show("В поле ВВЕДИТЕ ПЕРЕСТАНОВКУ\nНеправильная перестановка", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            if (Convert.ToInt16(numbers[0]) == -3)
            {
                MessageBox.Show("В поле ВВЕДИТЕ ПЕРЕСТАНОВКУ\nБолее одно пробела между символами", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            while (l < perl)
            {
                if ((per[l] == '0') || (per[l] == '1') || (per[l] == '2') || (per[l] == '3') || (per[l] == '4') || (per[l] == '5') || (per[l] == '6') || (per[l] == '7') || (per[l] == '8') || (per[l] == '9') || (per[l] == ' '))
                {
                    l++;
                }
                else
                {
                    MessageBox.Show("В поле ВВЕДИТЕ ПЕРЕСТАНОВКУ недопустимое значение \n Допускаются только цифры", "Ошибка", MessageBoxButtons.OK);
                    return;
                }
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            st = textBox4.Text.ToString();
           
            //for (int i = 0; i < per.Length; i++)
            //{
            //    int a = 0;
            //    for (int j = 0; j < per.Length; j++)
            //    {
            //        String s = "" + per[j];
            //        int v = Convert.ToInt16(s);
            //        if (v == i + 1)
            //        {
            //            a++;
            //        }
            //    }
            //    if (a != 1)
            //    {
            //        MessageBox.Show("Не корректно введёна перестановка", "Ошибка", MessageBoxButtons.OK);
            //        return;
            //    }
            //}
            int n = numbers.Count, d = st.Length, k = d / n;
            //int[] mas = new int[n];
            char[] chars = new char[d];
            //for (int i = 0; i < n; i++)
            //{
            //    String s = "" + per[i];
            //    int v = Convert.ToInt16(s);
            //    mas[i] = v - 1;
            //}
            String result = "";
            if (n * k != d)
            {
                k++;
                while (n * k != d)
                {
                    st += " ";
                    d++;
                }
            }
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    chars[Convert.ToInt16(numbers[j]) + i * n] = st[n * i + j];
                }
            }
            for (int i = 0; i < d; i++)
            {
                result += chars[i];
            }
            textBox2.Text = result;
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
            textBox4.Text = s;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Не корректно введёна перестановка", "Ошибка", MessageBoxButtons.OK);
        }
    }
}
