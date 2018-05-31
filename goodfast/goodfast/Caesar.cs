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
    public partial class Caesar : Form
    {
        public Caesar()
        {
            InitializeComponent();
        }

        private void Caesar_Load(object sender, EventArgs e)
        {

        }
        public static bool check(String Alf,String st,int n,int n2)
            {
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < n; i++)
            {
                if (map.ContainsKey(Alf[i]))
                {
                    MessageBox.Show("В поле АЛФАВИТ недопустимое значение \nЭлементы алфавита не должны повторяться", "Ошибка", MessageBoxButtons.OK);
                    return false;
                }

                else
                    map.Add(Alf[i], 1);
            }
            //for (int i = 0; i < n2; i++)
            //{
            //    if (map.ContainsKey(st[i]) == false)
            //    {
            //        MessageBox.Show("В тексте недопустимое значение \nЭлемента алфавита нет в тексте", "Ошибка", MessageBoxButtons.OK);
            //        return false;
            //    }
            //}
            return true;

            }
        
        private void button1_Click(object sender, EventArgs e)
        {

            String Alf, st, shift;
            Alf = textBox1.Text.ToString(); 
            st = textBox3.Text.ToString();
            shift = textBox2.Text.ToString();
            int n = Alf.Length, sdvl, l = 0;
            int n2 = st.Length;
            
            if (check(Alf,st,n,n2) == false)
            {
                return;
            }
           

           
            
            if(textBox1.Text == "")
            {
                MessageBox.Show("Введите Алфавит", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if(textBox3.Text == "")
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if(textBox2.Text == "")
            {
                MessageBox.Show("Введите сдвиг", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            //if (textBox1.Text.ToString().Length < Convert.ToUInt16(shift))
            //{
            //    MessageBox.Show("Размер сдвига не может быть больше длинны алфавита", "Ошибка", MessageBoxButtons.OK);
            //    return;
            //}
            sdvl = shift.Length;
            while (l < sdvl)
            {
                if ((shift[0] == '-') || (shift[l] == '0') || (shift[l] == '1') || (shift[l] == '2') || (shift[l] == '3') || (shift[l] == '4') || (shift[l] == '5') || (shift[l] == '6') || (shift[l] == '7') || (shift[l] == '8') || (shift[l] == '9'))
                {
                    l++;
                }
                else
                {
                    MessageBox.Show("В поле ВВЕДИТЕ СДВИГ недопустимое значение \n Допускаются только цифры", "Ошибка", MessageBoxButtons.OK);
                    return;
                }
            }
            Dictionary<char, char> dic = new Dictionary<char, char>();
            //int n = Alf.Length;
            int sdv = Convert.ToInt16(shift);
            
            //char[] chr = x.toCharArray();

           

                int bgsdv = sdv - (sdv / n) * n;
            for (int i = 0; i < n; i++)
            {
                if ((i + bgsdv < n) && (i + bgsdv >= 0))
                    dic.Add(Alf[i], Alf[i + bgsdv]);
                else
                {
                    if (i + bgsdv >=n)
                    dic.Add(Alf[i], Alf[i - n + bgsdv]);
                    if (i + bgsdv < 0)
                        dic.Add(Alf[i], Alf[i + n +bgsdv]);
                }
            }


            //for (int i = 0; i < n; i++)
            //{
            //    if ((i + bgShift < n) && (i + bgShift >= 0))
            //        map.put(chr[i], chr[i + bgShift]);
            //    else
            //    {
            //        if (i + bgShift >= n)
            //            map.put(chr[i], chr[i - n + bgShift]);
            //        if (i + bgShift < 0)
            //            map.put(chr[i], chr[i + n + bgShift]);
            //    }



                String s = "";
            for (int i = 0; i < n2 ; i++)
            {
                if (dic.ContainsKey(st[i]))
                {
                    s += dic[st[i]];
                }
                else
                    s += st[i];
            }
            textBox4.Text = s;

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = File.AppendText(desktop + "\\text.txt");
            sw.WriteLine(s);
            sw.Close();

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Alf, st, shift;
            int sdvl,l=0;
            Alf = textBox1.Text.ToString();
            st = textBox3.Text.ToString();
            shift = textBox2.Text.ToString();
            sdvl = shift.Length;
            while (l < sdvl)
            {
                if ((shift[0] == '-') || (shift[l] == '0') || (shift[l] == '1') || (shift[l] == '2') || (shift[l] == '3') || (shift[l] == '4') || (shift[l] == '5') || (shift[l] == '6') || (shift[l] == '7') || (shift[l] == '8') || (shift[l] == '9'))
                {
                    l++;
                }
                else
                {
                    MessageBox.Show("В поле ВВЕДИТЕ СДВИГ недопустимое значение \n Допускаются только цифры", "Ошибка", MessageBoxButtons.OK);
                    return;
                }
            }
            Dictionary<char, char> dic = new Dictionary<char, char>();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите Алфавит", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите сдвиг", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            int n = Alf.Length;
            int n2 = st.Length;
            int sdv = Convert.ToInt16(shift);
            if (check(Alf, st, n, n2) == false)
            {
                return;
            }



           
            

            //if (textBox1.Text.ToString().Length < Convert.ToUInt16(shift))
            //{
            //    MessageBox.Show("Размер сдвига не может быть больше длинны алфавита", "Ошибка", MessageBoxButtons.OK);
            //    return;
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    if (i + sdv < n)
            //        dic.Add(Alf[i + sdv], Alf[i]);
            //    else
            //        dic.Add(Alf[i + sdv - n], Alf[i]);
            //}

            int bgsdv = sdv - (sdv / n) * n;
            for (int i = 0; i < n; i++)
            {
                if ((i + bgsdv < n) && (i + bgsdv >= 0))
                    dic.Add(Alf[i + bgsdv], Alf[i]);
                else
                {
                    if (i + bgsdv >= n)
                        dic.Add(Alf[i - n + bgsdv], Alf[i]);
                    if (i + bgsdv < 0)
                        dic.Add(Alf[i + n + bgsdv], Alf[i]);
                }
            }

            String s = "";
            for (int i = 0; i < n2; i++)
            {
                if (dic.ContainsKey(st[i]))
                {
                    s += dic[st[i]];
                }
                else
                    s += st[i];
            }
            textBox4.Text = s;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = File.AppendText(desktop + "\\text.txt");
            sw.WriteLine(s);
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ifrm = new Menu();
            ifrm.Show(); 
            this.Close(); 
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
            MessageBox.Show("Шифр Цезаря — это вид шифра подстановки, в котором каждый символ в открытом тексте заменяется символом,\n находящимся на некотором постоянном числе позиций левее или правее него в алфавите. Например, в шифре со\n сдвигом вправо на 3, А была бы заменена на Г, Б станет Д, и так далее.", "Алгоритм Цезаря", MessageBoxButtons.OK);
        }
    }
    }

