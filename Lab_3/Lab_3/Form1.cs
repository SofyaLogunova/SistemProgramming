using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Файл_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем был ли выбран файл
            {
                richTextBox.Clear(); //Очищаем richTextBox
                openFileDialog1.Filter = "Text Files (*.txt)|*.txt"; 
                string fileName = openFileDialog1.FileName; 
                richTextBox.Text = File.ReadAllText(fileName, Encoding.GetEncoding(1251)); 
}

        }

        private void button9_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";
            saveFileDialog1.DefaultExt = ".txt"; 
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
                {
                var name = saveFileDialog1.FileName; //Задаем имя файлу
                File.WriteAllText(name, richTextBox.Text, Encoding.GetEncoding(1251));
                }
            richTextBox.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = richTextBox.Font;
            fontDialog1.Color = richTextBox.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox.Font = fontDialog1.Font;
                richTextBox.ForeColor = fontDialog1.Color;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            
            // расширенное окно для выбора цвета
            colorDialog1.FullOpen = true;
            // установка начального цвета для colorDialog
            colorDialog1.Color = this.BackColor;

            if (colorDialog1.ShowDialog() != DialogResult.Cancel)

                // установка цвета формы
                richTextBox.BackColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            richTextBox.SelectAll();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }
    }
}
