using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2._26_2._34
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //2.25
        public static DateTime EasterDate(int year)
        {
            int Y = year;
            int a = Y % 19;
            int b = Y / 100;
            int c = Y % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int L = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * L) / 451;
            int month = (h + L - 7 * m + 114) / 31;
            int day = ((h + L - 7 * m + 114) % 31) + 1;
            DateTime dt = new DateTime(year, month, day);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(EasterDate(2006).ToLongDateString());
        }

        //2.26
        private void button2_Click(object sender, EventArgs e)
        {
            int parrots = Convert.ToInt32(textBox1.Text);
            MessageBox.Show(parrots.ToString("X8"));
        }
        //2.27
        private void button3_Click(object sender, EventArgs e)
        {
            int myvalue = Convert.ToInt32(textBox1.Text);
            MessageBox.Show(Convert.ToString(myvalue, 2)); 
        }
        //2.28
        private void button4_Click(object sender, EventArgs e)
        {
            int myValue = Convert.ToInt32(textBox1.Text);

            MessageBox.Show(Convert.ToString(myValue, 8));
            
            MessageBox.Show(Convert.ToString(myValue, 16));
        }
        //2.29
        private void button5_Click(object sender, EventArgs e)
        {
            // введите в текстовое поле любое число или слово
            string numstring = textBox1.Text;
            bool bResult1;
            bResult1 = Information.IsNumeric(numstring);
            MessageBox.Show("Является ли " + numstring + " числом: " + bResult1);
        }
        //2.30
        static bool IsNumeric(object Expression)
        {
            
            bool isNum;
           
            double retNum;
            
            isNum = Double.TryParse(Convert.ToString(Expression),
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
           
            return isNum;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Является ли " + textBox1.Text +
                " числом: " + IsNumeric(textBox1.Text));
        }
        //2.31
        private void button7_Click(object sender, EventArgs e)
        {
            Guid newGuid = Guid.NewGuid();
            
            textBox1.Text = newGuid.ToString("N");
        }
        //2.32
        enum Cats { Рыжик = 3, Барсик = 5, Мурзик, Васька, Пушок };

        private void button8_Click(object sender, EventArgs e)
        {
            // Перечисляем все элементы перечисления
            string[] catNames = Enum.GetNames(typeof(Cats));
            foreach (string s in catNames)
            {
                listBox1.Items.Add(s);
            }
            // Перечисляем все значения перечисления
            int[] valCats = (int[])Enum.GetValues(typeof(Cats));
            foreach (int val in valCats)
            {
                listBox1.Items.Add(val.ToString());
            }
            MessageBox.Show(catNames[3].ToString());
            MessageBox.Show(valCats[3].ToString());

        }
        //2.33
        private void button9_Click(object sender, EventArgs e)
        {
            
            string[] allcolors =
            Enum.GetNames(typeof(System.Drawing.KnownColor));
            listBox1.Items.Clear();
            
            listBox1.Items.AddRange(allcolors);
        }
        //2.34
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object ColorEnum;
            ColorEnum = System.Enum.Parse(typeof(KnownColor), listBox1.Text);
            KnownColor SelectedColor = (KnownColor)ColorEnum;
            this.BackColor = System.Drawing.Color.FromKnownColor(SelectedColor);
        }
    }
}
