using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace hols
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
        }

        string[] Arr1 = new string[] { "string", "real", "integer", "for", "boolean", "var", "begin", "end", "foreach", "while", "repeat", "if", "then", "else", "case" };
        string[] Arr2 = new string[] { "@" , "not", "^" , "*" , "/" , "div", "mod", "and", "shl", "shr", "+" , "-" , "or", "xor", "=" , ">" , "<" , "<>" , "<=" , ">=" , "as" , "is" , "in" };
        char[] Arr3 = new char[] { ';', ' ', '\t', '\n' };
        string[] prost_oper = new string[] { ":=", "goto"};
        string[] prost_operand = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        int oper = 0;
        int operand = 0;
        int pr_operator = 0;
        int pr_operand = 0;
        Double D = 0;
        Double L = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            oper = 0;
            operand = 0;
            pr_operator = 0;
            pr_operand = 0;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            if (textBox1.Text.Length == 0)
                MessageBox.Show("Ничего не введено!");
            else
            {
                string[] tex = textBox1.Text.Split(Arr3);
                for (int i = 0; i < Arr1.Length; i++)
                    foreach (string A in tex)
                        if (A.Contains(Arr1[i]))
                        {
                            oper++;
                        }
                for (int i = 0; i < Arr2.Length; i++)
                    foreach (string A in tex)
                        if (A.Contains(Arr2[i]))
                        {
                            operand++;
                        }
                for (int i = 0; i < prost_oper.Length; i++)
                    foreach (string A in tex)
                        if (A.Contains(prost_oper[i]))
                        {
                            pr_operator++;
                        }
                for (int i = 0; i < prost_operand.Length; i++)
                    foreach (string A in tex)
                        if (A.Contains(prost_operand[i]))
                        {
                            pr_operand++;
                        }
                Huynya();
            }
        }
        private void Huynya()
        {
            textBox2.Text = Convert.ToString(oper + pr_operator);
            textBox3.Text = Convert.ToString(operand + pr_operand);
            int N1 = Convert.ToInt16(textBox2.Text);
            int N2 = Convert.ToInt16(textBox3.Text);
            textBox4.Text = Convert.ToString(pr_operator);
            textBox5.Text = Convert.ToString(pr_operand);
            int n1 = Convert.ToInt16(textBox4.Text);
            int n2 = Convert.ToInt16(textBox5.Text);
            textBox6.Text = Convert.ToString(N1 + N2);
            textBox7.Text = Convert.ToString(n1 + n2);
            int N = Convert.ToInt16(textBox6.Text);
            int n = Convert.ToInt16(textBox7.Text);
            D = (n1 / 2) * (N2 / n2);
            L = 1/D;
            textBox8.Text = Convert.ToString(L);
        }
    }
}
