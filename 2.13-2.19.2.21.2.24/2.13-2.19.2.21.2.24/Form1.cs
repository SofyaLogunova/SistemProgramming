using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._13_2._19._2._21._2._24
{
    public partial class Form1 : Form
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool PathCompactPathEx(
        System.Text.StringBuilder pszOut,
        string pszSrc,
        Int32 cchMax,
        Int32 dwFlags);
        public Form1()
        {
            InitializeComponent();
        }
        //2.13
        public static string ReverseString(string str)
        {
            
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            
            
            StringBuilder revStr = new StringBuilder(str.Length);
            
            for (int count = str.Length - 1; count > -1; count--)
            {
                revStr.Append(str[count]);
            }
            
            return revStr.ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ReverseString(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        //2.14
        private void button2_Click(object sender, EventArgs e)
        {
            
                string strPathFile =
                "c:/program files/My SuperProgram/skins/sample.txt";
                StringBuilder sb = new StringBuilder(260);
                
                bool b = PathCompactPathEx(sb, strPathFile, 20 + 1, 0);
                
                textBox3.Text = sb.ToString();
            
        }

        //2.15

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Старт")
            {
                timer1.Enabled = true;
                button3.Text = "Стоп";
            }
            else
            {
                timer1.Enabled = false;
                
                button3.Text = "Старт";
            }
        }
        public static int counter = 0;
      

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            string typingText = "C#.Народные советы";
            textBox4.Text = typingText.Substring(0, counter);
            Console.WriteLine($"pract: {typingText.Substring(0, counter)}");
            counter++;
            if (counter > typingText.Length)
                counter = 0;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        //2.16

        private string scrollText = "C#.Народные советы ";
        private void butScroll_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            scrollText = scrollText.Substring(1, scrollText.Length - 1) + scrollText.Substring(0, 1);
            textBox1.Text = scrollText;
        }
        private void butNoScroll_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        //2.17
       
        private void button4_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(textBox1.Text);
            stringBuilder.Append(textBox2.Text);
            textBox5.Text = stringBuilder.ToString();
        }

        //2.18
        private void button5_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            MessageBox.Show(today.Date.ToLongDateString());
        }
        //2.19
        private void button6_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            listBox1.Items.Clear();
            listBox1.Items.Add("d: " + dt.ToString("d"));
            listBox1.Items.Add("D: " + dt.ToString("D"));
            listBox1.Items.Add("f: " + dt.ToString("f"));
            listBox1.Items.Add("F: " + dt.ToString("F"));
            listBox1.Items.Add("g: " + dt.ToString("g"));
            listBox1.Items.Add("G: " + dt.ToString("G"));
            listBox1.Items.Add("m: " + dt.ToString("m"));
            listBox1.Items.Add("r: " + dt.ToString("r"));
            listBox1.Items.Add("s: " + dt.ToString("s"));
            listBox1.Items.Add("u: " + dt.ToString("u"));
            listBox1.Items.Add("U: " + dt.ToString("U"));
            listBox1.Items.Add("y: " + dt.ToString("y"));
            listBox1.Items.Add("MMMM dd: " + dt.ToString("MMMM dd"));
            listBox1.Items.Add("MM/dd/yyyy: " + dt.ToString("MM/dd/yyyy"));
            listBox1.Items.Add("MM/dd/yyyy HH:mm: " +
            dt.ToString("MM/dd/yyyy HH:mm"));
            listBox1.Items.Add("MM/dd/yyyy hh:mm tt: " +
            dt.ToString("MM/dd/yyyy hh:mm tt"));
            listBox1.Items.Add("MM/dd/yyyy H:mm: " +
            dt.ToString("MM/dd/yyyy H:mm"));
            listBox1.Items.Add("MM/dd/yyyy h:mm tt: " +
            dt.ToString("MM/dd/yyyy h:mm tt"));
            listBox1.Items.Add("MM/dd/yyyy HH:mm:ss: " +
            dt.ToString("MM/dd/yyyy HH:mm:ss"));

            listBox1.Items.Add("dddd, dd MMMM yyyy: " +
            dt.ToString("dddd, dd MMMM yyyy"));
            listBox1.Items.Add("dddd, dd MMMM yyyy HH:mm:ss: " +
            dt.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            listBox1.Items.Add("ddd, dd MMM yyyy HH':'mm':'ss 'GMT': " +
            dt.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'"));

            listBox1.Items.Add("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK: " +
            dt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK"));
            listBox1.Items.Add("yyyy'-'MM'-'dd'T'HH':'mm':'ss: " +
            dt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            listBox1.Items.Add("yyyy MMMM: " + dt.ToString("yyyy MMMM"));

            listBox1.Items.Add("H:mm: " + dt.ToString("H:mm"));
            listBox1.Items.Add("HH:mm: " + dt.ToString("HH:mm"));
            listBox1.Items.Add("HH:mm:ss: " + dt.ToString("HH:mm:ss"));
            listBox1.Items.Add("h:mm tt: " + dt.ToString("h:mm tt"));
            listBox1.Items.Add("hh:mm tt: " + dt.ToString("hh:mm tt"));
        }


        //2.21
        private void button7_Click(object sender, EventArgs e)
        {
            DateTime curdate = DateTime.Now;
            DateTime mydate = curdate.AddDays(7);
            MessageBox.Show(mydate.ToShortDateString());
        }
        //2.24
        private void button8_Click(object sender, EventArgs e)
        {
            bool leapYear = DateTime.IsLeapYear(DateTime.Now.Year);
            MessageBox.Show(
            String.Format("{0} является високосным годом: {1}",
            DateTime.Now.Year, leapYear));
        }

        //Разница дат
        private void button9_Click(object sender, EventArgs e)
        {
            DateTime dt1, dt2;
            TimeSpan delta; // TimeSpan представляет разницу между двумя датами
            dt1 = DateTime.Parse(textBox6.Text);
            dt2 = DateTime.Parse(textBox7.Text);
            delta = dt2 - dt1;
            

            MessageBox.Show(Convert.ToString(delta));


        }
    }
    }

