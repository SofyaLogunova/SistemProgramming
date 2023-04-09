using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Random m_Rnd = new Random();
        private Color RandomRGBColor()
        {
            return Color.FromArgb(255, m_Rnd.Next(0, 255),
            m_Rnd.Next(0, 255), m_Rnd.Next(0, 255));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = RandomRGBColor();
        }
    }
}
