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
    public partial class XOR : Form
    {

        public XOR()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String key, st, result = "";
            int i = 0,j, keyl, stl;
            key = textBox3.Text.ToString();
            keyl = key.Length;
            while (i < keyl)
            {
                if ((key[i] == '1') || (key[i] == '0'))
                {
                    i++;
                }
                else
                {
                    MessageBox.Show("В поле КЛЮЧ недопустимое значение \n Допустимые значения '0' '1'", "Ошибка", MessageBoxButtons.OK);
                    return;
                }
            }

            st = textBox1.Text.ToString();
            stl = st.Length;
            i = 0;
            while (i < stl)
            {
                if ((st[i] == '1') || (st[i] == '0'))
                {
                    i++;
                }
                else
                {
                    MessageBox.Show("В тексте недопустимое значение \n Допустимые значения '0' '1'", "Ошибка", MessageBoxButtons.OK);
                    return;
                }

            }
            if(textBox3.Text == "")
            {
                MessageBox.Show("Введите ключ", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if(textBox1.Text == "")
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            
            for ( i = 0; i < stl; i++)
            {
                j = i - keyl * (i / keyl);
                if (st[i] == key[j])
                    result += '0';
                else
                    result += '1';

            }

            textBox2.Text = result;

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = File.AppendText(desktop + "\\text.txt");
            sw.WriteLine(result);
            sw.Close();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            String key, st, result = "";
            int i = 0, j, keyl, stl;
            key = textBox3.Text.ToString();
            keyl = key.Length;
            st = textBox1.Text.ToString();
            stl = st.Length;
            for (i = 0; i < stl; i++)
            {
                j = i - keyl * (i / keyl);
                if (st[i] == key[j])
                    result += '0';
                else
                    result += '1';

            }

            textBox2.Text = result;

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = File.AppendText(desktop + "\\text.txt");
            sw.WriteLine(result);
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ifrm = new Menu();
            ifrm.Show();
            this.Close(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            int count = System.IO.File.ReadAllLines(desktop + "\\text.txt").Length;
            string s = File.ReadLines(desktop + "\\text.txt").Skip(count-1).First();
            textBox1.Text = s;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В программировании, обмен при помощи исключающего ИЛИ — это алгоритм, в котором используется операция \n исключающего ИЛИ (XOR), для обмена значениями между переменными, которые содержат данные одного типа, без использования дополнительной (временной) \n переменной. Этот алгоритм работает при помощи свойства симметрической разности, которым обладает XOR: A XOR A = 0 для всех A", "Алгоритм XOR", MessageBoxButtons.OK);
        }
    }
}
