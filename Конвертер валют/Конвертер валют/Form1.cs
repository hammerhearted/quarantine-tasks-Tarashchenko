using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Конвертер_валют
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            double usd = 69.7;
            double eur = 78.28;
            double gbp = 88.06;
            double x;
            double z;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "USD")
            {
                textBox1.  * usd;
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        


        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
