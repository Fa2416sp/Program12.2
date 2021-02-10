using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program12._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n, m, i, j;
        int[] summa = new int[50];

        int[,] matritsa = new int[50, 50];

        Random rnd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            m = 6; n = 5;
            int[,] matritsa = new int[m, n];
            for (i = 0; i <= m - 1; i++)
            {
                for (j = 0; j <= n - 1; j++)
                {
                    matritsa[i, j] = rnd.Next(-190, 270);
                }
            }
            dataGridView1.RowCount = m;
            dataGridView1.ColumnCount = n;
            for (i = 0; i <= m - 1; i++)
            {
                for (j = 0; j <= n - 1; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matritsa[i, j].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m = 9; n = 3; 
            dataGridView1.RowCount = m;
            dataGridView1.ColumnCount = n;
            textBox1.Text = "";
            for (j = 0; j <= n - 1; j++)
            {
                summa[j] = 1;
                for (i = 0; i <= m - 1; i++)
                {
                    matritsa[i, j] = -365 + rnd.Next(460);
                    dataGridView1.Rows[i].Cells[j].Value = matritsa[i, j].ToString();
                    if ((matritsa[i, j] > -100) && (Convert.ToInt32(matritsa[i, j]) <= -10) || (Convert.ToInt32(matritsa[i, j]) >= 10) && (Convert.ToInt32(matritsa[i, j]) < 100))
                    {
                        summa[j] = summa[j] * matritsa[i, j];
                    }
                    
                }

                if (summa[j] == 1) { textBox1.Text = textBox1.Text + " 0 "; }

                else
                {
                    textBox1.Text = textBox1.Text + $" {summa[j].ToString()} ";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int bubble; n = 3;
            for (i = 0; i <= n - 2; i++)
            {
                for (j = i + 1; j <= n - 1; j++)

                    if (summa[i] > summa[j])
                    {
                        bubble = summa[i];
                        summa[i] = summa[j];
                        summa[j] = bubble;
                    }
            }

            dataGridView2.ColumnCount = n;
            textBox2.Text = "";
            for (i = 0; i <= n - 1; i++)
            {
                if (summa[i] == 1)
                {
                    textBox2.Text = textBox2.Text + " 0 ";
                    dataGridView2[i, 0].Value = " 0 ";
                }
                else
                {
                    textBox2.Text = textBox2.Text + $" {summa[i].ToString()} ";
                    dataGridView2[i, 0].Value = summa[i].ToString();
                }
            }
        }
    }
}