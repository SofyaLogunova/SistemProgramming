using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._1_2._10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Vstavka_Click(object sender, EventArgs e)
        {
            string partBookTitle = textBox1.Text;
            string insertText = textBox2.Text;
            string bookTitle = partBookTitle.Insert(3, insertText);
            MessageBox.Show(bookTitle);
        }

        private void Dlstring_Click(object sender, EventArgs e)
        {
            string bookTitle = textBox1.Text;
            bookTitle = bookTitle.Remove(2);
            MessageBox.Show(bookTitle);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bookTitle = textBox1.Text;
            bookTitle = bookTitle.Substring(5, 3);
            MessageBox.Show(bookTitle);
        }

        private void Vxod_Click(object sender, EventArgs e)
        {
            string str1 = textBox1.Text; 
            string str2 = textBox2.Text; ;
            int i = str2.IndexOf(str1);
            if (i >= 0) MessageBox.Show(str1 + " входит в строку " + str2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tankman = textBox1.Text;
            string dog = textBox2.Text;
            textBox1.Text = tankman + dog; 
            int all = int.Parse(tankman) + int.Parse(dog);
            textBox1.Text += Environment.NewLine + all.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int charCode = 169;
            char specialChar = Convert.ToChar(charCode);
            textBox1.Text = specialChar.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int charCode = 0x00AE;
            char specialChar = Convert.ToChar(charCode);
            textBox1.Text += specialChar.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.String FiveStars = string.Join("", Enumerable.Repeat(textBox1.Text, 5));
            textBox2.Text = FiveStars;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string AutoName;
            AutoName = "BMW";

            textBox2.Text =
            String.Format("Стоимость {0} равна {1:0.0;c}", AutoName, textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //Color clr = Color.Blue;
            Color clr = (Color)TypeDescriptor.GetConverter(
            typeof(Color)).ConvertFromString(textBox1.Text);

            textBox1.Text =
            (TypeDescriptor.GetConverter(clr).ConvertToString(clr));
          
            
            this.BackColor = clr;
        }
    }
}
