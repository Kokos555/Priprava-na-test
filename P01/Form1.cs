using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pocet = 0;
            double soucet = 0;
            int pocitadlo = 1;
            Random rnd = new Random();
            foreach (Control ovladac in panel1.Controls)
            {
                if (ovladac is TextBox)
                {
                    int value = rnd.Next(5, 20);
                    (ovladac as TextBox).Text = string.Format("{0}", value);
                    if (value % 7 == 0)
                    {
                        pocet++;
                        soucet += value;
                    }
                }else if (ovladac is RadioButton)
                {
                    if ((ovladac as RadioButton).Enabled == false)
                    {
                        (ovladac as RadioButton).Enabled = true;
                    }else
                    {
                        (ovladac as RadioButton).Enabled = false;
                    }
                }else if (ovladac is Button)
                {
                    (ovladac as Button).Text += "T" + pocitadlo;
                    pocitadlo++;
                }
            }
            if (pocet != 0)
            {
                double aritmeticky_prumer = soucet / pocet;
                label1.Text = string.Format("Aritmeticky prumer cisel z TextBoxu delitelnych cislem 7 je {0}", aritmeticky_prumer);
            }else
            {
                label1.Text = string.Format("Nelze vypočítat aritmetický průměr.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Lines[0]);
            int y = Convert.ToInt32(textBox1.Lines[1]);
            int u = x;
            int w = y;
            int r = 0;
            while (w != 0)
            {
                r = u % w;
                u = w;
                w = r;
            }
            int nej_nasobek = (x * y) / u;
            MessageBox.Show(string.Format("Největší společný dělitel čísla {0} a {1} je {2}." + Environment.NewLine + "A nejmenší společný násobek čísla {0} a {1} je {3}", x, y, u, nej_nasobek));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int pocet = 0;
            double soucet1 = 0;
            foreach (string cisla in textBox1.Lines)
            {
                int cislo = Convert.ToInt32(cisla);
                int soucet = 0;
                int zbytek = cislo;
                while (zbytek > 0)
                {
                    int x = zbytek % 10;
                    soucet += x;
                    zbytek /= 10;
                }
                if (cislo % 2 == 1 && soucet % 2 == 0)
                {
                    pocet++;
                    soucet1 += cislo;
                }
            }
            if (pocet != 0)
            {
                double ar = soucet1 / pocet;
                label1.Text = string.Format("Aritmeticky prumer cisel je {0} a bylo použito {1} cisel", ar,pocet);
            }else
            {
                label1.Text = string.Format("Aritmeticky prumer neexistuje.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int max = Int32.MinValue;
            Random rnd = new Random();
            int cislo = Convert.ToInt32(textBox1.Lines[2]);
            for (int i = 0; i< cislo; i++)
            {
                int value = rnd.Next(0, 1000);
                listBox1.Items.Add(value);
            }
            int max2 = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                int cislo1 = Convert.ToInt32(listBox1.Items[i]);
                if (cislo1 > max)
                {
                    max2 = max;
                    max = cislo1;
                }else if (cislo1 > max2)
                {
                    max2 = cislo1;
                }
            }
            MessageBox.Show(string.Format("První maximální číslo je {1} druhé maximální číslo je {0}", max2, max));
        }
    }
}
