using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strNum1 = textBox1.Text;
            if (string.IsNullOrEmpty(strNum1))
            {
                strNum1 = "0";
            }
            string strNum2 = textBox2.Text;
            if (string.IsNullOrEmpty(strNum2))
            {
                strNum2 = "0";
            }
            Double flNum1 = Convert.ToSingle(strNum1);
            Double flNum2 = Convert.ToSingle(strNum2);
            Double sum = flNum1 + flNum2;
            textBox3.Text = Convert.ToString(sum);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strNum1 = textBox1.Text;
            if (string.IsNullOrEmpty(strNum1))
            {
                strNum1 = "0";
            }
            string strNum2 = textBox2.Text;
            if (string.IsNullOrEmpty(strNum2))
            {
                strNum2 = "0";
            }
            Double flNum1 = Convert.ToSingle(strNum1);
            Double flNum2 = Convert.ToSingle(strNum2);
            Double result = flNum1 - flNum2;
            textBox3.Text = Convert.ToString(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strNum1 = textBox1.Text;
            if (string.IsNullOrEmpty(strNum1))
            {
                strNum1 = "0";
            }
            string strNum2 = textBox2.Text;
            if (string.IsNullOrEmpty(strNum2))
            {
                strNum2 = "0";
            }
            Double flNum1 = Convert.ToSingle(strNum1);
            Double flNum2 = Convert.ToSingle(strNum2);
            Double result = flNum1 * flNum2;
            textBox3.Text = Convert.ToString(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strNum1 = textBox1.Text;
            if (string.IsNullOrEmpty(strNum1))
            {
                strNum1 = "0";
            }
            string strNum2 = textBox2.Text;
            if (string.IsNullOrEmpty(strNum2))
            {
                strNum2 = "0";
            }
            Double flNum1 = Convert.ToSingle(strNum1);
            Double flNum2 = Convert.ToSingle(strNum2);
            Double result = flNum1 / flNum2;
            textBox3.Text = Convert.ToString(result);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }
    }
}
